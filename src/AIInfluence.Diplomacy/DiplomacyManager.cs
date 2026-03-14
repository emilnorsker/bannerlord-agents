using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AIInfluence.Diseases;
using AIInfluence.DynamicEvents;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;
using KillCharacterAction = TaleWorlds.CampaignSystem.Actions.KillCharacterAction;

namespace AIInfluence.Diplomacy;

public class DiplomacyManager
{
	private static DiplomacyManager _instance;

	private readonly WarStatisticsTracker _warTracker;

	private readonly AllianceSystem _allianceSystem;

	private readonly WarFatigueSystem _fatigueSystem;

	private readonly DiplomacyStorage _storage;

	private readonly TradeAgreementSystem _tradeAgreementSystem;

	private readonly TerritoryTransferSystem _territoryTransferSystem;

	private readonly TributeSystem _tributeSystem;

	private readonly ReparationsSystem _reparationsSystem;

	private KingdomStatementGenerator _statementGenerator;

	private DynamicEventsAnalyzer _eventsAnalyzer;

	private PlayerStatementAnalyzer _playerAnalyzer;

	private readonly List<DynamicEvent> _activeDiplomaticEvents = new List<DynamicEvent>();

	private readonly Queue<DynamicEvent> _queuedDiplomaticEvents = new Queue<DynamicEvent>();

	private readonly Dictionary<string, CampaignTime> _eventStatementSchedule = new Dictionary<string, CampaignTime>();

	private readonly Dictionary<MapEvent, (int attackerInitial, int defenderInitial)> _battleInitialTroops = new Dictionary<MapEvent, (int, int)>();

	private readonly Dictionary<string, CampaignTime> _eventAnalysisSchedule = new Dictionary<string, CampaignTime>();

	private readonly Dictionary<string, Kingdom> _pendingStatements = new Dictionary<string, Kingdom>();

	private readonly Dictionary<string, Queue<(Kingdom kingdom, CampaignTime scheduledTime)>> _statementQueue = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>();

	private readonly List<DelayedPlayerStatement> _pendingPlayerStatements = new List<DelayedPlayerStatement>();

	private readonly Dictionary<Kingdom, CampaignTime> _playerKingdomLastStatement = new Dictionary<Kingdom, CampaignTime>();

	private readonly HashSet<string> _kingdomsCurrentlyGenerating = new HashSet<string>();

	private bool _isGeneratingStatements = false;

	private bool _initialized = false;

	private CampaignTime _lastDiplomaticUpdate;

	private int _nextUpdateIntervalDays;

	public static DiplomacyManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DiplomacyManager();
			}
			return _instance;
		}
	}

	public bool IsInitialized => _initialized;

	private DiplomacyManager()
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		_warTracker = WarStatisticsTracker.Instance;
		_allianceSystem = AllianceSystem.Instance;
		_fatigueSystem = WarFatigueSystem.Instance;
		_tradeAgreementSystem = TradeAgreementSystem.Instance;
		_territoryTransferSystem = TerritoryTransferSystem.Instance;
		_tributeSystem = TributeSystem.Instance;
		_reparationsSystem = ReparationsSystem.Instance;
		_storage = new DiplomacyStorage();
		_lastDiplomaticUpdate = CampaignTime.Now;
		_nextUpdateIntervalDays = GetRandomUpdateInterval();
	}

	public void Initialize()
	{
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		if (_initialized)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Already initialized - cleaning up for new campaign");
			_activeDiplomaticEvents.Clear();
			_eventStatementSchedule.Clear();
			_eventAnalysisSchedule.Clear();
			_pendingStatements.Clear();
			_statementQueue.Clear();
			_pendingPlayerStatements.Clear();
			_playerKingdomLastStatement.Clear();
			_battleInitialTroops.Clear();
			_kingdomsCurrentlyGenerating.Clear();
			_isGeneratingStatements = false;
			_initialized = false;
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cleanup complete, proceeding with initialization");
		}
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Initializing diplomacy system...");
		try
		{
			_allianceSystem.Initialize();
			_warTracker.Initialize();
			_tradeAgreementSystem.Initialize();
			_territoryTransferSystem.Initialize();
			_tributeSystem.Initialize();
			_reparationsSystem.Initialize();
			SynchronizeWars();
			DiplomaticEventsLoadResult diplomaticEventsLoadResult = _storage.LoadDiplomaticEventsWithSchedules();
			List<DynamicEvent> list = diplomaticEventsLoadResult.Events ?? new List<DynamicEvent>();
			bool flag = false;
			foreach (DynamicEvent item in list)
			{
				if (item != null)
				{
					bool flag2 = item.ParticipatingKingdoms != null && item.ParticipatingKingdoms.Any();
					if (item.RequiresDiplomaticAnalysis && (!flag2 || item.IsExpired()))
					{
						item.RequiresDiplomaticAnalysis = false;
						flag = true;
					}
				}
			}
			if (flag)
			{
				_storage.SaveDiplomaticEvents(list, diplomaticEventsLoadResult.StatementSchedules, diplomaticEventsLoadResult.AnalysisSchedules, diplomaticEventsLoadResult.StatementQueues, diplomaticEventsLoadResult.PendingStatements);
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Fixed stale diplomatic events (cleared requires_diplomatic_analysis) during load");
			}
			if (list.Any())
			{
				List<DynamicEvent> list2 = (from e in list
					where e != null && e.RequiresDiplomaticAnalysis && !e.IsExpired()
					where e.ParticipatingKingdoms != null && e.ParticipatingKingdoms.Any()
					select e).ToList();
				int num = list.Count - list2.Count;
				HashSet<string> activeEventIds = new HashSet<string>(from e in list2
					where !string.IsNullOrEmpty(e.Id)
					select e.Id);
				_activeDiplomaticEvents.AddRange(list2);
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Loaded {list2.Count} active diplomatic events from storage (skipped {num} completed/expired)");
				foreach (KeyValuePair<string, CampaignTime> item2 in diplomaticEventsLoadResult.StatementSchedules.Where((KeyValuePair<string, CampaignTime> s) => activeEventIds.Contains(s.Key)))
				{
					_eventStatementSchedule[item2.Key] = item2.Value;
				}
				foreach (KeyValuePair<string, CampaignTime> item3 in diplomaticEventsLoadResult.AnalysisSchedules.Where((KeyValuePair<string, CampaignTime> s) => activeEventIds.Contains(s.Key)))
				{
					_eventAnalysisSchedule[item3.Key] = item3.Value;
				}
				foreach (KeyValuePair<string, Kingdom> item4 in diplomaticEventsLoadResult.PendingStatements.Where((KeyValuePair<string, Kingdom> p) => activeEventIds.Contains(p.Key)))
				{
					_pendingStatements[item4.Key] = item4.Value;
				}
				foreach (KeyValuePair<string, Queue<(Kingdom, CampaignTime)>> item5 in diplomaticEventsLoadResult.StatementQueues.Where((KeyValuePair<string, Queue<(Kingdom kingdom, CampaignTime scheduledTime)>> q) => activeEventIds.Contains(q.Key)))
				{
					_statementQueue[item5.Key] = item5.Value;
					if (item5.Value.Count > 0 && !_pendingStatements.ContainsKey(item5.Key))
					{
						(Kingdom, CampaignTime) tuple = item5.Value.Peek();
						_pendingStatements[item5.Key] = tuple.Item1;
						if (!_eventStatementSchedule.ContainsKey(item5.Key))
						{
							_eventStatementSchedule[item5.Key] = tuple.Item2;
						}
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Restored first queued statement for {tuple.Item1.Name} in event {item5.Key}, scheduled for {tuple.Item2}");
					}
					else if (_eventStatementSchedule.ContainsKey(item5.Key) && !_pendingStatements.ContainsKey(item5.Key) && item5.Value.Count > 0)
					{
						(Kingdom, CampaignTime) tuple2 = item5.Value.Peek();
						_pendingStatements[item5.Key] = tuple2.Item1;
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Restored pending statement for {tuple2.Item1.Name} in event {item5.Key} to match existing schedule");
					}
				}
				if (_eventStatementSchedule.Count > 0 || _eventAnalysisSchedule.Count > 0 || _statementQueue.Count > 0)
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Restored schedules: {_eventStatementSchedule.Count} statements, {_eventAnalysisSchedule.Count} analyses, {_statementQueue.Count} queues");
					if (_pendingStatements.Count > 0)
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Restored {_pendingStatements.Count} pending statements ready for processing");
					}
				}
				foreach (DynamicEvent item6 in list2)
				{
					List<KingdomStatement> statementsByEventId = DiplomaticStatementsStorage.Instance.GetStatementsByEventId(item6.Id);
					if (statementsByEventId != null && statementsByEventId.Any())
					{
						int num2 = item6.KingdomStatements?.Count ?? 0;
						item6.KingdomStatements.Clear();
						item6.KingdomStatements.AddRange(statementsByEventId);
						List<string> values = (from s in statementsByEventId
							where s.Action == DiplomaticAction.ProposePeace || (s.Actions != null && s.Actions.Contains(DiplomaticAction.ProposePeace))
							select s.KingdomId + "->" + (s.TargetKingdomId ?? string.Join(",", s.TargetKingdomIds ?? new List<string>()))).ToList();
						DiplomacyLogger.Instance.Log(string.Format("[DIPLOMACY_MGR] Restored {0} statements for loaded event {1} (was {2} before clear). Proposals in restored: {3}", statementsByEventId.Count, item6.Id, num2, string.Join("; ", values)));
					}
					else
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] No saved statements found for event {item6.Id} in DiplomaticStatementsStorage. Event has {item6.KingdomStatements?.Count ?? 0} statements in memory.");
					}
				}
			}
			List<DelayedPlayerStatement> list3 = _storage.LoadPendingPlayerStatements();
			if (list3 != null && list3.Any())
			{
				_pendingPlayerStatements.AddRange(list3);
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Loaded {list3.Count} pending player statements from storage");
				foreach (DelayedPlayerStatement item7 in list3)
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Loaded pending statement: {item7.PlayerKingdom.Name}, Action={item7.Action}, PublicationTime={item7.PublicationTime}");
				}
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] No pending player statements found in storage");
			}
			RestoreDiplomaticEventsFromDynamicEvents();
			if (_activeDiplomaticEvents.Any())
			{
				RestoreEventSchedules();
			}
			KingdomStatementGenerator.CleanupOldAndInvalidProposals();
			if (!_activeDiplomaticEvents.Any() && (list3 == null || !list3.Any()))
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] No existing data found, initializing kingdoms for new campaign");
				foreach (Kingdom item8 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
				{
					_warTracker.InitializeKingdomStats(item8);
				}
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Existing data found, skipping kingdom initialization (loaded campaign)");
			}
			RegisterEvents();
			_statementGenerator = new KingdomStatementGenerator(this);
			_eventsAnalyzer = new DynamicEventsAnalyzer(this, AIInfluenceBehavior.Instance);
			_playerAnalyzer = new PlayerStatementAnalyzer(this);
			_initialized = true;
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Diplomacy system initialized successfully");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR during initialization: " + ex.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.Initialize", "Failed to initialize", ex);
		}
	}

	private void RegisterEvents()
	{
		CampaignEvents.WarDeclared.AddNonSerializedListener((object)this, (Action<IFaction, IFaction, DeclareWarDetail>)OnWarDeclared);
		CampaignEvents.MakePeace.AddNonSerializedListener((object)this, (Action<IFaction, IFaction, MakePeaceDetail>)OnPeaceMade);
		CampaignEvents.HourlyTickEvent.AddNonSerializedListener((object)this, (Action)OnHourlyTick);
		CampaignEvents.DailyTickEvent.AddNonSerializedListener((object)this, (Action)OnDailyTick);
		CampaignEvents.MapEventStarted.AddNonSerializedListener((object)this, (Action<MapEvent, PartyBase, PartyBase>)OnBattleStarted);
		CampaignEvents.MapEventEnded.AddNonSerializedListener((object)this, (Action<MapEvent>)OnBattleEnded);
		CampaignEvents.OnPrisonerTakenEvent.AddNonSerializedListener((object)this, (Action<FlattenedTroopRoster>)OnPrisonerTaken);
		CampaignEvents.HeroKilledEvent.AddNonSerializedListener((object)this, (Action<Hero, Hero, KillCharacterActionDetail, bool>)OnHeroKilled);
		CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener((object)this, (Action<Settlement, bool, Hero, Hero, Hero, ChangeOwnerOfSettlementDetail>)OnSettlementOwnerChanged);
		CampaignEvents.KingdomDestroyedEvent.AddNonSerializedListener((object)this, (Action<Kingdom>)OnKingdomDestroyed);
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Campaign events registered (including war fatigue tracking)");
	}

	public async Task ProcessDiplomaticEvent(DynamicEvent diplomaticEvent)
	{
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ProcessDiplomaticEvent called for event: " + (diplomaticEvent?.Id ?? "null"));
		if (diplomaticEvent == null)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Event is null");
			return;
		}
		if (!diplomaticEvent.AllowsDiplomaticResponse)
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Event does not allow diplomatic response. AllowsDiplomaticResponse = {diplomaticEvent.AllowsDiplomaticResponse}");
			return;
		}
		if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Diplomacy system is disabled");
			return;
		}
		if (_activeDiplomaticEvents.Any((DynamicEvent e) => e.Id == diplomaticEvent.Id))
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Event " + diplomaticEvent.Id + " is already active. Skipping duplicate processing.");
			return;
		}
		if (_queuedDiplomaticEvents.Any((DynamicEvent e) => e.Id == diplomaticEvent.Id))
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Event " + diplomaticEvent.Id + " is already queued.");
			return;
		}
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Scheduling diplomatic event: " + diplomaticEvent.Id);
		try
		{
			if (!_activeDiplomaticEvents.Any((DynamicEvent e) => e.Id == diplomaticEvent.Id))
			{
				_activeDiplomaticEvents.Add(diplomaticEvent);
				CampaignTime statementTime = CampaignTime.DaysFromNow(1f);
				_eventStatementSchedule[diplomaticEvent.Id] = statementTime;
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Diplomatic event " + diplomaticEvent.Id + " scheduled for statement generation in 1 day");
				SaveDiplomaticEventsWithSchedules();
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR processing diplomatic event: " + ex.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.ProcessDiplomaticEvent", "Failed to process event " + diplomaticEvent.Id, ex);
		}
	}

	public async Task<List<KingdomStatement>> GenerateKingdomStatements(DynamicEvent diplomaticEvent)
	{
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] GenerateKingdomStatements called for event: " + (diplomaticEvent?.Id ?? "null"));
		if (_statementGenerator == null)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Statement generator not initialized");
			return new List<KingdomStatement>();
		}
		List<Kingdom> kingdoms = GetParticipatingKingdoms(diplomaticEvent);
		DiplomacyLogger.Instance.Log(string.Format("[DIPLOMACY_MGR] Found {0} participating kingdoms: {1}", kingdoms.Count, string.Join(", ", kingdoms.Select((Kingdom k) => k.Name))));
		if (!kingdoms.Any())
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] No kingdoms participating in event");
			return new List<KingdomStatement>();
		}
		DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Generating statements for {kingdoms.Count} kingdoms");
		return await _statementGenerator.GenerateStatements(diplomaticEvent, kingdoms);
	}

	public void HandleKingdomStatement(KingdomStatement statement)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification || statement == null)
		{
			return;
		}
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Handling statement from " + statement.KingdomId);
		try
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == statement.KingdomId));
			if (val == null)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Source kingdom not found: " + statement.KingdomId);
				return;
			}
			List<DiplomaticAction> list = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
			List<string> list2 = ((statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any()) ? statement.TargetKingdomIds : ((!string.IsNullOrEmpty(statement.TargetKingdomId)) ? new List<string> { statement.TargetKingdomId } : new List<string>()));
			List<string> list3 = ((!string.IsNullOrEmpty(statement.SettlementId)) ? (from id in statement.SettlementId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
				select id.Trim()).ToList() : new List<string>());
			DiplomacyLogger.Instance.Log(string.Format("[DIPLOMACY_MGR] Executing {0} actions: {1}", list.Count, string.Join(", ", list)));
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Target kingdoms: " + string.Join(", ", list2));
			if (list3.Any())
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Settlement IDs: " + string.Join(", ", list3));
			}
			int num = 0;
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				DiplomaticAction diplomaticAction = list[num2];
				if (diplomaticAction == DiplomaticAction.None)
				{
					continue;
				}
				string text;
				if (list.Count == list2.Count)
				{
					text = list2[num2];
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Paired action {diplomaticAction} (index {num2}) with target kingdom {text}");
				}
				else if (list2.Any())
				{
					text = list2[0];
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Using first target kingdom {text} for action {diplomaticAction} (mismatch: {list.Count} actions, {list2.Count} targets)");
				}
				else
				{
					if (diplomaticAction != DiplomaticAction.ExpelClan && diplomaticAction != DiplomaticAction.QuarantineSettlement)
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] No target kingdoms found for action {diplomaticAction}, skipping");
						continue;
					}
					text = null;
				}
				bool flag = diplomaticAction == DiplomaticAction.TransferTerritory || diplomaticAction == DiplomaticAction.RejectTerritory || diplomaticAction == DiplomaticAction.DemandTerritory || diplomaticAction == DiplomaticAction.QuarantineSettlement;
				string text2 = null;
				if (flag && list3.Any())
				{
					if (num < list3.Count)
					{
						text2 = list3[num];
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Paired action {diplomaticAction} with settlement {text2} (settlement index {num})");
					}
					else
					{
						text2 = list3[0];
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Settlement index out of range for {diplomaticAction}, using first: {text2}");
					}
					num++;
				}
				DiplomaticActionInfo diplomaticActionInfo = new DiplomaticActionInfo
				{
					Action = diplomaticAction,
					SourceKingdomId = statement.KingdomId,
					TargetKingdomId = text,
					TargetClanId = statement.TargetClanId,
					Reason = (statement.Reason ?? statement.StatementText),
					SettlementId = text2,
					TradeAgreementDurationYears = statement.TradeAgreementDurationYears
				};
				if (diplomaticAction == DiplomaticAction.DemandTribute || diplomaticAction == DiplomaticAction.AcceptTribute)
				{
					diplomaticActionInfo.DailyTributeAmount = statement.DailyTributeAmount;
					diplomaticActionInfo.TributeDurationDays = statement.TributeDurationDays;
				}
			if (diplomaticAction == DiplomaticAction.FoundKingdom)
			{
				diplomaticActionInfo.NewKingdomName = statement.NewKingdomName;
				diplomaticActionInfo.NewKingdomInformalName = statement.NewKingdomInformalName;
			}
			if (diplomaticAction == DiplomaticAction.DemandReparations)
			{
				diplomaticActionInfo.ReparationsAmount = statement.ReparationsAmount;
				}
				if (diplomaticAction == DiplomaticAction.QuarantineSettlement)
				{
					diplomaticActionInfo.QuarantineDurationDays = statement.QuarantineDurationDays;
				}
				ExecuteDiplomaticAction(diplomaticActionInfo);
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR handling statement: " + ex.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.HandleKingdomStatement", "Failed to handle statement", ex);
		}
	}

	public void ExecuteDiplomaticAction(DiplomaticActionInfo actionInfo)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification || actionInfo == null)
		{
			return;
		}
		Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == actionInfo.SourceKingdomId));
		bool flag = actionInfo.Action != DiplomaticAction.ExpelClan && actionInfo.Action != DiplomaticAction.QuarantineSettlement && actionInfo.Action != DiplomaticAction.FoundKingdom;
		Kingdom val2 = (flag ? ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == actionInfo.TargetKingdomId)) : null);
		if (val == null)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot execute action: source kingdom not found");
			return;
		}
		if (flag && val2 == null)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot execute action: target kingdom not found");
			return;
		}
		string message = (flag ? $"[DIPLOMACY_MGR] Executing action: {actionInfo.Action} from {val.Name} to {val2.Name}" : $"[DIPLOMACY_MGR] Executing action: {actionInfo.Action} for {val.Name}");
		DiplomacyLogger.Instance.Log(message);
		switch (actionInfo.Action)
		{
		case DiplomaticAction.DeclareWar:
			if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot declare war: {val.Name} and {val2.Name} are already at war");
				break;
			}
			if (_allianceSystem.AreAllied(val, val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] WARNING: {val.Name} is declaring war on ally {val2.Name}. Alliance will be broken.");
			}
			DeclareWar(val, val2, actionInfo.Reason);
			break;
		case DiplomaticAction.ProposePeace:
			if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot propose peace: {val.Name} and {val2.Name} are not at war");
			}
			else
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Peace proposed by {val.Name} to {val2.Name}");
			}
			break;
		case DiplomaticAction.AcceptPeace:
			if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot accept peace: {val.Name} and {val2.Name} are not at war");
			}
			else
			{
				MakePeace(val, val2, actionInfo.Reason);
			}
			break;
		case DiplomaticAction.RejectPeace:
			if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot reject peace: {val.Name} and {val2.Name} are not at war");
			}
			else
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Peace proposal rejected by {val.Name} from {val2.Name}");
			}
			break;
		case DiplomaticAction.ProposeAlliance:
			if (_allianceSystem.AreAllied(val, val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot propose alliance: {val.Name} and {val2.Name} are already allied");
			}
			else
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Alliance proposed by {val.Name} to {val2.Name}");
			}
			break;
		case DiplomaticAction.AcceptAlliance:
			if (_allianceSystem.AreAllied(val, val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot accept alliance: {val.Name} and {val2.Name} are already allied");
				break;
			}
			if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot accept alliance: {val.Name} and {val2.Name} are at war");
				break;
			}
			_allianceSystem.CreateAlliance(val, val2);
			if (!string.IsNullOrEmpty(actionInfo.Reason))
			{
				_warTracker.SaveDiplomaticReason(val, val2, "alliance", actionInfo.Reason, actionInfo.Reason);
			}
			break;
		case DiplomaticAction.BreakAlliance:
			if (!_allianceSystem.AreAllied(val, val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot break alliance: {val.Name} and {val2.Name} are not allied");
				break;
			}
			_allianceSystem.BreakAlliance(val, val2);
			if (!string.IsNullOrEmpty(actionInfo.Reason))
			{
				_warTracker.SaveDiplomaticReason(val, val2, "alliance_break", actionInfo.Reason, actionInfo.Reason);
			}
			break;
		case DiplomaticAction.ProposeTradeAgreement:
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Trade agreement proposed by {val.Name} to {val2.Name}");
			break;
		case DiplomaticAction.AcceptTradeAgreement:
		{
			CampaignTime endTime;
			if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot accept trade agreement: {val.Name} and {val2.Name} are at war");
			}
			else if (_tradeAgreementSystem.HasTradeAgreement(val, val2, out endTime))
			{
				float num2 = ((actionInfo.TradeAgreementDurationYears > 0f) ? actionInfo.TradeAgreementDurationYears : 1f);
				_tradeAgreementSystem.CreateTradeAgreement(val, val2, num2);
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Trade agreement extended: {val.Name} ↔ {val2.Name} by {num2} years");
			}
			else
			{
				float num3 = ((actionInfo.TradeAgreementDurationYears > 0f) ? actionInfo.TradeAgreementDurationYears : 1f);
				_tradeAgreementSystem.CreateTradeAgreement(val, val2, num3);
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Trade agreement created: {val.Name} ↔ {val2.Name} for {num3} years");
			}
			break;
		}
		case DiplomaticAction.RejectTradeAgreement:
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Trade agreement rejected by {val.Name}");
			break;
		case DiplomaticAction.EndTradeAgreement:
			_tradeAgreementSystem.EndTradeAgreement(val, val2);
			break;
		case DiplomaticAction.TransferTerritory:
			if (!string.IsNullOrEmpty(actionInfo.SettlementId))
			{
				_territoryTransferSystem.TransferSettlementById(actionInfo.SettlementId, val, val2, actionInfo.Reason ?? "Diplomatic transfer");
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot transfer territory: no settlement specified");
			}
			break;
		case DiplomaticAction.DemandTerritory:
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] {val.Name} demands territory from {val2.Name}");
			break;
		case DiplomaticAction.RejectTerritory:
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] {val.Name} rejects territory demand from {val2.Name}");
			break;
		case DiplomaticAction.DemandTribute:
			if (actionInfo.DailyTributeAmount > 0 && actionInfo.TributeDurationDays > 0)
			{
				_tributeSystem.EstablishTribute(val2, val, actionInfo.DailyTributeAmount, actionInfo.TributeDurationDays, actionInfo.Reason ?? "Tribute demand");
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot establish tribute: invalid amount or duration");
			}
			break;
		case DiplomaticAction.AcceptTribute:
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] {val2.Name} accepts tribute to {val.Name}");
			break;
		case DiplomaticAction.RejectTribute:
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] {val2.Name} rejects tribute demand from {val.Name}");
			break;
		case DiplomaticAction.EndTribute:
			_tributeSystem.EndTribute(val, val2);
			break;
		case DiplomaticAction.DemandReparations:
			if (actionInfo.ReparationsAmount > 0)
			{
				_reparationsSystem.DemandReparations(val, val2, actionInfo.ReparationsAmount, actionInfo.Reason ?? "War reparations");
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot demand reparations: invalid amount");
			}
			break;
		case DiplomaticAction.AcceptReparations:
		{
			ReparationDemand pendingDemand = _reparationsSystem.GetPendingDemand(val2, val);
			if (pendingDemand != null)
			{
				_reparationsSystem.PayReparations(val, val2, pendingDemand.Amount, pendingDemand.Reason);
			}
			else
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] No pending reparation demand found from {((val2 != null) ? val2.Name : null)} to {((val != null) ? val.Name : null)}");
			}
			break;
		}
		case DiplomaticAction.RejectReparations:
			_reparationsSystem.RejectReparations(val2, val);
			break;
		case DiplomaticAction.ExpelClan:
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Processing ExpelClan action. TargetClanId: " + (actionInfo.TargetClanId ?? "null"));
			if (!string.IsNullOrEmpty(actionInfo.TargetClanId))
			{
				string targetClanId = actionInfo.TargetClanId;
				if (targetClanId == "player_faction")
				{
					Hero mainHero = Hero.MainHero;
					if (((mainHero != null) ? mainHero.Clan : null) != null)
					{
						targetClanId = ((MBObjectBase)Hero.MainHero.Clan).StringId;
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Converted 'player_faction' to clan ID: " + targetClanId);
					}
				}
				Clan val4 = ((IEnumerable<Clan>)Clan.All).FirstOrDefault((Func<Clan, bool>)((Clan c) => ((MBObjectBase)c).StringId == targetClanId));
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Looking for clan with ID: {targetClanId}, Found: {val4 != null}, Clan name: {((val4 != null) ? val4.Name : null)}, In kingdom: {((val4 != null) ? val4.Kingdom : null) == val}");
				if (val4 != null && val4.Kingdom == val)
				{
					if (val4 == val.RulingClan)
					{
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot expel clan: cannot expel the ruling clan");
						break;
					}
					Hero mainHero2 = Hero.MainHero;
					if (val4 == ((mainHero2 != null) ? mainHero2.Clan : null) && val.Leader == Hero.MainHero)
					{
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot expel clan: cannot expel player's clan when player is the kingdom leader");
						break;
					}
					ExpelledClanSystem.Instance.BanClan(val, val4, actionInfo.Reason ?? "Expelled by ruler");
					ChangeKingdomAction.ApplyByLeaveKingdom(val4, true);
					DiplomacyLogger.Instance.Log(string.Format("[DIPLOMACY_MGR] SUCCESS: Clan {0} ({1}) expelled from {2} by {3}", val4.Name, targetClanId, val.Name, (val.Leader == Hero.MainHero) ? "player" : "AI"));
					break;
				}
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot expel clan: clan not found or not in kingdom. TargetClanId: {actionInfo.TargetClanId} (resolved: {targetClanId}), Clan found: {val4 != null}, In kingdom: {((val4 != null) ? val4.Kingdom : null) == val}");
				if (!(actionInfo.TargetClanId == "player_faction"))
				{
					break;
				}
				Hero mainHero3 = Hero.MainHero;
				if (((mainHero3 != null) ? mainHero3.Clan : null) == null)
				{
					break;
				}
				Clan clan = Hero.MainHero.Clan;
				if (clan.Kingdom == val && clan != val.RulingClan)
				{
					if (val.Leader == Hero.MainHero)
					{
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot expel clan: cannot expel player's clan when player is the kingdom leader");
						break;
					}
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Fallback: Using player's clan directly. Clan: {clan.Name} ({((MBObjectBase)clan).StringId})");
					ExpelledClanSystem.Instance.BanClan(val, clan, actionInfo.Reason ?? "Expelled by ruler");
					ChangeKingdomAction.ApplyByLeaveKingdom(clan, true);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] SUCCESS (fallback): Clan {clan.Name} ({((MBObjectBase)clan).StringId}) expelled from {val.Name}");
				}
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot expel clan: no target clan specified");
			}
			break;
		case DiplomaticAction.QuarantineSettlement:
			DiplomacyLogger.Instance.Log(string.Format("[DIPLOMACY_MGR] Processing QuarantineSettlement action. SettlementId: {0}, Duration: {1}", actionInfo.SettlementId ?? "null", actionInfo.QuarantineDurationDays));
			if (!string.IsNullOrEmpty(actionInfo.SettlementId))
			{
				Settlement val3 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == actionInfo.SettlementId));
				if (val3 != null)
				{
					Clan ownerClan = val3.OwnerClan;
					if (((ownerClan != null) ? ownerClan.Kingdom : null) == val)
					{
						DiseaseManager instance = DiseaseManager.Instance;
						if (instance != null && instance.SettlementHasDisease(val3))
						{
							int num = ((actionInfo.QuarantineDurationDays >= 1) ? actionInfo.QuarantineDurationDays : 14);
							bool flag2 = instance.IsSettlementUnderQuarantine(val3);
							if (instance.SetQuarantine(val3, quarantined: true, num, forceByKingdomLeader: true))
							{
								string text = (flag2 ? "EXTENDED" : "SET");
								DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] SUCCESS: Quarantine {text} on {val3.Name} by +{num} days by {val.Name}");
							}
							else
							{
								DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] FAILED: Could not set quarantine on {val3.Name}");
							}
						}
						else
						{
							DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot quarantine {val3.Name}: no active disease");
						}
					}
					else
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cannot quarantine {val3.Name}: not owned by {val.Name}");
					}
				}
				else
				{
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot quarantine: settlement " + actionInfo.SettlementId + " not found");
				}
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot quarantine: no settlement specified");
			}
		break;
	case DiplomaticAction.FoundKingdom:
		FoundKingdom(val, actionInfo.TargetClanId, actionInfo.NewKingdomName, actionInfo.NewKingdomInformalName, actionInfo.Reason);
		break;
	default:
		DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Unknown action: {actionInfo.Action}");
		break;
	}
}

	private void FoundKingdom(Kingdom sourceKingdom, string founderClanId, string kingdomName, string informalName, string reason)
	{
		if (string.IsNullOrEmpty(founderClanId))
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] FoundKingdom: no founder clan specified");
			return;
		}
		Clan founderClan = ((IEnumerable<Clan>)Clan.All).FirstOrDefault((Func<Clan, bool>)((Clan c) => ((MBObjectBase)c).StringId == founderClanId));
		if (founderClan == null)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] FoundKingdom: founder clan not found: " + founderClanId);
			return;
		}
		if (founderClan.Kingdom != sourceKingdom)
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] FoundKingdom: clan {founderClan.Name} is not in source kingdom {sourceKingdom.Name}");
			return;
		}
		if (founderClan == sourceKingdom.RulingClan)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] FoundKingdom: ruling clan cannot found a new kingdom while it leads the current one");
			return;
		}
		if (!((IEnumerable<Settlement>)founderClan.Settlements).Any((Func<Settlement, bool>)((Settlement s) => s.IsTown || s.IsCastle)))
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] FoundKingdom: clan {founderClan.Name} owns no castle or town — cannot found a kingdom");
			return;
		}
		string name = (!string.IsNullOrWhiteSpace(kingdomName)) ? kingdomName : (((object)founderClan.Leader.Name)?.ToString() + "'s Kingdom");
		string informal = (!string.IsNullOrWhiteSpace(informalName)) ? informalName : name;
		DiplomacyPatches.WithBypass(delegate
		{
			Kingdom newKingdom = GameVersionCompatibility.CreateKingdom(new TextObject(name), new TextObject(informal), founderClan.Culture, founderClan.Banner);
			if (newKingdom == null)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] FoundKingdom: Kingdom.CreateKingdom returned null");
				return;
			}
			ChangeKingdomAction.ApplyByCreateKingdom(founderClan, newKingdom, true);
			DiplomacyLogger.Instance.LogDiplomaticAction("kingdom_founded", ((MBObjectBase)sourceKingdom).StringId, founderClanId, reason);
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] SUCCESS: Kingdom '{name}' founded by {founderClan.Name} (broke away from {sourceKingdom.Name})");
		});
	}

	private void DeclareWar(Kingdom kingdom1, Kingdom kingdom2, string reason)
	{
		if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2))
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] {kingdom1.Name} and {kingdom2.Name} are already at war");
			return;
		}
		if (_allianceSystem.AreAllied(kingdom1, kingdom2))
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] {kingdom1.Name} and {kingdom2.Name} are allies. Breaking alliance before declaring war.");
			_allianceSystem.BreakAlliance(kingdom1, kingdom2);
			DiplomacyLogger.Instance.LogDiplomaticAction("alliance_broken", ((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId, "Alliance broken due to war declaration");
		}
		if (_tradeAgreementSystem.HasTradeAgreement(kingdom1, kingdom2, out var _))
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] {kingdom1.Name} and {kingdom2.Name} have trade agreement. Ending trade agreement before declaring war.");
			_tradeAgreementSystem.EndTradeAgreement(kingdom1, kingdom2);
		}
		try
		{
			if (!string.IsNullOrEmpty(reason))
			{
				_warTracker.SaveDiplomaticReason(kingdom1, kingdom2, "war", reason, reason);
			}
			DiplomacyPatches.WithBypass(delegate
			{
				DeclareWarAction.ApplyByDefault((IFaction)(object)kingdom1, (IFaction)(object)kingdom2);
			});
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] War declared: {kingdom1.Name} vs {kingdom2.Name}");
			DiplomacyLogger.Instance.LogDiplomaticAction("war_declared", ((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId, reason ?? "AI-driven war declaration");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR declaring war: " + ex.Message);
		}
	}

	private void MakePeace(Kingdom kingdom1, Kingdom kingdom2, string reason)
	{
		if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2))
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] {kingdom1.Name} and {kingdom2.Name} are not at war");
			return;
		}
		try
		{
			if (!string.IsNullOrEmpty(reason))
			{
				_warTracker.SaveDiplomaticReason(kingdom1, kingdom2, "peace", reason, reason);
			}
			DiplomacyPatches.WithBypass(delegate
			{
				MakePeaceAction.Apply((IFaction)(object)kingdom1, (IFaction)(object)kingdom2);
			});
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Peace made: {kingdom1.Name} and {kingdom2.Name}");
			DiplomacyLogger.Instance.LogDiplomaticAction("peace_made", ((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId, reason ?? "AI-driven peace treaty");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR making peace: " + ex.Message);
		}
	}

	public void UpdateWarStatistics()
	{
		try
		{
			_warTracker.UpdateWarStatistics();
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] War statistics updated");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR updating war statistics: " + ex.Message);
		}
	}

	private List<Kingdom> GetParticipatingKingdoms(DynamicEvent diplomaticEvent)
	{
		List<Kingdom> list = new List<Kingdom>();
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] GetParticipatingKingdoms called. ParticipatingKingdoms: " + string.Join(", ", diplomaticEvent.ParticipatingKingdoms ?? new List<string>()));
		if (diplomaticEvent.ParticipatingKingdoms != null && diplomaticEvent.ParticipatingKingdoms.Any())
		{
			foreach (string kingdomId in diplomaticEvent.ParticipatingKingdoms)
			{
				Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kingdomId));
				if (val != null && !val.IsEliminated)
				{
					if (val.Leader == null)
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Skipping kingdom {val.Name} ({kingdomId}) - no leader (Leader=NULL)");
						continue;
					}
					list.Add(val);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Added kingdom: {val.Name} ({kingdomId})");
				}
				else
				{
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Kingdom not found or eliminated: " + kingdomId);
				}
			}
		}
		else
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] No participating kingdoms in event");
		}
		return list;
	}

	private void OnWarDeclared(IFaction factionDeclaringWar, IFaction factionDeclaredWarAgainst, DeclareWarDetail detail)
	{
		Kingdom val = (Kingdom)(object)((factionDeclaringWar is Kingdom) ? factionDeclaringWar : null);
		if (val != null)
		{
			Kingdom val2 = (Kingdom)(object)((factionDeclaredWarAgainst is Kingdom) ? factionDeclaredWarAgainst : null);
			if (val2 != null)
			{
				_warTracker.TrackWarStart(val, val2);
				_tradeAgreementSystem.OnWarDeclared(val, val2);
				_tributeSystem.OnWarDeclared(val, val2);
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] War declared: {val.Name} declared war on {val2.Name}");
			}
		}
	}

	private void OnPeaceMade(IFaction faction1, IFaction faction2, MakePeaceDetail detail)
	{
		Kingdom val = (Kingdom)(object)((faction1 is Kingdom) ? faction1 : null);
		if (val != null)
		{
			Kingdom val2 = (Kingdom)(object)((faction2 is Kingdom) ? faction2 : null);
			if (val2 != null)
			{
				_warTracker.OnWarEnded(val, val2);
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Peace made: {val.Name} and {val2.Name}");
			}
		}
	}

	private void OnBattleStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		if (mapEvent == null)
		{
			return;
		}
		try
		{
			int totalTroopCount = GameVersionCompatibility.GetTotalTroopCount((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)1));
			int totalTroopCount2 = GameVersionCompatibility.GetTotalTroopCount((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)0));
			_battleInitialTroops[mapEvent] = (totalTroopCount, totalTroopCount2);
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR tracking battle start: " + ex.Message);
		}
	}

	private void OnBattleEnded(MapEvent mapEvent)
	{
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Invalid comparison between Unknown and I4
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Invalid comparison between Unknown and I4
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		if (mapEvent == null)
		{
			return;
		}
		try
		{
			if (!_battleInitialTroops.TryGetValue(mapEvent, out (int, int) value))
			{
				return;
			}
			int item = value.Item1;
			int item2 = value.Item2;
			int totalTroopCount = GameVersionCompatibility.GetTotalTroopCount((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)1));
			int totalTroopCount2 = GameVersionCompatibility.GetTotalTroopCount((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)0));
			int item3 = Math.Max(0, item - totalTroopCount);
			int item4 = Math.Max(0, item2 - totalTroopCount2);
			_battleInitialTroops.Remove(mapEvent);
			if (!DiplomacyHelpers.VerifyBattleSides(mapEvent.AttackerSide.LeaderParty, mapEvent.DefenderSide.LeaderParty, out var kingdom, out var kingdom2))
			{
				return;
			}
			Dictionary<Kingdom, (int, Kingdom)> dictionary = new Dictionary<Kingdom, (int, Kingdom)>();
			if (kingdom != null)
			{
				dictionary[kingdom] = (item3, kingdom2);
			}
			if (kingdom2 != null)
			{
				dictionary[kingdom2] = (item4, kingdom);
			}
			foreach (KeyValuePair<Kingdom, (int, Kingdom)> item7 in dictionary)
			{
				Kingdom key = item7.Key;
				int item5 = item7.Value.Item1;
				Kingdom item6 = item7.Value.Item2;
				if (item5 > 0)
				{
					_warTracker.UpdateCasualties(key, item5, item6);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Battle casualties: {key.Name} lost {item5} troops" + ((item6 != null) ? $" against {item6.Name}" : ""));
				}
			}
			if ((int)mapEvent.WinningSide == -1 || (int)mapEvent.DefeatedSide == -1)
			{
				return;
			}
			MapEventSide mapEventSide = mapEvent.GetMapEventSide(mapEvent.WinningSide);
			MapEventSide mapEventSide2 = mapEvent.GetMapEventSide(mapEvent.DefeatedSide);
			if (!DiplomacyHelpers.VerifyBattleSides(mapEventSide.LeaderParty, mapEventSide2.LeaderParty, out var kingdom3, out var kingdom4))
			{
				return;
			}
			foreach (MapEventParty item8 in (List<MapEventParty>)(object)mapEventSide2.Parties)
			{
				if (item8.Party.IsMobile && item8.Party.MobileParty != null && item8.Party.MobileParty.IsCaravan)
				{
					Hero owner = item8.Party.Owner;
					object obj;
					if (owner == null)
					{
						obj = null;
					}
					else
					{
						Clan clan = owner.Clan;
						obj = ((clan != null) ? clan.Kingdom : null);
					}
					Kingdom val = (Kingdom)obj;
					if (val != null && val == kingdom4)
					{
						_warTracker.IncrementCaravansDestroyed(kingdom4);
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Caravan destroyed: {kingdom4.Name} caravan destroyed by {kingdom3.Name}");
					}
				}
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR tracking battle: " + ex.Message);
		}
	}

	private void OnPrisonerTaken(FlattenedTroopRoster roster)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (roster == null)
		{
			return;
		}
		try
		{
			foreach (FlattenedTroopRosterElement item in roster)
			{
				FlattenedTroopRosterElement current = item;
				if ((current).Troop == null || !((BasicCharacterObject)(current).Troop).IsHero)
				{
					continue;
				}
				Hero heroObject = (current).Troop.HeroObject;
				if (heroObject != null && heroObject.IsLord)
				{
					PartyBase partyBelongedToAsPrisoner = heroObject.PartyBelongedToAsPrisoner;
					Hero val = ((partyBelongedToAsPrisoner != null) ? partyBelongedToAsPrisoner.LeaderHero : null);
					if (val != null && DiplomacyHelpers.VerifyHeroEventSides(val, heroObject, out var kingdom, out var kingdom2) && FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom2, (IFaction)(object)kingdom))
					{
						_warTracker.IncrementLordsCaptured(kingdom2);
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Lord captured: {heroObject.Name} ({kingdom2.Name}) by {kingdom.Name}");
					}
				}
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR tracking prisoners: " + ex.Message);
		}
	}

	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Invalid comparison between Unknown and I4
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if (victim == null || !victim.IsLord)
		{
			return;
		}
		try
		{
			if (killer != null && DiplomacyHelpers.VerifyHeroEventSides(killer, victim, out var kingdom, out var kingdom2) && FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom2, (IFaction)(object)kingdom) && (int)detail != 0 && (int)detail != 2 && (int)detail != 3)
			{
				_warTracker.IncrementLordsKilled(kingdom2);
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Lord killed in war: {victim.Name} ({kingdom2.Name}) by {kingdom.Name} (detail: {detail})");
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR tracking hero death: " + ex.Message);
		}
	}

	private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementDetail detail)
	{
		if (settlement == null)
		{
			return;
		}
		try
		{
			if (newOwner != null && oldOwner != null && DiplomacyHelpers.VerifyHeroEventSides(newOwner, oldOwner, out var kingdom, out var kingdom2) && FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom2, (IFaction)(object)kingdom))
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Settlement captured: {settlement.Name} lost by {kingdom2.Name}, taken by {kingdom.Name}");
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR tracking settlement capture: " + ex.Message);
		}
	}

	private void OnKingdomDestroyed(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return;
		}
		try
		{
			_tradeAgreementSystem.OnKingdomDestroyed(kingdom);
			_tributeSystem.OnKingdomDestroyed(kingdom);
			_reparationsSystem.OnKingdomDestroyed(kingdom);
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, Kingdom> item2 in _pendingStatements.ToList())
			{
				if (item2.Value != null && ((MBObjectBase)item2.Value).StringId == ((MBObjectBase)kingdom).StringId)
				{
					list.Add(item2.Key);
					_pendingStatements.Remove(item2.Key);
					_eventStatementSchedule.Remove(item2.Key);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Removed scheduled statement for destroyed kingdom {kingdom.Name} from event {item2.Key}");
				}
			}
			foreach (KeyValuePair<string, Queue<(Kingdom, CampaignTime)>> item3 in _statementQueue.ToList())
			{
				Queue<(Kingdom, CampaignTime)> value = item3.Value;
				int count = value.Count;
				Queue<(Kingdom, CampaignTime)> queue = new Queue<(Kingdom, CampaignTime)>();
				int num = 0;
				while (value.Count > 0)
				{
					(Kingdom, CampaignTime) item = value.Dequeue();
					if (item.Item1 != null && ((MBObjectBase)item.Item1).StringId == ((MBObjectBase)kingdom).StringId)
					{
						num++;
					}
					else
					{
						queue.Enqueue(item);
					}
				}
				while (queue.Count > 0)
				{
					value.Enqueue(queue.Dequeue());
				}
				if (num > 0)
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Removed {num} queued statements for destroyed kingdom {kingdom.Name} from event {item3.Key}");
				}
				if (value.Count == 0)
				{
					_statementQueue.Remove(item3.Key);
				}
			}
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Kingdom destroyed, cleaned up diplomatic agreements: {kingdom.Name}");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR handling kingdom destruction: " + ex.Message);
		}
	}

	private void OnHourlyTick()
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy || !_initialized)
		{
			if (GlobalSettings<ModSettings>.Instance.EnableDiplomacy && !_initialized)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Diplomacy enabled but manager not initialized - skipping OnHourlyTick");
			}
		}
		else
		{
			_warTracker.UpdateWarStatistics();
			ProcessScheduledStatements();
			ProcessScheduledAnalyses();
			ProcessPendingPlayerStatements();
			CheckPlayerKingdomTimeouts();
		}
	}

	public bool HasActiveDiplomaticEvents()
	{
		return _activeDiplomaticEvents.Any();
	}

	public void ClearActiveDiplomaticEvents()
	{
		try
		{
			int count = _activeDiplomaticEvents.Count;
			_activeDiplomaticEvents.Clear();
			SaveDiplomaticEventsWithSchedules();
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cleared {count} active diplomatic events for force generation");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR clearing active diplomatic events: " + ex.Message);
		}
	}

	public void CompleteCleanup()
	{
		try
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Starting complete diplomacy system cleanup...");
			int count = _activeDiplomaticEvents.Count;
			int count2 = _queuedDiplomaticEvents.Count;
			int count3 = _eventStatementSchedule.Count;
			int count4 = _eventAnalysisSchedule.Count;
			int count5 = _pendingStatements.Count;
			int count6 = _statementQueue.Count;
			int count7 = _pendingPlayerStatements.Count;
			_activeDiplomaticEvents.Clear();
			_queuedDiplomaticEvents.Clear();
			_eventStatementSchedule.Clear();
			_eventAnalysisSchedule.Clear();
			_pendingStatements.Clear();
			_statementQueue.Clear();
			_pendingPlayerStatements.Clear();
			_playerKingdomLastStatement.Clear();
			_battleInitialTroops.Clear();
			_kingdomsCurrentlyGenerating.Clear();
			_isGeneratingStatements = false;
			ClearDialogueAnalysisEvents();
			SaveDiplomaticEventsWithSchedules();
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Complete cleanup finished:");
			DiplomacyLogger.Instance.Log($"  - Active events cleared: {count}");
			DiplomacyLogger.Instance.Log($"  - Queued events cleared: {count2}");
			DiplomacyLogger.Instance.Log($"  - Scheduled statements cleared: {count3}");
			DiplomacyLogger.Instance.Log($"  - Scheduled analyses cleared: {count4}");
			DiplomacyLogger.Instance.Log($"  - Pending statements cleared: {count5}");
			DiplomacyLogger.Instance.Log($"  - Statement queues cleared: {count6}");
			DiplomacyLogger.Instance.Log($"  - Pending player statements cleared: {count7}");
			DiplomacyLogger.Instance.Log("  - DialogueAnalysisEvents cleared from all NPCs");
			DiplomacyLogger.Instance.Log("  - All generation locks and timers reset");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR during complete cleanup: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void OnDailyTick()
	{
		if (GlobalSettings<ModSettings>.Instance.EnableDiplomacy && _initialized)
		{
			_allianceSystem.CleanupEliminatedKingdoms();
			_warTracker.ApplyDailyFatigueRecovery();
			_tradeAgreementSystem.OnDailyTick();
			_tributeSystem.ProcessDailyPayments();
			_reparationsSystem.OnDailyTick();
			_territoryTransferSystem.CleanOldRecords();
			_reparationsSystem.CleanOldRecords();
			_tributeSystem.CleanOldRecords();
			DiplomaticStatementsStorage.Instance.GetRecentStatements();
			try
			{
				_allianceSystem.SynchronizeAlliances();
				SynchronizeWars();
				_tradeAgreementSystem.SynchronizeTradeAgreements();
			}
			catch (Exception ex)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR during daily synchronization: " + ex.Message);
			}
			CleanupStaleDiplomaticEvents();
		}
	}

	private void CleanupStaleDiplomaticEvents()
	{
		if (_activeDiplomaticEvents.Count == 0)
		{
			return;
		}
		List<string> staleEventIds = new List<string>();
		foreach (DynamicEvent activeDiplomaticEvent in _activeDiplomaticEvents)
		{
			if (activeDiplomaticEvent == null || string.IsNullOrEmpty(activeDiplomaticEvent.Id))
			{
				staleEventIds.Add(activeDiplomaticEvent?.Id ?? "null");
				continue;
			}
			if (!activeDiplomaticEvent.RequiresDiplomaticAnalysis)
			{
				staleEventIds.Add(activeDiplomaticEvent.Id);
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cleaning up stale event " + activeDiplomaticEvent.Id + ": RequiresDiplomaticAnalysis=false (already completed)");
				continue;
			}
			if (activeDiplomaticEvent.IsExpired())
			{
				staleEventIds.Add(activeDiplomaticEvent.Id);
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cleaning up stale event " + activeDiplomaticEvent.Id + ": expired");
				continue;
			}
			bool flag = activeDiplomaticEvent.ParticipatingKingdoms != null && activeDiplomaticEvent.ParticipatingKingdoms.Any();
			bool flag2 = _eventStatementSchedule.ContainsKey(activeDiplomaticEvent.Id) || _eventAnalysisSchedule.ContainsKey(activeDiplomaticEvent.Id);
			bool flag3 = _statementQueue.ContainsKey(activeDiplomaticEvent.Id) && _statementQueue[activeDiplomaticEvent.Id].Count > 0;
			bool flag4 = _pendingStatements.ContainsKey(activeDiplomaticEvent.Id);
			if (!flag && !flag2 && !flag3 && !flag4)
			{
				staleEventIds.Add(activeDiplomaticEvent.Id);
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cleaning up stale event " + activeDiplomaticEvent.Id + ": no participants and no schedules (orphaned)");
			}
		}
		if (!staleEventIds.Any())
		{
			return;
		}
		_activeDiplomaticEvents.RemoveAll((DynamicEvent e) => e == null || staleEventIds.Contains(e?.Id));
		foreach (string item in staleEventIds)
		{
			if (item != null)
			{
				_eventStatementSchedule.Remove(item);
				_eventAnalysisSchedule.Remove(item);
				_pendingStatements.Remove(item);
				_statementQueue.Remove(item);
			}
		}
		foreach (string item2 in staleEventIds)
		{
			if (item2 != null)
			{
				DynamicEventsManager.Instance?.MarkDiplomaticEventAsCompleted(item2);
			}
		}
		SaveDiplomaticEventsWithSchedules();
		DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Removed {staleEventIds.Count} stale event(s) from active diplomatic events");
	}

	private void SynchronizeWars()
	{
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Synchronizing wars with game state...");
		HashSet<string> hashSet = new HashSet<string>();
		int num = 0;
		int num2 = 0;
		foreach (Kingdom kingdom1 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			foreach (Kingdom item2 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k != kingdom1))
			{
				string[] array = new string[2]
				{
					((MBObjectBase)kingdom1).StringId,
					((MBObjectBase)item2).StringId
				};
				Array.Sort(array);
				string item = string.Join("_", array);
				if (!hashSet.Contains(item))
				{
					hashSet.Add(item);
					bool flag = false;
					KingdomWarStats kingdomWarStats = (_warTracker.KingdomStats.ContainsKey(((MBObjectBase)kingdom1).StringId) ? _warTracker.KingdomStats[((MBObjectBase)kingdom1).StringId] : null);
					if (kingdomWarStats != null && kingdomWarStats.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)item2).StringId))
					{
						WarStatsAgainstKingdom warStatsAgainstKingdom = kingdomWarStats.WarsAgainstKingdoms[((MBObjectBase)item2).StringId];
						flag = warStatsAgainstKingdom.IsActive;
					}
					bool flag2 = FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom1, (IFaction)(object)item2);
					if (flag && !flag2)
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Synchronizing: Declaring missing war {kingdom1.Name} vs {item2.Name}");
						DeclareWar(kingdom1, item2, "Synchronization: restoring war from saved data");
						num++;
					}
					else if (!flag && flag2)
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Synchronizing: Making peace for unexpected war {kingdom1.Name} vs {item2.Name}");
						MakePeace(kingdom1, item2, "Synchronization: removing unexpected war");
						num2++;
					}
				}
			}
		}
		DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] War synchronization complete: {num} declared, {num2} peace made");
	}

	public WarStatisticsTracker GetWarTracker()
	{
		return _warTracker;
	}

	public AllianceSystem GetAllianceSystem()
	{
		return _allianceSystem;
	}

	public WarFatigueSystem GetFatigueSystem()
	{
		return _fatigueSystem;
	}

	public TradeAgreementSystem GetTradeAgreementSystem()
	{
		return _tradeAgreementSystem;
	}

	public TerritoryTransferSystem GetTerritoryTransferSystem()
	{
		return _territoryTransferSystem;
	}

	public TributeSystem GetTributeSystem()
	{
		return _tributeSystem;
	}

	public ReparationsSystem GetReparationsSystem()
	{
		return _reparationsSystem;
	}

	public List<DynamicEvent> GetActiveDiplomaticEvents()
	{
		if (_activeDiplomaticEvents == null)
		{
			return new List<DynamicEvent>();
		}
		return _activeDiplomaticEvents.Where((DynamicEvent e) => e?.RequiresDiplomaticAnalysis ?? false).ToList();
	}

	public List<string> GetOrderedParticipatingKingdoms(string eventId)
	{
		DynamicEvent dynamicEvent = _activeDiplomaticEvents.FirstOrDefault((DynamicEvent e) => e.Id == eventId);
		if (dynamicEvent == null)
		{
			try
			{
				List<DynamicEvent> source = _storage?.LoadDiplomaticEvents() ?? new List<DynamicEvent>();
				dynamicEvent = source.FirstOrDefault((DynamicEvent e) => e != null && e.Id == eventId);
			}
			catch
			{
			}
		}
		if (dynamicEvent == null)
		{
			return new List<string>();
		}
		List<string> list = new List<string>();
		HashSet<string> processedKingdomIds = new HashSet<string>();
		if (dynamicEvent.KingdomStatements != null && dynamicEvent.KingdomStatements.Any())
		{
			List<KingdomStatement> list2 = dynamicEvent.KingdomStatements.OrderBy((KingdomStatement s) => s.CampaignDays).ToList();
			foreach (KingdomStatement item2 in list2)
			{
				if (!string.IsNullOrEmpty(item2.KingdomId) && !processedKingdomIds.Contains(item2.KingdomId))
				{
					list.Add(item2.KingdomId);
					processedKingdomIds.Add(item2.KingdomId);
				}
			}
		}
		if (_pendingStatements.ContainsKey(eventId))
		{
			Kingdom val = _pendingStatements[eventId];
			if (!processedKingdomIds.Contains(((MBObjectBase)val).StringId))
			{
				list.Add(((MBObjectBase)val).StringId);
				processedKingdomIds.Add(((MBObjectBase)val).StringId);
			}
		}
		if (_statementQueue.ContainsKey(eventId) && _statementQueue[eventId].Count > 0)
		{
			Queue<(Kingdom, CampaignTime)> queue = new Queue<(Kingdom, CampaignTime)>(_statementQueue[eventId]);
			while (queue.Count > 0)
			{
				Kingdom item = queue.Dequeue().Item1;
				if (!processedKingdomIds.Contains(((MBObjectBase)item).StringId))
				{
					list.Add(((MBObjectBase)item).StringId);
					processedKingdomIds.Add(((MBObjectBase)item).StringId);
				}
			}
		}
		if (dynamicEvent.ParticipatingKingdoms != null)
		{
			List<string> collection = dynamicEvent.ParticipatingKingdoms.Where((string id) => !processedKingdomIds.Contains(id)).ToList();
			list.AddRange(collection);
		}
		return list;
	}

	public void SaveAllData()
	{
		try
		{
			_allianceSystem.SaveData();
			_warTracker.SaveData();
			_tradeAgreementSystem.SaveData();
			_territoryTransferSystem.SaveData();
			_tributeSystem.SaveData();
			_reparationsSystem.SaveData();
			SaveDiplomaticEventsWithSchedules();
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] All diplomacy data saved successfully");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR saving diplomacy data: " + ex.Message);
		}
	}

	public void ClearCurrentSaveData()
	{
		try
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Clearing all diplomacy data for current save...");
			_storage.ClearCurrentSaveData();
			_allianceSystem.Alliances.Clear();
			_allianceSystem.AllianceTimes.Clear();
			_warTracker.ClearAllData();
			_activeDiplomaticEvents.Clear();
			_tradeAgreementSystem.TradeAgreements.Clear();
			_tributeSystem.Tributes.Clear();
			_reparationsSystem.ReparationsHistory.Clear();
			_reparationsSystem.PendingDemands.Clear();
			_territoryTransferSystem.TransferHistory.Clear();
			ExpelledClanSystem.Instance.ExpelledClans.Clear();
			DiplomaticStatementsStorage.Instance.ClearAllStatements();
			ClearDialogueAnalysisEvents();
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] All diplomacy data cleared successfully");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR clearing diplomacy data: " + ex.Message);
		}
	}

	private void ClearDialogueAnalysisEvents()
	{
		try
		{
			AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
			if (instance == null)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] AIInfluenceBehavior instance not found - cannot clear DialogueAnalysisEvents");
				return;
			}
			int num = 0;
			int num2 = 0;
			Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
			if (nPCContexts != null && nPCContexts.Any())
			{
				List<NPCContext> list = nPCContexts.Values.ToList();
				foreach (NPCContext item in list)
				{
					if (item.DialogueAnalysisEvents != null && item.DialogueAnalysisEvents.Count > 0)
					{
						num2 += item.DialogueAnalysisEvents.Count;
						item.DialogueAnalysisEvents.Clear();
						num++;
					}
				}
			}
			string activeSaveDirectory = instance.GetActiveSaveDirectory();
			if (!string.IsNullOrEmpty(activeSaveDirectory) && nPCContexts != null)
			{
				List<string> list2 = nPCContexts.Keys.ToList();
				foreach (string item2 in list2)
				{
					string text = instance.FindNPCFileByStringId(activeSaveDirectory, item2);
					if (string.IsNullOrEmpty(text) || !File.Exists(text))
					{
						continue;
					}
					try
					{
						string text2 = File.ReadAllText(text);
						NPCContext nPCContext = JsonConvert.DeserializeObject<NPCContext>(text2);
						if (nPCContext.DialogueAnalysisEvents != null && nPCContext.DialogueAnalysisEvents.Count > 0)
						{
							nPCContext.DialogueAnalysisEvents.Clear();
							string contents = JsonConvert.SerializeObject((object)nPCContext, (Formatting)1);
							File.WriteAllText(text, contents);
						}
					}
					catch (Exception ex)
					{
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR clearing DialogueAnalysisEvents for " + item2 + ": " + ex.Message);
					}
				}
			}
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Cleared {num2} DialogueAnalysisEvents from {num} NPCs");
		}
		catch (Exception ex2)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR in ClearDialogueAnalysisEvents: " + ex2.Message);
		}
	}

	private void ProcessScheduledStatements()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		if (_eventStatementSchedule.Count > 0)
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] ProcessScheduledStatements called. {_eventStatementSchedule.Count} scheduled events");
		}
		if (_isGeneratingStatements)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Statement generation already in progress, skipping this cycle");
			return;
		}
		List<string> list = new List<string>();
		CampaignTime val;
		foreach (KeyValuePair<string, CampaignTime> item2 in _eventStatementSchedule.ToList())
		{
			if (CampaignTime.Now >= item2.Value)
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Event {item2.Key} is ready: scheduled for {item2.Value}, current time {CampaignTime.Now}");
				list.Add(item2.Key);
				continue;
			}
			val = item2.Value;
			double toDays = (val).ToDays;
			val = CampaignTime.Now;
			float num = (float)(toDays - (val).ToDays);
			if (num > 0f && !(num < 100f))
			{
			}
		}
		foreach (string eventId in list.Take(1))
		{
			DynamicEvent diplomaticEvent = _activeDiplomaticEvents.FirstOrDefault((DynamicEvent e) => e.Id == eventId);
			if (diplomaticEvent != null)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Processing event " + eventId + ": " + diplomaticEvent.Type + " involving " + string.Join(", ", diplomaticEvent.ParticipatingKingdoms ?? new List<string>()));
				_eventStatementSchedule.Remove(eventId);
				List<DelayedPlayerStatement> list2 = _pendingPlayerStatements.Where((DelayedPlayerStatement s) => s.PlayerKingdom != null && diplomaticEvent.ParticipatingKingdoms.Contains(((MBObjectBase)s.PlayerKingdom).StringId)).ToList();
				if (list2.Any())
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Event {eventId} has {list2.Count} pending player statements. Skipping statement generation until they are published.");
					continue;
				}
				if (!_pendingStatements.ContainsKey(eventId))
				{
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Generating statements for all kingdoms in event");
					GenerateStatementsForEvent(diplomaticEvent);
					break;
				}
				Kingdom val2 = _pendingStatements[eventId];
				_pendingStatements.Remove(eventId);
				if (val2 != null && !val2.IsEliminated)
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Generating single statement for {val2.Name}");
					GenerateSingleStatementForEvent(diplomaticEvent, val2);
					if (_statementQueue.ContainsKey(eventId) && _statementQueue[eventId].Count > 0)
					{
						_statementQueue[eventId].Dequeue();
						if (_statementQueue[eventId].Count > 0)
						{
							(Kingdom, CampaignTime) tuple = _statementQueue[eventId].Peek();
							ScheduleNextStatement(eventId, tuple.Item1, tuple.Item2);
							double toDays2 = (tuple.Item2).ToDays;
							val = CampaignTime.Now;
							int num2 = (int)(toDays2 - (val).ToDays);
							DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled next queued statement for {tuple.Item1.Name} in {num2} days. {_statementQueue[eventId].Count} remaining in queue.");
						}
						else
						{
							_statementQueue.Remove(eventId);
						}
					}
					break;
				}
				string text = ((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? "null";
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Skipping statement generation for destroyed/eliminated kingdom: " + text + " (event " + eventId + ")");
				if (!_statementQueue.ContainsKey(eventId) || _statementQueue[eventId].Count <= 0)
				{
					continue;
				}
				Queue<(Kingdom, CampaignTime)> queue = _statementQueue[eventId];
				Queue<(Kingdom, CampaignTime)> queue2 = new Queue<(Kingdom, CampaignTime)>();
				while (queue.Count > 0)
				{
					(Kingdom, CampaignTime) item = queue.Dequeue();
					if (item.Item1 != null && !item.Item1.IsEliminated)
					{
						queue2.Enqueue(item);
					}
				}
				while (queue2.Count > 0)
				{
					queue.Enqueue(queue2.Dequeue());
				}
				if (queue.Count > 0)
				{
					(Kingdom, CampaignTime) tuple2 = queue.Peek();
					ScheduleNextStatement(eventId, tuple2.Item1, tuple2.Item2);
					double toDays3 = (tuple2.Item2).ToDays;
					val = CampaignTime.Now;
					int num3 = (int)(toDays3 - (val).ToDays);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled next queued statement for {tuple2.Item1.Name} in {num3} days. {queue.Count} remaining in queue.");
				}
				else
				{
					_statementQueue.Remove(eventId);
				}
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Event " + eventId + " not found in active events list");
				_eventStatementSchedule.Remove(eventId);
			}
		}
	}

	public void ScheduleNextStatement(string eventId, Kingdom kingdom, CampaignTime scheduledTime)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		_eventStatementSchedule[eventId] = scheduledTime;
		_pendingStatements[eventId] = kingdom;
		DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled next statement for {kingdom.Name} in event {eventId}");
	}

	public bool IsKingdomBusyWithStatements(string kingdomId)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		foreach (KeyValuePair<string, Kingdom> pendingStatement in _pendingStatements)
		{
			if (((MBObjectBase)pendingStatement.Value).StringId == kingdomId)
			{
				return true;
			}
		}
		foreach (KeyValuePair<string, CampaignTime> item in _eventStatementSchedule)
		{
			if (item.Value <= CampaignTime.Now && _pendingStatements.ContainsKey(item.Key) && ((MBObjectBase)_pendingStatements[item.Key]).StringId == kingdomId)
			{
				return true;
			}
		}
		return false;
	}

	private async Task GenerateSingleStatementForEvent(DynamicEvent diplomaticEvent, Kingdom kingdom)
	{
		try
		{
			if (kingdom == null || kingdom.IsEliminated)
			{
				string kingdomName = ((kingdom == null) ? null : ((object)kingdom.Name)?.ToString()) ?? "null";
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot generate statement: kingdom " + kingdomName + " is destroyed or eliminated");
				return;
			}
			_isGeneratingStatements = true;
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Generating single statement for {kingdom.Name} (lock acquired)");
			if (DiplomacyManagerHelpers.IsPlayerKingdom(kingdom))
			{
				Hero mainHero = Hero.MainHero;
				object obj;
				if (mainHero == null)
				{
					obj = null;
				}
				else
				{
					Clan clan = mainHero.Clan;
					obj = ((clan != null) ? clan.Kingdom : null);
				}
				Kingdom playerKingdom = (Kingdom)obj;
				if (playerKingdom != null && playerKingdom == kingdom)
				{
					HashSet<string> respondedKingdomIds = (from s in diplomaticEvent.KingdomStatements.Skip(diplomaticEvent.StatementsAtRoundStart)
						select s.KingdomId).ToHashSet();
					if (!respondedKingdomIds.Contains(((MBObjectBase)kingdom).StringId))
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Skipping player kingdom {kingdom.Name} - waiting for manual input");
						List<Kingdom> allKingdoms = GetParticipatingKingdoms(diplomaticEvent);
						Kingdom nextKingdom = (from k in allKingdoms
							where !DiplomacyManagerHelpers.IsPlayerKingdom(k)
							where !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k)
							select k).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => !respondedKingdomIds.Contains(((MBObjectBase)k).StringId)));
						if (nextKingdom != null)
						{
							int intervalDays = GetRandomUpdateInterval();
							ScheduleNextStatement(scheduledTime: CampaignTime.DaysFromNow((float)intervalDays), eventId: diplomaticEvent.Id, kingdom: nextKingdom);
							DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Skipped player kingdom, scheduled next NPC {nextKingdom.Name} in {intervalDays} days");
						}
						return;
					}
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Player kingdom {kingdom.Name} already responded in this round.");
				}
			}
			KingdomStatement statement = await _statementGenerator.GenerateSingleStatement(diplomaticEvent, kingdom);
			if (statement != null)
			{
				if (!diplomaticEvent.KingdomStatements.Contains(statement))
				{
					diplomaticEvent.KingdomStatements.Add(statement);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Added statement to event for {kingdom.Name}");
				}
				else
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Statement already in event for {kingdom.Name} (added by generator)");
				}
				diplomaticEvent.ResetFailedStatementAttempt(((MBObjectBase)kingdom).StringId);
				DynamicEventsManager.Instance?.SaveActiveEvents();
				List<DiplomaticAction> actionsToExecute = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
				List<string> targetKingdomIds = ((statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any()) ? statement.TargetKingdomIds : ((!string.IsNullOrEmpty(statement.TargetKingdomId)) ? new List<string> { statement.TargetKingdomId } : new List<string>()));
				List<string> settlementIds = ((!string.IsNullOrEmpty(statement.SettlementId)) ? (from id in statement.SettlementId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
					select id.Trim()).ToList() : new List<string>());
				int settlementIndex = 0;
				for (int actionIndex = 0; actionIndex < actionsToExecute.Count; actionIndex++)
				{
					DiplomaticAction action = actionsToExecute[actionIndex];
					if (action == DiplomaticAction.None || action == DiplomaticAction.ProposeAlliance || action == DiplomaticAction.ProposePeace)
					{
						continue;
					}
					bool isInternalAction = action == DiplomaticAction.ExpelClan || action == DiplomaticAction.QuarantineSettlement || action == DiplomaticAction.FoundKingdom;
					if (!targetKingdomIds.Any() && !isInternalAction)
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] No target kingdoms found for action {action} from {statement.KingdomId}, skipping");
						continue;
					}
					string targetKingdomId = ((isInternalAction && !targetKingdomIds.Any()) ? null : ((actionsToExecute.Count != targetKingdomIds.Count) ? targetKingdomIds[0] : targetKingdomIds[actionIndex]));
					bool isSettlementAction = action == DiplomaticAction.TransferTerritory || action == DiplomaticAction.RejectTerritory || action == DiplomaticAction.DemandTerritory || action == DiplomaticAction.QuarantineSettlement;
					string settlementIdForAction = null;
					if (isSettlementAction && settlementIds.Any())
					{
						settlementIdForAction = ((settlementIndex < settlementIds.Count) ? settlementIds[settlementIndex] : settlementIds[0]);
						settlementIndex++;
					}
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Executing immediate action from statement: {action} from {statement.KingdomId} to {targetKingdomId}");
					DiplomaticActionInfo actionInfo = new DiplomaticActionInfo
					{
						Action = action,
						SourceKingdomId = statement.KingdomId,
						TargetKingdomId = targetKingdomId,
						TargetClanId = statement.TargetClanId,
						Reason = (statement.Reason ?? statement.StatementText),
						SettlementId = settlementIdForAction,
						TradeAgreementDurationYears = statement.TradeAgreementDurationYears
					};
					if (action == DiplomaticAction.DemandTribute || action == DiplomaticAction.AcceptTribute)
					{
						actionInfo.DailyTributeAmount = statement.DailyTributeAmount;
						actionInfo.TributeDurationDays = statement.TributeDurationDays;
					}
					if (action == DiplomaticAction.DemandReparations)
					{
						actionInfo.ReparationsAmount = statement.ReparationsAmount;
					}
					if (action == DiplomaticAction.QuarantineSettlement)
					{
						actionInfo.QuarantineDurationDays = statement.QuarantineDurationDays;
					}
					if (action == DiplomaticAction.FoundKingdom)
					{
						actionInfo.NewKingdomName = statement.NewKingdomName;
						actionInfo.NewKingdomInformalName = statement.NewKingdomInformalName;
					}
					ExecuteDiplomaticAction(actionInfo);
				}
			}
			else
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Statement generation failed for {kingdom.Name}");
				if (DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(kingdom))
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Leader {kingdom.Leader.Name} is prisoner - skipping retry and moving to next kingdom");
				}
				else
				{
					if (diplomaticEvent.IncrementFailedStatementAttempt(((MBObjectBase)kingdom).StringId))
					{
						CampaignTime retryTime = CampaignTime.DaysFromNow(1f);
						diplomaticEvent.SetKingdomStatementRetryDelay(((MBObjectBase)kingdom).StringId, 1);
						ScheduleNextStatement(diplomaticEvent.Id, kingdom, retryTime);
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled retry for {kingdom.Name} in 1 day (attempt {diplomaticEvent.FailedStatementAttempts[((MBObjectBase)kingdom).StringId]}/3)");
						return;
					}
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Max retries reached for {kingdom.Name}, moving to next kingdom");
				}
			}
			List<Kingdom> allKingdomsForCount = GetParticipatingKingdoms(diplomaticEvent);
			int expectedStatements = allKingdomsForCount.Count((Kingdom k) => !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k) && !DiplomacyManagerHelpers.IsPlayerKingdom(k));
			int totalStatements = diplomaticEvent.KingdomStatements.Count;
			int statementsInCurrentRound = totalStatements - diplomaticEvent.StatementsAtRoundStart;
			int skippedCount = allKingdomsForCount.Count - expectedStatements;
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Round tracking: Total={totalStatements}, RoundStart={diplomaticEvent.StatementsAtRoundStart}, CurrentRound={statementsInCurrentRound}, Expected={expectedStatements} (excluding {skippedCount} imprisoned leaders/player kingdom)");
			HashSet<string> respondedInCurrentRound = (from s in diplomaticEvent.KingdomStatements.Skip(diplomaticEvent.StatementsAtRoundStart)
				select s.KingdomId).ToHashSet();
			List<Kingdom> allActiveNpcKingdoms = allKingdomsForCount.Where((Kingdom k) => !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k) && !DiplomacyManagerHelpers.IsPlayerKingdom(k)).ToList();
			int uniqueRespondedInRound = respondedInCurrentRound.Count;
			int uniqueExpectedInRound = allActiveNpcKingdoms.Count;
			if (statementsInCurrentRound >= expectedStatements && uniqueRespondedInRound >= uniqueExpectedInRound)
			{
				List<DelayedPlayerStatement> pendingPlayerStatements = _pendingPlayerStatements.Where((DelayedPlayerStatement s) => s.PlayerKingdom != null && diplomaticEvent.ParticipatingKingdoms.Contains(((MBObjectBase)s.PlayerKingdom).StringId)).ToList();
				if (!pendingPlayerStatements.Any())
				{
					Random random = new Random();
					int daysUntilAnalysis = random.Next(1, 3);
					CampaignTime analysisTime = CampaignTime.DaysFromNow((float)daysUntilAnalysis);
					_eventAnalysisSchedule[diplomaticEvent.Id] = analysisTime;
					if (_statementQueue.ContainsKey(diplomaticEvent.Id))
					{
						_statementQueue.Remove(diplomaticEvent.Id);
					}
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] All kingdoms responded in this round. Analysis scheduled for event {diplomaticEvent.Id} in {daysUntilAnalysis} days");
				}
				else
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] All kingdoms responded but {pendingPlayerStatements.Count} player statements are still pending. Analysis NOT scheduled yet.");
				}
			}
			else
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Waiting for more statements in round {diplomaticEvent.DiplomaticRounds} ({statementsInCurrentRound}/{expectedStatements}). Analysis NOT scheduled yet.");
				List<Kingdom> allKingdoms2 = GetParticipatingKingdoms(diplomaticEvent);
				HashSet<string> respondedKingdomIds2 = (from s in diplomaticEvent.KingdomStatements.Skip(diplomaticEvent.StatementsAtRoundStart)
					select s.KingdomId).ToHashSet();
				List<Kingdom> kingdomsToSchedule = (from k in allKingdoms2
					where !DiplomacyManagerHelpers.IsPlayerKingdom(k)
					where !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k)
					where !respondedKingdomIds2.Contains(((MBObjectBase)k).StringId)
					select k).ToList();
				if (kingdomsToSchedule.Any())
				{
					if (!_statementQueue.ContainsKey(diplomaticEvent.Id))
					{
						_statementQueue[diplomaticEvent.Id] = new Queue<(Kingdom, CampaignTime)>();
					}
					_statementQueue[diplomaticEvent.Id].Clear();
					int baseIntervalDays = GetRandomUpdateInterval();
					for (int i = 0; i < kingdomsToSchedule.Count; i++)
					{
						Kingdom kingdomToSchedule = kingdomsToSchedule[i];
						int intervalDays2 = baseIntervalDays + i;
						CampaignTime nextStatementTime = CampaignTime.DaysFromNow((float)intervalDays2);
						_statementQueue[diplomaticEvent.Id].Enqueue((kingdomToSchedule, nextStatementTime));
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Queued statement for {kingdomToSchedule.Name} in {intervalDays2} days (position {i + 1}/{kingdomsToSchedule.Count})");
					}
					(Kingdom kingdom, CampaignTime scheduledTime) firstStatement = _statementQueue[diplomaticEvent.Id].Peek();
					ScheduleNextStatement(diplomaticEvent.Id, firstStatement.kingdom, firstStatement.scheduledTime);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled first statement for {firstStatement.kingdom.Name} in {baseIntervalDays} days. {kingdomsToSchedule.Count} total kingdoms queued.");
				}
				else
				{
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] WARNING: Could not find any kingdoms to respond");
				}
			}
			SaveDiplomaticEventsWithSchedules();
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR generating single statement: " + ex2.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.GenerateSingleStatementForEvent", $"Failed to generate statement for {kingdom.Name} in event {diplomaticEvent.Id}", ex2);
		}
		finally
		{
			_isGeneratingStatements = false;
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Statement generation lock released");
		}
	}

	private void ProcessScheduledAnalyses()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, CampaignTime> kvp in _eventAnalysisSchedule.ToList())
		{
			DynamicEvent dynamicEvent = _activeDiplomaticEvents.FirstOrDefault((DynamicEvent e) => e.Id == kvp.Key);
			if (dynamicEvent != null && CampaignTime.Now >= kvp.Value && dynamicEvent.IsReadyForAnalysis())
			{
				list.Add(kvp.Key);
			}
		}
		foreach (string eventId in list)
		{
			DynamicEvent diplomaticEvent = _activeDiplomaticEvents.FirstOrDefault((DynamicEvent e) => e.Id == eventId);
			if (diplomaticEvent == null)
			{
				continue;
			}
			List<Kingdom> participatingKingdoms = GetParticipatingKingdoms(diplomaticEvent);
			int num = participatingKingdoms.Count((Kingdom k) => !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k) && !DiplomacyManagerHelpers.IsPlayerKingdom(k));
			int num2 = diplomaticEvent.KingdomStatements?.Count ?? 0;
			int num3 = num2 - diplomaticEvent.StatementsAtRoundStart;
			HashSet<string> hashSet = (from s in (diplomaticEvent.KingdomStatements ?? new List<KingdomStatement>()).Skip(diplomaticEvent.StatementsAtRoundStart)
				select s.KingdomId).ToHashSet();
			List<Kingdom> list2 = participatingKingdoms.Where((Kingdom k) => !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k) && !DiplomacyManagerHelpers.IsPlayerKingdom(k)).ToList();
			int count = hashSet.Count;
			int count2 = list2.Count;
			if (num3 < num || count < count2)
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Event {eventId} scheduled for analysis, but not all kingdoms responded yet. Current: {count}/{count2} (statements: {num3}/{num}). Rescheduling analysis and restoring statement queue.");
				_eventAnalysisSchedule.Remove(eventId);
				HashSet<string> respondedKingdoms = (from s in (diplomaticEvent.KingdomStatements ?? new List<KingdomStatement>()).Skip(diplomaticEvent.StatementsAtRoundStart)
					select s.KingdomId).ToHashSet();
				List<Kingdom> list3 = (from k in list2
					where !DiplomacyManagerHelpers.IsPlayerKingdom(k)
					where !respondedKingdoms.Contains(((MBObjectBase)k).StringId)
					select k).ToList();
				if (list3.Any())
				{
					if (!_statementQueue.ContainsKey(diplomaticEvent.Id))
					{
						_statementQueue[diplomaticEvent.Id] = new Queue<(Kingdom, CampaignTime)>();
					}
					_statementQueue[diplomaticEvent.Id].Clear();
					int randomUpdateInterval = GetRandomUpdateInterval();
					for (int num4 = 0; num4 < list3.Count; num4++)
					{
						Kingdom val = list3[num4];
						int num5 = randomUpdateInterval + num4;
						CampaignTime item = CampaignTime.DaysFromNow((float)num5);
						_statementQueue[diplomaticEvent.Id].Enqueue((val, item));
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Queued statement for {val.Name} in {num5} days (position {num4 + 1}/{list3.Count})");
					}
					(Kingdom, CampaignTime) tuple = _statementQueue[diplomaticEvent.Id].Peek();
					ScheduleNextStatement(diplomaticEvent.Id, tuple.Item1, tuple.Item2);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled first statement for {tuple.Item1.Name} in {randomUpdateInterval} days. {list3.Count} total kingdoms queued.");
				}
			}
			else
			{
				List<DelayedPlayerStatement> list4 = _pendingPlayerStatements.Where((DelayedPlayerStatement s) => s.PlayerKingdom != null && diplomaticEvent.ParticipatingKingdoms.Contains(((MBObjectBase)s.PlayerKingdom).StringId)).ToList();
				if (list4.Any())
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Event {eventId} has {list4.Count} pending player statements. Skipping analysis until they are published.");
					continue;
				}
				_eventAnalysisSchedule.Remove(eventId);
				List<KingdomStatement> statements = diplomaticEvent.KingdomStatements.ToList();
				AnalyzeAndExecuteDiplomaticActions(diplomaticEvent, statements);
			}
		}
	}

	private async Task GenerateStatementsForEvent(DynamicEvent diplomaticEvent)
	{
		try
		{
			_isGeneratingStatements = true;
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Generating statements for event " + diplomaticEvent.Id + " (lock acquired)");
			List<KingdomStatement> statements = await _statementGenerator.GenerateStatements(diplomaticEvent, GetParticipatingKingdoms(diplomaticEvent));
			if (statements == null || !statements.Any())
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] No statements generated");
				return;
			}
			List<KingdomStatement> newStatements = statements.Where((KingdomStatement s) => !diplomaticEvent.KingdomStatements.Contains(s)).ToList();
			if (newStatements.Any())
			{
				diplomaticEvent.KingdomStatements.AddRange(newStatements);
			}
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Generated {statements.Count} kingdom statements in this call");
			DynamicEventsManager.Instance?.SaveActiveEvents();
			foreach (KingdomStatement statement in statements)
			{
				List<DiplomaticAction> actionsToExecute = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
				List<string> targetKingdomIds = ((statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any()) ? statement.TargetKingdomIds : ((!string.IsNullOrEmpty(statement.TargetKingdomId)) ? new List<string> { statement.TargetKingdomId } : new List<string>()));
				if (!targetKingdomIds.Any())
				{
					if (!actionsToExecute.All((DiplomaticAction a) => a == DiplomaticAction.ExpelClan || a == DiplomaticAction.QuarantineSettlement))
					{
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] No target kingdoms found for statement from " + statement.KingdomId + ", skipping action execution");
						continue;
					}
					targetKingdomIds.Add(null);
				}
				foreach (DiplomaticAction action in actionsToExecute)
				{
					if (action != DiplomaticAction.DeclareWar)
					{
						continue;
					}
					List<string> warTargetIds = ((actionsToExecute.Count == targetKingdomIds.Count) ? targetKingdomIds.Where((string _, int idx) => actionsToExecute[idx] == DiplomaticAction.DeclareWar).ToList() : targetKingdomIds);
					Kingdom sourceKingdom = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == statement.KingdomId));
					if (sourceKingdom == null)
					{
						break;
					}
					foreach (string targetId in warTargetIds)
					{
						if (string.IsNullOrEmpty(targetId))
						{
							continue;
						}
						Kingdom targetKingdom = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == targetId));
						if (targetKingdom != null)
						{
							if (_allianceSystem.AreAllied(sourceKingdom, targetKingdom))
							{
								DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Pre-emptively breaking alliance before war: {sourceKingdom.Name} ↔ {targetKingdom.Name}");
								_allianceSystem.BreakAlliance(sourceKingdom, targetKingdom);
							}
							if (_tradeAgreementSystem.HasTradeAgreement(sourceKingdom, targetKingdom, out var _))
							{
								DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Pre-emptively ending trade agreement before war: {sourceKingdom.Name} ↔ {targetKingdom.Name}");
								_tradeAgreementSystem.EndTradeAgreement(sourceKingdom, targetKingdom);
							}
						}
					}
					break;
				}
				List<string> settlementIds = ((!string.IsNullOrEmpty(statement.SettlementId)) ? (from id in statement.SettlementId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
					select id.Trim()).ToList() : new List<string>());
				int settlementIndex = 0;
				for (int i = 0; i < actionsToExecute.Count; i++)
				{
					DiplomaticAction action2 = actionsToExecute[i];
					if (action2 == DiplomaticAction.None || action2 == DiplomaticAction.ProposeAlliance || action2 == DiplomaticAction.ProposePeace || action2 == DiplomaticAction.ProposeTradeAgreement || action2 == DiplomaticAction.DemandTerritory || action2 == DiplomaticAction.DemandTribute || action2 == DiplomaticAction.DemandReparations)
					{
						continue;
					}
					string targetKingdomId;
					if ((action2 == DiplomaticAction.ExpelClan || action2 == DiplomaticAction.QuarantineSettlement || action2 == DiplomaticAction.FoundKingdom) && !targetKingdomIds.Any())
					{
						targetKingdomId = null;
					}
					else if (actionsToExecute.Count == targetKingdomIds.Count)
					{
						targetKingdomId = targetKingdomIds[i];
					}
					else if (targetKingdomIds.Any())
					{
						targetKingdomId = targetKingdomIds[0];
					}
					else
					{
						targetKingdomId = null;
					}
					Kingdom sourceKingdom2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == statement.KingdomId));
					Kingdom targetKingdom2 = ((!string.IsNullOrEmpty(targetKingdomId)) ? ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == targetKingdomId)) : null);
					if (sourceKingdom2 != null && targetKingdom2 != null)
					{
						bool isAtWar = FactionManager.IsAtWarAgainstFaction((IFaction)(object)sourceKingdom2, (IFaction)(object)targetKingdom2);
						if (isAtWar && (action2 == DiplomaticAction.AcceptAlliance || action2 == DiplomaticAction.AcceptTradeAgreement))
						{
							DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Skipping {action2}: {sourceKingdom2.Name} and {targetKingdom2.Name} are at war");
							continue;
						}
						if (isAtWar && action2 == DiplomaticAction.DeclareWar)
						{
							DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Skipping {action2}: {sourceKingdom2.Name} and {targetKingdom2.Name} are already at war");
							continue;
						}
					}
					bool isSettlementAction = action2 == DiplomaticAction.TransferTerritory || action2 == DiplomaticAction.RejectTerritory || action2 == DiplomaticAction.DemandTerritory || action2 == DiplomaticAction.QuarantineSettlement;
					string settlementIdForAction = null;
					if (isSettlementAction && settlementIds.Any())
					{
						settlementIdForAction = ((settlementIndex < settlementIds.Count) ? settlementIds[settlementIndex] : settlementIds[0]);
						settlementIndex++;
					}
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Executing immediate action from statement: {action2} from {statement.KingdomId} to {targetKingdomId}");
					DiplomaticActionInfo actionInfo = new DiplomaticActionInfo
					{
						Action = action2,
						SourceKingdomId = statement.KingdomId,
						TargetKingdomId = targetKingdomId,
						TargetClanId = statement.TargetClanId,
						Reason = (statement.Reason ?? statement.StatementText),
						SettlementId = settlementIdForAction,
						TradeAgreementDurationYears = statement.TradeAgreementDurationYears
					};
					if (action2 == DiplomaticAction.DemandTribute || action2 == DiplomaticAction.AcceptTribute)
					{
						actionInfo.DailyTributeAmount = statement.DailyTributeAmount;
						actionInfo.TributeDurationDays = statement.TributeDurationDays;
					}
					if (action2 == DiplomaticAction.DemandReparations)
					{
						actionInfo.ReparationsAmount = statement.ReparationsAmount;
					}
					if (action2 == DiplomaticAction.QuarantineSettlement)
					{
						actionInfo.QuarantineDurationDays = statement.QuarantineDurationDays;
					}
					if (action2 == DiplomaticAction.FoundKingdom)
					{
						actionInfo.NewKingdomName = statement.NewKingdomName;
						actionInfo.NewKingdomInformalName = statement.NewKingdomInformalName;
					}
					ExecuteDiplomaticAction(actionInfo);
				}
			}
			List<Kingdom> allKingdomsForCountCheck = GetParticipatingKingdoms(diplomaticEvent);
			int expectedStatements = allKingdomsForCountCheck.Count((Kingdom k) => !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k));
			int totalStatements = diplomaticEvent.KingdomStatements.Count;
			int statementsInCurrentRound = totalStatements - diplomaticEvent.StatementsAtRoundStart;
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Round tracking: Total={totalStatements}, RoundStart={diplomaticEvent.StatementsAtRoundStart}, CurrentRound={statementsInCurrentRound}, Expected={expectedStatements} (excluding {allKingdomsForCountCheck.Count - expectedStatements} imprisoned leaders)");
			SaveDiplomaticEventsWithSchedules();
			if (statementsInCurrentRound >= expectedStatements)
			{
				List<DelayedPlayerStatement> pendingPlayerStatements = _pendingPlayerStatements.Where((DelayedPlayerStatement s) => s.PlayerKingdom != null && diplomaticEvent.ParticipatingKingdoms.Contains(((MBObjectBase)s.PlayerKingdom).StringId)).ToList();
				if (!pendingPlayerStatements.Any())
				{
					Random random = new Random();
					int daysUntilAnalysis = random.Next(1, 3);
					CampaignTime analysisTime = CampaignTime.DaysFromNow((float)daysUntilAnalysis);
					_eventAnalysisSchedule[diplomaticEvent.Id] = analysisTime;
					if (_statementQueue.ContainsKey(diplomaticEvent.Id))
					{
						_statementQueue.Remove(diplomaticEvent.Id);
					}
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] All kingdoms responded in round {diplomaticEvent.DiplomaticRounds}. Analysis scheduled for event {diplomaticEvent.Id} in {daysUntilAnalysis} days");
				}
				else
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] All kingdoms responded but {pendingPlayerStatements.Count} player statements are still pending. Analysis NOT scheduled yet.");
				}
			}
			else
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Waiting for more statements in round {diplomaticEvent.DiplomaticRounds} ({statementsInCurrentRound}/{expectedStatements}). Analysis NOT scheduled yet.");
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR generating statements: " + ex2.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.GenerateStatementsForEvent", "Failed to generate statements for event " + diplomaticEvent.Id, ex2);
		}
		finally
		{
			_isGeneratingStatements = false;
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Statement generation lock released");
		}
	}

	private int GetRandomUpdateInterval()
	{
		Random random = new Random();
		int statementGenerationIntervalDays = GlobalSettings<ModSettings>.Instance.StatementGenerationIntervalDays;
		return random.Next(1, statementGenerationIntervalDays + 1);
	}

	private async Task AnalyzeAndExecuteDiplomaticActions(DynamicEvent diplomaticEvent, List<KingdomStatement> statements)
	{
		if (_eventsAnalyzer == null)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Events analyzer not initialized");
			return;
		}
		try
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Analyzing diplomatic statements for event " + diplomaticEvent.Id);
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Analyzing diplomatic situation");
			DiplomaticAnalysisResult analysisResult = await _eventsAnalyzer.AnalyzeDiplomaticEvent(diplomaticEvent, statements);
			if (analysisResult == null)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Analysis returned null result - scheduling retry");
				diplomaticEvent.SetAnalysisRetryDelay(3);
				CampaignTime retryTime = CampaignTime.DaysFromNow(3f);
				_eventAnalysisSchedule[diplomaticEvent.Id] = retryTime;
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Analysis retry scheduled for event " + diplomaticEvent.Id + " in 3 days");
				return;
			}
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Analysis result: Continue={analysisResult.ShouldContinueEvent}, End={analysisResult.ShouldEndEvent}");
			if (analysisResult.RetryDelayDays > 0)
			{
				diplomaticEvent.SetAnalysisRetryDelay(analysisResult.RetryDelayDays);
				CampaignTime retryTime2 = CampaignTime.DaysFromNow((float)analysisResult.RetryDelayDays);
				_eventAnalysisSchedule[diplomaticEvent.Id] = retryTime2;
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Analysis retry scheduled for event {diplomaticEvent.Id} in {analysisResult.RetryDelayDays} days");
			}
			if (analysisResult.RelationChanges != null && analysisResult.RelationChanges.Any())
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Processing {analysisResult.RelationChanges.Count} relation changes");
				foreach (RelationChangeInfo relationChange in analysisResult.RelationChanges)
				{
					ApplyRelationChange(relationChange);
				}
			}
			List<string> newlyAddedKingdoms = new List<string>();
			if (analysisResult.KingdomsToAdd != null && analysisResult.KingdomsToAdd.Any())
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Adding {analysisResult.KingdomsToAdd.Count} kingdoms to event");
				int maxKingdoms = GlobalSettings<ModSettings>.Instance?.MaxParticipatingKingdoms ?? 4;
				Hero mainHero = Hero.MainHero;
				object obj;
				if (mainHero == null)
				{
					obj = null;
				}
				else
				{
					Clan clan = mainHero.Clan;
					obj = ((clan != null) ? clan.Kingdom : null);
				}
				Kingdom playerKingdom = (Kingdom)obj;
				string playerKingdomId = ((playerKingdom != null) ? ((MBObjectBase)playerKingdom).StringId : null);
				int nonPlayerKingdomsCount = diplomaticEvent.ParticipatingKingdoms.Count((string k) => k != playerKingdomId);
				foreach (string kingdomId in analysisResult.KingdomsToAdd)
				{
					if (kingdomId != playerKingdomId && nonPlayerKingdomsCount >= maxKingdoms)
					{
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Maximum participating kingdoms limit reached ({maxKingdoms}, excluding player). Cannot add more kingdoms.");
						break;
					}
					if (!diplomaticEvent.ParticipatingKingdoms.Contains(kingdomId))
					{
						diplomaticEvent.ParticipatingKingdoms.Add(kingdomId);
						newlyAddedKingdoms.Add(kingdomId);
						Kingdom kingdom = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kingdomId));
						string kingdomName = ((kingdom != null) ? ((object)kingdom.Name).ToString() : null) ?? kingdomId;
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Added kingdom: " + kingdomName + " (" + kingdomId + ")");
						if (kingdomId != playerKingdomId)
						{
							nonPlayerKingdomsCount++;
						}
					}
				}
			}
			if (analysisResult.KingdomsToRemove != null && analysisResult.KingdomsToRemove.Any())
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Removing {analysisResult.KingdomsToRemove.Count} kingdoms from event");
				foreach (string kingdomId2 in analysisResult.KingdomsToRemove)
				{
					if (diplomaticEvent.ParticipatingKingdoms.Contains(kingdomId2))
					{
						diplomaticEvent.ParticipatingKingdoms.Remove(kingdomId2);
						Kingdom kingdom2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kingdomId2));
						string kingdomName2 = ((kingdom2 != null) ? ((object)kingdom2.Name).ToString() : null) ?? kingdomId2;
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Removed kingdom: " + kingdomName2 + " (" + kingdomId2 + ")");
					}
				}
			}
			if ((analysisResult.KingdomsToAdd != null && analysisResult.KingdomsToAdd.Any()) || (analysisResult.KingdomsToRemove != null && analysisResult.KingdomsToRemove.Any()))
			{
				DiplomacyLogger.Instance.Log(string.Format("[DIPLOMACY_MGR] Updated participating kingdoms ({0} total): {1}", diplomaticEvent.ParticipatingKingdoms.Count, string.Join(", ", diplomaticEvent.ParticipatingKingdoms)));
			}
			if (analysisResult.ApplicableNPCs != null && analysisResult.ApplicableNPCs.Any())
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Updating applicable NPCs for event " + diplomaticEvent.Id);
				string oldNPCs = string.Join(", ", diplomaticEvent.ApplicableNPCs.Any() ? diplomaticEvent.ApplicableNPCs : new List<string> { "none" });
				diplomaticEvent.ApplicableNPCs = new List<string>(analysisResult.ApplicableNPCs);
				string newNPCs = string.Join(", ", diplomaticEvent.ApplicableNPCs);
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Applicable NPCs changed from [" + oldNPCs + "] to [" + newNPCs + "]");
				if (!analysisResult.ApplicableNPCs.Contains("all") || oldNPCs.Contains("all"))
				{
				}
			}
			List<EconomicEffect> effectsForUpdate = null;
			DiseaseEventData diseaseDataForUpdate = null;
			if (analysisResult.EconomicEffects != null && analysisResult.EconomicEffects.Any())
			{
				try
				{
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Applying {analysisResult.EconomicEffects.Count} economic effects from diplomatic analysis");
					foreach (EconomicEffect effect in analysisResult.EconomicEffects)
					{
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Economic effect: " + effect.TargetType + " -> " + (effect.TargetId ?? "multiple") + ", reason: " + effect.Reason);
					}
					EconomicEffectsManager.Instance?.AddEconomicEffects(analysisResult.EconomicEffects);
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Economic effects applied successfully");
					effectsForUpdate = analysisResult.EconomicEffects;
				}
				catch (Exception ex)
				{
					Exception ex2 = ex;
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR applying economic effects: " + ex2.Message);
					DiplomacyLogger.Instance.LogError("DiplomacyManager.AnalyzeAndExecuteDiplomaticActions", "Failed to apply economic effects for event " + diplomaticEvent.Id, ex2);
				}
			}
			if (analysisResult.DiseaseData != null && !string.IsNullOrEmpty(analysisResult.DiseaseData.SettlementId) && (GlobalSettings<ModSettings>.Instance?.EnableDiseaseSystem ?? false))
			{
				try
				{
					Disease disease = DiseaseManager.Instance?.CreateDiseaseFromDiseaseEventData(diplomaticEvent, analysisResult.DiseaseData);
					if (disease != null)
					{
						diseaseDataForUpdate = analysisResult.DiseaseData;
						DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Created disease '" + disease.Name + "' in " + analysisResult.DiseaseData.SettlementId + " from analyzer");
					}
				}
				catch (Exception ex)
				{
					Exception ex3 = ex;
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR creating disease from analyzer: " + ex3.Message);
				}
			}
			if (!string.IsNullOrEmpty(analysisResult.EventUpdate))
			{
				diplomaticEvent.AddEventUpdate(analysisResult.EventUpdate, "Diplomatic Analysis", effectsForUpdate, diseaseDataForUpdate);
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Added event update to history" + ((effectsForUpdate != null && effectsForUpdate.Any()) ? $" with {effectsForUpdate.Count} economic effects" : "") + ((diseaseDataForUpdate != null) ? " with disease data" : ""));
				ShowEventUpdateToPlayer(diplomaticEvent, analysisResult.EventUpdate);
			}
			if (analysisResult.ShouldEndEvent)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Ending diplomatic event " + diplomaticEvent.Id);
				string[] participatingKingdoms = diplomaticEvent.ParticipatingKingdoms?.ToArray() ?? new string[0];
				DiplomacyLogger.Instance.LogSituationResolved(diplomaticEvent.Id, "Analysis Complete", participatingKingdoms);
				diplomaticEvent.RequiresDiplomaticAnalysis = false;
				_activeDiplomaticEvents.RemoveAll((DynamicEvent e) => e.Id == diplomaticEvent.Id);
				DynamicEventsManager.Instance?.MarkDiplomaticEventAsCompleted(diplomaticEvent.Id);
				_eventStatementSchedule.Remove(diplomaticEvent.Id);
				_eventAnalysisSchedule.Remove(diplomaticEvent.Id);
				_pendingStatements.Remove(diplomaticEvent.Id);
				_statementQueue.Remove(diplomaticEvent.Id);
				try
				{
					List<DynamicEvent> storedEventsForCompletion = _storage.LoadDiplomaticEvents() ?? new List<DynamicEvent>();
					int existingIndex = storedEventsForCompletion.FindIndex((DynamicEvent e) => e != null && e.Id == diplomaticEvent.Id);
					if (existingIndex >= 0)
					{
						storedEventsForCompletion[existingIndex] = diplomaticEvent;
					}
					else
					{
						storedEventsForCompletion.Add(diplomaticEvent);
					}
					SaveDiplomaticEventsWithSchedules(storedEventsForCompletion);
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Saved completed event " + diplomaticEvent.Id + " with final update");
				}
				catch (Exception ex4)
				{
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] WARNING: Failed to save completed event " + diplomaticEvent.Id + " to storage: " + ex4.Message + ". In-memory state is correct, will be saved on next opportunity.");
				}
				ShowEventCompletionToPlayer(diplomaticEvent);
				DynamicEventsManager.Instance?.ResetGenerationTimer();
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Reset automatic event generation timer after diplomatic event completion");
				TryStartNextQueuedDiplomaticEvent();
			}
			else if (analysisResult.ShouldContinueEvent)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Diplomatic event " + diplomaticEvent.Id + " will continue");
				diplomaticEvent.DiplomaticRounds++;
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Starting diplomatic round {diplomaticEvent.DiplomaticRounds}");
				DiplomacyLogger.Instance.Log($"DIPLOMATIC EVENT CONTINUES: {diplomaticEvent.Id} - Round {diplomaticEvent.DiplomaticRounds}");
				diplomaticEvent.StatementsAtRoundStart = diplomaticEvent.KingdomStatements.Count;
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Statements at round start: {diplomaticEvent.StatementsAtRoundStart}");
				ContinueDiplomaticNegotiations(diplomaticEvent, newlyAddedKingdoms);
			}
			List<DynamicEvent> allStoredEvents = _storage.LoadDiplomaticEvents() ?? new List<DynamicEvent>();
			HashSet<string> activeEventIds = new HashSet<string>(from e in _activeDiplomaticEvents
				where e != null && !string.IsNullOrEmpty(e.Id)
				select e.Id);
			foreach (DynamicEvent activeEvent in _activeDiplomaticEvents)
			{
				if (activeEvent != null && !string.IsNullOrEmpty(activeEvent.Id))
				{
					int existingIndex2 = allStoredEvents.FindIndex((DynamicEvent e) => e != null && e.Id == activeEvent.Id);
					if (existingIndex2 >= 0)
					{
						allStoredEvents[existingIndex2] = activeEvent;
					}
					else
					{
						allStoredEvents.Add(activeEvent);
					}
				}
			}
			if (analysisResult.ShouldEndEvent && !string.IsNullOrEmpty(diplomaticEvent.Id))
			{
				DynamicEvent completedInStorage = allStoredEvents.FirstOrDefault((DynamicEvent e) => e != null && e.Id == diplomaticEvent.Id);
				if (completedInStorage?.RequiresDiplomaticAnalysis ?? false)
				{
					completedInStorage.RequiresDiplomaticAnalysis = false;
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Safety net: fixed stale RequiresDiplomaticAnalysis flag for completed event " + diplomaticEvent.Id + " in storage");
				}
				if (completedInStorage == null)
				{
					allStoredEvents.Add(diplomaticEvent);
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Safety net: added completed event " + diplomaticEvent.Id + " to storage");
				}
			}
			allStoredEvents.RemoveAll((DynamicEvent e) => e != null && !string.IsNullOrEmpty(e.Id) && !activeEventIds.Contains(e.Id) && (e.EventHistory == null || !e.EventHistory.Any()));
			SaveDiplomaticEventsWithSchedules(allStoredEvents);
		}
		catch (Exception ex5)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR analyzing diplomatic actions: " + ex5.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.AnalyzeAndExecuteDiplomaticActions", "Failed to analyze event " + diplomaticEvent.Id, ex5);
		}
	}

	public void QueueDiplomaticEvent(DynamicEvent diplomaticEvent)
	{
		if (diplomaticEvent != null && !_activeDiplomaticEvents.Any((DynamicEvent e) => e.Id == diplomaticEvent.Id) && !_queuedDiplomaticEvents.Any((DynamicEvent e) => e.Id == diplomaticEvent.Id))
		{
			_queuedDiplomaticEvents.Enqueue(diplomaticEvent);
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Diplomatic event {diplomaticEvent.Id} queued manually. {_queuedDiplomaticEvents.Count} event(s) waiting.");
		}
	}

	private void TryStartNextQueuedDiplomaticEvent()
	{
		if (_queuedDiplomaticEvents.Count != 0)
		{
			DynamicEvent dynamicEvent = _queuedDiplomaticEvents.Dequeue();
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Starting queued diplomatic event {dynamicEvent.Id}. Remaining queued events: {_queuedDiplomaticEvents.Count}");
			ProcessDiplomaticEvent(dynamicEvent);
		}
	}

	private async Task ContinueDiplomaticNegotiations(DynamicEvent diplomaticEvent, List<string> priorityKingdoms = null)
	{
		try
		{
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduling next round of negotiations for event {diplomaticEvent.Id}, round {diplomaticEvent.DiplomaticRounds}");
			List<Kingdom> allKingdoms = GetParticipatingKingdoms(diplomaticEvent);
			List<Kingdom> kingdomsToSchedule = (from k in allKingdoms
				where !DiplomacyManagerHelpers.IsPlayerKingdom(k)
				where !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k)
				select k).ToList();
			if (kingdomsToSchedule.Any())
			{
				if (!_statementQueue.ContainsKey(diplomaticEvent.Id))
				{
					_statementQueue[diplomaticEvent.Id] = new Queue<(Kingdom, CampaignTime)>();
				}
				_statementQueue[diplomaticEvent.Id].Clear();
				List<Kingdom> sortedKingdoms = kingdomsToSchedule.OrderByDescending((Kingdom k) => priorityKingdoms != null && priorityKingdoms.Contains(((MBObjectBase)k).StringId)).ToList();
				Random random = new Random();
				int baseIntervalDays = 1 + random.Next(1, GlobalSettings<ModSettings>.Instance.StatementGenerationIntervalDays + 1);
				for (int i = 0; i < sortedKingdoms.Count; i++)
				{
					Kingdom kingdom = sortedKingdoms[i];
					int intervalDays = baseIntervalDays + i;
					CampaignTime nextStatementTime = CampaignTime.DaysFromNow((float)intervalDays);
					_statementQueue[diplomaticEvent.Id].Enqueue((kingdom, nextStatementTime));
					bool isPriority = priorityKingdoms != null && priorityKingdoms.Contains(((MBObjectBase)kingdom).StringId);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Queued statement for {kingdom.Name} in {intervalDays} days (position {i + 1}/{sortedKingdoms.Count}, priority: {isPriority})");
				}
				(Kingdom kingdom, CampaignTime scheduledTime) firstStatement = _statementQueue[diplomaticEvent.Id].Peek();
				_eventStatementSchedule[diplomaticEvent.Id] = firstStatement.scheduledTime;
				_pendingStatements[diplomaticEvent.Id] = firstStatement.kingdom;
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled first statement for {firstStatement.kingdom.Name} in {baseIntervalDays} days. {sortedKingdoms.Count} total kingdoms queued for round {diplomaticEvent.DiplomaticRounds}.");
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] WARNING: No kingdoms to schedule for new round in event " + diplomaticEvent.Id);
			}
			SaveDiplomaticEventsWithSchedules();
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR continuing negotiations: " + ex2.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.ContinueDiplomaticNegotiations", "Failed to continue negotiations for event " + diplomaticEvent.Id, ex2);
		}
	}

	private void ShowDiplomaticActionToPlayer(DiplomaticActionInfo action)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == action.SourceKingdomId));
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == action.TargetKingdomId));
			if (val != null && val2 != null)
			{
				string actionDisplayText = GetActionDisplayText(action.Action);
				string text = $"{actionDisplayText}: {val.Name} → {val2.Name}";
				Color actionColor = GetActionColor(action.Action);
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR showing action to player: " + ex.Message);
		}
	}

	private void ShowEventUpdateToPlayer(DynamicEvent diplomaticEvent, string eventUpdate)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		try
		{
			Color val = default(Color);
			val = new Color(1f, 0.55f, 0f, 1f);
			InformationManager.DisplayMessage(new InformationMessage(eventUpdate, val));
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR showing event update to player: " + ex.Message);
		}
	}

	private void ShowEventCompletionToPlayer(DynamicEvent diplomaticEvent)
	{
		try
		{
			string text = "Diplomatic Event Completed: " + diplomaticEvent.Type;
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR showing event completion to player: " + ex.Message);
		}
	}

	private string GetActionDisplayText(DiplomaticAction action)
	{
		return action switch
		{
			DiplomaticAction.DeclareWar => "War Declared", 
			DiplomaticAction.ProposePeace => "Peace Proposed", 
			DiplomaticAction.AcceptPeace => "Peace Accepted", 
			DiplomaticAction.ProposeAlliance => "Alliance Proposed", 
			DiplomaticAction.AcceptAlliance => "Alliance Formed", 
			DiplomaticAction.BreakAlliance => "Alliance Broken", 
			_ => "Diplomatic Action", 
		};
	}

	private Color GetActionColor(DiplomaticAction action)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		switch (action)
		{
		case DiplomaticAction.DeclareWar:
		case DiplomaticAction.BreakAlliance:
			return ExtraColors.RedAIInfluence;
		case DiplomaticAction.ProposePeace:
		case DiplomaticAction.AcceptPeace:
			return ExtraColors.GreenAIInfluence;
		case DiplomaticAction.ProposeAlliance:
		case DiplomaticAction.AcceptAlliance:
			return Colors.Blue;
		default:
			return Colors.White;
		}
	}

	private void ApplyRelationChange(RelationChangeInfo relationChange)
	{
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == relationChange.Kingdom1Id));
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == relationChange.Kingdom2Id));
			if (val == null || val2 == null)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot apply relation change: kingdom not found (" + relationChange.Kingdom1Id + " or " + relationChange.Kingdom2Id + ")");
				return;
			}
			Hero leader = val.Leader;
			Hero leader2 = val2.Leader;
			if (leader == null || leader2 == null)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot apply relation change: leader not found");
				return;
			}
			int num = Math.Max(GlobalSettings<ModSettings>.Instance.MinKingdomRelationChange, Math.Min(GlobalSettings<ModSettings>.Instance.MaxKingdomRelationChange, relationChange.Change));
			if (num == 0)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Relation change is 0, skipping");
				return;
			}
			int relation = leader.GetRelation(leader2);
			bool flag = true;
			string text = "";
			if (num > 0 && relation >= 100)
			{
				flag = false;
				text = " (already at maximum)";
			}
			else if (num < 0 && relation <= -100)
			{
				flag = false;
				text = " (already at minimum)";
			}
			if (!flag)
			{
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Relation change {num} had no effect - relations stayed at {relation}{text}. Reason: {relationChange.Reason}");
				return;
			}
			ChangeRelationAction.ApplyRelationChangeBetweenHeroes(leader, leader2, num, true);
			int relation2 = leader.GetRelation(leader2);
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Relation changed: {val.Name} ↔ {val2.Name} ({relation} → {relation2}, change: {num})");
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Reason: " + relationChange.Reason);
			if ((object)val == Hero.MainHero.MapFaction || (object)val2 == Hero.MainHero.MapFaction)
			{
				string text2 = ((num > 0) ? "improved" : "worsened");
				Color val3 = ((num > 0) ? ExtraColors.GreenAIInfluence : ExtraColors.RedAIInfluence);
			}
			DiplomacyLogger.Instance.Log($"Relation change: {val.Name} ({relationChange.Kingdom1Id}) ↔ {val2.Name} ({relationChange.Kingdom2Id}): {relation} → {relation2} ({num:+0;-0}) - {relationChange.Reason}");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR applying relation change: " + ex.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.ApplyRelationChange", "Failed to apply relation change between " + relationChange.Kingdom1Id + " and " + relationChange.Kingdom2Id, ex);
		}
	}

	public async Task ProcessPlayerStatement(string playerText)
	{
		try
		{
			DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] ProcessPlayerStatement called with text: " + playerText);
			Hero mainHero = Hero.MainHero;
			object obj;
			if (mainHero == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = mainHero.Clan;
				obj = ((clan != null) ? clan.Kingdom : null);
			}
			Kingdom playerKingdom = (Kingdom)obj;
			if (playerKingdom == null)
			{
				DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Player does not have a kingdom");
				return;
			}
			if (string.IsNullOrWhiteSpace(playerText))
			{
				DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Empty statement text");
				return;
			}
			DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Processing statement from {playerKingdom.Name}: {playerText}");
			DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Calling _playerAnalyzer.AnalyzePlayerStatement");
			PlayerStatementResult analysis = await _playerAnalyzer.AnalyzePlayerStatement(playerText, playerKingdom, _activeDiplomaticEvents);
			DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Analysis returned: {analysis != null}");
			if (analysis == null)
			{
				DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Failed to analyze player statement");
				InformationManager.DisplayMessage(new InformationMessage("Failed to analyze your statement. Please try again.", ExtraColors.RedAIInfluence));
				return;
			}
			DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Analysis complete: Action={analysis.Action}, Targets={analysis.TargetKingdomIds.Count}, Tone={analysis.Tone}");
			if ((analysis.TargetKingdomIds == null || !analysis.TargetKingdomIds.Any()) && analysis.Action != DiplomaticAction.None)
			{
				DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] No valid targets found for action {analysis.Action}");
				InformationManager.DisplayMessage(new InformationMessage("No valid kingdoms found for this diplomatic action.", ExtraColors.RedAIInfluence));
				return;
			}
			Random random = new Random();
			int baseHoursDelay = random.Next(6, 13);
			if (analysis.TargetKingdomIds.Any())
			{
				List<string> validTargetIds = new List<string>();
				foreach (string targetKingdomId in analysis.TargetKingdomIds)
				{
					Kingdom targetKingdom = ((IEnumerable<Kingdom>)analysis.TargetKingdoms).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == targetKingdomId));
					if (targetKingdom != null)
					{
						validTargetIds.Add(targetKingdomId);
					}
					else
					{
						DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Skipping invalid target kingdom: " + targetKingdomId);
					}
				}
				if (validTargetIds.Any())
				{
					int hoursDelay = baseHoursDelay + random.Next(-2, 3);
					hoursDelay = Math.Max(1, hoursDelay);
					CampaignTime publicationTime = CampaignTime.HoursFromNow((float)hoursDelay);
					DelayedPlayerStatement delayedStatement = new DelayedPlayerStatement
					{
						StatementText = playerText,
						Action = analysis.Action,
						Actions = (analysis.Actions ?? new List<DiplomaticAction> { analysis.Action }),
						TargetKingdomIds = validTargetIds,
						Reason = analysis.Reason,
						Tone = analysis.Tone,
						PlayerKingdom = playerKingdom,
						PublicationTime = publicationTime,
				SettlementId = analysis.SettlementId,
					DailyTributeAmount = analysis.DailyTributeAmount,
					TributeDurationDays = analysis.TributeDurationDays,
					ReparationsAmount = analysis.ReparationsAmount,
					TradeAgreementDurationYears = analysis.TradeAgreementDurationYears,
					QuarantineDurationDays = analysis.QuarantineDurationDays,
					TargetClanId = analysis.TargetClanId,
					NewKingdomName = analysis.NewKingdomName,
					NewKingdomInformalName = analysis.NewKingdomInformalName
				};
				_pendingPlayerStatements.Add(delayedStatement);
				DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Added statement with {validTargetIds.Count} targets, delay: {hoursDelay} hours");
					foreach (string targetId in validTargetIds)
					{
						Kingdom targetKingdom2 = ((IEnumerable<Kingdom>)analysis.TargetKingdoms).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == targetId));
						DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO]   - Target: {((targetKingdom2 != null) ? targetKingdom2.Name : null)} ({targetId})");
					}
					_storage.SavePendingPlayerStatements(_pendingPlayerStatements);
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Created 1 statement with {validTargetIds.Count} targets for action {analysis.Action}");
				}
				else
				{
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] No valid targets found for action {analysis.Action}");
					InformationManager.DisplayMessage(new InformationMessage("No valid kingdoms found for this diplomatic action.", ExtraColors.RedAIInfluence));
				}
			}
			else
			{
				int hoursDelay2 = baseHoursDelay;
				CampaignTime publicationTime2 = CampaignTime.HoursFromNow((float)hoursDelay2);
				DelayedPlayerStatement delayedStatement2 = new DelayedPlayerStatement
				{
					StatementText = playerText,
					Action = analysis.Action,
					TargetKingdomIds = new List<string>(),
					Reason = analysis.Reason,
					Tone = analysis.Tone,
					PlayerKingdom = playerKingdom,
					PublicationTime = publicationTime2,
					SettlementId = analysis.SettlementId,
					DailyTributeAmount = analysis.DailyTributeAmount,
					TributeDurationDays = analysis.TributeDurationDays,
					ReparationsAmount = analysis.ReparationsAmount,
					TradeAgreementDurationYears = analysis.TradeAgreementDurationYears,
					QuarantineDurationDays = analysis.QuarantineDurationDays,
					TargetClanId = analysis.TargetClanId,
					NewKingdomName = analysis.NewKingdomName,
					NewKingdomInformalName = analysis.NewKingdomInformalName
				};
				_pendingPlayerStatements.Add(delayedStatement2);
				_storage.SavePendingPlayerStatements(_pendingPlayerStatements);
				DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Statement scheduled for publication in {hoursDelay2} hours");
				DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Added to pending statements: Action={delayedStatement2.Action}, PublicationTime={delayedStatement2.PublicationTime}");
				DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Total pending statements: {_pendingPlayerStatements.Count}");
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] ERROR processing player statement: " + ex2.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.ProcessPlayerStatement", "Failed to process player statement", ex2);
		}
	}

	private void ProcessPendingPlayerStatements()
	{
		List<DelayedPlayerStatement> list = _pendingPlayerStatements.Where((DelayedPlayerStatement s) => CampaignTime.Now >= s.PublicationTime).ToList();
		if (list.Any())
		{
			DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Found {list.Count} statements ready for publication");
		}
		foreach (DelayedPlayerStatement item in list)
		{
			_pendingPlayerStatements.Remove(item);
			PublishPlayerStatement(item);
		}
		if (list.Any())
		{
			_storage.SavePendingPlayerStatements(_pendingPlayerStatements);
		}
	}

	private Color GetVanillaDiplomaticNotificationColorForPlayer(DelayedPlayerStatement statement)
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (statement.PlayerKingdom == null || Clan.PlayerClan == null)
			{
				return Color.White;
			}
			List<Kingdom> list = new List<Kingdom>();
			if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any())
			{
				foreach (string targetKingdomId in statement.TargetKingdomIds)
				{
					MBObjectManager instance = MBObjectManager.Instance;
					Kingdom val = ((instance != null) ? instance.GetObject<Kingdom>(targetKingdomId) : null);
					if (val != null)
					{
						list.Add(val);
					}
				}
			}
			ChatNotificationType val2 = ((Clan.PlayerClan.Kingdom != null) ? ((ChatNotificationType)2) : (((object)statement.PlayerKingdom != Clan.PlayerClan.MapFaction && !list.Any((Kingdom k) => (object)k == Clan.PlayerClan.MapFaction)) ? ((ChatNotificationType)9) : ((ChatNotificationType)1)));
			uint notificationColor = Campaign.Current.Models.DiplomacyModel.GetNotificationColor(val2);
			return Color.FromUint(notificationColor);
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR getting vanilla color: " + ex.Message);
			return Color.White;
		}
	}

	private async Task PublishPlayerStatement(DelayedPlayerStatement statement)
	{
		try
		{
			DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Publishing player statement from {statement.PlayerKingdom.Name}");
			InformationManager.DisplayMessage(new InformationMessage(statement.StatementText ?? "", ExtraColors.KingdomColorMessage));
			_playerKingdomLastStatement[statement.PlayerKingdom] = CampaignTime.Now;
			List<DiplomaticAction> actionsToExecute = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
			List<string> targetKingdomIds = ((statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any()) ? statement.TargetKingdomIds : new List<string>());
			List<string> settlementIds = ((!string.IsNullOrEmpty(statement.SettlementId)) ? (from id in statement.SettlementId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
				select id.Trim()).ToList() : new List<string>());
			int settlementIndex = 0;
			for (int actionIndex = 0; actionIndex < actionsToExecute.Count; actionIndex++)
			{
				DiplomaticAction action = actionsToExecute[actionIndex];
				if (action == DiplomaticAction.None || action == DiplomaticAction.ProposeAlliance || action == DiplomaticAction.ProposePeace)
				{
					continue;
				}
				bool isNoTargetAction = action == DiplomaticAction.QuarantineSettlement || action == DiplomaticAction.ExpelClan || action == DiplomaticAction.FoundKingdom;
				if (!targetKingdomIds.Any() && !isNoTargetAction)
				{
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] No target kingdoms found for action {action}, skipping");
					continue;
				}
				bool isSettlementAction = action == DiplomaticAction.TransferTerritory || action == DiplomaticAction.RejectTerritory || action == DiplomaticAction.DemandTerritory || action == DiplomaticAction.QuarantineSettlement;
				string settlementIdForAction = null;
				if (isSettlementAction && settlementIds.Any())
				{
					settlementIdForAction = ((settlementIndex < settlementIds.Count) ? settlementIds[settlementIndex] : settlementIds[0]);
					settlementIndex++;
				}
				if (!targetKingdomIds.Any() && isNoTargetAction)
				{
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Executing no-target action: {action}");
				DiplomaticActionInfo actionInfo = new DiplomaticActionInfo
				{
					Action = action,
					SourceKingdomId = ((MBObjectBase)statement.PlayerKingdom).StringId,
					TargetClanId = statement.TargetClanId,
					Reason = statement.Reason,
					SettlementId = settlementIdForAction,
					QuarantineDurationDays = statement.QuarantineDurationDays,
					NewKingdomName = statement.NewKingdomName,
					NewKingdomInformalName = statement.NewKingdomInformalName
				};
				ExecuteDiplomaticAction(actionInfo);
				continue;
				}
				if (actionsToExecute.Count == targetKingdomIds.Count)
				{
					string targetKingdomId = targetKingdomIds[actionIndex];
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Executing immediate action: {action} for target: {targetKingdomId}");
					DiplomaticActionInfo actionInfo2 = new DiplomaticActionInfo
					{
						Action = action,
						SourceKingdomId = ((MBObjectBase)statement.PlayerKingdom).StringId,
						TargetKingdomId = targetKingdomId,
						TargetClanId = statement.TargetClanId,
						Reason = statement.Reason,
						SettlementId = settlementIdForAction,
						DailyTributeAmount = statement.DailyTributeAmount,
						TributeDurationDays = statement.TributeDurationDays,
						ReparationsAmount = statement.ReparationsAmount,
						TradeAgreementDurationYears = statement.TradeAgreementDurationYears,
						QuarantineDurationDays = statement.QuarantineDurationDays
					};
					ExecuteDiplomaticAction(actionInfo2);
					continue;
				}
				foreach (string targetKingdomId2 in targetKingdomIds)
				{
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Executing immediate action: {action} for target: {targetKingdomId2}");
					ExecuteDiplomaticAction(new DiplomaticActionInfo
					{
						Action = action,
						SourceKingdomId = ((MBObjectBase)statement.PlayerKingdom).StringId,
						TargetKingdomId = targetKingdomId2,
						TargetClanId = statement.TargetClanId,
						Reason = statement.Reason,
						SettlementId = settlementIdForAction
					});
				}
			}
			DynamicEvent activeEvent = _activeDiplomaticEvents.FirstOrDefault();
			if (activeEvent != null)
			{
				DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Adding statement to existing event " + activeEvent.Id);
				bool wasNewParticipant = false;
				if (!activeEvent.ParticipatingKingdoms.Contains(((MBObjectBase)statement.PlayerKingdom).StringId))
				{
					activeEvent.ParticipatingKingdoms.Add(((MBObjectBase)statement.PlayerKingdom).StringId);
					wasNewParticipant = true;
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Added {statement.PlayerKingdom.Name} as participant in event {activeEvent.Id}");
				}
				KingdomStatement playerStatement = new KingdomStatement
				{
					KingdomId = ((MBObjectBase)statement.PlayerKingdom).StringId,
					StatementText = statement.StatementText,
					Action = statement.Action,
					TargetKingdomId = null,
					TargetKingdomIds = statement.TargetKingdomIds,
					Reason = statement.Reason,
					Timestamp = CampaignTime.Now,
					EventId = activeEvent.Id
				};
				KingdomStatement existingTimeoutPlaceholder = activeEvent.KingdomStatements.Skip(activeEvent.StatementsAtRoundStart).FirstOrDefault((KingdomStatement s) => s.KingdomId == ((MBObjectBase)statement.PlayerKingdom).StringId && s.StatementText == "[No response]");
				List<KingdomStatement> existingPlayerStatements = (from s in activeEvent.KingdomStatements.Skip(activeEvent.StatementsAtRoundStart)
					where s.KingdomId == ((MBObjectBase)statement.PlayerKingdom).StringId && (s.TargetKingdomIds?.SequenceEqual(statement.TargetKingdomIds) ?? false)
					select s).ToList();
				foreach (KingdomStatement existingStatement in existingPlayerStatements)
				{
					if (existingStatement != existingTimeoutPlaceholder)
					{
						DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Removing existing player statement before adding updated one");
						activeEvent.KingdomStatements.Remove(existingStatement);
						DiplomaticStatementsStorage.Instance.RemoveStatement(existingStatement);
					}
				}
				if (existingTimeoutPlaceholder != null)
				{
					DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Removing timeout placeholder before adding real player statement");
					activeEvent.KingdomStatements.Remove(existingTimeoutPlaceholder);
					DiplomaticStatementsStorage.Instance.RemoveStatement(existingTimeoutPlaceholder);
				}
				activeEvent.KingdomStatements.Add(playerStatement);
				DiplomaticStatementsStorage.Instance.AddStatement(playerStatement);
				int expectedStatements = 1 + (statement.TargetKingdomIds?.Count ?? 0);
				int totalStatements = activeEvent.KingdomStatements.Count;
				int statementsInCurrentRound = totalStatements - activeEvent.StatementsAtRoundStart;
				DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Round tracking: Total={totalStatements}, RoundStart={activeEvent.StatementsAtRoundStart}, CurrentRound={statementsInCurrentRound}, Expected={expectedStatements}, NewParticipant={wasNewParticipant}");
				if (statementsInCurrentRound >= expectedStatements && !wasNewParticipant)
				{
					Random random = new Random();
					int daysUntilAnalysis = random.Next(1, 3);
					CampaignTime analysisTime = CampaignTime.DaysFromNow((float)daysUntilAnalysis);
					_eventAnalysisSchedule[activeEvent.Id] = analysisTime;
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] All kingdoms responded. Analysis scheduled in {daysUntilAnalysis} days");
				}
				SaveDiplomaticEventsWithSchedules();
			}
			else if (statement.Action != DiplomaticAction.None)
			{
				DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Creating new diplomatic event");
				await CreateDiplomaticEventFromPlayerStatement(statement);
			}
			else
			{
				DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Statement without action published to world");
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] ERROR publishing player statement: " + ex2.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.PublishPlayerStatement", "Failed to publish player statement", ex2);
		}
	}

	private async Task CreateDiplomaticEventFromPlayerStatement(DelayedPlayerStatement statement)
	{
		try
		{
			DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Creating diplomatic event for player action: {statement.Action}");
			List<string> participants = new List<string> { ((MBObjectBase)statement.PlayerKingdom).StringId };
			if (statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any())
			{
				participants.AddRange(statement.TargetKingdomIds);
			}
			else if (!string.IsNullOrEmpty(statement.TargetKingdomId))
			{
				participants.Add(statement.TargetKingdomId);
			}
			DynamicEvent obj = new DynamicEvent
			{
				Id = Guid.NewGuid().ToString(),
				Type = "diplomatic",
				Description = $"Player diplomatic action: {statement.Action}",
				Importance = 8,
				RequiresDiplomaticAnalysis = true,
				ParticipatingKingdoms = participants,
				KingdomStatements = new List<KingdomStatement>(),
				DiplomaticRounds = 1,
				StatementsAtRoundStart = 0,
				CreationTime = DateTime.Now
			};
			CampaignTime now = CampaignTime.Now;
			obj.CreationCampaignDays = (float)(now).ToDays;
			now = CampaignTime.Now;
			obj.ExpirationCampaignDays = (float)((now).ToDays + (double)GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan);
			obj.ExpirationTime = DateTime.Now.AddDays(GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan);
			obj.ApplicableNPCs = new List<string> { "faction_leaders", "clan_leaders" };
			DynamicEvent diplomaticEvent = obj;
			KingdomStatement playerStatement = new KingdomStatement
			{
				KingdomId = ((MBObjectBase)statement.PlayerKingdom).StringId,
				StatementText = statement.StatementText,
				Action = statement.Action,
				TargetKingdomId = null,
				TargetKingdomIds = statement.TargetKingdomIds,
				Reason = statement.Reason,
				Timestamp = CampaignTime.Now,
				EventId = diplomaticEvent.Id
			};
			diplomaticEvent.KingdomStatements.Add(playerStatement);
			DiplomaticStatementsStorage.Instance.AddStatement(playerStatement);
			List<string> targetNames = statement.TargetKingdomIds.Select(delegate(string id)
			{
				Kingdom? obj3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == id));
				return ((obj3 == null) ? null : ((object)obj3.Name)?.ToString()) ?? id;
			}).ToList();
			diplomaticEvent.AddEventUpdate(string.Concat(str2: (targetNames.Count > 1) ? (string.Join(", ", targetNames.Take(targetNames.Count - 1)) + " and " + targetNames.Last()) : (targetNames.FirstOrDefault() ?? "the realm"), str0: ((object)statement.PlayerKingdom.Name)?.ToString() ?? ((MBObjectBase)statement.PlayerKingdom).StringId, str1: " has made a diplomatic statement regarding "), "Event Created");
			_activeDiplomaticEvents.Add(diplomaticEvent);
			DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Created diplomatic event {diplomaticEvent.Id} with {participants.Count} initial participants");
			DiplomaticAnalysisResult analysisResult = await _eventsAnalyzer.AnalyzeDiplomaticEvent(diplomaticEvent, new List<KingdomStatement>());
			if (analysisResult != null && analysisResult.KingdomsToAdd != null && analysisResult.KingdomsToAdd.Any())
			{
				DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Analyzer suggests adding {analysisResult.KingdomsToAdd.Count} kingdoms");
				int maxKingdoms = GlobalSettings<ModSettings>.Instance?.MaxParticipatingKingdoms ?? 4;
				Hero mainHero = Hero.MainHero;
				object obj2;
				if (mainHero == null)
				{
					obj2 = null;
				}
				else
				{
					Clan clan = mainHero.Clan;
					obj2 = ((clan != null) ? clan.Kingdom : null);
				}
				Kingdom playerKingdom = (Kingdom)obj2;
				string playerKingdomId = ((playerKingdom != null) ? ((MBObjectBase)playerKingdom).StringId : null);
				int nonPlayerKingdomsCount = diplomaticEvent.ParticipatingKingdoms.Count((string k) => k != playerKingdomId);
				foreach (string kingdomId in analysisResult.KingdomsToAdd)
				{
					if (kingdomId != playerKingdomId && nonPlayerKingdomsCount >= maxKingdoms)
					{
						DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Maximum participating kingdoms limit reached ({maxKingdoms}, excluding player). Cannot add more kingdoms.");
						break;
					}
					if (!diplomaticEvent.ParticipatingKingdoms.Contains(kingdomId))
					{
						diplomaticEvent.ParticipatingKingdoms.Add(kingdomId);
						Kingdom kingdom = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kingdomId));
						string kingdomName = ((kingdom != null) ? ((object)kingdom.Name).ToString() : null) ?? kingdomId;
						DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Added kingdom: " + kingdomName + " (" + kingdomId + ")");
						if (kingdomId != playerKingdomId)
						{
							nonPlayerKingdomsCount++;
						}
					}
				}
			}
			if (analysisResult != null && analysisResult.ApplicableNPCs != null && analysisResult.ApplicableNPCs.Any())
			{
				diplomaticEvent.ApplicableNPCs = new List<string>(analysisResult.ApplicableNPCs);
				DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] Updated applicable NPCs: " + string.Join(", ", diplomaticEvent.ApplicableNPCs));
			}
			diplomaticEvent.StatementsAtRoundStart = 0;
			int totalParticipants = diplomaticEvent.ParticipatingKingdoms.Count;
			if (totalParticipants > 1)
			{
				Random random = new Random();
				int daysUntilResponse = random.Next(1, GlobalSettings<ModSettings>.Instance.StatementGenerationIntervalDays + 1);
				CampaignTime responseTime = CampaignTime.DaysFromNow((float)daysUntilResponse);
				Kingdom firstNPCKingdom = (from kid in diplomaticEvent.ParticipatingKingdoms
					select ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kid)) into k
					where k != null && !DiplomacyManagerHelpers.IsPlayerKingdom(k)
					select k).FirstOrDefault();
				if (firstNPCKingdom != null)
				{
					ScheduleNextStatement(diplomaticEvent.Id, firstNPCKingdom, responseTime);
					DiplomacyLogger.Instance.Log($"[PLAYER_DIPLO] Scheduled first NPC response from {firstNPCKingdom.Name} in {daysUntilResponse} days");
				}
			}
			SaveDiplomaticEventsWithSchedules();
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			DiplomacyLogger.Instance.Log("[PLAYER_DIPLO] ERROR creating diplomatic event from player statement: " + ex2.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyManager.CreateDiplomaticEventFromPlayerStatement", "Failed to create diplomatic event", ex2);
		}
	}

	private void CheckPlayerKingdomTimeouts()
	{
	}

	private void RestoreEventSchedules()
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Restoring schedules for loaded diplomatic events...");
		foreach (DynamicEvent activeDiplomaticEvent in _activeDiplomaticEvents)
		{
			if (activeDiplomaticEvent.ParticipatingKingdoms == null || !activeDiplomaticEvent.ParticipatingKingdoms.Any())
			{
				continue;
			}
			List<Kingdom> participatingKingdoms = GetParticipatingKingdoms(activeDiplomaticEvent);
			int num = participatingKingdoms.Count((Kingdom k) => !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(k));
			int num2 = activeDiplomaticEvent.KingdomStatements?.Count ?? 0;
			int num3 = num2 - activeDiplomaticEvent.StatementsAtRoundStart;
			if (num2 == 0)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Event " + activeDiplomaticEvent.Id + " has no statements yet - scheduling initial generation");
				CampaignTime value = CampaignTime.HoursFromNow(1f);
				_eventStatementSchedule[activeDiplomaticEvent.Id] = value;
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Scheduled initial statement generation for event " + activeDiplomaticEvent.Id + " in 1 hour");
				continue;
			}
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Event {activeDiplomaticEvent.Id}: Round={activeDiplomaticEvent.DiplomaticRounds}, Total Kingdoms={num} (excluding {participatingKingdoms.Count - num} imprisoned leaders), Current Statements={num3}");
			bool flag = num3 >= num;
			bool flag2 = _eventStatementSchedule.ContainsKey(activeDiplomaticEvent.Id);
			bool flag3 = _statementQueue.ContainsKey(activeDiplomaticEvent.Id) && _statementQueue[activeDiplomaticEvent.Id].Count > 0;
			bool flag4 = _eventAnalysisSchedule.ContainsKey(activeDiplomaticEvent.Id);
			if (flag2 || flag3)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Event " + activeDiplomaticEvent.Id + " already has restored schedules/queues, skipping recreation");
			}
			else if (num3 < num && !flag)
			{
				HashSet<string> respondedKingdoms = (from s in activeDiplomaticEvent.KingdomStatements.Skip(activeDiplomaticEvent.StatementsAtRoundStart)
					select s.KingdomId).ToHashSet();
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Responded kingdoms in current round: " + string.Join(", ", respondedKingdoms));
				foreach (string kid in activeDiplomaticEvent.ParticipatingKingdoms)
				{
					Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom kingdom) => ((MBObjectBase)kingdom).StringId == kid));
					if (val != null)
					{
						bool flag5 = DiplomacyManagerHelpers.IsPlayerKingdom(val);
						bool flag6 = DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(val);
						bool flag7 = respondedKingdoms.Contains(kid);
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR]   Kingdom {val.Name} ({kid}): IsPlayer={flag5}, LeaderPrisoner={flag6}, AlreadyResponded={flag7}");
					}
				}
				List<Kingdom> list = (from text in activeDiplomaticEvent.ParticipatingKingdoms.Where(delegate(string text)
					{
						Kingdom val4 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom kingdom) => ((MBObjectBase)kingdom).StringId == text));
						return val4 != null && !DiplomacyManagerHelpers.IsPlayerKingdom(val4) && !DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(val4) && !respondedKingdoms.Contains(text);
					})
					select ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == text)) into k
					where k != null
					select k).ToList();
				if (list.Any())
				{
					if (!_statementQueue.ContainsKey(activeDiplomaticEvent.Id))
					{
						_statementQueue[activeDiplomaticEvent.Id] = new Queue<(Kingdom, CampaignTime)>();
					}
					_statementQueue[activeDiplomaticEvent.Id].Clear();
					Random random = new Random();
					for (int num4 = 0; num4 < list.Count; num4++)
					{
						Kingdom val2 = list[num4];
						int num5 = random.Next(1, 7) + num4;
						CampaignTime item = CampaignTime.HoursFromNow((float)num5);
						_statementQueue[activeDiplomaticEvent.Id].Enqueue((val2, item));
						DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Queued statement for {val2.Name} in {num5} hours (position {num4 + 1}/{list.Count})");
					}
					(Kingdom, CampaignTime) tuple = _statementQueue[activeDiplomaticEvent.Id].Peek();
					_eventStatementSchedule[activeDiplomaticEvent.Id] = tuple.Item2;
					_pendingStatements[activeDiplomaticEvent.Id] = tuple.Item1;
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled first statement for {tuple.Item1.Name} in {random.Next(1, 7)} hours. {list.Count} total kingdoms queued.");
				}
				else
				{
					DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] WARNING: Could not find any kingdoms to schedule for event " + activeDiplomaticEvent.Id);
				}
			}
			else if (flag)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] allActiveKingdomsResponded=true for event " + activeDiplomaticEvent.Id);
				foreach (string kid2 in activeDiplomaticEvent.ParticipatingKingdoms)
				{
					Kingdom val3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom kingdom) => ((MBObjectBase)kingdom).StringId == kid2));
					if (val3 != null)
					{
						bool flag8 = DiplomacyManagerHelpers.IsPlayerKingdom(val3);
						bool flag9 = DiplomacyManagerHelpers.IsLeaderPrisonerOfPlayer(val3);
						DiplomacyLogger instance = DiplomacyLogger.Instance;
						object[] obj = new object[5] { val3.Name, kid2, flag8, flag9, null };
						Hero leader = val3.Leader;
						obj[4] = ((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "NULL";
						instance.Log(string.Format("[DIPLOMACY_MGR]   Kingdom {0} ({1}): IsPlayer={2}, LeaderPrisoner={3}, Leader={4}", obj));
					}
				}
				if (!flag4 && !_eventAnalysisSchedule.ContainsKey(activeDiplomaticEvent.Id))
				{
					Random random2 = new Random();
					int num6 = random2.Next(1, 3);
					CampaignTime value2 = CampaignTime.DaysFromNow((float)num6);
					_eventAnalysisSchedule[activeDiplomaticEvent.Id] = value2;
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] All active kingdoms already responded, scheduled analysis for event {activeDiplomaticEvent.Id} in {num6} days");
				}
			}
			else if (!flag4 && !_eventAnalysisSchedule.ContainsKey(activeDiplomaticEvent.Id))
			{
				Random random3 = new Random();
				int num7 = random3.Next(1, 4);
				CampaignTime value3 = CampaignTime.DaysFromNow((float)num7);
				_eventAnalysisSchedule[activeDiplomaticEvent.Id] = value3;
				DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Scheduled analysis for event {activeDiplomaticEvent.Id} in {num7} days");
			}
		}
		DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Schedule restoration complete. Statements scheduled: {_eventStatementSchedule.Count}, Analyses scheduled: {_eventAnalysisSchedule.Count}");
	}

	private void SaveDiplomaticEventsWithSchedules(List<DynamicEvent> events = null)
	{
		List<DynamicEvent> diplomaticEvents = events ?? _activeDiplomaticEvents;
		_storage.SaveDiplomaticEvents(diplomaticEvents, _eventStatementSchedule, _eventAnalysisSchedule, _statementQueue, _pendingStatements);
	}

	private void RestoreDiplomaticEventsFromDynamicEvents()
	{
		try
		{
			DynamicEventsManager instance = DynamicEventsManager.Instance;
			if (instance == null)
			{
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Cannot restore diplomatic events: DynamicEventsManager is null");
				return;
			}
			List<DynamicEvent> source = instance.GetAllEvents() ?? new List<DynamicEvent>();
			List<DynamicEvent> list = (from e in source
				where e.AllowsDiplomaticResponse && e.RequiresDiplomaticAnalysis && !e.IsExpired()
				where !_activeDiplomaticEvents.Any((DynamicEvent d) => d.Id == e.Id)
				select e).ToList();
			if (!list.Any())
			{
				return;
			}
			DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Restoring {list.Count} diplomatic event(s) from dynamic events storage");
			foreach (DynamicEvent item in list)
			{
				_activeDiplomaticEvents.Add(item);
				DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] Restored diplomatic event: " + item.Id);
				List<KingdomStatement> statementsByEventId = DiplomaticStatementsStorage.Instance.GetStatementsByEventId(item.Id);
				if (statementsByEventId != null && statementsByEventId.Any())
				{
					item.KingdomStatements.Clear();
					item.KingdomStatements.AddRange(statementsByEventId);
					DiplomacyLogger.Instance.Log($"[DIPLOMACY_MGR] Restored {statementsByEventId.Count} statements for event {item.Id}");
				}
			}
			SaveDiplomaticEventsWithSchedules();
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLOMACY_MGR] ERROR restoring diplomatic events from dynamic events: " + ex.Message);
		}
	}

	private void LogMessage(string message)
	{
		DiplomacyLogger.Instance.Log(message);
	}
}
