using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AIInfluence.Diplomacy;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class WorldInfoManager
{
	private class BattleInitialData
	{
		public int AttackerInitial { get; set; }

		public int DefenderInitial { get; set; }

		public HashSet<string> AttackerHeroIds { get; set; } = new HashSet<string>();

		public HashSet<string> DefenderHeroIds { get; set; } = new HashSet<string>();

		public List<Hero> AttackerHeroes { get; set; } = new List<Hero>();

		public List<Hero> DefenderHeroes { get; set; } = new List<Hero>();
	}

	private class EventProcessingTask
	{
		public string EventType { get; set; }

		public CampaignEvent BaseEvent { get; set; }

		public Settlement Location { get; set; }

		public Hero Participant { get; set; }

		public List<string> PendingNpcIds { get; set; }

		public bool DeferSave { get; set; }

		public object ExtraData { get; set; }

		public bool IsCompleted => PendingNpcIds == null || PendingNpcIds.Count == 0;

		public EventProcessingTask(string type, CampaignEvent ev, Settlement loc, Hero part, List<string> npcs, bool defer = false, object extra = null)
		{
			EventType = type;
			BaseEvent = ev;
			Location = loc;
			Participant = part;
			PendingNpcIds = npcs;
			DeferSave = defer;
			ExtraData = extra;
		}
	}

	private class PerformanceProfiler
	{
		private readonly Dictionary<string, (double totalMs, int callCount, int itemCount)> _timings = new Dictionary<string, (double, int, int)>();

		private readonly Dictionary<string, Stopwatch> _activeTimers = new Dictionary<string, Stopwatch>();

		private readonly string _logFilePath;

		public PerformanceProfiler()
		{
			try
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
				string text = Path.Combine(fullName, "logs");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				_logFilePath = Path.Combine(text, "mod_log.txt");
			}
			catch
			{
				_logFilePath = null;
			}
		}

		public void Start(string methodName)
		{
			if (_activeTimers.ContainsKey(methodName))
			{
				Stop(methodName);
			}
			Stopwatch value = Stopwatch.StartNew();
			_activeTimers[methodName] = value;
		}

		public void Stop(string methodName, int itemCount = 0)
		{
			if (_activeTimers.TryGetValue(methodName, out var value))
			{
				value.Stop();
				double totalMilliseconds = value.Elapsed.TotalMilliseconds;
				if (_timings.ContainsKey(methodName))
				{
					(double, int, int) tuple = _timings[methodName];
					int item = Math.Max(tuple.Item3, itemCount);
					_timings[methodName] = (tuple.Item1 + totalMilliseconds, tuple.Item2 + 1, item);
				}
				else
				{
					_timings[methodName] = (totalMilliseconds, 1, itemCount);
				}
				_activeTimers.Remove(methodName);
			}
		}

		public void LogResults()
		{
			if (_logFilePath == null || _timings.Count == 0)
			{
				return;
			}
			try
			{
				List<string> list = new List<string>();
				list.Add($"[{DateTime.Now:HH:mm:ss}] WorldInfoManager.OnDailyTick Performance Profile");
				list.Add("=".PadRight(80, '='));
				double num = (_timings.ContainsKey("OnDailyTick") ? _timings["OnDailyTick"].totalMs : 0.0);
				list.Add($"Total OnDailyTick time: {num:F2} ms");
				List<KeyValuePair<string, (double, int, int)>> list2 = (from kvp in _timings
					where kvp.Key != "OnDailyTick"
					orderby kvp.Value.totalMs descending
					select kvp).ToList();
				list.Add("");
				list.Add("Top methods (WorldInfoManager.OnDailyTick):");
				foreach (KeyValuePair<string, (double, int, int)> item4 in list2)
				{
					double item = item4.Value.Item1;
					int item2 = item4.Value.Item2;
					int item3 = item4.Value.Item3;
					double num2 = ((item2 > 0) ? (item / (double)item2) : 0.0);
					double num3 = ((num > 0.0) ? (item / num * 100.0) : 0.0);
					string text = "";
					if (item3 > 0)
					{
						double num4 = ((item3 > 0) ? (item / (double)item3) : 0.0);
						text = $" ({item3} items processed, avg: {num4:F2} ms/item)";
					}
					else if (item2 > 1)
					{
						text = $" ({item2} calls, avg: {num2:F2} ms/call)";
					}
					list.Add($"  - {item4.Key} = {item:F2} ms ({num3:F1}%){text}");
				}
				list.Add("");
				list.Add("");
				File.AppendAllText(_logFilePath, string.Join(Environment.NewLine, list) + Environment.NewLine);
			}
			catch (Exception ex)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to write performance profile: " + ex.Message);
			}
		}
	}

	public class WorldSecretsManager
	{
		private static readonly WorldSecretsManager _instance = new WorldSecretsManager();

		private List<WorldSecret> _secrets;

		private readonly Random _random = new Random();

		private DateTime _lastFileModified;

		private string _secretsFilePath;

		public static WorldSecretsManager Instance => _instance;

		private WorldSecretsManager()
		{
			LoadSecrets();
		}

		private void LoadSecrets()
		{
			try
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
				_secretsFilePath = Path.Combine(fullName, "world_secrets.json");
				AIInfluenceBehavior.Instance?.LogMessage("[SECRETS] Attempting to load secrets from: " + _secretsFilePath);
				if (File.Exists(_secretsFilePath))
				{
					string text = File.ReadAllText(_secretsFilePath);
					AIInfluenceBehavior.Instance?.LogMessage($"[SECRETS] JSON loaded, length: {text.Length} characters");
					_secrets = JsonConvert.DeserializeObject<List<WorldSecret>>(text);
					if (_secrets != null && _secrets.Any())
					{
						_lastFileModified = File.GetLastWriteTime(_secretsFilePath);
						foreach (WorldSecret secret in _secrets)
						{
							AIInfluenceBehavior.Instance?.LogMessage(string.Format("[SECRETS] Loaded secret '{0}': knowledgeChance={1}, applicableNPCs={2}", secret.Id, secret.KnowledgeChance, string.Join(",", secret.ApplicableNPCs ?? new List<string>())));
						}
						AIInfluenceBehavior.Instance?.LogMessage($"[NPC] Successfully loaded {_secrets.Count} secrets from world_secrets.json");
					}
					else
					{
						_secrets = new List<WorldSecret>();
						AIInfluenceBehavior.Instance?.LogMessage("[SECRETS] ERROR: Deserialization returned null or empty list!");
					}
				}
				else
				{
					_secrets = new List<WorldSecret>();
					_lastFileModified = DateTime.MinValue;
					AIInfluenceBehavior.Instance?.LogMessage("[SECRETS] ERROR: world_secrets.json not found at " + _secretsFilePath);
				}
			}
			catch (Exception ex)
			{
				_secrets = new List<WorldSecret>();
				_lastFileModified = DateTime.MinValue;
				AIInfluenceBehavior.Instance?.LogMessage("[SECRETS] CRITICAL ERROR loading world_secrets.json: " + ex.Message);
				AIInfluenceBehavior.Instance?.LogMessage("[SECRETS] Stack trace: " + ex.StackTrace);
			}
		}

		public List<WorldSecret> GetSecrets()
		{
			if (File.Exists(_secretsFilePath))
			{
				DateTime lastWriteTime = File.GetLastWriteTime(_secretsFilePath);
				if (lastWriteTime > _lastFileModified)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] world_secrets.json modified, reloading...");
					LoadSecrets();
				}
			}
			return _secrets;
		}

		public void CheckSecretKnowledge(Hero npc, NPCContext context)
		{
			if (npc == null || context == null)
			{
				return;
			}
			foreach (WorldSecret secret in _secrets)
			{
				if (!context.KnownSecrets.Contains(secret.Id) && IsApplicableNPC(npc, secret.ApplicableNPCs))
				{
					int num = _random.Next(0, 101);
					if (num <= secret.KnowledgeChance)
					{
						context.KnownSecrets.Add(secret.Id);
						AIInfluenceBehavior.Instance?.LogMessage($"[NPC] {npc.Name} learned secret: {secret.Id} (roll: {num} <= {secret.KnowledgeChance})");
					}
					else
					{
						AIInfluenceBehavior.Instance?.LogMessage($"[NPC] {npc.Name} did not learn secret: {secret.Id} (roll: {num} > {secret.KnowledgeChance})");
					}
				}
			}
		}

		private bool IsApplicableNPC(Hero npc, List<string> applicableNPCs)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Invalid comparison between Unknown and I4
			if (applicableNPCs.Contains("all"))
			{
				return true;
			}
			if (applicableNPCs.Contains("lords") && (int)npc.Occupation == 3)
			{
				return true;
			}
			if (applicableNPCs.Contains("companions") && npc.IsWanderer)
			{
				return true;
			}
			if (applicableNPCs.Contains("faction_leaders"))
			{
				Clan clan = npc.Clan;
				object obj;
				if (clan == null)
				{
					obj = null;
				}
				else
				{
					IFaction mapFaction = clan.MapFaction;
					obj = ((mapFaction != null) ? mapFaction.Leader : null);
				}
				if (npc == obj)
				{
					return true;
				}
			}
			if (applicableNPCs.Contains("village_notables") && npc.IsNotable)
			{
				Settlement currentSettlement = npc.CurrentSettlement;
				if (currentSettlement != null && currentSettlement.IsVillage)
				{
					return true;
				}
			}
			if (applicableNPCs.Contains("merchants") && npc.IsMerchant)
			{
				return true;
			}
			return false;
		}
	}

	public class InformationManager
	{
		private static readonly InformationManager _instance = new InformationManager();

		private List<Information> _infos;

		private readonly Random _random = new Random();

		private DateTime _lastFileModified;

		private string _infoFilePath;

		public static InformationManager Instance => _instance;

		private InformationManager()
		{
			LoadInfo();
		}

		private void LoadInfo()
		{
			try
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
				_infoFilePath = Path.Combine(fullName, "world_info.json");
				AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Attempting to load info from: " + _infoFilePath);
				if (File.Exists(_infoFilePath))
				{
					string text = File.ReadAllText(_infoFilePath);
					_infos = JsonConvert.DeserializeObject<List<Information>>(text);
					_lastFileModified = File.GetLastWriteTime(_infoFilePath);
					ModSettings instance = GlobalSettings<ModSettings>.Instance;
					if (instance != null && instance.EnableDetailedInfoLogging)
					{
						AIInfluenceBehavior.Instance?.LogMessage(string.Format("[INFO] Loaded {0} info entries from world_info.json: {1}", _infos.Count, string.Join(", ", _infos.Select((Information i) => i.Id + " (category: " + i.Category + ")"))));
					}
				}
				else
				{
					_infos = new List<Information>();
					_lastFileModified = DateTime.MinValue;
					ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
					if (instance2 != null && instance2.EnableDetailedInfoLogging)
					{
						AIInfluenceBehavior.Instance?.LogMessage("[INFO] world_info.json not found at " + _infoFilePath + ", using empty info list");
					}
				}
			}
			catch (Exception ex)
			{
				_infos = new List<Information>();
				_lastFileModified = DateTime.MinValue;
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to load world_info.json: " + ex.Message);
			}
		}

		public List<Information> GetInfo()
		{
			if (File.Exists(_infoFilePath))
			{
				DateTime lastWriteTime = File.GetLastWriteTime(_infoFilePath);
				if (lastWriteTime > _lastFileModified)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] world_info.json modified, reloading...");
					LoadInfo();
				}
			}
			return _infos;
		}

		public void CheckInfoKnowledge(Hero npc, NPCContext context)
		{
			if (npc == null || context == null)
			{
				return;
			}
			bool flag = GlobalSettings<ModSettings>.Instance?.EnableDetailedInfoLogging ?? false;
			foreach (Information info in _infos)
			{
				if (context.KnownInfo.Contains(info.Id) || !IsApplicableNPC(npc, info.ApplicableNPCs))
				{
					continue;
				}
				int num = _random.Next(0, 101);
				if (num <= info.UsageChance)
				{
					context.KnownInfo.Add(info.Id);
					if (flag)
					{
						AIInfluenceBehavior.Instance?.LogMessage($"[INFO] {npc.Name} learned info: {info.Id} (roll: {num} <= {info.UsageChance})");
					}
				}
				else if (flag)
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[INFO] {npc.Name} did not learn info: {info.Id} (roll: {num} > {info.UsageChance})");
				}
			}
		}

		private bool IsApplicableNPC(Hero npc, List<string> applicableNPCs)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Invalid comparison between Unknown and I4
			if (applicableNPCs.Contains("all"))
			{
				return true;
			}
			if (applicableNPCs.Contains("lords") && (int)npc.Occupation == 3)
			{
				return true;
			}
			if (applicableNPCs.Contains("companions") && npc.IsWanderer)
			{
				return true;
			}
			if (applicableNPCs.Contains("faction_leaders"))
			{
				Clan clan = npc.Clan;
				object obj;
				if (clan == null)
				{
					obj = null;
				}
				else
				{
					IFaction mapFaction = clan.MapFaction;
					obj = ((mapFaction != null) ? mapFaction.Leader : null);
				}
				if (npc == obj)
				{
					return true;
				}
			}
			if (applicableNPCs.Contains("village_notables") && npc.IsNotable)
			{
				Settlement currentSettlement = npc.CurrentSettlement;
				if (currentSettlement != null && currentSettlement.IsVillage)
				{
					return true;
				}
			}
			if (applicableNPCs.Contains("merchants") && npc.IsMerchant)
			{
				return true;
			}
			return false;
		}
	}

	public class DeathRecord
	{
		public Hero Victim { get; set; }

		public Hero Killer { get; set; }

		public KillCharacterActionDetail DeathDetail { get; set; }

		public CampaignTime DeathTime { get; set; }

		public string DeathCause { get; set; }

		public string KillerName { get; set; }

		public string KillerStringId { get; set; }
	}

	public class MarriageRecord
	{
		public Hero Husband { get; set; }

		public Hero Wife { get; set; }

		public CampaignTime MarriageTime { get; set; }

		public string PoliticalSignificance { get; set; }
	}

	private static WorldInfoManager _instance;

	private readonly string _worldFilePath;

	private string _cachedWorldInfo;

	private DateTime _worldFileLastModified;

	private readonly string _playerDescriptionFilePath;

	private string _cachedPlayerDescription;

	private DateTime _playerDescriptionLastModified;

	private readonly string _actionRulesFilePath;

	private string _cachedActionRules;

	private DateTime _actionRulesLastModified;

	private readonly string _kingdomStatementRulesFilePath;

	private string _cachedKingdomStatementRules;

	private DateTime _kingdomStatementRulesLastModified;

	private readonly string _eventsAnalyzerRulesFilePath;

	private string _cachedEventsAnalyzerRules;

	private DateTime _eventsAnalyzerRulesLastModified;

	private readonly string _eventsGeneratorRulesFilePath;

	private string _cachedEventsGeneratorRules;

	private DateTime _eventsGeneratorRulesLastModified;

	private readonly string player = "(player involved)";

	private readonly Dictionary<MapEvent, BattleInitialData> _battleInitialData = new Dictionary<MapEvent, BattleInitialData>();

	private readonly Dictionary<string, (HashSet<string> participantIds, CampaignTime battleEndTime)> _recentBattleParticipantsByCapturer = new Dictionary<string, (HashSet<string>, CampaignTime)>();

	private readonly List<DeathRecord> _recentDeaths = new List<DeathRecord>();

	private readonly List<MarriageRecord> _recentMarriages = new List<MarriageRecord>();

	private string _cachedWarStatus;

	private CampaignTime _lastWarStatusUpdate = CampaignTime.Never;

	private Queue<string> _dailyTickQueue = new Queue<string>();

	private const int BATCH_SIZE_PER_TICK = 5;

	private Queue<EventProcessingTask> _pendingEventTasks = new Queue<EventProcessingTask>();

	private const int EVENT_NPC_BATCH_SIZE = 15;

	public static WorldInfoManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new WorldInfoManager();
			}
			return _instance;
		}
	}

	private WorldInfoManager()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_worldFilePath = Path.Combine(fullName, "world.txt");
		_cachedWorldInfo = null;
		_worldFileLastModified = DateTime.MinValue;
		_playerDescriptionFilePath = Path.Combine(fullName, "playerdescription.txt");
		_cachedPlayerDescription = null;
		_playerDescriptionLastModified = DateTime.MinValue;
		_actionRulesFilePath = Path.Combine(fullName, "actionrules.txt");
		_cachedActionRules = null;
		_actionRulesLastModified = DateTime.MinValue;
		_kingdomStatementRulesFilePath = Path.Combine(fullName, "kingdomstatementrules.txt");
		_cachedKingdomStatementRules = null;
		_kingdomStatementRulesLastModified = DateTime.MinValue;
		_eventsAnalyzerRulesFilePath = Path.Combine(fullName, "eventsanalyzerrules.txt");
		_cachedEventsAnalyzerRules = null;
		_eventsAnalyzerRulesLastModified = DateTime.MinValue;
		_eventsGeneratorRulesFilePath = Path.Combine(fullName, "eventsgeneratorrules.txt");
		_cachedEventsGeneratorRules = null;
		_eventsGeneratorRulesLastModified = DateTime.MinValue;
		AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] WorldInfoManager initialized.");
	}

	public void RegisterEvents()
	{
		CampaignEvents.WarDeclared.AddNonSerializedListener((object)this, (Action<IFaction, IFaction, DeclareWarDetail>)OnWarDeclared);
		CampaignEvents.TournamentFinished.AddNonSerializedListener((object)this, (Action<CharacterObject, MBReadOnlyList<CharacterObject>, Town, ItemObject>)OnTournamentFinished);
		CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener((object)this, (Action<Settlement, bool, Hero, Hero, Hero, ChangeOwnerOfSettlementDetail>)OnSettlementOwnerChanged);
		CampaignEvents.KingdomDecisionConcluded.AddNonSerializedListener((object)this, (Action<KingdomDecision, DecisionOutcome, bool>)OnKingdomDecisionConcluded);
		CampaignEvents.DailyTickEvent.AddNonSerializedListener((object)this, (Action)OnDailyTick);
		CampaignEvents.HourlyTickEvent.AddNonSerializedListener((object)this, (Action)OnHourlyTick);
		CampaignEvents.MapEventStarted.AddNonSerializedListener((object)this, (Action<MapEvent, PartyBase, PartyBase>)OnBattleStarted);
		CampaignEvents.MapEventEnded.AddNonSerializedListener((object)this, (Action<MapEvent>)OnBattleEnded);
		CampaignEvents.OnPartyAddedToMapEventEvent.AddNonSerializedListener((object)this, (Action<PartyBase>)OnPartyAddedToMapEvent);
		CampaignEvents.HeroKilledEvent.AddNonSerializedListener((object)this, (Action<Hero, Hero, KillCharacterActionDetail, bool>)OnHeroKilled);
		RegisterMarriageEvent();
		AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] WorldInfoManager events registered.");
	}

	private void OnPartyAddedToMapEvent(PartyBase party)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Invalid comparison between Unknown and I4
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Invalid comparison between Unknown and I4
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		if (party == null)
		{
			return;
		}
		MobileParty mobileParty = party.MobileParty;
		MapEvent mapEvent = party.MapEvent;
		if (mapEvent == null || mobileParty == null || !_battleInitialData.TryGetValue(mapEvent, out var value))
		{
			return;
		}
		BattleSideEnum side = party.Side;
		HashSet<string> hashSet = (((int)side == 1) ? value.AttackerHeroIds : value.DefenderHeroIds);
		List<Hero> list = (((int)side == 1) ? value.AttackerHeroes : value.DefenderHeroes);
		if (mobileParty.LeaderHero != null && hashSet.Add(((MBObjectBase)mobileParty.LeaderHero).StringId))
		{
			list.Add(mobileParty.LeaderHero);
		}
		if (mobileParty.MemberRoster != null)
		{
			foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)mobileParty.MemberRoster.GetTroopRoster())
			{
				if (item.Character != null && ((BasicCharacterObject)item.Character).IsHero && item.Character.HeroObject != null && hashSet.Add(((MBObjectBase)item.Character.HeroObject).StringId))
				{
					list.Add(item.Character.HeroObject);
				}
			}
		}
		if (mobileParty.MemberRoster != null)
		{
			if ((int)side == 1)
			{
				value.AttackerInitial += mobileParty.MemberRoster.TotalManCount;
			}
			else
			{
				value.DefenderInitial += mobileParty.MemberRoster.TotalManCount;
			}
		}
	}

	private void RegisterMarriageEvent()
	{
		try
		{
			PropertyInfo property = typeof(CampaignEvents).GetProperty("BeforeHeroesMarried", BindingFlags.Static | BindingFlags.Public);
			if (property != null)
			{
				object value = property.GetValue(null);
				MethodInfo methodInfo = value?.GetType().GetMethod("AddNonSerializedListener");
				if (methodInfo != null)
				{
					Type typeFromHandle = typeof(Action<Hero, Hero, bool>);
					Delegate obj = Delegate.CreateDelegate(typeFromHandle, this, "OnMarriageAccepted");
					methodInfo.Invoke(value, new object[2] { this, obj });
					AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Registered BeforeHeroesMarried event");
				}
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to register BeforeHeroesMarried event: " + ex.Message);
		}
	}

	public string ReadWorldInfo()
	{
		try
		{
			if (File.Exists(_worldFilePath))
			{
				DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(_worldFilePath);
				if (_cachedWorldInfo != null && lastWriteTimeUtc <= _worldFileLastModified)
				{
					return _cachedWorldInfo;
				}
				string text = File.ReadAllText(_worldFilePath).Trim();
				if (!string.IsNullOrEmpty(text))
				{
					_cachedWorldInfo = text;
					_worldFileLastModified = lastWriteTimeUtc;
					return text;
				}
				AIInfluenceBehavior.Instance?.LogMessage("[WARNING] File " + _worldFilePath + " is empty. Using default world: Calradia.");
				_cachedWorldInfo = "Calradia";
				_worldFileLastModified = lastWriteTimeUtc;
				return "Calradia";
			}
			if (_cachedWorldInfo != null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] File " + _worldFilePath + " not found. Using cached world: " + _cachedWorldInfo);
				return _cachedWorldInfo;
			}
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] File " + _worldFilePath + " not found. Using default world: Calradia.");
			_cachedWorldInfo = "Calradia";
			_worldFileLastModified = DateTime.MinValue;
			return "Calradia";
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to read world info from " + _worldFilePath + ": " + ex.Message + ". Using cached or default world: Calradia.");
			return _cachedWorldInfo ?? "Calradia";
		}
	}

	public string ReadPlayerDescription()
	{
		try
		{
			if (File.Exists(_playerDescriptionFilePath))
			{
				DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(_playerDescriptionFilePath);
				if (_cachedPlayerDescription != null && lastWriteTimeUtc <= _playerDescriptionLastModified)
				{
					return _cachedPlayerDescription;
				}
				string text = File.ReadAllText(_playerDescriptionFilePath).Trim();
				if (!string.IsNullOrEmpty(text))
				{
					_cachedPlayerDescription = text;
					_playerDescriptionLastModified = lastWriteTimeUtc;
					return text;
				}
				_cachedPlayerDescription = null;
				_playerDescriptionLastModified = lastWriteTimeUtc;
				return null;
			}
			return null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to read player description from " + _playerDescriptionFilePath + ": " + ex.Message + ".");
			return null;
		}
	}

	public string ReadActionRules()
	{
		try
		{
			if (File.Exists(_actionRulesFilePath))
			{
				DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(_actionRulesFilePath);
				if (_cachedActionRules != null && lastWriteTimeUtc <= _actionRulesLastModified)
				{
					return _cachedActionRules;
				}
				string text = File.ReadAllText(_actionRulesFilePath).Trim();
				if (!string.IsNullOrEmpty(text))
				{
					_cachedActionRules = text;
					_actionRulesLastModified = lastWriteTimeUtc;
					return text;
				}
				_cachedActionRules = null;
				_actionRulesLastModified = lastWriteTimeUtc;
				return null;
			}
			return null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to read action rules from " + _actionRulesFilePath + ": " + ex.Message + ".");
			return null;
		}
	}

	public string ReadKingdomStatementRules()
	{
		try
		{
			if (File.Exists(_kingdomStatementRulesFilePath))
			{
				DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(_kingdomStatementRulesFilePath);
				if (_cachedKingdomStatementRules != null && lastWriteTimeUtc <= _kingdomStatementRulesLastModified)
				{
					return _cachedKingdomStatementRules;
				}
				string text = File.ReadAllText(_kingdomStatementRulesFilePath).Trim();
				if (!string.IsNullOrEmpty(text))
				{
					_cachedKingdomStatementRules = text;
					_kingdomStatementRulesLastModified = lastWriteTimeUtc;
					return text;
				}
				_cachedKingdomStatementRules = null;
				_kingdomStatementRulesLastModified = lastWriteTimeUtc;
				return null;
			}
			return null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to read kingdom statement rules from " + _kingdomStatementRulesFilePath + ": " + ex.Message + ".");
			return null;
		}
	}

	public string ReadEventsAnalyzerRules()
	{
		try
		{
			if (File.Exists(_eventsAnalyzerRulesFilePath))
			{
				DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(_eventsAnalyzerRulesFilePath);
				if (_cachedEventsAnalyzerRules != null && lastWriteTimeUtc <= _eventsAnalyzerRulesLastModified)
				{
					return _cachedEventsAnalyzerRules;
				}
				string text = File.ReadAllText(_eventsAnalyzerRulesFilePath).Trim();
				if (!string.IsNullOrEmpty(text))
				{
					_cachedEventsAnalyzerRules = text;
					_eventsAnalyzerRulesLastModified = lastWriteTimeUtc;
					return text;
				}
				_cachedEventsAnalyzerRules = null;
				_eventsAnalyzerRulesLastModified = lastWriteTimeUtc;
				return null;
			}
			return null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to read events analyzer rules from " + _eventsAnalyzerRulesFilePath + ": " + ex.Message + ".");
			return null;
		}
	}

	public string ReadEventsGeneratorRules()
	{
		try
		{
			if (File.Exists(_eventsGeneratorRulesFilePath))
			{
				DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(_eventsGeneratorRulesFilePath);
				if (_cachedEventsGeneratorRules != null && lastWriteTimeUtc <= _eventsGeneratorRulesLastModified)
				{
					return _cachedEventsGeneratorRules;
				}
				string text = File.ReadAllText(_eventsGeneratorRulesFilePath).Trim();
				if (!string.IsNullOrEmpty(text))
				{
					_cachedEventsGeneratorRules = text;
					_eventsGeneratorRulesLastModified = lastWriteTimeUtc;
					return text;
				}
				_cachedEventsGeneratorRules = null;
				_eventsGeneratorRulesLastModified = lastWriteTimeUtc;
				return null;
			}
			return null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to read events generator rules from " + _eventsGeneratorRulesFilePath + ": " + ex.Message + ".");
			return null;
		}
	}

	private string GetCachedWarStatus()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (_cachedWarStatus != null && !(_lastWarStatusUpdate == CampaignTime.Never))
		{
			CampaignTime val = CampaignTime.Now - _lastWarStatusUpdate;
			if (!((val).ToDays >= 1.0))
			{
				goto IL_0061;
			}
		}
		_cachedWarStatus = CalculateWarStatus();
		_lastWarStatusUpdate = CampaignTime.Now;
		goto IL_0061;
		IL_0061:
		return _cachedWarStatus ?? "no wars";
	}

	private string CalculateWarStatus()
	{
		List<string> list = new List<string>();
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		Clan clan = Hero.MainHero.Clan;
		Kingdom val = ((clan != null) ? clan.Kingdom : null);
		WarStatisticsTracker instance = WarStatisticsTracker.Instance;
		foreach (Kingdom item6 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k.Leader != null))
		{
			List<IFaction> list2 = (from f in GameVersionCompatibility.GetEnemyFactions((IFaction)(object)item6)
				where (f is Kingdom && !f.IsMinorFaction && !f.IsBanditFaction && !f.IsEliminated) || (f is Clan && !f.IsMinorFaction && !f.IsBanditFaction)
				select f).ToList();
			foreach (IFaction item7 in list2)
			{
				if ((object)item7 == Hero.MainHero.Clan)
				{
					continue;
				}
				string item = GetWarKey(((MBObjectBase)item6).StringId, item7.StringId);
				if (hashSet.Contains(item))
				{
					continue;
				}
				hashSet.Add(item);
				string text = "";
				if (instance != null)
				{
					Kingdom val2 = (Kingdom)(object)((item7 is Kingdom) ? item7 : null);
					if (val2 != null)
					{
						DiplomaticReason diplomaticReason = instance.GetDiplomaticReason(item6, val2, "war");
						if (diplomaticReason != null && !string.IsNullOrEmpty(diplomaticReason.Reason))
						{
							text = " (" + diplomaticReason.Reason + ")";
						}
					}
				}
				Clan val3 = (Clan)(object)((item7 is Clan) ? item7 : null);
				string text2;
				if (val3 != null)
				{
					text2 = $"{item6.Name} (kingdom_id:{((MBObjectBase)item6).StringId}) is at war with {item7.Name} (clan_id:{((MBObjectBase)val3).StringId}) (minor conflict)";
				}
				else
				{
					Kingdom val4 = (Kingdom)(object)((item7 is Kingdom) ? item7 : null);
					text2 = ((val4 == null) ? $"{item6.Name} (kingdom_id:{((MBObjectBase)item6).StringId}) is at war with {item7.Name} (faction_id:{item7.StringId}){text}" : $"{item6.Name} (kingdom_id:{((MBObjectBase)item6).StringId}) is at war with {item7.Name} (kingdom_id:{((MBObjectBase)val4).StringId}){text}");
				}
				if (val != null)
				{
					if (!((object)val).Equals((object?)item6))
					{
						Kingdom val5 = (Kingdom)(object)((item7 is Kingdom) ? item7 : null);
						if (val5 == null || !((object)val).Equals((object?)val5))
						{
							goto IL_02a0;
						}
					}
					text2 += " (player involved)";
				}
				goto IL_02a0;
				IL_02a0:
				list.Add(text2);
			}
		}
		foreach (Clan item8 in ((IEnumerable<Clan>)Clan.All).Where((Clan c) => !c.IsMinorFaction && !c.IsBanditFaction && c != Hero.MainHero.Clan && !c.IsEliminated && c.Leader != null))
		{
			List<IFaction> list3 = (from f in GameVersionCompatibility.GetEnemyFactions((IFaction)(object)item8)
				where (f is Kingdom && !f.IsMinorFaction && !f.IsBanditFaction && !f.IsEliminated) || (f is Clan && !f.IsMinorFaction && !f.IsBanditFaction && !f.IsEliminated)
				select f).ToList();
			foreach (IFaction item9 in list3)
			{
				if ((object)item9 == Hero.MainHero.Clan)
				{
					continue;
				}
				string item2 = GetWarKey(((MBObjectBase)item8).StringId, item9.StringId);
				if (!hashSet.Contains(item2))
				{
					hashSet.Add(item2);
					Kingdom val6 = (Kingdom)(object)((item9 is Kingdom) ? item9 : null);
					string item3;
					if (val6 != null)
					{
						item3 = $"{item8.Name} (clan_id:{((MBObjectBase)item8).StringId}) is at war with {item9.Name} (kingdom_id:{((MBObjectBase)val6).StringId}) (minor conflict)";
					}
					else
					{
						Clan val7 = (Clan)(object)((item9 is Clan) ? item9 : null);
						item3 = ((val7 == null) ? $"{item8.Name} (clan_id:{((MBObjectBase)item8).StringId}) is at war with {item9.Name} (faction_id:{item9.StringId})" : $"{item8.Name} (clan_id:{((MBObjectBase)item8).StringId}) is at war with {item9.Name} (clan_id:{((MBObjectBase)val7).StringId}) (minor conflict)");
					}
					list.Add(item3);
				}
			}
		}
		if (Hero.MainHero.Clan != null)
		{
			List<IFaction> list4 = (from f in GameVersionCompatibility.GetEnemyFactions((IFaction)(object)Hero.MainHero.Clan)
				where (f is Kingdom && !f.IsMinorFaction && !f.IsBanditFaction) || (f is Clan && !f.IsMinorFaction && !f.IsBanditFaction)
				select f).ToList();
			foreach (IFaction item10 in list4)
			{
				string item4 = GetWarKey(((MBObjectBase)Hero.MainHero.Clan).StringId, item10.StringId);
				if (hashSet.Contains(item4))
				{
					continue;
				}
				hashSet.Add(item4);
				if (val != null)
				{
					if (item10 is Kingdom && val.IsAtWarWith(item10))
					{
						continue;
					}
					Clan val8 = (Clan)(object)((item10 is Clan) ? item10 : null);
					if (val8 != null && val.IsAtWarWith((IFaction)(object)val8))
					{
						continue;
					}
				}
				Kingdom val9 = (Kingdom)(object)((item10 is Kingdom) ? item10 : null);
				string item5;
				if (val9 != null)
				{
					item5 = $"{item10.Name} (kingdom_id:{((MBObjectBase)val9).StringId}) is at war with {Hero.MainHero.Clan.Name} (clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId}) (player involved, minor conflict)";
				}
				else
				{
					Clan val10 = (Clan)(object)((item10 is Clan) ? item10 : null);
					item5 = ((val10 == null) ? $"{item10.Name} (faction_id:{item10.StringId}) is at war with {Hero.MainHero.Clan.Name} (clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId}) (player involved)" : $"{item10.Name} (clan_id:{((MBObjectBase)val10).StringId}) is at war with {Hero.MainHero.Clan.Name} (clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId}) (player involved, minor conflict)");
				}
				list.Add(item5);
			}
		}
		int num = list.Count((string w) => w.Contains("kingdom_id:") && !w.Contains("clan_id:") && !w.Contains("(minor conflict)"));
		int num2 = list.Count((string w) => w.Contains("(minor conflict)"));
		int num3 = list.Count((string w) => w.Contains("clan_id:") && !w.Contains("(minor conflict)"));
		AIInfluenceBehavior.Instance?.LogMessage($"[CalculateWarStatus] Generated {list.Count} total wars: " + $"Kingdom↔Kingdom: {num}, Minor conflicts: {num2}, Clan↔Clan: {num3}");
		return list.Any() ? string.Join("; ", list) : "no wars";
		static string GetWarKey(string id1, string id2)
		{
			return (id1.CompareTo(id2) < 0) ? (id1 + "|" + id2) : (id2 + "|" + id1);
		}
	}

	public void UpdateWarStatus(NPCContext context)
	{
		string cachedWarStatus = GetCachedWarStatus();
		context.WarStatus = FilterMinorConflicts(cachedWarStatus, context);
	}

	private string FilterMinorConflicts(string fullWarStatus, NPCContext context)
	{
		if (string.IsNullOrEmpty(fullWarStatus) || fullWarStatus == "no wars")
		{
			return fullWarStatus;
		}
		Hero hero = context.Hero;
		Clan val = ((hero != null) ? hero.Clan : null);
		string text = ((val != null) ? ((MBObjectBase)val).StringId : null);
		string[] array = fullWarStatus.Split(new string[1] { "; " }, StringSplitOptions.RemoveEmptyEntries);
		List<string> list = new List<string>();
		int num = array.Length;
		int num2 = 0;
		int num3 = 0;
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		IReadOnlyList<Clan> readOnlyList = Array.Empty<Clan>();
		if (context.ConversationHistory != null && context.ConversationHistory.Any())
		{
			readOnlyList = ClanMentionParser.GetMentionedClans(context.ConversationHistory, 3);
			hashSet = new HashSet<string>(readOnlyList.Select((Clan c) => ((MBObjectBase)c).StringId), StringComparer.OrdinalIgnoreCase);
		}
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			if (!text2.Contains("(minor conflict)"))
			{
				list.Add(text2);
				num3++;
				continue;
			}
			num2++;
			bool flag = false;
			if (!string.IsNullOrEmpty(text) && (text2.IndexOf("clan_id:" + text, StringComparison.OrdinalIgnoreCase) >= 0 || text2.IndexOf("clan_id:" + text + ")", StringComparison.OrdinalIgnoreCase) >= 0))
			{
				flag = true;
			}
			if (!flag && hashSet.Any())
			{
				foreach (string item in hashSet)
				{
					if (text2.IndexOf("clan_id:" + item, StringComparison.OrdinalIgnoreCase) >= 0 || text2.IndexOf("clan_id:" + item + ")", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag && readOnlyList.Any())
			{
				foreach (Clan item2 in readOnlyList)
				{
					string text3 = ((object)item2.Name)?.ToString();
					if (string.IsNullOrEmpty(text3) || text3.Length < 3)
					{
						continue;
					}
					int num5 = text2.IndexOf(text3, StringComparison.OrdinalIgnoreCase);
					if (num5 < 0)
					{
						continue;
					}
					int num6 = num5 + text3.Length;
					if (num6 < text2.Length)
					{
						string text4 = text2.Substring(num6, Math.Min(30, text2.Length - num6));
						if (text4.Contains("(clan_id:"))
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				list.Add(text2);
			}
		}
		if (context.ConversationHistory != null && context.ConversationHistory.Any())
		{
			int num7 = list.Count - num3;
			Hero hero2 = context.Hero;
			string text5 = ((hero2 == null) ? null : ((object)hero2.Name)?.ToString()) ?? context.Name ?? "Unknown";
			Hero hero3 = context.Hero;
			object obj;
			if (hero3 == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = hero3.Clan;
				obj = ((clan == null) ? null : ((object)clan.Name)?.ToString());
			}
			if (obj == null)
			{
				obj = "No clan";
			}
			string text6 = (string)obj;
			string text7 = (readOnlyList.Any() ? string.Join(", ", readOnlyList.Select((Clan c) => ((object)c.Name)?.ToString() ?? "Unknown")) : "none");
			AIInfluenceBehavior.Instance?.LogMessage("[WarStatus Filter] NPC: " + text5 + " (Clan: " + text6 + ") | " + $"Total: {num} (Regular: {num3}, Minor: {num2}) | " + $"Filtered: {list.Count} (Regular: {num3}, Minor: {num7}) | " + "Mentioned clans: " + text7);
		}
		return list.Any() ? string.Join("; ", list) : "no wars";
	}

	private string NormalizeClanName(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in text)
		{
			if (char.IsLetterOrDigit(c))
			{
				stringBuilder.Append(char.ToLowerInvariant(c));
			}
		}
		return stringBuilder.ToString();
	}

	public void UpdatePlayerRelation(NPCContext context, Hero npc)
	{
		int relation = npc.GetRelation(Hero.MainHero);
		string description = ((relation <= -50) ? "very hostile" : ((relation <= -10) ? "hostile" : ((relation <= 10) ? "neutral" : ((relation > 50) ? "very friendly" : "friendly"))));
		context.PlayerRelation = new PlayerRelation
		{
			Value = relation,
			Description = description
		};
	}

	public void UpdateCurrentTask(NPCContext context, Hero npc)
	{
		if (npc.IsPrisoner && npc.PartyBelongedToAsPrisoner == PartyBase.MainParty)
		{
			string text = ((object)MobileParty.MainParty.Name)?.ToString() ?? "player party";
			string text2 = ((MBObjectBase)MobileParty.MainParty).StringId ?? "unknown";
			if (Hero.MainHero.CurrentSettlement != null)
			{
				Settlement currentSettlement = Hero.MainHero.CurrentSettlement;
				string text3 = (currentSettlement.IsTown ? "city" : (currentSettlement.IsCastle ? "castle" : "village"));
				CultureObject culture = currentSettlement.Culture;
				string text4 = ((culture != null) ? ((object)((BasicCultureObject)culture).Name).ToString() : null) ?? "unknown culture";
				IFaction mapFaction = currentSettlement.MapFaction;
				string text5 = ((mapFaction != null) ? ((object)mapFaction.Name).ToString() : null);
				string text6 = ((!string.IsNullOrEmpty(text5) && text5 != "no kingdom") ? ("kingdom of " + text5) : "not part of any kingdom");
				string region = GetRegion(currentSettlement);
				Clan ownerClan = currentSettlement.OwnerClan;
				string text7 = ((ownerClan != null) ? ((object)ownerClan.Name).ToString() : null) ?? "no clan";
				context.CurrentTask = $"no specific task, because you are a prisoner in {text} (id:{text2}) party, located in {currentSettlement.Name} (id:{((MBObjectBase)currentSettlement).StringId}, {text3} of {text4}, owned by clan {text7}, {text6}, {region})";
				return;
			}
			(Settlement, float) nearestSettlementInfo = GetNearestSettlementInfo(Hero.MainHero.PartyBelongedTo);
			string text8 = ((Hero.MainHero.PartyBelongedTo != null && Hero.MainHero.PartyBelongedTo.IsCurrentlyAtSea) ? " sailing at sea" : " traveling on land");
			if (nearestSettlementInfo.Item2 <= 20f && nearestSettlementInfo.Item1 != null)
			{
				string text9 = (nearestSettlementInfo.Item1.IsTown ? "city" : (nearestSettlementInfo.Item1.IsCastle ? "castle" : "village"));
				CultureObject culture2 = nearestSettlementInfo.Item1.Culture;
				string text10 = ((culture2 == null) ? null : ((object)((BasicCultureObject)culture2).Name)?.ToString()) ?? "unknown culture";
				IFaction mapFaction2 = nearestSettlementInfo.Item1.MapFaction;
				string text11 = ((mapFaction2 == null) ? null : ((object)mapFaction2.Name)?.ToString());
				string text12 = ((!string.IsNullOrEmpty(text11) && text11 != "no kingdom") ? ("kingdom of " + text11) : "not part of any kingdom");
				Clan ownerClan2 = nearestSettlementInfo.Item1.OwnerClan;
				string text13 = ((ownerClan2 != null) ? ((object)ownerClan2.Name).ToString() : null) ?? "no clan";
				context.CurrentTask = $"no specific task, because you are a prisoner in {text} (id:{text2}) party,{text8}, located near {nearestSettlementInfo.Item1.Name} (id:{((MBObjectBase)nearestSettlementInfo.Item1).StringId}, {text9} of {text10}, owned by clan {text13}, {text12})";
			}
			else
			{
				context.CurrentTask = "no specific task, because you are a prisoner in " + text + " (id:" + text2 + ") party," + text8 + ", traveling through the wilderness";
			}
		}
		else if (npc.CurrentSettlement != null)
		{
			context.CurrentTask = $"resting in {npc.CurrentSettlement.Name} (id:{((MBObjectBase)npc.CurrentSettlement).StringId})";
		}
		else if (npc.PartyBelongedTo != null)
		{
			MobileParty partyBelongedTo = npc.PartyBelongedTo;
			string text14 = (partyBelongedTo.IsCurrentlyAtSea ? " sailing at sea" : " traveling on land");
			if (partyBelongedTo.Army != null)
			{
				Army army = partyBelongedTo.Army;
				string text15 = (army.LeaderParty.IsCurrentlyAtSea ? " sailing at sea" : " traveling on land");
				if (army.LeaderParty.CurrentSettlement != null)
				{
					context.CurrentTask = $"marching with the army, stationed in {army.LeaderParty.CurrentSettlement.Name} (id:{((MBObjectBase)army.LeaderParty.CurrentSettlement).StringId})";
				}
				else if (army.LeaderParty.SiegeEvent != null && army.LeaderParty.SiegeEvent.BesiegedSettlement != null)
				{
					Settlement besiegedSettlement = army.LeaderParty.SiegeEvent.BesiegedSettlement;
					context.CurrentTask = $"marching with the army, besieging {besiegedSettlement.Name} (id:{((MBObjectBase)besiegedSettlement).StringId})";
				}
				else if (army.LeaderParty.TargetSettlement != null)
				{
					Settlement targetSettlement = army.LeaderParty.TargetSettlement;
					if (targetSettlement.MapFaction != null && army.LeaderParty.MapFaction != null && army.LeaderParty.MapFaction.IsAtWarWith(targetSettlement.MapFaction))
					{
						string text16 = (targetSettlement.IsTown ? "town" : (targetSettlement.IsCastle ? "castle" : "village"));
						context.CurrentTask = $"marching with the army,{text15}, preparing to besiege {targetSettlement.Name} (id:{((MBObjectBase)targetSettlement).StringId}) {text16}";
					}
					else
					{
						context.CurrentTask = $"marching with the army,{text15}, traveling to {targetSettlement.Name} (id:{((MBObjectBase)targetSettlement).StringId})";
					}
				}
				else
				{
					Settlement item = GetNearestSettlementInfo(army.LeaderParty).Settlement;
					context.CurrentTask = ((item != null) ? $"marching with the army,{text15}, patrolling near {item.Name} (id:{((MBObjectBase)item).StringId})" : ("marching with the army" + text15 + " in the field"));
				}
			}
			else if (partyBelongedTo.CurrentSettlement != null)
			{
				context.CurrentTask = $"stationed in {partyBelongedTo.CurrentSettlement.Name} (id:{((MBObjectBase)partyBelongedTo.CurrentSettlement).StringId})";
			}
			else if (partyBelongedTo.SiegeEvent != null && partyBelongedTo.SiegeEvent.BesiegedSettlement != null)
			{
				Settlement besiegedSettlement2 = partyBelongedTo.SiegeEvent.BesiegedSettlement;
				context.CurrentTask = $"besieging {besiegedSettlement2.Name} (id:{((MBObjectBase)besiegedSettlement2).StringId})";
			}
			else if (partyBelongedTo.MoveTargetParty != null && partyBelongedTo.MoveTargetParty == MobileParty.MainParty)
			{
				context.CurrentTask = $"pursuing the player party (led by {MobileParty.MainParty.Name}, player_id:{((MBObjectBase)Hero.MainHero).StringId}),{text14}";
			}
			else if (partyBelongedTo.TargetParty != null && partyBelongedTo.TargetParty == MobileParty.MainParty)
			{
				context.CurrentTask = $"pursuing the player party (led by {MobileParty.MainParty.Name}, player_id:{((MBObjectBase)Hero.MainHero).StringId}),{text14}";
			}
			else if (partyBelongedTo.TargetSettlement != null)
			{
				context.CurrentTask = $"traveling to {partyBelongedTo.TargetSettlement.Name} (id:{((MBObjectBase)partyBelongedTo.TargetSettlement).StringId}),{text14}";
			}
			else
			{
				Settlement item2 = GetNearestSettlementInfo(partyBelongedTo).Settlement;
				context.CurrentTask = ((item2 != null) ? $"patrolling near {item2.Name} (id:{((MBObjectBase)item2).StringId}),{text14}" : ("leading a party" + text14 + " in the field"));
			}
		}
		else
		{
			context.CurrentTask = "no specific task";
		}
	}

	public void UpdateEmotionalState(NPCContext context, Hero npc)
	{
		string mood = "calm";
		string reason = "no specific reason";
		int relation = npc.GetRelation(Hero.MainHero);
		bool flag = context.RecentEvents?.Any(delegate(CampaignEvent e)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (e.Type == "Battle")
			{
				CampaignTime val = CampaignTime.Now - e.Timestamp;
				if ((val).ToDays <= 4.0)
				{
					result = ((e.Description.Contains("I lost a battle") || e.Description.Contains("We were defeated in a battle")) ? 1 : 0);
					goto IL_005d;
				}
			}
			result = 0;
			goto IL_005d;
			IL_005d:
			return (byte)result != 0;
		}) ?? false;
		bool flag2 = context.RecentEvents?.Any(delegate(CampaignEvent e)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (e.Type == "Battle")
			{
				CampaignTime val = CampaignTime.Now - e.Timestamp;
				if ((val).ToDays <= 4.0)
				{
					result = ((e.Description.Contains("I won a battle") || e.Description.Contains("We won a battle")) ? 1 : 0);
					goto IL_005d;
				}
			}
			result = 0;
			goto IL_005d;
			IL_005d:
			return (byte)result != 0;
		}) ?? false;
		bool flag3 = false;
		if (context.RecentEvents != null)
		{
			if (npc.MapFaction != null)
			{
				string npcFactionName = ((object)npc.MapFaction.Name).ToString();
				flag3 = context.RecentEvents.Any(delegate(CampaignEvent e)
				{
					//IL_0012: Unknown result type (might be due to invalid IL or missing references)
					//IL_0018: Unknown result type (might be due to invalid IL or missing references)
					//IL_001d: Unknown result type (might be due to invalid IL or missing references)
					//IL_0022: Unknown result type (might be due to invalid IL or missing references)
					int result;
					if (e.Type == "WarDeclared")
					{
						CampaignTime val = CampaignTime.Now - e.Timestamp;
						if ((val).ToDays <= 10.0)
						{
							result = ((e.Description.Contains("declared war on " + npcFactionName) || e.Description.Contains(npcFactionName + " declared war on")) ? 1 : 0);
							goto IL_0073;
						}
					}
					result = 0;
					goto IL_0073;
					IL_0073:
					return (byte)result != 0;
				});
			}
			if (!flag3 && npc.Clan != null)
			{
				string npcClanName = ((object)npc.Clan.Name).ToString();
				flag3 = context.RecentEvents.Any(delegate(CampaignEvent e)
				{
					//IL_0012: Unknown result type (might be due to invalid IL or missing references)
					//IL_0018: Unknown result type (might be due to invalid IL or missing references)
					//IL_001d: Unknown result type (might be due to invalid IL or missing references)
					//IL_0022: Unknown result type (might be due to invalid IL or missing references)
					int result;
					if (e.Type == "WarDeclared")
					{
						CampaignTime val = CampaignTime.Now - e.Timestamp;
						if ((val).ToDays <= 10.0)
						{
							result = ((e.Description.Contains("declared war on " + npcClanName) || e.Description.Contains(npcClanName + " declared war on")) ? 1 : 0);
							goto IL_0073;
						}
					}
					result = 0;
					goto IL_0073;
					IL_0073:
					return (byte)result != 0;
				});
			}
		}
		bool flag4 = context.RecentEvents?.Any(delegate(CampaignEvent e)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (e.Type == "HeroKilled")
			{
				CampaignTime val = CampaignTime.Now - e.Timestamp;
				if ((val).ToDays <= 12.0)
				{
					result = ((!e.Description.Contains("you did not know them")) ? 1 : 0);
					goto IL_004b;
				}
			}
			result = 0;
			goto IL_004b;
			IL_004b:
			return (byte)result != 0;
		}) ?? false;
		float num = context.NPCForces?.WoundedPercentage ?? 0f;
		if (relation <= -50)
		{
			mood = "suspicious";
			reason = "due to very hostile relations with the player";
		}
		else if (flag2)
		{
			mood = "triumphant";
			reason = "due to a recent battle victory";
		}
		else if (flag)
		{
			mood = "angry";
			reason = "due to a recent battle loss";
		}
		else if (flag3)
		{
			mood = "tense";
			reason = "due to a recent war declaration";
		}
		else if (flag4)
		{
			mood = "grieving";
			reason = "due to a recent death of a hero";
		}
		else if (num > 30f)
		{
			mood = "weary";
			reason = "due to a weakened party";
		}
		else if (relation >= 50)
		{
			mood = "joyful";
			reason = "due to very friendly relations with the player";
		}
		context.EmotionalState = new EmotionalState
		{
			Mood = mood,
			Reason = reason
		};
	}

	public void UpdateTimeContext(NPCContext context)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected I4, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime now = CampaignTime.Now;
		Seasons getSeasonOfYear = (now).GetSeasonOfYear;
		Seasons val = getSeasonOfYear;
		string season = (int)val switch
		{
			0 => "spring", 
			1 => "summer", 
			2 => "autumn", 
			3 => "winter", 
			_ => "unknown", 
		};
		float num = (now).GetHourOfDay;
		int num2 = (int)num;
		string timeOfDay = ((num2 >= 6 && num2 < 12) ? "morning" : ((num2 >= 12 && num2 < 18) ? "day" : ((num2 < 18 || num2 >= 22) ? "night" : "evening")));
		int getYear = (now).GetYear;
		int num3 = (now).GetDayOfYear / 30;
		if (num3 < 1)
		{
			num3 = 1;
		}
		if (num3 > 12)
		{
			num3 = 12;
		}
		context.TimeContext = new TimeContext
		{
			Season = season,
			Year = getYear,
			Month = num3,
			TimeOfDay = timeOfDay,
			Hour = num2,
			LastUpdated = now
		};
	}

	public void UpdatePlayerForces(NPCContext context)
	{
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		MobileParty partyBelongedTo = Hero.MainHero.PartyBelongedTo;
		if (partyBelongedTo == null)
		{
			context.PlayerForces = new PlayerForces
			{
				PartySize = 0,
				WoundedPercentage = 0f,
				HasArmy = false
			};
			AIInfluenceBehavior.Instance?.LogMessage("[NPC] Updated player forces: No party, 0 men, 0% wounded, no army");
			return;
		}
		Hero npc = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
		bool flag = CanNPCSeePlayerForces(npc);
		int num = 0;
		int num2 = 0;
		bool flag2 = partyBelongedTo.Army != null;
		if (flag)
		{
			if (flag2)
			{
				foreach (MobileParty item in (List<MobileParty>)(object)partyBelongedTo.Army.Parties)
				{
					num += item.MemberRoster.TotalManCount;
					num2 += item.MemberRoster.TotalWoundedRegulars;
				}
			}
			else
			{
				num = partyBelongedTo.MemberRoster.TotalManCount;
				num2 = partyBelongedTo.MemberRoster.TotalWoundedRegulars;
			}
		}
		else
		{
			num = EstimatePlayerForces(partyBelongedTo, flag2);
			num2 = 0;
		}
		float woundedPercentage = ((num > 0) ? ((float)num2 / (float)num * 100f) : 0f);
		List<TroopDetail> list = new List<TroopDetail>();
		if (flag)
		{
			if (flag2)
			{
				Dictionary<string, (int, int)> dictionary = new Dictionary<string, (int, int)>();
				foreach (MobileParty item2 in (List<MobileParty>)(object)partyBelongedTo.Army.Parties)
				{
					foreach (TroopRosterElement item3 in (List<TroopRosterElement>)(object)item2.MemberRoster.GetTroopRoster())
					{
						TroopRosterElement current3 = item3;
						if (current3.Character != null && !((BasicCharacterObject)current3.Character).IsHero)
						{
							string stringId = ((MBObjectBase)current3.Character).StringId;
							int number = (current3).Number;
							int woundedNumber = (current3).WoundedNumber;
							if (dictionary.ContainsKey(stringId))
							{
								(int, int) tuple = dictionary[stringId];
								dictionary[stringId] = (tuple.Item1 + number, tuple.Item2 + woundedNumber);
							}
							else
							{
								dictionary[stringId] = (number, woundedNumber);
							}
						}
					}
				}
				foreach (KeyValuePair<string, (int, int)> kvp in dictionary)
				{
					CharacterObject val = ((IEnumerable<CharacterObject>)CharacterObject.All).FirstOrDefault((Func<CharacterObject, bool>)((CharacterObject c) => ((MBObjectBase)c).StringId == kvp.Key));
					if (val != null)
					{
						list.Add(new TroopDetail
						{
							Name = ((object)((BasicCharacterObject)val).Name).ToString(),
							StringId = kvp.Key,
							Count = kvp.Value.Item1,
							WoundedCount = kvp.Value.Item2
						});
					}
				}
			}
			else
			{
				foreach (TroopRosterElement item4 in (List<TroopRosterElement>)(object)partyBelongedTo.MemberRoster.GetTroopRoster())
				{
					TroopRosterElement current4 = item4;
					if (current4.Character != null && !((BasicCharacterObject)current4.Character).IsHero)
					{
						list.Add(new TroopDetail
						{
							Name = ((object)((BasicCharacterObject)current4.Character).Name).ToString(),
							StringId = ((MBObjectBase)current4.Character).StringId,
							Count = (current4).Number,
							WoundedCount = (current4).WoundedNumber
						});
					}
				}
			}
		}
		context.PlayerForces = new PlayerForces
		{
			PartySize = num,
			WoundedPercentage = woundedPercentage,
			HasArmy = flag2,
			TroopDetails = list
		};
	}

	private bool CanNPCSeePlayerForces(Hero npc)
	{
		if (npc == null)
		{
			return false;
		}
		if (npc.PartyBelongedTo != null)
		{
			return true;
		}
		if (npc.IsLord || npc.IsClanLeader)
		{
			return true;
		}
		if (npc.IsNotable)
		{
			Settlement currentSettlement = npc.CurrentSettlement;
			if (currentSettlement == null || !currentSettlement.IsTown)
			{
				Settlement currentSettlement2 = npc.CurrentSettlement;
				if (currentSettlement2 == null || !currentSettlement2.IsCastle)
				{
					goto IL_0075;
				}
			}
			return true;
		}
		goto IL_0075;
		IL_0075:
		return false;
	}

	private int EstimatePlayerForces(MobileParty playerParty, bool hasArmy)
	{
		if (hasArmy)
		{
			Random random = new Random();
			return random.Next(30, 101);
		}
		int num = 1;
		if (playerParty != null && playerParty.MemberRoster != null)
		{
			num = playerParty.MemberRoster.TotalManCount;
		}
		if (num <= 5)
		{
			return num;
		}
		return Math.Max(5, num + new Random().Next(-10, 21));
	}

	public void UpdateNPCForces(NPCContext context, Hero npc)
	{
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		MobileParty npcParty = npc.PartyBelongedTo;
		if (npcParty == null)
		{
			context.NPCForces = new NPCForces
			{
				PartySize = 0,
				WoundedPercentage = 0f,
				HasArmy = false
			};
			return;
		}
		int num = 0;
		int num2 = 0;
		bool flag = npcParty.Army != null;
		string text = null;
		if (flag)
		{
			List<MobileParty> list = ((IEnumerable<MobileParty>)npcParty.Army.Parties).Where((MobileParty p) => p == npcParty.Army.LeaderParty || p.AttachedTo == npcParty.Army.LeaderParty).ToList();
			List<string> list2 = new List<string>();
			foreach (MobileParty item in list)
			{
				int totalManCount = item.MemberRoster.TotalManCount;
				num += totalManCount;
				num2 += item.MemberRoster.TotalWoundedRegulars;
				if (item.LeaderHero != null)
				{
					string arg = ((object)item.LeaderHero.Name).ToString();
					string stringId = ((MBObjectBase)item.LeaderHero).StringId;
					list2.Add($"{arg}'s (id:{stringId}) party ({totalManCount} soldiers)");
				}
				else
				{
					list2.Add($"{((object)item.Name).ToString()}'s party ({totalManCount} soldiers)");
				}
			}
			List<MobileParty> list3 = ((IEnumerable<MobileParty>)npcParty.Army.Parties).Where((MobileParty p) => p != npcParty.Army.LeaderParty && !((List<MobileParty>)(object)npcParty.Army.LeaderParty.AttachedParties).Contains(p)).ToList();
			int num3 = 0;
			List<string> list4 = new List<string>();
			if (list3.Count > 0)
			{
				foreach (MobileParty item2 in list3)
				{
					int totalManCount2 = item2.MemberRoster.TotalManCount;
					num3 += totalManCount2;
					if (item2.LeaderHero != null)
					{
						string arg2 = ((object)item2.LeaderHero.Name).ToString();
						string stringId2 = ((MBObjectBase)item2.LeaderHero).StringId;
						list4.Add($"{arg2} (id:{stringId2}) with {totalManCount2} soldiers");
					}
					else
					{
						list4.Add($"{((object)item2.Name).ToString()} with {totalManCount2} soldiers");
					}
				}
			}
			text = ((list3.Count <= 0) ? string.Format("Total army strength is {0} soldiers. It consists of the following parties: {1}.", num, string.Join(", ", list2)) : (string.Format("Total current army strength is {0} soldiers. It consists of the following parties: {1}. ", num, string.Join(", ", list2)) + string.Format("Additionally, {0} soldiers are expected to arrive soon from the following lords: {1}.", num3, string.Join(", ", list4))));
		}
		else
		{
			num = npcParty.MemberRoster.TotalManCount;
			num2 = npcParty.MemberRoster.TotalWoundedRegulars;
		}
		float woundedPercentage = ((num > 0) ? ((float)num2 / (float)num * 100f) : 0f);
		List<TroopDetail> list5 = new List<TroopDetail>();
		if (flag)
		{
			List<MobileParty> list6 = ((IEnumerable<MobileParty>)npcParty.Army.Parties).Where((MobileParty p) => p == npcParty.Army.LeaderParty || p.AttachedTo == npcParty.Army.LeaderParty).ToList();
			Dictionary<string, (int, int)> dictionary = new Dictionary<string, (int, int)>();
			foreach (MobileParty item3 in list6)
			{
				foreach (TroopRosterElement item4 in (List<TroopRosterElement>)(object)item3.MemberRoster.GetTroopRoster())
				{
					TroopRosterElement current4 = item4;
					if (current4.Character != null && !((BasicCharacterObject)current4.Character).IsHero)
					{
						string stringId3 = ((MBObjectBase)current4.Character).StringId;
						int number = (current4).Number;
						int woundedNumber = (current4).WoundedNumber;
						if (dictionary.ContainsKey(stringId3))
						{
							(int, int) tuple = dictionary[stringId3];
							dictionary[stringId3] = (tuple.Item1 + number, tuple.Item2 + woundedNumber);
						}
						else
						{
							dictionary[stringId3] = (number, woundedNumber);
						}
					}
				}
			}
			foreach (KeyValuePair<string, (int, int)> kvp in dictionary)
			{
				CharacterObject val = ((IEnumerable<CharacterObject>)CharacterObject.All).FirstOrDefault((Func<CharacterObject, bool>)((CharacterObject c) => ((MBObjectBase)c).StringId == kvp.Key));
				if (val != null)
				{
					list5.Add(new TroopDetail
					{
						Name = ((object)((BasicCharacterObject)val).Name).ToString(),
						StringId = kvp.Key,
						Count = kvp.Value.Item1,
						WoundedCount = kvp.Value.Item2
					});
				}
			}
		}
		else
		{
			foreach (TroopRosterElement item5 in (List<TroopRosterElement>)(object)npcParty.MemberRoster.GetTroopRoster())
			{
				TroopRosterElement current5 = item5;
				if (current5.Character != null && !((BasicCharacterObject)current5.Character).IsHero)
				{
					list5.Add(new TroopDetail
					{
						Name = ((object)((BasicCharacterObject)current5.Character).Name).ToString(),
						StringId = ((MBObjectBase)current5.Character).StringId,
						Count = (current5).Number,
						WoundedCount = (current5).WoundedNumber
					});
				}
			}
		}
		context.NPCForces = new NPCForces
		{
			PartySize = num,
			WoundedPercentage = woundedPercentage,
			HasArmy = flag,
			ArmyDetails = text,
			TroopDetails = list5
		};
		if (flag)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[NPC] Army details for {npc.Name}: {text}");
		}
	}

	public void UpdateInformationAccessLevel(NPCContext context, Hero npc)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		string text = (npc.IsClanLeader ? "clan leader" : (((int)npc.Occupation == 3) ? "noble" : (npc.IsMerchant ? "merchant" : "commoner")));
		Clan clan = npc.Clan;
		object obj;
		if (clan == null)
		{
			obj = null;
		}
		else
		{
			IFaction mapFaction = clan.MapFaction;
			obj = ((mapFaction != null) ? mapFaction.Leader : null);
		}
		if (npc == obj)
		{
			text = "king";
		}
		switch (text)
		{
		case "king":
		case "clan leader":
			context.InformationAccessLevel = "high";
			break;
		case "noble":
			context.InformationAccessLevel = "medium";
			break;
		default:
			context.InformationAccessLevel = "low";
			break;
		}
	}

	private double GetEventAge(CampaignEvent campaignEvent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime val;
		if (campaignEvent.Timestamp != CampaignTime.Never)
		{
			val = CampaignTime.Now - campaignEvent.Timestamp;
			return (val).ToDays;
		}
		if (campaignEvent.EventTimeDays > 0.0)
		{
			val = CampaignTime.Now;
			return (val).ToDays - campaignEvent.EventTimeDays;
		}
		return 999.0;
	}

	public void CleanOldEvents(NPCContext context)
	{
		if (context == null || string.IsNullOrEmpty(context.StringId))
		{
			return;
		}
		if (context.RecentEvents == null)
		{
			context.RecentEvents = new List<CampaignEvent>();
			return;
		}
		int count = context.RecentEvents.Count;
		TrimRecentEvents(context);
		int count2 = context.RecentEvents.Count;
		if (count2 < count)
		{
			Hero val = context.Hero;
			if (val == null || !val.IsAlive)
			{
				val = (context.Hero = AIInfluenceBehavior.Instance?.GetHeroById(context.StringId));
			}
			if (val != null)
			{
				AIInfluenceBehavior.Instance?.SaveNPCContext(context.StringId, val, context);
			}
		}
	}

	public void ProcessRomanceDecay(NPCContext context)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if (context.RomanceLevel <= 0f || context.LastRomanceInteractionDays < 0)
		{
			return;
		}
		CampaignTime now = CampaignTime.Now;
		int num = (int)(now).ToDays;
		int num2 = num - context.LastRomanceInteractionDays;
		if (num2 <= GlobalSettings<ModSettings>.Instance.RomanceDecayDays)
		{
			return;
		}
		int num3 = num2 - GlobalSettings<ModSettings>.Instance.RomanceDecayDays;
		float num4 = num3 * GlobalSettings<ModSettings>.Instance.RomanceDecayAmount;
		float romanceLevel = context.RomanceLevel;
		context.RomanceLevel = Math.Max(0f, context.RomanceLevel - num4);
		if (romanceLevel == context.RomanceLevel)
		{
			return;
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] Romance decay for {context.Name}: {romanceLevel:F1} -> {context.RomanceLevel:F1} (days without romance: {num2}, decay: {num4:F1})");
		if (string.IsNullOrEmpty(context.StringId) || AIInfluenceBehavior.Instance == null)
		{
			return;
		}
		Hero val = context.Hero;
		if (val == null || !val.IsAlive)
		{
			val = (context.Hero = AIInfluenceBehavior.Instance.GetHeroById(context.StringId));
		}
		if (val != null)
		{
			string nPCFilePath = AIInfluenceBehavior.Instance.GetNPCFilePath(context.StringId);
			if (!string.IsNullOrEmpty(nPCFilePath))
			{
				AIInfluenceBehavior.Instance.SaveNPCContext(context.StringId, val, context);
			}
		}
	}

	private void OnDailyTick()
	{
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		string text = AIInfluenceBehavior.Instance?.GetActiveSaveDirectory();
		List<string> list = new List<string>();
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
		{
			"diplomatic_statements", "dynamic_events", "economic_effects", "diplomatic_events", "pending_player_statements", "war_statistics", "alliances", "alliance_data", "settlement_ownership_history", "kingdom_leadership_history",
			"trade_agreements", "territory_transfers", "tribute_agreements", "tributes", "reparations", "expelled_clans", "rp_items"
		};
		if (!string.IsNullOrEmpty(text) && Directory.Exists(text))
		{
			try
			{
				string[] files = Directory.GetFiles(text, "*.json");
				string[] array = files;
				foreach (string path in array)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
					if (!hashSet.Contains(fileNameWithoutExtension))
					{
						list.Add(fileNameWithoutExtension);
					}
				}
			}
			catch (Exception ex)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Error reading save folder for cleanup: " + ex.Message);
			}
		}
		if (list.Count == 0)
		{
			Dictionary<string, NPCContext> dictionary = AIInfluenceBehavior.Instance?.GetNPCContexts();
			if (dictionary != null && dictionary.Any())
			{
				list.AddRange(dictionary.Keys.ToList());
			}
		}
		if (list.Count == 0)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] No NPCs found for daily tick processing.");
			return;
		}
		lock (_dailyTickQueue)
		{
			_dailyTickQueue.Clear();
			foreach (string item in list)
			{
				_dailyTickQueue.Enqueue(item);
			}
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[PERF] OnDailyTick: Queued {list.Count} NPCs for background processing and cleanup.");
		if (GlobalSettings<ModSettings>.Instance.EnableDeadNPCCleanup)
		{
			AIInfluenceBehavior.Instance?.CleanupDeadNPCs();
		}
		CampaignTime now = CampaignTime.Now;
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<string, (HashSet<string>, CampaignTime)> item2 in _recentBattleParticipantsByCapturer)
		{
			CampaignTime val = now - item2.Value.Item2;
			float num = (float)(val).ToHours;
			if (num > 24f)
			{
				list2.Add(item2.Key);
			}
		}
		foreach (string item3 in list2)
		{
			_recentBattleParticipantsByCapturer.Remove(item3);
		}
	}

	public void Tick(float dt)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		ProcessEventTasks();
		if (_dailyTickQueue.Count == 0)
		{
			return;
		}
		int i = 0;
		CampaignTime now = CampaignTime.Now;
		float currentDays = (float)(now).ToDays;
		for (; i < 5; i++)
		{
			if (_dailyTickQueue.Count <= 0)
			{
				break;
			}
			string text;
			lock (_dailyTickQueue)
			{
				text = _dailyTickQueue.Dequeue();
			}
			NPCContext nPCContext = AIInfluenceBehavior.Instance?.GetNPCContextByStringId(text);
			if (nPCContext == null)
			{
				nPCContext = AIInfluenceBehavior.Instance?.LoadNPCContext(text);
				if (nPCContext != null && !string.IsNullOrEmpty(nPCContext.StringId))
				{
					Dictionary<string, NPCContext> dictionary = AIInfluenceBehavior.Instance?.GetNPCContexts();
					if (dictionary != null)
					{
						dictionary[nPCContext.StringId] = nPCContext;
					}
				}
			}
			if (nPCContext != null)
			{
				ProcessSingleNPC(nPCContext, text, currentDays);
			}
		}
	}

	private void ProcessEventTasks()
	{
		if (_pendingEventTasks.Count == 0)
		{
			return;
		}
		bool flag = GlobalSettings<ModSettings>.Instance?.EnableDetailedInfoLogging ?? false;
		if (_pendingEventTasks.Count > 0 && flag)
		{
			EventProcessingTask eventProcessingTask = _pendingEventTasks.Peek();
			if (eventProcessingTask.EventType == "Battle")
			{
				string arg = (IsEventPlayerInvolved(eventProcessingTask.EventType, eventProcessingTask.ExtraData) ? " (player involved)" : "");
				AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-QUEUE-PROCESS] Processing battle queue: {eventProcessingTask.PendingNpcIds.Count} NPCs remaining{arg}");
			}
		}
		int num = 1;
		for (int i = 0; i < num; i++)
		{
			if (_pendingEventTasks.Count <= 0)
			{
				break;
			}
			EventProcessingTask eventProcessingTask2 = _pendingEventTasks.Peek();
			int num2 = Math.Min(eventProcessingTask2.PendingNpcIds.Count, 15);
			for (int j = 0; j < num2; j++)
			{
				string text = eventProcessingTask2.PendingNpcIds[0];
				eventProcessingTask2.PendingNpcIds.RemoveAt(0);
				NPCContext nPCContext = AIInfluenceBehavior.Instance?.GetNPCContextByStringId(text);
				if (nPCContext != null)
				{
					Hero val = nPCContext.Hero;
					if (val == null || !val.IsAlive)
					{
						val = (nPCContext.Hero = AIInfluenceBehavior.Instance?.GetHeroById(text));
					}
					if (val != null && val.IsAlive)
					{
						if (eventProcessingTask2.EventType == "Battle" && flag)
						{
							AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-PROCESS-QUEUE] Processing {val.Name} ({text}) for battle event");
						}
						ProcessSingleNpcForEvent(val, nPCContext, eventProcessingTask2);
					}
				}
				else if (eventProcessingTask2.EventType == "Battle" && flag)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[BATTLE-PROCESS-QUEUE] SKIPPED " + text + " - no context found");
				}
			}
			if (eventProcessingTask2.PendingNpcIds.Count == 0)
			{
				_pendingEventTasks.Dequeue();
				continue;
			}
			break;
		}
	}

	private void ProcessSingleNpcForEvent(Hero npc, NPCContext context, EventProcessingTask task)
	{
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		switch (task.EventType)
		{
		case "SettlementCapture":
			if (task.ExtraData is SettlementCaptureData settlementCaptureData)
			{
				string personalizedSettlementEvent = GetPersonalizedSettlementEvent(npc, settlementCaptureData.Settlement, settlementCaptureData.NewOwner, settlementCaptureData.PreviousOwner, null, "", settlementCaptureData.PlayerInvolved, settlementCaptureData.PlayerRoleTag);
				CampaignEvent campaignEvent2 = new CampaignEvent
				{
					Type = "SettlementCapture",
					Description = personalizedSettlementEvent,
					Timestamp = task.BaseEvent.Timestamp
				};
				AddEventToNPCWithLogic(context, npc, campaignEvent2, task.Location, task.Participant, task.DeferSave, task.ExtraData);
			}
			break;
		case "Battle":
			if (task.ExtraData is BattleData bData)
			{
				ProcessBattleEventForNPC(npc, context, bData, task.BaseEvent.Timestamp, task.DeferSave);
			}
			break;
		case "HeroKilled":
			if (!(task.ExtraData is HeroKilledData heroKilledData))
			{
				break;
			}
			if (heroKilledData.Killer != null && npc == heroKilledData.Killer)
			{
				string description = "You " + GetDeathCauseDescriptionForKiller(heroKilledData.Detail, heroKilledData.Victim);
				CampaignEvent item = new CampaignEvent
				{
					Type = "HeroKilled",
					Description = description,
					Timestamp = task.BaseEvent.Timestamp
				};
				if (context.RecentEvents == null)
				{
					context.RecentEvents = new List<CampaignEvent>();
				}
				context.RecentEvents.Add(item);
				UpdateEmotionalStateOnDeath(npc, context, heroKilledData.Victim, heroKilledData.Killer);
				AIInfluenceBehavior.Instance?.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			}
			else
			{
				string personalizedDeathEvent = GetPersonalizedDeathEvent(npc, context, heroKilledData.Victim, heroKilledData.Killer, heroKilledData.BaseText, heroKilledData.Detail, task.Location, heroKilledData.PlayerInvolved, heroKilledData.PlayerRoleTag);
				CampaignEvent campaignEvent = new CampaignEvent
				{
					Type = "HeroKilled",
					Description = personalizedDeathEvent,
					Timestamp = task.BaseEvent.Timestamp
				};
				if (AddEventToNPCWithLogic(context, npc, campaignEvent, task.Location, task.Participant, task.DeferSave, task.ExtraData))
				{
					UpdateEmotionalStateOnDeath(npc, context, heroKilledData.Victim, heroKilledData.Killer);
				}
			}
			break;
		case "Marriage":
			if (!(task.ExtraData is MarriageData marriageData))
			{
				break;
			}
			if (npc == marriageData.Proposer)
			{
				string description2 = $"I married {marriageData.ProposedTo.Name} (id:{((MBObjectBase)marriageData.ProposedTo).StringId}){marriageData.MarriageType}";
				CampaignEvent item2 = new CampaignEvent
				{
					Type = "Marriage",
					Description = description2,
					Timestamp = task.BaseEvent.Timestamp
				};
				if (context.RecentEvents == null)
				{
					context.RecentEvents = new List<CampaignEvent>();
				}
				context.RecentEvents.Add(item2);
				AIInfluenceBehavior.Instance?.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			}
			else if (npc == marriageData.ProposedTo)
			{
				string description3 = $"I married {marriageData.Proposer.Name} (id:{((MBObjectBase)marriageData.Proposer).StringId}){marriageData.MarriageType}";
				CampaignEvent item3 = new CampaignEvent
				{
					Type = "Marriage",
					Description = description3,
					Timestamp = task.BaseEvent.Timestamp
				};
				if (context.RecentEvents == null)
				{
					context.RecentEvents = new List<CampaignEvent>();
				}
				context.RecentEvents.Add(item3);
				AIInfluenceBehavior.Instance?.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			}
			else
			{
				AddEventToNPCWithLogic(context, npc, task.BaseEvent, task.Location, task.Participant, task.DeferSave, task.ExtraData);
			}
			break;
		case "PrisonerTaken":
		case "PrisonerReleased":
			if (task.ExtraData is PrisonerEventData pData)
			{
				ProcessPrisonerEventForNPC(npc, context, pData, task.BaseEvent.Timestamp, task.DeferSave);
			}
			break;
		case "Tournament":
			if (task.ExtraData is TournamentData tData)
			{
				ProcessTournamentEventForNPC(npc, context, tData, task.BaseEvent.Timestamp, task.DeferSave);
			}
			break;
		default:
			AddEventToNPCWithLogic(context, npc, task.BaseEvent, task.Location, task.Participant, task.DeferSave, task.ExtraData);
			break;
		}
	}

	private void ProcessPrisonerEventForNPC(Hero npc, NPCContext context, PrisonerEventData pData, CampaignTime timestamp, bool deferSave)
	{
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		string type = pData.Type;
		string text3;
		if (npc == pData.Prisoner)
		{
			if (type == "PrisonerTaken")
			{
				string text = "unknown";
				if (pData.Participant != null)
				{
					text = ((object)pData.Participant.Name)?.ToString() ?? "unknown";
					if (pData.Participant.Clan != null)
					{
						text += $" (clan:{pData.Participant.Clan.Name}";
						if (pData.Participant.Clan.Kingdom != null)
						{
							text += $", kingdom:{pData.Participant.Clan.Kingdom.Name}";
						}
						text = text + ", id:" + ((MBObjectBase)pData.Participant).StringId + ")";
					}
					else
					{
						text = text + " (id:" + ((MBObjectBase)pData.Participant).StringId + ")";
					}
				}
				string text2 = text;
				Settlement location = pData.Location;
				text3 = "I was captured by " + text2 + " and taken to " + (((location == null) ? null : ((object)location.Name)?.ToString()) ?? "an unknown location");
			}
			else
			{
				string text4 = "unknown";
				if (pData.Participant != null)
				{
					text4 = ((object)pData.Participant.Name)?.ToString() ?? "unknown";
					if (pData.Participant.Clan != null)
					{
						text4 += $" (clan:{pData.Participant.Clan.Name}";
						if (pData.Participant.Clan.Kingdom != null)
						{
							text4 += $", kingdom:{pData.Participant.Clan.Kingdom.Name}";
						}
						text4 = text4 + ", id:" + ((MBObjectBase)pData.Participant).StringId + ")";
					}
					else
					{
						text4 = text4 + " (id:" + ((MBObjectBase)pData.Participant).StringId + ")";
					}
				}
				string text5 = text4;
				Settlement location2 = pData.Location;
				text3 = "I was released from captivity by " + text5 + " at " + (((location2 == null) ? null : ((object)location2.Name)?.ToString()) ?? "an unknown location");
			}
		}
		else if (pData.Participant != null && npc == pData.Participant)
		{
			if (type == "PrisonerTaken")
			{
				string text6 = ((object)pData.Prisoner.Name)?.ToString() ?? "unknown";
				if (pData.Prisoner.Clan != null)
				{
					text6 += $" (clan:{pData.Prisoner.Clan.Name}";
					if (pData.Prisoner.Clan.Kingdom != null)
					{
						text6 += $", kingdom:{pData.Prisoner.Clan.Kingdom.Name}";
					}
					text6 = text6 + ", id:" + ((MBObjectBase)pData.Prisoner).StringId + ")";
				}
				else
				{
					text6 = text6 + " (id:" + ((MBObjectBase)pData.Prisoner).StringId + ")";
				}
				string text7 = text6;
				Settlement location3 = pData.Location;
				text3 = "I captured " + text7 + " and took them to " + (((location3 == null) ? null : ((object)location3.Name)?.ToString()) ?? "an unknown location");
			}
			else
			{
				string text8 = ((object)pData.Prisoner.Name)?.ToString() ?? "unknown";
				if (pData.Prisoner.Clan != null)
				{
					text8 += $" (clan:{pData.Prisoner.Clan.Name}";
					if (pData.Prisoner.Clan.Kingdom != null)
					{
						text8 += $", kingdom:{pData.Prisoner.Clan.Kingdom.Name}";
					}
					text8 = text8 + ", id:" + ((MBObjectBase)pData.Prisoner).StringId + ")";
				}
				else
				{
					text8 = text8 + " (id:" + ((MBObjectBase)pData.Prisoner).StringId + ")";
				}
				string text9 = text8;
				Settlement location4 = pData.Location;
				text3 = "I released " + text9 + " from captivity at " + (((location4 == null) ? null : ((object)location4.Name)?.ToString()) ?? "an unknown location");
			}
		}
		else
		{
			text3 = pData.Description;
		}
		string description = (pData.IsPlayerInvolved ? ("(player involved) " + text3) : text3);
		CampaignEvent campaignEvent = new CampaignEvent
		{
			Type = type,
			Description = description,
			Timestamp = timestamp
		};
		bool flag = AddEventToNPCWithLogic(context, npc, campaignEvent, pData.Location, pData.Prisoner, deferSave, pData);
		if (flag && npc == pData.Prisoner)
		{
			if (type == "PrisonerTaken")
			{
				EmotionalState obj = new EmotionalState
				{
					Mood = "captured"
				};
				Hero participant = pData.Participant;
				obj.Reason = "I was captured by " + (((participant == null) ? null : ((object)participant.Name)?.ToString()) ?? "unknown");
				context.EmotionalState = obj;
			}
			else
			{
				EmotionalState obj2 = new EmotionalState
				{
					Mood = "relieved"
				};
				Hero participant2 = pData.Participant;
				obj2.Reason = "I was released from captivity by " + (((participant2 == null) ? null : ((object)participant2.Name)?.ToString()) ?? "unknown");
				context.EmotionalState = obj2;
			}
			if (!deferSave && AIInfluenceBehavior.Instance != null)
			{
				AIInfluenceBehavior.Instance.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			}
		}
		else if (flag && pData.Participant != null && npc == pData.Participant)
		{
			if (type == "PrisonerTaken")
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "triumphant",
					Reason = "I captured " + (((object)pData.Prisoner.Name)?.ToString() ?? "unknown")
				};
			}
			else
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "benevolent",
					Reason = "I released " + (((object)pData.Prisoner.Name)?.ToString() ?? "unknown")
				};
			}
			if (!deferSave && AIInfluenceBehavior.Instance != null)
			{
				AIInfluenceBehavior.Instance.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			}
		}
	}

	private void ProcessTournamentEventForNPC(Hero npc, NPCContext context, TournamentData tData, CampaignTime timestamp, bool deferSave)
	{
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		Settlement settlement = tData.Settlement;
		string text = ((settlement == null) ? null : ((object)settlement.Name)?.ToString()) ?? "unknown settlement";
		Settlement settlement2 = tData.Settlement;
		string text2 = ((settlement2 != null) ? ((MBObjectBase)settlement2).StringId : null) ?? "unknown";
		Hero winner = tData.Winner;
		string text3 = ((winner == null) ? null : ((object)winner.Name)?.ToString()) ?? "unknown";
		Hero winner2 = tData.Winner;
		string text4 = ((winner2 != null) ? ((MBObjectBase)winner2).StringId : null) ?? "unknown";
		bool flag = tData.ParticipantIds.Contains(((MBObjectBase)npc).StringId);
		bool flag2 = tData.Winner != null && npc == tData.Winner;
		bool flag3 = npc.IsPlayerCompanion && npc.PartyBelongedTo == Hero.MainHero.PartyBelongedTo;
		string description;
		if (flag2)
		{
			description = "I won the tournament in " + text + " (id:" + text2 + ")";
		}
		else if (flag)
		{
			description = "I participated in the tournament in " + text + " (id:" + text2 + "), which was won by " + text3 + " (id:" + text4 + ")";
		}
		else if (flag3 && tData.IsPlayerInvolved)
		{
			if (tData.PlayerWon)
			{
				description = "The player won the tournament in " + text + " (id:" + text2 + ") while I was traveling with them";
			}
			else if (tData.PlayerParticipated)
			{
				description = "The player participated in the tournament in " + text + " (id:" + text2 + "), which was won by " + text3 + " (id:" + text4 + "), while I was traveling with them";
			}
			else if (tData.ClanMemberWon && tData.ClanMemberWinner != null)
			{
				string text5 = ((object)tData.ClanMemberWinner.Name)?.ToString() ?? "unknown";
				string text6 = ((MBObjectBase)tData.ClanMemberWinner).StringId ?? "unknown";
				description = "A member of the player's clan, " + text5 + " (id:" + text6 + "), won the tournament in " + text + " (id:" + text2 + ") while I was traveling with the player";
			}
			else if (tData.ClanMemberParticipated && tData.ClanMemberParticipant != null)
			{
				string text7 = ((object)tData.ClanMemberParticipant.Name)?.ToString() ?? "unknown";
				string text8 = ((MBObjectBase)tData.ClanMemberParticipant).StringId ?? "unknown";
				description = "A member of the player's clan, " + text7 + " (id:" + text8 + "), participated in the tournament in " + text + " (id:" + text2 + "), which was won by " + text3 + " (id:" + text4 + "), while I was traveling with the player";
			}
			else
			{
				description = "A tournament in " + text + " (id:" + text2 + ") was won by " + text3 + " (id:" + text4 + ") while I was traveling with the player";
			}
		}
		else
		{
			Hero val = null;
			bool flag4 = false;
			if (npc.Clan != null && tData.ParticipantHeroes != null)
			{
				foreach (Hero participantHero in tData.ParticipantHeroes)
				{
					if (participantHero != null && participantHero.Clan != null && participantHero.Clan == npc.Clan && participantHero != npc)
					{
						val = participantHero;
						if (tData.Winner != null && participantHero == tData.Winner)
						{
							flag4 = true;
						}
						break;
					}
				}
			}
			if (flag4 && val != null)
			{
				string text9 = ((object)val.Name)?.ToString() ?? "unknown";
				string text10 = ((MBObjectBase)val).StringId ?? "unknown";
				description = "My clan member " + text9 + " (id:" + text10 + ") won the tournament in " + text + " (id:" + text2 + ")";
			}
			else if (val != null)
			{
				string text11 = ((object)val.Name)?.ToString() ?? "unknown";
				string text12 = ((MBObjectBase)val).StringId ?? "unknown";
				description = "My clan member " + text11 + " (id:" + text12 + ") participated in the tournament in " + text + " (id:" + text2 + "), which was won by " + text3 + " (id:" + text4 + ")";
			}
			else if (npc.Clan != null && tData.Winner != null && tData.Winner.Clan != null && tData.Winner.Clan == npc.Clan && tData.Winner != npc)
			{
				string text13 = ((object)tData.Winner.Name)?.ToString() ?? "unknown";
				string text14 = ((MBObjectBase)tData.Winner).StringId ?? "unknown";
				description = "My clan member " + text13 + " (id:" + text14 + ") won the tournament in " + text + " (id:" + text2 + ")";
			}
			else
			{
				description = "Tournament in " + text + " (id:" + text2 + ") won by " + text3 + " (id:" + text4 + ")";
			}
		}
		CampaignEvent campaignEvent = new CampaignEvent
		{
			Type = "Tournament",
			Description = description,
			Timestamp = timestamp
		};
		if (AddEventToNPCWithLogic(context, npc, campaignEvent, tData.Settlement, tData.Winner, deferSave, tData) && (flag2 || flag))
		{
			if (flag2)
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "victorious",
					Reason = "I won the tournament in " + text + " (id:" + text2 + ")"
				};
			}
			else
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "competitive",
					Reason = "I participated in the tournament in " + text + " (id:" + text2 + ")"
				};
			}
			if (!deferSave && AIInfluenceBehavior.Instance != null)
			{
				AIInfluenceBehavior.Instance.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			}
		}
	}

	private void ProcessBattleEventForNPC(Hero npc, NPCContext context, BattleData bData, CampaignTime timestamp, bool deferSave)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Invalid comparison between Unknown and I4
		//IL_086c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Invalid comparison between Unknown and I4
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Invalid comparison between Unknown and I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Invalid comparison between Unknown and I4
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Invalid comparison between Unknown and I4
		//IL_09b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Invalid comparison between Unknown and I4
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Invalid comparison between Unknown and I4
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Invalid comparison between Unknown and I4
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Invalid comparison between Unknown and I4
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Invalid comparison between Unknown and I4
		bool flag = bData.AttackerHeroIds.Contains(((MBObjectBase)npc).StringId);
		bool flag2 = bData.DefenderHeroIds.Contains(((MBObjectBase)npc).StringId);
		bool flag3 = flag || flag2;
		if ((int)bData.BattleType == 5 && bData.BattleSettlement != null && (npc == bData.BattleSettlement.Owner || npc.Clan == bData.BattleSettlement.OwnerClan))
		{
			flag3 = true;
			flag2 = true;
		}
		bool flag4 = ((int)bData.WinningSide == 1 && flag) || ((int)bData.WinningSide == 0 && flag2);
		List<string> list = new List<string>();
		HashSet<string> hashSet = ((!flag4) ? (((int)bData.WinningSide == 1) ? bData.DefenderHeroIds : bData.AttackerHeroIds) : (((int)bData.WinningSide == 1) ? bData.AttackerHeroIds : bData.DefenderHeroIds));
		if (hashSet != null && hashSet.Count > 1)
		{
			AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
			foreach (string item in hashSet)
			{
				if (!(item != ((MBObjectBase)npc).StringId))
				{
					continue;
				}
				Hero val = instance?.GetHeroById(item);
				if (val == null || !val.IsAlive)
				{
					continue;
				}
				string text = ((object)val.Name).ToString();
				if (val.Clan != null)
				{
					text += $" (clan:{val.Clan.Name}";
					if (val.Clan.Kingdom != null)
					{
						text += $", kingdom:{val.Clan.Kingdom.Name}";
					}
					text = text + ", id:" + ((MBObjectBase)val).StringId + ")";
				}
				else
				{
					text = text + " (id:" + ((MBObjectBase)val).StringId + ")";
				}
				list.Add(text);
			}
		}
		string text5;
		if (flag3)
		{
			string text2 = (((int)bData.BattleType == 5) ? "siege" : "field battle");
			if ((int)bData.BattleType != 5)
			{
				Campaign current2 = Campaign.Current;
				if (((current2 != null) ? current2.MapSceneWrapper : null) != null)
				{
					IMapScene mapSceneWrapper = Campaign.Current.MapSceneWrapper;
					CampaignVec2 val2 = new CampaignVec2(bData.Position, true);
					TerrainType terrainTypeAtPosition = mapSceneWrapper.GetTerrainTypeAtPosition(ref val2);
					if ((int)terrainTypeAtPosition == 10 || (int)terrainTypeAtPosition == 8 || (int)terrainTypeAtPosition == 19 || (int)terrainTypeAtPosition == 18 || (int)terrainTypeAtPosition == 11)
					{
						text2 = "naval battle";
					}
				}
			}
			string text3 = "";
			if (bData.BattleSettlement != null)
			{
				string arg = (bData.BattleSettlement.IsTown ? "town" : (bData.BattleSettlement.IsCastle ? "castle" : "village"));
				text3 = $" at {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) {arg}";
			}
			string text4 = "";
			if (list.Count > 0)
			{
				text4 = ((list.Count != 1) ? (" together with " + string.Join(", ", list)) : (" together with " + list[0]));
			}
			text5 = (((int)bData.BattleType == 5 && bData.BattleSettlement != null) ? (flag4 ? (flag2 ? ((npc != bData.WinnerHero) ? $"We successfully defended {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) from siege by {bData.LosingSideInfo}{text4}. Our {bData.WinnerStats} repelled their {bData.LoserStats}." : $"I successfully defended {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) from siege by {bData.LosingSideInfo}{text4}. My {bData.WinnerStats} repelled their {bData.LoserStats}.") : ((npc != bData.WinnerHero) ? $"We won a {text2} and captured {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) from {bData.LosingSideInfo}{text4}. Our {bData.WinnerStats} defeated their {bData.LoserStats}." : $"I won a {text2} and captured {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) from {bData.LosingSideInfo}{text4}. My {bData.WinnerStats} defeated their {bData.LoserStats}.")) : (flag2 ? ((npc != bData.LoserHero) ? $"We lost a {text2} and {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) was captured by {bData.WinningSideInfo}{text4}. Our {bData.LoserStats} were defeated by their {bData.WinnerStats}." : $"I lost a {text2} and {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) was captured by {bData.WinningSideInfo}{text4}. My {bData.LoserStats} were defeated by their {bData.WinnerStats}.") : ((npc != bData.LoserHero) ? $"We failed to capture {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) in a siege. Our {bData.LoserStats} were defeated by {bData.WinningSideInfo}{text4} with {bData.WinnerStats}." : $"I failed to capture {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) in a siege. My {bData.LoserStats} were defeated by {bData.WinningSideInfo}{text4} with {bData.WinnerStats}."))) : ((npc == bData.WinnerHero) ? ("I won a " + text2 + " against " + bData.LosingSideInfo + text4 + text3 + ". My " + bData.WinnerStats + " defeated their " + bData.LoserStats + ".") : (flag4 ? ("We won a " + text2 + " against " + bData.LosingSideInfo + text4 + text3 + ". Our " + bData.WinnerStats + " defeated their " + bData.LoserStats + ".") : ((npc != bData.LoserHero) ? ("We were defeated in a " + text2 + " against " + bData.WinningSideInfo + text4 + text3 + ". Our " + bData.LoserStats + " were defeated by their " + bData.WinnerStats + ".") : ("I lost a " + text2 + " against " + bData.WinningSideInfo + text4 + text3 + ". My " + bData.LoserStats + " were defeated by their " + bData.WinnerStats + ".")))));
		}
		else
		{
			string text6 = (((int)bData.BattleType == 5) ? "siege" : "field battle");
			string text7 = "";
			if (bData.BattleSettlement != null)
			{
				string arg2 = (bData.BattleSettlement.IsTown ? "town" : (bData.BattleSettlement.IsCastle ? "castle" : "village"));
				text7 = $" at {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) {arg2}";
			}
			text5 = text6 + " ended" + text7 + ": " + bData.WinningSideInfo + " with " + bData.WinnerStats + " defeated " + bData.LosingSideInfo + " with " + bData.LoserStats + ".";
		}
		string description = (bData.IsPlayerInvolved ? (((!string.IsNullOrEmpty(bData.PlayerInvolvementTag)) ? (bData.PlayerInvolvementTag + " ") : "(player involved) ") + text5) : text5);
		CampaignEvent campaignEvent = new CampaignEvent
		{
			Type = "Battle",
			Description = description,
			Timestamp = timestamp
		};
		bool flag5 = GlobalSettings<ModSettings>.Instance?.EnableDetailedInfoLogging ?? false;
		string text8 = (bData.IsPlayerInvolved ? " (player involved)" : "");
		if (flag5)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-PROCESS] Processing battle event for {npc.Name} (direct: {flag3}, attacker: {flag}, defender: {flag2}){text8}");
		}
		bool flag6 = AddEventToNPCWithLogic(context, npc, campaignEvent, bData.BattleSettlement, bData.WinnerHero, deferSave, bData);
		if (flag5)
		{
			if (flag6)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-PROCESS] {npc.Name} learned about battle{text8}");
			}
			else
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-PROCESS] {npc.Name} did NOT learn about battle{text8}");
			}
		}
		if (flag6 && flag3)
		{
			UpdateEmotionalStateOnBattle(npc, context, bData, flag4);
		}
	}

	private void UpdateEmotionalStateOnBattle(Hero npc, NPCContext context, BattleData bData, bool wasOnWinningSide)
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Invalid comparison between Unknown and I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Invalid comparison between Unknown and I4
		if (wasOnWinningSide)
		{
			if ((int)bData.BattleType == 5 && bData.BattleSettlement != null && (npc == bData.BattleSettlement.Owner || npc.Clan == bData.BattleSettlement.OwnerClan))
			{
				if (npc == bData.WinnerHero)
				{
					context.EmotionalState = new EmotionalState
					{
						Mood = "victorious",
						Reason = $"I successfully defended {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) from siege"
					};
				}
				else
				{
					context.EmotionalState = new EmotionalState
					{
						Mood = "proud",
						Reason = $"we successfully defended {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) from siege"
					};
				}
			}
			else if (npc == bData.WinnerHero)
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "victorious",
					Reason = "I led my forces to victory against " + bData.LosingSideInfo
				};
			}
			else
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "proud",
					Reason = "we won the battle against " + bData.LosingSideInfo
				};
			}
		}
		else if ((int)bData.BattleType == 5 && bData.BattleSettlement != null && (npc == bData.BattleSettlement.Owner || npc.Clan == bData.BattleSettlement.OwnerClan))
		{
			if (npc == bData.LoserHero)
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "devastated",
					Reason = $"I lost {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) to {bData.WinningSideInfo} in siege"
				};
			}
			else
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "demoralized",
					Reason = $"we lost {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) to {bData.WinningSideInfo} in siege"
				};
			}
		}
		else if ((int)bData.BattleType == 5 && bData.BattleSettlement != null)
		{
			if (npc == bData.LoserHero)
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "defeated",
					Reason = $"I failed to capture {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) from {bData.WinningSideInfo}"
				};
			}
			else
			{
				context.EmotionalState = new EmotionalState
				{
					Mood = "demoralized",
					Reason = $"we failed to capture {bData.BattleSettlement.Name} (id:{((MBObjectBase)bData.BattleSettlement).StringId}) from {bData.WinningSideInfo}"
				};
			}
		}
		else if (npc == bData.LoserHero)
		{
			context.EmotionalState = new EmotionalState
			{
				Mood = "defeated",
				Reason = "I was defeated by " + bData.WinningSideInfo
			};
		}
		else
		{
			context.EmotionalState = new EmotionalState
			{
				Mood = "demoralized",
				Reason = "we lost the battle against " + bData.WinningSideInfo
			};
		}
	}

	private void UpdateEmotionalStateOnDeath(Hero npc, NPCContext context, Hero victim, Hero killer)
	{
		EmotionalState emotionalState = DetermineEmotionalResponseToDeath(npc, victim, killer);
		if (emotionalState == null)
		{
			return;
		}
		context.EmotionalState = emotionalState;
		AIInfluenceBehavior.Instance?.LogMessage($"[EMOTION] {npc.Name} emotional state changed to '{emotionalState.Mood}' because {emotionalState.Reason}");
		if (AIInfluenceBehavior.Instance != null)
		{
			string nPCFilePath = AIInfluenceBehavior.Instance.GetNPCFilePath(((MBObjectBase)npc).StringId);
			if (!string.IsNullOrEmpty(nPCFilePath))
			{
				AIInfluenceBehavior.Instance.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			}
		}
	}

	private void ProcessSingleNPC(NPCContext context, string npcId, float currentDays)
	{
		CleanOldEvents(context);
		ProcessRomanceDecay(context);
		UpdateLastSeenFriendsForNPC(context, npcId, currentDays);
	}

	private void UpdateLastSeenFriendsForNPC(NPCContext context, string npcId, float currentDays)
	{
		if (string.IsNullOrEmpty(context.StringId))
		{
			return;
		}
		Hero npc = context.Hero;
		if (npc == null || !npc.IsAlive)
		{
			npc = AIInfluenceBehavior.Instance.GetHeroById(context.StringId);
			context.Hero = npc;
		}
		if (npc == null)
		{
			return;
		}
		if (context.LastSeenFriends == null)
		{
			context.LastSeenFriends = new Dictionary<string, float>();
		}
		bool flag = false;
		List<Hero> list = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h != npc && h != null && npc.IsFriend(h)).ToList();
		if (npc.IsPlayerCompanion && npc.PartyBelongedTo == Hero.MainHero.PartyBelongedTo)
		{
			List<Hero> list2 = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h != npc && h != null && h.IsPlayerCompanion && h.PartyBelongedTo == Hero.MainHero.PartyBelongedTo).ToList();
			foreach (Hero item in list2)
			{
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		foreach (Hero item2 in list)
		{
			if (IsHeroesNearby(npc, item2))
			{
				context.LastSeenFriends[((MBObjectBase)item2).StringId] = currentDays;
				flag = true;
			}
		}
		if (flag && AIInfluenceBehavior.Instance != null)
		{
			AIInfluenceBehavior.Instance.SaveNPCContext(npcId, npc, context);
		}
	}

	private bool IsHeroesNearby(Hero hero1, Hero hero2)
	{
		if (hero1 == null || hero2 == null)
		{
			return false;
		}
		if (hero1.PartyBelongedTo != null && hero2.PartyBelongedTo != null && hero1.PartyBelongedTo == hero2.PartyBelongedTo)
		{
			return true;
		}
		MobileParty partyBelongedTo = hero1.PartyBelongedTo;
		if (((partyBelongedTo != null) ? partyBelongedTo.Army : null) != null)
		{
			MobileParty partyBelongedTo2 = hero2.PartyBelongedTo;
			if (((partyBelongedTo2 != null) ? partyBelongedTo2.Army : null) != null && hero1.PartyBelongedTo.Army == hero2.PartyBelongedTo.Army)
			{
				return true;
			}
		}
		if (hero1.CurrentSettlement != null && hero2.CurrentSettlement != null && hero1.CurrentSettlement == hero2.CurrentSettlement)
		{
			return true;
		}
		return false;
	}

	private void OnHourlyTick()
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, NPCContext> npcContextsDict = AIInfluenceBehavior.Instance?.GetNPCContexts();
		if (npcContextsDict == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] No NPC contexts available for hourly tick.");
			return;
		}
		List<string> list = npcContextsDict.Keys.ToList();
		if (list == null || list.Count == 0)
		{
			return;
		}
		NPCContext value;
		List<NPCContext> list2 = (from k in list
			select npcContextsDict.TryGetValue(k, out value) ? value : null into c
			where c != null
			select c).ToList();
		if (list2 == null || !list2.Any())
		{
			return;
		}
		foreach (NPCContext item in list2)
		{
			if (item.TimeContext != null)
			{
				CampaignTime val = CampaignTime.Now - item.TimeContext.LastUpdated;
				if (!((val).ToHours >= 2.0))
				{
					continue;
				}
			}
			UpdateTimeContext(item);
		}
	}

	private void OnWarDeclared(IFaction factionDeclaringWar, IFaction factionDeclaredWarAgainst, DeclareWarDetail detail)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		if (factionDeclaringWar == null || factionDeclaredWarAgainst == null)
		{
			return;
		}
		string arg = (factionDeclaringWar.IsKingdomFaction ? $"{factionDeclaringWar.Name} (kingdom_id:{factionDeclaringWar.StringId})" : $"{factionDeclaringWar.Name} (clan_id:{factionDeclaringWar.StringId})");
		string arg2 = (factionDeclaredWarAgainst.IsKingdomFaction ? $"{factionDeclaredWarAgainst.Name} (kingdom_id:{factionDeclaredWarAgainst.StringId})" : $"{factionDeclaredWarAgainst.Name} (clan_id:{factionDeclaredWarAgainst.StringId})");
		string text = (((factionDeclaringWar is Clan && factionDeclaredWarAgainst is Kingdom) || (factionDeclaringWar is Kingdom && factionDeclaredWarAgainst is Clan)) ? $"WAR DECLARED: {arg} declared war on {arg2} (minor conflict) ({detail})" : $"WAR DECLARED: {arg} declared war on {arg2} ({detail})");
		if ((object)Hero.MainHero.Clan == factionDeclaringWar || (object)Hero.MainHero.Clan == factionDeclaredWarAgainst || Hero.MainHero.MapFaction == factionDeclaringWar || Hero.MainHero.MapFaction == factionDeclaredWarAgainst)
		{
			string text2 = "";
			text2 = (((object)Hero.MainHero.Clan != factionDeclaringWar && Hero.MainHero.MapFaction != factionDeclaringWar) ? "(war was declared against your faction)" : "(your faction declared war)");
			string text3 = $"(player's clan: {Hero.MainHero.Clan.Name}, clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId})";
			text = text + " " + text2 + " " + text3;
		}
		Dictionary<string, NPCContext> npcContextsDict = AIInfluenceBehavior.Instance?.GetNPCContexts();
		if (npcContextsDict == null || !npcContextsDict.Any())
		{
			return;
		}
		List<string> source = npcContextsDict.Keys.ToList();
		NPCContext value;
		List<NPCContext> list = (from k in source
			select npcContextsDict.TryGetValue(k, out value) ? value : null into c
			where c != null
			select c).ToList();
		CampaignEvent ev = new CampaignEvent
		{
			Type = "WarDeclared",
			Description = text,
			Timestamp = CampaignTime.Now
		};
		WarDeclaredData extra = new WarDeclaredData
		{
			Faction1 = factionDeclaringWar,
			Faction2 = factionDeclaredWarAgainst
		};
		Hero part = null;
		Clan val = (Clan)(object)((factionDeclaringWar is Clan) ? factionDeclaringWar : null);
		if (val != null && val.Leader != null)
		{
			part = val.Leader;
		}
		else
		{
			Kingdom val2 = (Kingdom)(object)((factionDeclaringWar is Kingdom) ? factionDeclaringWar : null);
			if (val2 != null && val2.Leader != null)
			{
				part = val2.Leader;
			}
		}
		QueueEventForInformedNPCs(ev, null, part, null, defer: false, extra);
	}

	private void OnTournamentFinished(CharacterObject winner, MBReadOnlyList<CharacterObject> participants, Town town, ItemObject prize)
	{
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		if (((town != null) ? ((SettlementComponent)town).Settlement : null) == null)
		{
			return;
		}
		string text = ((object)((SettlementComponent)town).Settlement.Name).ToString();
		string stringId = ((MBObjectBase)((SettlementComponent)town).Settlement).StringId;
		string text2 = ((object)((BasicCharacterObject)winner).Name).ToString();
		Hero heroObject = winner.HeroObject;
		string text3 = ((heroObject != null) ? ((MBObjectBase)heroObject).StringId : null) ?? "unknown";
		bool flag = winner == Hero.MainHero.CharacterObject;
		bool flag2 = ((List<CharacterObject>)(object)participants).Contains(Hero.MainHero.CharacterObject);
		bool flag3 = !flag && winner.HeroObject != null && winner.HeroObject.Clan == Hero.MainHero.Clan;
		Hero clanMemberWinner = (flag3 ? winner.HeroObject : null);
		CharacterObject val = ((IEnumerable<CharacterObject>)participants).FirstOrDefault((Func<CharacterObject, bool>)((CharacterObject p) => p.HeroObject != null && p.HeroObject != Hero.MainHero && p.HeroObject.Clan == Hero.MainHero.Clan));
		bool flag4 = val != null && !flag2;
		Hero clanMemberParticipant = (flag4 ? val.HeroObject : null);
		bool flag5 = flag || flag2 || flag3 || flag4;
		TournamentData tournamentData = new TournamentData
		{
			Settlement = ((SettlementComponent)town).Settlement,
			Winner = winner.HeroObject,
			IsPlayerInvolved = flag5,
			PlayerWon = flag,
			PlayerParticipated = flag2,
			ClanMemberWon = flag3,
			ClanMemberParticipated = flag4,
			ClanMemberWinner = clanMemberWinner,
			ClanMemberParticipant = clanMemberParticipant
		};
		foreach (CharacterObject item in (List<CharacterObject>)(object)participants)
		{
			if (((BasicCharacterObject)item).IsHero && item.HeroObject != null)
			{
				tournamentData.ParticipantIds.Add(((MBObjectBase)item.HeroObject).StringId);
				tournamentData.ParticipantHeroes.Add(item.HeroObject);
			}
		}
		if (winner.HeroObject != null && !tournamentData.ParticipantIds.Contains(((MBObjectBase)winner.HeroObject).StringId))
		{
			tournamentData.ParticipantIds.Add(((MBObjectBase)winner.HeroObject).StringId);
			tournamentData.ParticipantHeroes.Add(winner.HeroObject);
		}
		string text4 = "Tournament in " + text + " (id:" + stringId + ") won by " + text2 + " (id:" + text3 + ")";
		if (flag5)
		{
			string text5 = "";
			if (winner == Hero.MainHero.CharacterObject)
			{
				text5 = "(you won)";
			}
			else if (winner.HeroObject != null && winner.HeroObject.Clan == Hero.MainHero.Clan)
			{
				text5 = $"(won by your clan member {winner.HeroObject.Name})";
			}
			else if (((List<CharacterObject>)(object)participants).Contains(Hero.MainHero.CharacterObject))
			{
				text5 = "(you participated)";
			}
			else
			{
				CharacterObject val2 = ((IEnumerable<CharacterObject>)participants).FirstOrDefault((Func<CharacterObject, bool>)((CharacterObject p) => p.HeroObject != null && p.HeroObject.Clan == Hero.MainHero.Clan));
				text5 = $"(your clan member {((val2 != null) ? ((BasicCharacterObject)val2).Name : null)} participated)";
			}
			string text6 = $"(player's clan: {Hero.MainHero.Clan.Name}, clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId})";
			text4 = text4 + " " + text5 + " " + text6;
		}
		CampaignEvent ev = new CampaignEvent
		{
			Type = "Tournament",
			Description = text4,
			Timestamp = CampaignTime.Now
		};
		HashSet<string> hashSet = new HashSet<string>();
		if (winner.HeroObject != null)
		{
			hashSet.Add(((MBObjectBase)winner.HeroObject).StringId);
		}
		foreach (string participantId in tournamentData.ParticipantIds)
		{
			hashSet.Add(participantId);
		}
		if (flag5 && Hero.MainHero.PartyBelongedTo != null)
		{
			List<Hero> list = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h != null && h != Hero.MainHero && h.IsPlayerCompanion && h.PartyBelongedTo == Hero.MainHero.PartyBelongedTo && !h.IsDead && !h.IsPrisoner).ToList();
			foreach (Hero item2 in list)
			{
				if (!hashSet.Contains(((MBObjectBase)item2).StringId))
				{
					hashSet.Add(((MBObjectBase)item2).StringId);
				}
			}
		}
		Hero heroObject2 = winner.HeroObject;
		HashSet<string> collection = AddEventToDirectParticipantsImmediately("Tournament", ev, ((SettlementComponent)town).Settlement, heroObject2, hashSet, tournamentData);
		HashSet<string> hashSet2 = new HashSet<string>(collection);
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance != null && ((SettlementComponent)town).Settlement != null)
		{
			Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
			if (nPCContexts != null)
			{
				List<string> list2 = nPCContexts.Keys.ToList();
				foreach (string item3 in list2)
				{
					if (!nPCContexts.TryGetValue(item3, out var value) || value == null)
					{
						continue;
					}
					Hero val3 = value.Hero;
					if (val3 == null || !val3.IsAlive)
					{
						val3 = instance.GetHeroById(item3);
						if (val3 == null || !val3.IsAlive)
						{
							continue;
						}
						value.Hero = val3;
					}
					if (!hashSet2.Contains(item3))
					{
						bool flag6 = false;
						if (val3.CurrentSettlement == ((SettlementComponent)town).Settlement)
						{
							flag6 = true;
						}
						else if (val3.PartyBelongedTo != null && val3.PartyBelongedTo.CurrentSettlement == ((SettlementComponent)town).Settlement)
						{
							flag6 = true;
						}
						if (flag6)
						{
							EventProcessingTask task = new EventProcessingTask("Tournament", ev, ((SettlementComponent)town).Settlement, heroObject2, new List<string> { item3 }, defer: false, tournamentData);
							ProcessSingleNpcForEvent(val3, value, task);
							instance.SaveNPCContextImmediate(item3, val3, value);
							hashSet2.Add(item3);
						}
					}
				}
			}
		}
		QueueEventForInformedNPCs(ev, ((SettlementComponent)town).Settlement, heroObject2, null, defer: false, tournamentData, hashSet2);
	}

	private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturer, ChangeOwnerOfSettlementDetail detail)
	{
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] OnSettlementOwnerChanged called with null settlement!");
			return;
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] OnSettlementOwnerChanged triggered for {settlement.Name}.");
		string text = ((object)settlement.Name).ToString();
		string stringId = ((MBObjectBase)settlement).StringId;
		string ownerInfo = GetOwnerInfo(oldOwner);
		string ownerInfo2 = GetOwnerInfo(newOwner);
		string text2 = ((!(ownerInfo == ownerInfo2)) ? (text + " (id:" + stringId + ") captured by " + ownerInfo2 + " from " + ownerInfo) : (text + " (id:" + stringId + ") transferred within " + ownerInfo2));
		bool flag = newOwner == Hero.MainHero || oldOwner == Hero.MainHero || capturer == Hero.MainHero || Hero.MainHero.Clan == ((newOwner != null) ? newOwner.Clan : null) || Hero.MainHero.Clan == ((oldOwner != null) ? oldOwner.Clan : null);
		string text3 = "";
		if (flag)
		{
			string text4 = $"(player's clan: {Hero.MainHero.Clan.Name}, clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId})";
			if (newOwner == Hero.MainHero)
			{
				text3 = "(you gained control of the settlement) " + text4;
			}
			else if (Hero.MainHero.Clan == ((newOwner != null) ? newOwner.Clan : null))
			{
				text3 = $"(your clan member {newOwner.Name} gained control of the settlement) {text4}";
			}
			else if (oldOwner == Hero.MainHero)
			{
				text3 = "(you lost control of the settlement) " + text4;
			}
			else if (Hero.MainHero.Clan == ((oldOwner != null) ? oldOwner.Clan : null))
			{
				text3 = $"(your clan member {oldOwner.Name} lost control of the settlement) {text4}";
			}
			else if (capturer == Hero.MainHero)
			{
				text3 = "(you captured the settlement) " + text4;
			}
			else if (Hero.MainHero.Clan == ((capturer != null) ? capturer.Clan : null))
			{
				text3 = $"(your clan member {capturer.Name} captured the settlement) {text4}";
			}
			text2 = text2 + " " + text3;
		}
		Dictionary<string, NPCContext> npcContextsDict = AIInfluenceBehavior.Instance?.GetNPCContexts();
		if (npcContextsDict == null || !npcContextsDict.Any())
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] No NPC contexts available for SettlementOwnerChanged event.");
			return;
		}
		List<string> source = npcContextsDict.Keys.ToList();
		NPCContext value;
		List<NPCContext> list = (from k in source
			select npcContextsDict.TryGetValue(k, out value) ? value : null into c
			where c != null
			select c).ToList();
		SettlementCaptureData settlementCaptureData = new SettlementCaptureData
		{
			Settlement = settlement,
			NewOwner = newOwner,
			PreviousOwner = oldOwner,
			NewClan = ((newOwner != null) ? newOwner.Clan : null),
			PreviousClan = ((oldOwner != null) ? oldOwner.Clan : null),
			PlayerInvolved = flag,
			PlayerRoleTag = text3
		};
		CampaignEvent ev = new CampaignEvent
		{
			Type = "SettlementCapture",
			Description = text2,
			Timestamp = CampaignTime.Now
		};
		HashSet<string> hashSet = new HashSet<string>();
		if (newOwner != null)
		{
			hashSet.Add(((MBObjectBase)newOwner).StringId);
		}
		if (oldOwner != null)
		{
			hashSet.Add(((MBObjectBase)oldOwner).StringId);
		}
		if (capturer != null)
		{
			hashSet.Add(((MBObjectBase)capturer).StringId);
		}
		HashSet<string> processedParticipantIds = AddEventToDirectParticipantsImmediately("SettlementCapture", ev, settlement, newOwner, hashSet, settlementCaptureData);
		QueueEventForInformedNPCs(ev, settlement, newOwner, null, defer: false, settlementCaptureData, processedParticipantIds);
		AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] SettlementCapture event queued: " + text2);
	}

	private string GetPersonalizedSettlementEvent(Hero npc, Settlement settlement, Hero newOwner, Hero previousOwner, Hero capturer, string baseDescription, bool playerInvolved = false, string playerRoleTag = "")
	{
		string text = ((object)settlement.Name).ToString();
		string stringId = ((MBObjectBase)settlement).StringId;
		string text2 = "";
		bool flag = previousOwner != null && newOwner != null && previousOwner.MapFaction != newOwner.MapFaction;
		if (npc == newOwner)
		{
			text2 = "You gained control of " + text + " (id:" + stringId + ")";
		}
		else if (capturer != null && npc == capturer)
		{
			text2 = "You led the assault that captured " + text + " (id:" + stringId + ")";
		}
		else if (npc == previousOwner)
		{
			if (flag)
			{
				object arg;
				if (newOwner == null)
				{
					arg = null;
				}
				else
				{
					IFaction mapFaction = newOwner.MapFaction;
					arg = ((mapFaction != null) ? mapFaction.Name : null);
				}
				text2 = $"You lost control of {text} (id:{stringId}) to {arg}";
			}
			else
			{
				text2 = $"You transferred control of {text} (id:{stringId}) to {((newOwner != null) ? newOwner.Name : null)}";
			}
		}
		else if (newOwner != null && npc.Clan == newOwner.Clan)
		{
			text2 = "Your clan gained control of " + text + " (id:" + stringId + ")";
		}
		else if (previousOwner != null && npc.Clan == previousOwner.Clan)
		{
			text2 = "Your clan lost control of " + text + " (id:" + stringId + ")";
		}
		else if (((newOwner != null) ? newOwner.MapFaction : null) != null && npc.MapFaction == newOwner.MapFaction)
		{
			text2 = "Your kingdom gained " + text + " (id:" + stringId + ")";
		}
		else if (((previousOwner != null) ? previousOwner.MapFaction : null) != null && npc.MapFaction == previousOwner.MapFaction)
		{
			text2 = "Your kingdom lost " + text + " (id:" + stringId + ")";
		}
		else
		{
			string ownerInfo = GetOwnerInfo(previousOwner);
			string ownerInfo2 = GetOwnerInfo(newOwner);
			text2 = ((!flag) ? (text + " (id:" + stringId + ") was transferred from " + ownerInfo + " to " + ownerInfo2) : (text + " (id:" + stringId + ") was captured by " + ownerInfo2 + " from " + ownerInfo));
		}
		if (playerInvolved && !string.IsNullOrEmpty(playerRoleTag))
		{
			text2 = text2 + " " + playerRoleTag;
		}
		return text2;
	}

	private string GetOwnerInfo(Hero owner)
	{
		if (owner == null)
		{
			return "unknown";
		}
		Clan clan = owner.Clan;
		if (((clan != null) ? clan.Kingdom : null) != null)
		{
			return $"{owner.Clan.Kingdom.Name} (kingdom_id:{((MBObjectBase)owner.Clan.Kingdom).StringId})";
		}
		if (owner.Clan != null)
		{
			return $"{owner.Clan.Name} (clan_id:{((MBObjectBase)owner.Clan).StringId})";
		}
		return $"{owner.Name} (id:{((MBObjectBase)owner).StringId})";
	}

	private string GetDeathCauseDescription(KillCharacterActionDetail detail, Hero killer)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected I4, but got Unknown
		return ((int)detail - 1) switch
		{
			0 => (killer != null) ? $"was murdered by {killer.Name} (id:{((MBObjectBase)killer).StringId})" : "was assassinated", 
			1 => "died during childbirth", 
			2 => "passed away due to old age", 
			3 => (killer != null) ? $"was slain in battle by {killer.Name} (id:{((MBObjectBase)killer).StringId})" : "died in battle", 
			4 => "was severely wounded in battle and succumbed to injuries", 
			5 => "was executed", 
			7 => "disappeared under mysterious circumstances and is presumed dead", 
			_ => "died under unknown circumstances", 
		};
	}

	private string GetDeathCauseDescriptionForKiller(KillCharacterActionDetail detail, Hero victim)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected I4, but got Unknown
		return ((int)detail - 1) switch
		{
			0 => $"murdered {victim.Name} (id:{((MBObjectBase)victim).StringId})", 
			3 => $"slayed {victim.Name} (id:{((MBObjectBase)victim).StringId}) in battle", 
			5 => $"executed {victim.Name} (id:{((MBObjectBase)victim).StringId})", 
			4 => $"severely wounded {victim.Name} (id:{((MBObjectBase)victim).StringId}) in battle, who later succumbed to injuries", 
			_ => $"caused the death of {victim.Name} (id:{((MBObjectBase)victim).StringId})", 
		};
	}

	private string GetHeroWithKingdomInfo(Hero hero)
	{
		if (hero == null)
		{
			return "unknown";
		}
		string text = ((object)hero.Name).ToString();
		string stringId = ((MBObjectBase)hero).StringId;
		Clan clan = hero.Clan;
		if (((clan != null) ? clan.Kingdom : null) != null)
		{
			return $"{text} (id:{stringId}) of {hero.Clan.Kingdom.Name} (kingdom_id:{((MBObjectBase)hero.Clan.Kingdom).StringId})";
		}
		if (hero.Clan != null)
		{
			return $"{text} (id:{stringId}) of {hero.Clan.Name} (clan_id:{((MBObjectBase)hero.Clan).StringId})";
		}
		return text + " (id:" + stringId + ")";
	}

	private string GetBattleSideInfo(BattleSideEnum side, MapEvent mapEvent, List<Hero> participants = null)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Invalid comparison between Unknown and I4
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Invalid comparison between Unknown and I4
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Invalid comparison between Unknown and I4
		MBReadOnlyList<MapEventParty> val = mapEvent.PartiesOnSide(side);
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		List<string> list = new List<string>();
		string text = null;
		if (participants != null && participants.Count > 0)
		{
			foreach (Hero participant in participants)
			{
				string text2 = ((object)participant.Name).ToString();
				if (participant.Clan != null)
				{
					text2 += $" (clan:{participant.Clan.Name}";
					if (participant.Clan.Kingdom != null)
					{
						text2 += $", kingdom:{participant.Clan.Kingdom.Name}";
						hashSet.Add($"{participant.Clan.Kingdom.Name} (kingdom_id:{((MBObjectBase)participant.Clan.Kingdom).StringId})");
					}
					text2 += ")";
					hashSet2.Add($"{participant.Clan.Name} (clan_id:{((MBObjectBase)participant.Clan).StringId})");
				}
				list.Add(text2);
			}
		}
		else
		{
			foreach (MapEventParty item in (List<MapEventParty>)(object)val)
			{
				Hero leaderHero = item.Party.LeaderHero;
				if (leaderHero != null)
				{
					string text3 = ((object)leaderHero.Name).ToString();
					if (leaderHero.Clan != null)
					{
						text3 += $" (clan:{leaderHero.Clan.Name}";
						if (leaderHero.Clan.Kingdom != null)
						{
							text3 += $", kingdom:{leaderHero.Clan.Kingdom.Name}";
							hashSet.Add($"{leaderHero.Clan.Kingdom.Name} (kingdom_id:{((MBObjectBase)leaderHero.Clan.Kingdom).StringId})");
						}
						text3 += ")";
						hashSet2.Add($"{leaderHero.Clan.Name} (clan_id:{((MBObjectBase)leaderHero.Clan).StringId})");
					}
					list.Add(text3);
				}
				PartyBase party = item.Party;
				MobileParty val2 = ((party != null) ? party.MobileParty : null);
				if (val2 != null)
				{
					if (val2.IsCaravan)
					{
						text = "caravan";
					}
					else if (val2.IsVillager && text == null)
					{
						text = "villagers";
					}
					else if (val2.IsBandit && text == null)
					{
						text = "bandits";
					}
				}
			}
		}
		if (list.Count > 0)
		{
			int num = 3;
			string text4 = ((list.Count == 1) ? list[0] : string.Join(", ", list.Take(num)));
			if (list.Count > num)
			{
				text4 += $" and {list.Count - num} others";
			}
			return text4;
		}
		List<string> list2 = new List<string>();
		list2.AddRange(hashSet);
		list2.AddRange(hashSet2);
		if (list2.Count == 0)
		{
			if ((int)mapEvent.EventType == 5 && mapEvent.MapEventSettlement != null)
			{
				Settlement mapEventSettlement = mapEvent.MapEventSettlement;
				if ((int)side == 0)
				{
					IFaction mapFaction = mapEventSettlement.MapFaction;
					if (mapFaction != null && mapFaction.IsKingdomFaction)
					{
						return $"{mapEventSettlement.MapFaction.Name} (kingdom_id:{mapEventSettlement.MapFaction.StringId}) defenders";
					}
					Hero owner = mapEventSettlement.Owner;
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
					if (obj != null)
					{
						return $"{mapEventSettlement.Owner.Clan.Kingdom.Name} (kingdom_id:{((MBObjectBase)mapEventSettlement.Owner.Clan.Kingdom).StringId}) defenders";
					}
					Hero owner2 = mapEventSettlement.Owner;
					if (((owner2 != null) ? owner2.Clan : null) != null)
					{
						return $"{mapEventSettlement.Owner.Clan.Name} (clan_id:{((MBObjectBase)mapEventSettlement.Owner.Clan).StringId}) defenders";
					}
				}
				else if ((int)side == 1)
				{
					MapEventParty val3 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)1)).FirstOrDefault();
					object obj2;
					if (val3 == null)
					{
						obj2 = null;
					}
					else
					{
						PartyBase party2 = val3.Party;
						obj2 = ((party2 != null) ? party2.LeaderHero : null);
					}
					if (obj2 != null)
					{
						Hero leaderHero2 = val3.Party.LeaderHero;
						Clan clan2 = leaderHero2.Clan;
						if (((clan2 != null) ? clan2.Kingdom : null) != null)
						{
							return $"{leaderHero2.Clan.Kingdom.Name} (kingdom_id:{((MBObjectBase)leaderHero2.Clan.Kingdom).StringId}) attackers";
						}
						if (leaderHero2.Clan != null)
						{
							return $"{leaderHero2.Clan.Name} (clan_id:{((MBObjectBase)leaderHero2.Clan).StringId}) attackers";
						}
					}
				}
			}
			foreach (MapEventParty item2 in (List<MapEventParty>)(object)val)
			{
				PartyBase party3 = item2.Party;
				if (party3 != null)
				{
					IFaction mapFaction2 = party3.MapFaction;
					if (((mapFaction2 != null) ? new bool?(mapFaction2.IsKingdomFaction) : ((bool?)null)) == true)
					{
						hashSet.Add($"{item2.Party.MapFaction.Name} (kingdom_id:{item2.Party.MapFaction.StringId})");
						continue;
					}
				}
				PartyBase party4 = item2.Party;
				if (((party4 != null) ? party4.MapFaction : null) != null && !item2.Party.MapFaction.IsBanditFaction)
				{
					hashSet2.Add($"{item2.Party.MapFaction.Name} (clan_id:{item2.Party.MapFaction.StringId})");
				}
			}
			list2.Clear();
			list2.AddRange(hashSet);
			list2.AddRange(hashSet2);
			if (list2.Count > 0)
			{
				string text5 = ((list2.Count == 1) ? list2[0] : string.Join(" and ", list2));
				return (text != null) ? (text5 + " " + text) : text5;
			}
			foreach (MapEventParty item3 in (List<MapEventParty>)(object)val)
			{
				PartyBase party5 = item3.Party;
				if (party5 != null)
				{
					MobileParty mobileParty = party5.MobileParty;
					if (((mobileParty != null) ? new bool?(mobileParty.IsBandit) : ((bool?)null)) == true)
					{
						return "bandits";
					}
				}
				PartyBase party6 = item3.Party;
				if (party6 != null)
				{
					MobileParty mobileParty2 = party6.MobileParty;
					if (((mobileParty2 != null) ? new bool?(mobileParty2.IsVillager) : ((bool?)null)) == true)
					{
						return "villagers";
					}
				}
				PartyBase party7 = item3.Party;
				if (party7 != null)
				{
					MobileParty mobileParty3 = party7.MobileParty;
					if (((mobileParty3 != null) ? new bool?(mobileParty3.IsCaravan) : ((bool?)null)) == true)
					{
						return "caravan";
					}
				}
			}
			return (((IEnumerable<MapEventParty>)val).Count() > 1) ? "unknown coalition" : "unknown forces";
		}
		if (list2.Count == 1)
		{
			return (text != null) ? (list2[0] + " " + text) : list2[0];
		}
		string text6 = string.Join(" and ", list2);
		return (text != null) ? (text6 + " " + text) : text6;
	}

	private void OnKingdomDecisionConcluded(KingdomDecision decision, DecisionOutcome outcome, bool wasCancelled)
	{
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		if (((decision != null) ? decision.Kingdom : null) == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] OnKingdomDecisionConcluded called with null decision or decision.Kingdom!");
			return;
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] OnKingdomDecisionConcluded triggered for {decision.Kingdom.Name}.");
		if (wasCancelled)
		{
			string decisionDescription = GetDecisionDescription(decision, outcome);
			AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Kingdom decision was cancelled: " + decisionDescription);
			return;
		}
		string text = ((object)decision.Kingdom.Name).ToString();
		string stringId = ((MBObjectBase)decision.Kingdom).StringId;
		string decisionDescription2 = GetDecisionDescription(decision, outcome);
		string text2 = text + " (id:" + stringId + ") passed a new law: " + decisionDescription2;
		Dictionary<string, NPCContext> npcContextsDict = AIInfluenceBehavior.Instance?.GetNPCContexts();
		if (npcContextsDict == null || !npcContextsDict.Any())
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] No NPC contexts available for KingdomDecisionConcluded event.");
			return;
		}
		List<string> source = npcContextsDict.Keys.ToList();
		NPCContext value;
		List<NPCContext> list = (from k in source
			select npcContextsDict.TryGetValue(k, out value) ? value : null into c
			where c != null
			select c).ToList();
		CampaignEvent ev = new CampaignEvent
		{
			Type = "Law",
			Description = text2,
			Timestamp = CampaignTime.Now
		};
		Settlement factionMidSettlement = decision.Kingdom.FactionMidSettlement;
		QueueEventForInformedNPCs(ev, factionMidSettlement, decision.Kingdom.Leader);
		AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Law event queued: " + text2);
	}

	private void OnBattleStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Invalid comparison between Unknown and I4
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Invalid comparison between Unknown and I4
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		if (mapEvent == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] OnBattleStarted called with null mapEvent!");
			return;
		}
		bool flag = GlobalSettings<ModSettings>.Instance?.EnableDetailedInfoLogging ?? false;
		BattleInitialData battleInitialData = new BattleInitialData();
		BattleSideEnum[] array = (BattleSideEnum[])(object)new BattleSideEnum[2]
		{
			(BattleSideEnum)1,
			default(BattleSideEnum)
		};
		foreach (BattleSideEnum val in array)
		{
			int num = 0;
			HashSet<string> hashSet = (((int)val == 1) ? battleInitialData.AttackerHeroIds : battleInitialData.DefenderHeroIds);
			List<Hero> list = (((int)val == 1) ? battleInitialData.AttackerHeroes : battleInitialData.DefenderHeroes);
			MBReadOnlyList<MapEventParty> val2 = mapEvent.PartiesOnSide(val);
			if (val2 == null)
			{
				continue;
			}
			foreach (MapEventParty item in (List<MapEventParty>)(object)val2)
			{
				if (item.Party == null)
				{
					continue;
				}
				num += item.Party.MemberRoster.TotalManCount;
				if (item.Party.LeaderHero != null && hashSet.Add(((MBObjectBase)item.Party.LeaderHero).StringId))
				{
					list.Add(item.Party.LeaderHero);
					if (flag)
					{
						AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-HERO-COLLECT] Added leader: {item.Party.LeaderHero.Name} ({((MBObjectBase)item.Party.LeaderHero).StringId})");
					}
				}
				if (item.Party.MemberRoster != null)
				{
					foreach (TroopRosterElement item2 in (List<TroopRosterElement>)(object)item.Party.MemberRoster.GetTroopRoster())
					{
						if (item2.Character == null || !((BasicCharacterObject)item2.Character).IsHero || item2.Character.HeroObject == null)
						{
							continue;
						}
						string stringId = ((MBObjectBase)item2.Character.HeroObject).StringId;
						if (!string.IsNullOrEmpty(stringId) && hashSet.Add(stringId))
						{
							list.Add(item2.Character.HeroObject);
							if (flag)
							{
								AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-HERO-COLLECT] Added from roster: {item2.Character.HeroObject.Name} ({stringId})");
							}
						}
					}
				}
				if (item.Party.MobileParty != MobileParty.MainParty)
				{
					continue;
				}
				foreach (Hero item3 in Hero.MainHero.CompanionsInParty)
				{
					if (item3 != null && item3.IsAlive && hashSet.Add(((MBObjectBase)item3).StringId))
					{
						list.Add(item3);
						if (flag)
						{
							AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-HERO-COLLECT] Added companion: {item3.Name} ({((MBObjectBase)item3).StringId})");
						}
					}
				}
			}
			if ((int)val == 1)
			{
				battleInitialData.AttackerInitial = num;
			}
			else
			{
				battleInitialData.DefenderInitial = num;
			}
		}
		_battleInitialData[mapEvent] = battleInitialData;
	}

	private void OnBattleEnded(MapEvent mapEvent)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Invalid comparison between Unknown and I4
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Invalid comparison between Unknown and I4
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Invalid comparison between Unknown and I4
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Invalid comparison between Unknown and I4
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Invalid comparison between Unknown and I4
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Invalid comparison between Unknown and I4
		//IL_071c: Unknown result type (might be due to invalid IL or missing references)
		//IL_071e: Invalid comparison between Unknown and I4
		//IL_0729: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Invalid comparison between Unknown and I4
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Invalid comparison between Unknown and I4
		//IL_0790: Unknown result type (might be due to invalid IL or missing references)
		//IL_079d: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0834: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_0777: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_0902: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Invalid comparison between Unknown and I4
		//IL_090e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Invalid comparison between Unknown and I4
		//IL_099c: Unknown result type (might be due to invalid IL or missing references)
		//IL_095e: Unknown result type (might be due to invalid IL or missing references)
		if (mapEvent == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] OnBattleEnded called with null mapEvent!");
			return;
		}
		bool flag = GlobalSettings<ModSettings>.Instance?.EnableDetailedInfoLogging ?? false;
		BattleSideEnum winningSide = mapEvent.WinningSide;
		if ((int)winningSide == -1)
		{
			return;
		}
		BattleSideEnum val = (BattleSideEnum)(1 - (int)winningSide);
		BattleInitialData battleInitialData = null;
		if (_battleInitialData.TryGetValue(mapEvent, out var value))
		{
			battleInitialData = value;
			_battleInitialData.Remove(mapEvent);
		}
		MapEventParty? obj = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide(winningSide)).FirstOrDefault();
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			PartyBase party = obj.Party;
			obj2 = ((party != null) ? party.LeaderHero : null);
		}
		Hero val2 = (Hero)obj2;
		if (val2 == null && battleInitialData != null)
		{
			val2 = (((int)winningSide == 1) ? battleInitialData.AttackerHeroes.FirstOrDefault() : battleInitialData.DefenderHeroes.FirstOrDefault());
		}
		if (val2 == null)
		{
			MBReadOnlyList<MapEventParty> parties = mapEvent.GetMapEventSide(winningSide).Parties;
			val2 = ((IEnumerable<MapEventParty>)parties).Select(delegate(MapEventParty p)
			{
				PartyBase party3 = p.Party;
				return (party3 != null) ? party3.LeaderHero : null;
			}).FirstOrDefault((Func<Hero, bool>)((Hero h) => h != null));
		}
		MapEventParty? obj3 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide(val)).FirstOrDefault();
		object obj4;
		if (obj3 == null)
		{
			obj4 = null;
		}
		else
		{
			PartyBase party2 = obj3.Party;
			obj4 = ((party2 != null) ? party2.LeaderHero : null);
		}
		Hero val3 = (Hero)obj4;
		if (val3 == null && battleInitialData != null)
		{
			val3 = (((int)val == 1) ? battleInitialData.AttackerHeroes.FirstOrDefault() : battleInitialData.DefenderHeroes.FirstOrDefault());
		}
		int troopCasualties = mapEvent.AttackerSide.TroopCasualties;
		int troopCasualties2 = mapEvent.DefenderSide.TroopCasualties;
		int num = battleInitialData?.AttackerInitial ?? (mapEvent.AttackerSide.RecalculateMemberCountOfSide() + troopCasualties);
		int num2 = battleInitialData?.DefenderInitial ?? (mapEvent.DefenderSide.RecalculateMemberCountOfSide() + troopCasualties2);
		if (num < troopCasualties)
		{
			num = troopCasualties;
		}
		if (num2 < troopCasualties2)
		{
			num2 = troopCasualties2;
		}
		string text = (((int)winningSide == 1) ? $"{num} troops (lost {troopCasualties})" : $"{num2} troops (lost {troopCasualties2})");
		string text2 = (((int)winningSide == 1) ? $"{num2} troops (lost {troopCasualties2})" : $"{num} troops (lost {troopCasualties})");
		HashSet<string> hashSet = ((battleInitialData?.AttackerHeroIds != null) ? new HashSet<string>(battleInitialData.AttackerHeroIds) : new HashSet<string>());
		HashSet<string> hashSet2 = ((battleInitialData?.DefenderHeroIds != null) ? new HashSet<string>(battleInitialData.DefenderHeroIds) : new HashSet<string>());
		List<Hero> list = new List<Hero>();
		List<Hero> list2 = new List<Hero>();
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (battleInitialData != null)
		{
			if (battleInitialData.AttackerHeroIds != null)
			{
				foreach (string attackerHeroId in battleInitialData.AttackerHeroIds)
				{
					Hero val4 = instance?.GetHeroById(attackerHeroId);
					if (val4 != null && val4.IsAlive)
					{
						list.Add(val4);
					}
				}
			}
			if (battleInitialData.DefenderHeroIds != null)
			{
				foreach (string defenderHeroId in battleInitialData.DefenderHeroIds)
				{
					Hero val5 = instance?.GetHeroById(defenderHeroId);
					if (val5 != null && val5.IsAlive)
					{
						list2.Add(val5);
					}
				}
			}
		}
		BattleSideEnum[] array = (BattleSideEnum[])(object)new BattleSideEnum[2]
		{
			(BattleSideEnum)1,
			default(BattleSideEnum)
		};
		foreach (BattleSideEnum val6 in array)
		{
			HashSet<string> hashSet3 = (((int)val6 == 1) ? hashSet : hashSet2);
			List<Hero> list3 = (((int)val6 == 1) ? list : list2);
			MapEventSide mapEventSide = mapEvent.GetMapEventSide(val6);
			if (mapEventSide == null || mapEventSide.Parties == null)
			{
				continue;
			}
			foreach (MapEventParty item3 in (List<MapEventParty>)(object)mapEventSide.Parties)
			{
				if (item3.Party == null)
				{
					continue;
				}
				if (item3.Party.LeaderHero != null && hashSet3.Add(((MBObjectBase)item3.Party.LeaderHero).StringId))
				{
					list3.Add(item3.Party.LeaderHero);
				}
				if (item3.Party.MemberRoster == null)
				{
					continue;
				}
				foreach (TroopRosterElement item4 in (List<TroopRosterElement>)(object)item3.Party.MemberRoster.GetTroopRoster())
				{
					if (item4.Character != null && ((BasicCharacterObject)item4.Character).IsHero && item4.Character.HeroObject != null && hashSet3.Add(((MBObjectBase)item4.Character.HeroObject).StringId))
					{
						list3.Add(item4.Character.HeroObject);
					}
				}
			}
		}
		List<string> list4 = new List<string>();
		foreach (string item5 in hashSet.Concat(hashSet2))
		{
			Hero val7 = AIInfluenceBehavior.Instance?.GetHeroById(item5);
			if (val7 != null && val7.Clan == Hero.MainHero.Clan)
			{
				string item = ((val7 == Hero.MainHero) ? "you" : ((object)val7.Name).ToString());
				if (!list4.Contains(item))
				{
					list4.Add(item);
				}
			}
		}
		bool flag2 = mapEvent.IsPlayerMapEvent || list4.Count > 0;
		string playerInvolvementTag = (flag2 ? string.Format("(player involvement: {0} from clan {1} (id:{2}))", string.Join(", ", list4), Hero.MainHero.Clan.Name, ((MBObjectBase)Hero.MainHero.Clan).StringId) : "");
		if (flag)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-PARTICIPANTS] Battle ended - Attackers: {hashSet.Count} heroes ({list.Count} alive), Defenders: {hashSet2.Count} heroes ({list2.Count} alive), Player involved: {flag2}");
		}
		List<Hero> participants = (((int)winningSide == 1) ? list : list2);
		List<Hero> participants2 = (((int)winningSide == 1) ? list2 : list);
		string battleSideInfo = GetBattleSideInfo(winningSide, mapEvent, participants);
		string battleSideInfo2 = GetBattleSideInfo(val, mapEvent, participants2);
		Settlement val8 = null;
		CampaignVec2 position;
		if ((int)mapEvent.EventType == 5)
		{
			val8 = mapEvent.MapEventSettlement;
		}
		else if ((int)mapEvent.EventType == 1)
		{
			position = mapEvent.Position;
			val8 = GetNearestSettlementInfo((position).ToVec2()).Settlement;
		}
		BattleData obj5 = new BattleData
		{
			BattleType = mapEvent.EventType
		};
		position = mapEvent.Position;
		obj5.Position = (position).ToVec2();
		obj5.BattleSettlement = val8;
		obj5.WinningSide = winningSide;
		obj5.WinnerHero = val2;
		obj5.LoserHero = val3;
		obj5.WinningSideInfo = battleSideInfo;
		obj5.LosingSideInfo = battleSideInfo2;
		obj5.WinnerStats = text;
		obj5.LoserStats = text2;
		obj5.AttackerHeroIds = hashSet;
		obj5.DefenderHeroIds = hashSet2;
		obj5.IsPlayerInvolved = flag2;
		obj5.PlayerInvolvementTag = playerInvolvementTag;
		BattleData battleData = obj5;
		CampaignEvent campaignEvent = new CampaignEvent();
		campaignEvent.Type = "Battle";
		campaignEvent.Timestamp = CampaignTime.Now;
		campaignEvent.Description = battleSideInfo + " won a " + (((val8 == null) ? null : ((object)val8.Name)?.ToString()) ?? "field") + " battle against " + battleSideInfo2 + ". " + text + " defeated " + text2 + ".";
		CampaignEvent ev = campaignEvent;
		HashSet<string> hashSet4 = new HashSet<string>();
		if (hashSet != null)
		{
			hashSet4.UnionWith(hashSet);
		}
		if (hashSet2 != null)
		{
			hashSet4.UnionWith(hashSet2);
		}
		HashSet<string> processedParticipantIds = AddEventToDirectParticipantsImmediately("Battle", ev, val8, val2, hashSet4, battleData);
		HashSet<string> hashSet5 = (((int)winningSide == 1) ? hashSet : hashSet2);
		CampaignTime now = CampaignTime.Now;
		if (hashSet5 != null)
		{
			foreach (string item6 in hashSet5)
			{
				if (!_recentBattleParticipantsByCapturer.ContainsKey(item6))
				{
					_recentBattleParticipantsByCapturer[item6] = (new HashSet<string>(), now);
				}
				HashSet<string> item2 = _recentBattleParticipantsByCapturer[item6].participantIds;
				item2.Clear();
				item2.UnionWith(hashSet5);
				_recentBattleParticipantsByCapturer[item6] = (item2, now);
			}
		}
		QueueEventForInformedNPCs(ev, val8, val2, null, defer: false, battleData, processedParticipantIds);
		try
		{
			string battleType = (((int)mapEvent.EventType == 5) ? "Siege" : "FieldBattle");
			BattleLogger.Instance.LogBattleEnded(battleType, battleSideInfo, battleSideInfo2, num, num2, troopCasualties, troopCasualties2, (val8 == null) ? null : ((object)val8.Name)?.ToString(), flag2);
		}
		catch
		{
		}
	}

	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		if (victim == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] OnHeroKilled called with null victim!");
			return;
		}
		AIInfluenceBehavior.Instance?.LogMessage(string.Format("[DEBUG] OnHeroKilled triggered for {0} killed by {1} (detail: {2}).", victim.Name, ((killer == null) ? null : ((object)killer.Name)?.ToString()) ?? "unknown", detail));
		if (victim.IsAlive)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] Hero {victim.Name} is still alive, skipping event.");
			return;
		}
		NPCContext nPCContext = AIInfluenceBehavior.Instance?.GetNPCContextByStringId(((MBObjectBase)victim).StringId);
		bool flag = nPCContext != null && !string.IsNullOrEmpty(nPCContext.DeathReason);
		if (!victim.IsLord && !flag)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] Skipping HeroKilled event for non-lord: {victim.Name} (isRoleplayDeath: {flag})");
			return;
		}
		if (flag)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[ROLEPLAY_DEATH] Processing roleplay death for {victim.Name} (IsLord: {victim.IsLord})");
		}
		Clan clan = victim.Clan;
		if ((clan != null && clan.Tier >= 5) || victim.IsKingdomLeader)
		{
			AddDeathRecord(victim, killer, detail);
		}
		if (victim.IsKingdomLeader)
		{
			string text = ((object)victim.Name).ToString();
			string stringId = ((MBObjectBase)victim).StringId;
			Clan clan2 = victim.Clan;
			object obj;
			if (clan2 == null)
			{
				obj = null;
			}
			else
			{
				Kingdom kingdom = clan2.Kingdom;
				obj = ((kingdom == null) ? null : ((object)kingdom.Name)?.ToString());
			}
			if (obj == null)
			{
				obj = "unknown kingdom";
			}
			string text2 = (string)obj;
			Clan clan3 = victim.Clan;
			object obj2;
			if (clan3 == null)
			{
				obj2 = null;
			}
			else
			{
				Kingdom kingdom2 = clan3.Kingdom;
				obj2 = ((kingdom2 != null) ? ((MBObjectBase)kingdom2).StringId : null);
			}
			if (obj2 == null)
			{
				obj2 = "unknown";
			}
			string text3 = (string)obj2;
			string text4 = ((killer == null) ? null : ((object)killer.Name)?.ToString()) ?? "unknown";
			string text5 = ((killer != null) ? ((MBObjectBase)killer).StringId : null) ?? "unknown";
			CampaignEvent campaignEvent = new CampaignEvent();
			campaignEvent.Type = "KingdomLeaderDeath";
			campaignEvent.Description = "Kingdom leader " + text + " (id:" + stringId + ") of " + text2 + " (id:" + text3 + ") was killed by " + text4 + " (id:" + text5 + "). This will trigger a succession crisis.";
			campaignEvent.Timestamp = CampaignTime.Now;
			CampaignEvent ev = campaignEvent;
			QueueEventForInformedNPCs(ev, victim.CurrentSettlement, victim);
		}
		string text6 = ((object)victim.Name).ToString();
		string stringId2 = ((MBObjectBase)victim).StringId;
		Settlement currentSettlement = victim.CurrentSettlement;
		bool flag2 = killer == Hero.MainHero || victim == Hero.MainHero || (killer != null && killer.Clan == Hero.MainHero.Clan) || (victim != null && victim.Clan == Hero.MainHero.Clan);
		string playerRoleTag = "";
		if (flag2)
		{
			if (killer == Hero.MainHero)
			{
				playerRoleTag = "(you are the killer)";
			}
			else if (victim == Hero.MainHero)
			{
				playerRoleTag = "(you are the victim)";
			}
			else if (killer != null && killer.Clan == Hero.MainHero.Clan)
			{
				playerRoleTag = $"(killer was your clan member {killer.Name})";
			}
			else if (victim != null && victim.Clan == Hero.MainHero.Clan)
			{
				playerRoleTag = $"(victim was your clan member {victim.Name})";
			}
		}
		NPCContext nPCContext2 = AIInfluenceBehavior.Instance?.GetNPCContextByStringId(((MBObjectBase)victim).StringId);
		string text7;
		if (nPCContext2 != null && !string.IsNullOrEmpty(nPCContext2.DeathReason))
		{
			string deathReason = nPCContext2.DeathReason;
			text7 = text6 + " (id:" + stringId2 + ") " + deathReason;
		}
		else
		{
			string deathReason = GetDeathCauseDescription(detail, killer);
			text7 = text6 + " (id:" + stringId2 + ") " + deathReason;
		}
		HeroKilledData heroKilledData = new HeroKilledData
		{
			Victim = victim,
			Killer = killer,
			Detail = detail,
			BaseText = text7,
			PlayerInvolved = flag2,
			PlayerRoleTag = playerRoleTag
		};
		CampaignEvent ev2 = new CampaignEvent
		{
			Type = "HeroKilled",
			Description = text7,
			Timestamp = CampaignTime.Now
		};
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(((MBObjectBase)victim).StringId);
		if (killer != null)
		{
			hashSet.Add(((MBObjectBase)killer).StringId);
		}
		HashSet<string> processedParticipantIds = AddEventToDirectParticipantsImmediately("HeroKilled", ev2, currentSettlement, victim, hashSet, heroKilledData);
		QueueEventForInformedNPCs(ev2, currentSettlement, victim, null, defer: false, heroKilledData, processedParticipantIds);
		AIInfluenceBehavior.Instance?.LogMessage(string.Format("[DEBUG] HeroKilled event queued: {0} killed by {1}", victim.Name, ((killer == null) ? null : ((object)killer.Name)?.ToString()) ?? "unknown"));
	}

	private string GetPersonalizedDeathEvent(Hero npc, NPCContext context, Hero victim, Hero killer, string baseEventText, KillCharacterActionDetail detail, Settlement deathLocation, bool playerInvolved, string playerRoleTag)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null || victim == null)
		{
			return baseEventText;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		string heroWithKingdomInfo = GetHeroWithKingdomInfo(victim);
		string heroWithKingdomInfo2 = GetHeroWithKingdomInfo(killer);
		string text = "";
		if (playerInvolved)
		{
			string text2 = $"(player's clan: {Hero.MainHero.Clan.Name}, clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId})";
			text = " " + playerRoleTag + " " + text2;
		}
		string text3 = ((deathLocation != null) ? $" near {deathLocation.Name}" : "");
		bool flag = IsKnownToNPC(npc, victim);
		bool flag2 = killer != null && IsKnownToNPC(npc, killer);
		int relation = npc.GetRelation(victim);
		int relationWithKiller = ((killer != null) ? npc.GetRelation(killer) : 0);
		int relationshipThreshold = instance?.RelationshipThreshold ?? 20;
		string text4 = DetermineDeathEventDetailLevel(npc, context, victim, killer, relation, relationWithKiller, relationshipThreshold) switch
		{
			"family" => $"{heroWithKingdomInfo} was killed by {heroWithKingdomInfo2} ({detail}){text3}{text}", 
			"allies" => heroWithKingdomInfo + " was killed by " + heroWithKingdomInfo2 + text3 + text, 
			"enemies" => heroWithKingdomInfo + " was killed by " + heroWithKingdomInfo2 + text, 
			"commoners" => "A lord was killed" + text3, 
			_ => (killer == null) ? (heroWithKingdomInfo + " died" + text3 + text) : (heroWithKingdomInfo + " was killed" + text3 + text), 
		};
		List<string> list = new List<string>();
		if (flag && flag2)
		{
			list.Add("you knew both");
		}
		else if (flag)
		{
			list.Add("you knew the victim");
		}
		else if (flag2)
		{
			list.Add("you knew the killer");
		}
		else
		{
			list.Add("you did not know them");
		}
		return text4 + " (" + string.Join(", ", list) + ")";
	}

	private string DetermineDeathEventDetailLevel(Hero npc, NPCContext context, Hero victim, Hero killer, int relationWithVictim, int relationWithKiller, int relationshipThreshold)
	{
		if (npc.Clan == victim.Clan || IsRelated(npc, victim))
		{
			return "family";
		}
		if (relationWithVictim > relationshipThreshold)
		{
			return "family";
		}
		if (relationWithVictim < -relationshipThreshold)
		{
			return "enemies";
		}
		if (npc.MapFaction != null && npc.MapFaction == victim.MapFaction)
		{
			return "allies";
		}
		if (npc.MapFaction != null && victim.MapFaction != null && FactionManager.IsAtWarAgainstFaction(npc.MapFaction, victim.MapFaction))
		{
			return "enemies";
		}
		if (killer != null && relationWithKiller > relationshipThreshold)
		{
			return "allies";
		}
		if (context.InformationAccessLevel == "high" || context.InformationAccessLevel == "medium")
		{
			return "allies";
		}
		if (context.InformationAccessLevel == "low")
		{
			return "commoners";
		}
		return "neutral";
	}

	private bool IsKnownToNPC(Hero npc, Hero hero)
	{
		if (npc == null || hero == null || npc == hero)
		{
			return false;
		}
		if (IsRelated(npc, hero))
		{
			return true;
		}
		if (npc.Clan != null && npc.Clan == hero.Clan)
		{
			return true;
		}
		if (npc.GetRelation(hero) > 25)
		{
			return true;
		}
		if (npc.GetRelation(hero) < -35)
		{
			return true;
		}
		if (npc.MapFaction != null && npc.MapFaction == hero.MapFaction)
		{
			return true;
		}
		return false;
	}

	private EmotionalState DetermineEmotionalResponseToDeath(Hero npc, Hero victim, Hero killer)
	{
		if (npc == null || victim == null)
		{
			return null;
		}
		bool flag = IsKnownToNPC(npc, victim);
		bool flag2 = killer != null && IsKnownToNPC(npc, killer);
		if (!flag && !flag2)
		{
			return null;
		}
		bool flag3 = IsRelated(npc, victim);
		bool flag4 = npc.IsFriend(victim);
		bool flag5 = npc.Clan != null && npc.Clan == victim.Clan;
		bool flag6 = npc.IsEnemy(victim);
		bool flag7 = killer != null && npc == killer && flag6;
		if (flag3)
		{
			return new EmotionalState
			{
				Mood = "devastated",
				Reason = $"my family member {victim.Name} (id:{((MBObjectBase)victim).StringId}) was killed"
			};
		}
		if (flag4)
		{
			return new EmotionalState
			{
				Mood = "deeply saddened",
				Reason = $"my friend {victim.Name} (id:{((MBObjectBase)victim).StringId}) died"
			};
		}
		if (flag5)
		{
			return new EmotionalState
			{
				Mood = "grieving",
				Reason = $"{victim.Name} (id:{((MBObjectBase)victim).StringId}) from my clan has fallen"
			};
		}
		if (flag7)
		{
			return new EmotionalState
			{
				Mood = "triumphant",
				Reason = $"I slayed my enemy {victim.Name} (id:{((MBObjectBase)victim).StringId})"
			};
		}
		if (flag6)
		{
			return new EmotionalState
			{
				Mood = "satisfied",
				Reason = $"my enemy {victim.Name} (id:{((MBObjectBase)victim).StringId}) is dead"
			};
		}
		return null;
	}

	private void OnMarriageAccepted(Hero proposer, Hero proposedTo, bool showNotification)
	{
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		if (proposer == null || proposedTo == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] OnMarriageAccepted called with null proposer or proposedTo!");
			return;
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] OnMarriageAccepted triggered for {proposer.Name} and {proposedTo.Name}.");
		if (proposer.IsLord && proposedTo.IsLord)
		{
			AddMarriageRecord(proposer, proposedTo);
		}
		string heroWithKingdomInfo = GetHeroWithKingdomInfo(proposer);
		string heroWithKingdomInfo2 = GetHeroWithKingdomInfo(proposedTo);
		string text = "";
		Clan clan = proposer.Clan;
		if (((clan != null) ? clan.Kingdom : null) != null)
		{
			Clan clan2 = proposedTo.Clan;
			if (((clan2 != null) ? clan2.Kingdom : null) != null)
			{
				text = ((proposer.Clan.Kingdom != proposedTo.Clan.Kingdom) ? " (political alliance)" : " (internal alliance)");
				goto IL_012a;
			}
		}
		if (proposer.Clan != null && proposedTo.Clan != null && proposer.Clan != proposedTo.Clan)
		{
			text = " (clan alliance)";
		}
		goto IL_012a;
		IL_012a:
		string text2 = heroWithKingdomInfo + " married " + heroWithKingdomInfo2 + text;
		if (proposer == Hero.MainHero || proposedTo == Hero.MainHero || proposer.Clan == Hero.MainHero.Clan || proposedTo.Clan == Hero.MainHero.Clan)
		{
			string text3 = "";
			text3 = ((proposer == Hero.MainHero || proposedTo == Hero.MainHero) ? "(you got married)" : ((proposer.Clan != Hero.MainHero.Clan) ? $"(your clan member {proposedTo.Name} got married)" : $"(your clan member {proposer.Name} got married)"));
			string text4 = $"(player's clan: {Hero.MainHero.Clan.Name}, clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId})";
			text2 = text2 + " " + text3 + " " + text4;
		}
		Dictionary<string, NPCContext> npcContextsDict = AIInfluenceBehavior.Instance?.GetNPCContexts();
		if (npcContextsDict == null || !npcContextsDict.Any())
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] No NPC contexts available for HeroesMarried event.");
			return;
		}
		List<string> source = npcContextsDict.Keys.ToList();
		NPCContext value;
		List<NPCContext> list = (from k in source
			select npcContextsDict.TryGetValue(k, out value) ? value : null into c
			where c != null
			select c).ToList();
		CampaignEvent ev = new CampaignEvent
		{
			Type = "Marriage",
			Description = text2,
			Timestamp = CampaignTime.Now
		};
		Settlement loc = proposer.CurrentSettlement ?? proposedTo.CurrentSettlement;
		MarriageData marriageData = new MarriageData
		{
			Proposer = proposer,
			ProposedTo = proposedTo,
			MarriageType = text
		};
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(((MBObjectBase)proposer).StringId);
		hashSet.Add(((MBObjectBase)proposedTo).StringId);
		HashSet<string> processedParticipantIds = AddEventToDirectParticipantsImmediately("Marriage", ev, loc, proposer, hashSet, marriageData);
		QueueEventForInformedNPCs(ev, loc, proposer, null, defer: false, marriageData, processedParticipantIds);
		AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Marriage event queued: " + text2);
	}

	private string GetDecisionDescription(KingdomDecision decision, DecisionOutcome outcome)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = ((object)decision.GetChosenOutcomeText(outcome, decision.SupportStatusOfFinalDecision, false))?.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
			string text2 = ((object)decision.GetGeneralTitle())?.ToString();
			if (!string.IsNullOrEmpty(text2))
			{
				return text2;
			}
			return "Decision of type " + ((object)decision).GetType().Name;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to get decision description: " + ex.Message);
			return "Decision of type " + ((object)decision).GetType().Name;
		}
	}

	public string GetLocationInfo(Hero npc, MobileParty npcParty)
	{
		//IL_167d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1682: Unknown result type (might be due to invalid IL or missing references)
		//IL_1686: Unknown result type (might be due to invalid IL or missing references)
		//IL_168b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1691: Unknown result type (might be due to invalid IL or missing references)
		//IL_1454: Unknown result type (might be due to invalid IL or missing references)
		//IL_1459: Unknown result type (might be due to invalid IL or missing references)
		//IL_145b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1476: Expected I4, but got Unknown
		if (npcParty != null && npcParty == Hero.MainHero.PartyBelongedTo)
		{
			string arg = ((npc == Hero.MainHero.Spouse) ? "spouse" : (npc.IsPlayerCompanion ? "companion" : "party member"));
			AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] {npc.Name} is player {arg}");
			if (Hero.MainHero.CurrentSettlement != null)
			{
				Settlement currentSettlement = Hero.MainHero.CurrentSettlement;
				string text = (currentSettlement.IsTown ? "city" : (currentSettlement.IsCastle ? "castle" : "village"));
				CultureObject culture = currentSettlement.Culture;
				string text2 = ((culture != null) ? ((object)((BasicCultureObject)culture).Name).ToString() : null) ?? "unknown culture";
				IFaction mapFaction = currentSettlement.MapFaction;
				string text3 = ((mapFaction != null) ? ((object)mapFaction.Name).ToString() : null);
				string text4 = ((!string.IsNullOrEmpty(text3) && text3 != "no kingdom") ? ("kingdom of " + text3) : "not part of any kingdom");
				string region = GetRegion(currentSettlement);
				string text5 = ((currentSettlement.Town != null) ? GetBasicProsperityDescription(currentSettlement.Town.Prosperity) : ((currentSettlement.Village != null) ? GetBasicProsperityDescription(currentSettlement.Village.Hearth) : "unknown prosperity"));
				if (currentSettlement.IsTown || currentSettlement.IsCastle)
				{
					try
					{
						LocationComplex locationComplex = currentSettlement.LocationComplex;
						if (locationComplex != null)
						{
							IEnumerable<Location> listOfLocations = locationComplex.GetListOfLocations();
							foreach (Location item in listOfLocations)
							{
								IEnumerable<LocationCharacter> characterList = item.GetCharacterList();
								if (characterList.Any(delegate(LocationCharacter c)
								{
									CharacterObject character = c.Character;
									return ((character != null) ? character.HeroObject : null) == npc;
								}))
								{
									string text6 = item.StringId switch
									{
										"tavern" => "tavern", 
										"lordshall" => "lord's hall", 
										"prison" => "prison", 
										"arena" => "arena", 
										_ => item.StringId, 
									};
									List<string> list = (from c in characterList.Where(delegate(LocationCharacter c)
										{
											CharacterObject character = c.Character;
											return ((character != null) ? character.HeroObject : null) != null && c.Character.HeroObject != npc && c.Character.HeroObject != Hero.MainHero;
										})
										select $"{c.Character.HeroObject.Name} (id:{((MBObjectBase)c.Character.HeroObject).StringId})").ToList();
									string text7 = (list.Any() ? ("present: " + string.Join(", ", list)) : "no others present");
									AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] Companion {npc.Name} found in {text6} of {currentSettlement.Name}");
									return $"traveling with you in the {text6} of {currentSettlement.Name} ({text} of {text2}, {text4}, {region}). {text5}. {text7}";
								}
							}
							AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] Companion {npc.Name} not found in any specific location in {currentSettlement.Name}");
						}
					}
					catch (Exception ex)
					{
						AIInfluenceBehavior.Instance?.LogMessage($"[ERROR] Failed to check LocationComplex for companion {npc.Name} in {currentSettlement.Name}: {ex.Message}");
					}
				}
				return $"located in {currentSettlement.Name} ({text} of {text2}, {text4}, {region}). {text5}";
			}
			string text8 = ((Hero.MainHero.PartyBelongedTo != null && Hero.MainHero.PartyBelongedTo.IsCurrentlyAtSea) ? " sailing at sea" : " on land");
			(Settlement, float) nearestSettlementInfo = GetNearestSettlementInfo(Hero.MainHero.PartyBelongedTo);
			if (nearestSettlementInfo.Item2 <= 20f)
			{
				string text9 = (nearestSettlementInfo.Item1.IsTown ? "city" : (nearestSettlementInfo.Item1.IsCastle ? "castle" : "village"));
				CultureObject culture2 = nearestSettlementInfo.Item1.Culture;
				string text10 = ((culture2 == null) ? null : ((object)((BasicCultureObject)culture2).Name)?.ToString()) ?? "unknown culture";
				IFaction mapFaction2 = nearestSettlementInfo.Item1.MapFaction;
				string text11 = ((mapFaction2 == null) ? null : ((object)mapFaction2.Name)?.ToString());
				string text12 = ((!string.IsNullOrEmpty(text11) && text11 != "no kingdom") ? ("kingdom of " + text11) : "not part of any kingdom");
				return $"located near {nearestSettlementInfo.Item1.Name} ({text9} of {text10}, {text12}),{text8}";
			}
			return "located in the wilderness," + text8;
		}
		if (npc.IsPrisoner && npc.PartyBelongedToAsPrisoner == PartyBase.MainParty)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] {npc.Name} is prisoner in player's party");
			if (Hero.MainHero.CurrentSettlement != null)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] {npc.Name} - player is in settlement {Hero.MainHero.CurrentSettlement.Name}");
				Settlement currentSettlement2 = Hero.MainHero.CurrentSettlement;
				string text13 = (currentSettlement2.IsTown ? "city" : (currentSettlement2.IsCastle ? "castle" : "village"));
				CultureObject culture3 = currentSettlement2.Culture;
				string text14 = ((culture3 != null) ? ((object)((BasicCultureObject)culture3).Name).ToString() : null) ?? "unknown culture";
				IFaction mapFaction3 = currentSettlement2.MapFaction;
				string text15 = ((mapFaction3 != null) ? ((object)mapFaction3.Name).ToString() : null);
				string text16 = ((!string.IsNullOrEmpty(text15) && text15 != "no kingdom") ? ("kingdom of " + text15) : "not part of any kingdom");
				string region2 = GetRegion(currentSettlement2);
				string text17 = ((currentSettlement2.Town != null) ? GetBasicProsperityDescription(currentSettlement2.Town.Prosperity) : ((currentSettlement2.Village != null) ? GetBasicProsperityDescription(currentSettlement2.Village.Hearth) : "unknown prosperity"));
				return $"held as prisoner in your party while you are located in {currentSettlement2.Name} ({text13} of {text14}, {text16}, {region2}). {text17}";
			}
			string text18 = ((Hero.MainHero.PartyBelongedTo != null && Hero.MainHero.PartyBelongedTo.IsCurrentlyAtSea) ? " sailing at sea" : " traveling on land");
			(Settlement, float) nearestSettlementInfo2 = GetNearestSettlementInfo(Hero.MainHero.PartyBelongedTo);
			AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
			if (instance != null)
			{
				TextObject name = npc.Name;
				var (val, _) = nearestSettlementInfo2;
				instance.LogMessage(string.Format("[DEBUG] {0} - player is traveling, nearest settlement: {1} at distance {2}", name, ((val == null) ? null : ((object)val.Name)?.ToString()) ?? "none", nearestSettlementInfo2.Item2));
			}
			if (nearestSettlementInfo2.Item2 <= 20f)
			{
				string text19 = (nearestSettlementInfo2.Item1.IsTown ? "city" : (nearestSettlementInfo2.Item1.IsCastle ? "castle" : "village"));
				CultureObject culture4 = nearestSettlementInfo2.Item1.Culture;
				string text20 = ((culture4 == null) ? null : ((object)((BasicCultureObject)culture4).Name)?.ToString()) ?? "unknown culture";
				IFaction mapFaction4 = nearestSettlementInfo2.Item1.MapFaction;
				string text21 = ((mapFaction4 == null) ? null : ((object)mapFaction4.Name)?.ToString());
				string text22 = ((!string.IsNullOrEmpty(text21) && text21 != "no kingdom") ? ("kingdom of " + text21) : "not part of any kingdom");
				return $"held as prisoner in your party,{text18}, located near {nearestSettlementInfo2.Item1.Name} ({text19} of {text20}, {text22})";
			}
			return "held as prisoner in your party," + text18 + ", traveling through the wilderness";
		}
		if (npc.CurrentSettlement != null)
		{
			Settlement settlement = npc.CurrentSettlement;
			string text23 = (settlement.IsTown ? "city" : (settlement.IsCastle ? "castle" : "village"));
			CultureObject culture5 = settlement.Culture;
			string text24 = ((culture5 != null) ? ((object)((BasicCultureObject)culture5).Name).ToString() : null) ?? "unknown culture";
			Clan ownerClan = settlement.OwnerClan;
			string text25 = ((ownerClan != null) ? ((object)ownerClan.Name).ToString() : null) ?? "no clan";
			Clan ownerClan2 = settlement.OwnerClan;
			object obj;
			if (ownerClan2 == null)
			{
				obj = null;
			}
			else
			{
				Hero leader = ownerClan2.Leader;
				obj = ((leader == null) ? null : ((object)leader.Name)?.ToString());
			}
			string text26 = (string)obj;
			string text27 = ((settlement.OwnerClan != null) ? ("owned by clan " + text25 + (string.IsNullOrEmpty(text26) ? "" : (" led by " + text26))) : "with no ruling clan");
			IFaction mapFaction5 = settlement.MapFaction;
			string text28 = ((mapFaction5 != null) ? ((object)mapFaction5.Name).ToString() : null);
			string text29 = ((!string.IsNullOrEmpty(text28) && text28 != "no kingdom") ? ("kingdom of " + text28) : "not part of any kingdom");
			string region3 = GetRegion(settlement);
			string text30 = (((IEnumerable<Hero>)settlement.Notables).Any() ? string.Join(", ", ((IEnumerable<Hero>)settlement.Notables).Select((Hero n) => ((object)n.Name).ToString())) : "no notable figures");
			string text31 = ((settlement.Town != null && Campaign.Current.TournamentManager.GetTournamentGame(settlement.Town) != null) ? "a tournament is being held" : "no tournaments");
			Town town = settlement.Town;
			string text32 = ((((town != null) ? town.CurrentBuilding : null) != null) ? ("current project: " + (GameVersionCompatibility.GetBuildingTypeName(settlement.Town.CurrentBuilding) ?? "unknown")) : "no active projects");
			string text33 = ((settlement.Town != null) ? GetProsperityDescription(settlement.Town.Prosperity) : ((settlement.Village != null) ? GetBasicProsperityDescription(settlement.Village.Hearth) : "unknown prosperity"));
			string text34 = ((settlement.Town != null) ? GetLoyaltyDescription(settlement.Town.Loyalty, text25) : "not applicable");
			string text35 = ((settlement.Town != null) ? GetSecurityDescription(settlement.Town.Security) : "not applicable");
			string text36 = ((settlement.Town != null) ? GetFoodDescription(((Fief)settlement.Town).FoodStocks) : "not applicable");
			List<string> list2 = (from s in ((IEnumerable<Settlement>)Campaign.Current.Settlements).Where((Settlement s) => s != settlement).Select(delegate(Settlement s)
				{
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_000c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0010: Unknown result type (might be due to invalid IL or missing references)
					Vec2 position2D = settlement.GetPosition2D();
					return (Settlement: s, Distance: (position2D).Distance(s.GetPosition2D()));
				})
				where s.Distance <= 50f
				orderby s.Distance
				select s).Take(3).Select(delegate((Settlement Settlement, float Distance) s)
			{
				string text60 = (s.Settlement.IsTown ? "city" : (s.Settlement.IsCastle ? "castle" : "village"));
				CultureObject culture6 = s.Settlement.Culture;
				string text61 = ((culture6 == null) ? null : ((object)((BasicCultureObject)culture6).Name)?.ToString()) ?? "unknown culture";
				IFaction mapFaction7 = s.Settlement.MapFaction;
				string text62 = ((mapFaction7 == null) ? null : ((object)mapFaction7.Name)?.ToString());
				string text63 = ((!string.IsNullOrEmpty(text62) && text62 != "no kingdom") ? ("kingdom of " + text62) : "not part of any kingdom");
				return $"{s.Settlement.Name} ({text60} of {text61}, {text63})";
			}).ToList();
			string text37 = (list2.Any() ? ("nearby settlements: " + string.Join(", ", list2)) : "no nearby settlements");
			string boundVillagesDescription = GetBoundVillagesDescription(settlement);
			object obj2;
			if (settlement.LastAttackerParty == null)
			{
				obj2 = "no recent attacks";
			}
			else
			{
				IFaction mapFaction6 = settlement.LastAttackerParty.MapFaction;
				obj2 = (((mapFaction6 == null) ? null : ((object)mapFaction6.Name)?.ToString()) ?? ((object)settlement.LastAttackerParty.Name)?.ToString()) + " attacked recently";
			}
			string text38 = (string)obj2;
			Town town2 = settlement.Town;
			string text39 = ((((town2 != null) ? town2.LastCapturedBy : null) != null) ? $"last captured by {settlement.Town.LastCapturedBy.Name}" : "never captured");
			string text40 = "none";
			if (npc.Clan == settlement.OwnerClan && settlement.Party.PrisonRoster.Count > 0)
			{
				List<string> list3 = (from t in (IEnumerable<TroopRosterElement>)settlement.Party.PrisonRoster.GetTroopRoster()
					where ((BasicCharacterObject)t.Character).IsHero && t.Character.HeroObject.IsLord
					select ((object)t.Character.HeroObject.Name).ToString()).ToList();
				text40 = (list3.Any() ? ("prisoners: " + string.Join(", ", list3)) : "no lord prisoners");
			}
			if (settlement.IsTown || settlement.IsCastle)
			{
				try
				{
					LocationComplex locationComplex2 = settlement.LocationComplex;
					if (locationComplex2 != null)
					{
						IEnumerable<Location> listOfLocations2 = locationComplex2.GetListOfLocations();
						foreach (Location item2 in listOfLocations2)
						{
							IEnumerable<LocationCharacter> characterList2 = item2.GetCharacterList();
							if (characterList2.Any(delegate(LocationCharacter c)
							{
								CharacterObject character = c.Character;
								return ((character != null) ? character.HeroObject : null) == npc;
							}))
							{
								string text41 = item2.StringId switch
								{
									"tavern" => "tavern", 
									"lordshall" => "lord's hall", 
									"prison" => "prison", 
									"arena" => "arena", 
									_ => item2.StringId, 
								};
								List<string> list4 = (from c in characterList2.Where(delegate(LocationCharacter c)
									{
										CharacterObject character = c.Character;
										return ((character != null) ? character.HeroObject : null) != null && c.Character.HeroObject != npc;
									})
									select $"{c.Character.HeroObject.Name} (id:{((MBObjectBase)c.Character.HeroObject).StringId})").ToList();
								string text42 = (list4.Any() ? ("present: " + string.Join(", ", list4)) : "no others present");
								AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] NPC {npc.Name} found in {text41} of {settlement.Name}");
								string ownershipContextForAI = SettlementOwnershipTracker.Instance.GetOwnershipContextForAI(((MBObjectBase)settlement).StringId);
								string text43 = ((!string.IsNullOrEmpty(ownershipContextForAI)) ? (", " + ownershipContextForAI) : "");
								string text44 = $"located in the {text41} of {settlement.Name} ({text23} of {text24}, {text27}, {text29}, {region3}{text43})";
								string text45 = "Prosperity: " + text33 + "; Loyalty: " + text34 + "; Security: " + text35 + "; Food: " + text36;
								string text46 = "Notables: " + text30 + "; " + text31 + "; " + text32 + "; " + text37 + "; " + boundVillagesDescription + "; " + text38 + "; " + text39;
								string text47 = ((text40 != "none") ? ("; " + text40) : "");
								return text44 + ". " + text45 + ". " + text46 + text47 + ". " + text42 + ".";
							}
						}
					}
					else
					{
						AIInfluenceBehavior.Instance?.LogMessage($"[WARNING] LocationComplex is null for {settlement.Name}");
					}
				}
				catch (Exception ex2)
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[ERROR] Failed to check LocationComplex for {npc.Name} in {settlement.Name}: {ex2.Message}");
				}
				string ownershipContextForAI2 = SettlementOwnershipTracker.Instance.GetOwnershipContextForAI(((MBObjectBase)settlement).StringId);
				string text48 = ((!string.IsNullOrEmpty(ownershipContextForAI2)) ? (", " + ownershipContextForAI2) : "");
				string text49 = $"located in {settlement.Name} ({text23} of {text24}, {text27}, {text29}, {region3}{text48})";
				string text50 = "Prosperity: " + text33 + "; Loyalty: " + text34 + "; Security: " + text35 + "; Food: " + text36;
				string text51 = "Notables: " + text30 + "; " + text31 + "; " + text32 + "; " + text37 + "; " + boundVillagesDescription + "; " + text38 + "; " + text39;
				string text52 = ((text40 != "none") ? ("; " + text40) : "");
				return text49 + ". " + text50 + ". " + text51 + text52 + ".";
			}
			if (settlement.IsVillage && settlement.Village != null)
			{
				VillageStates villageState = settlement.Village.VillageState;
				string text53 = (int)villageState switch
				{
					0 => "prospering", 
					1 => "being raided", 
					4 => "looted and deserted", 
					2 => "forced to provide volunteers", 
					3 => "forced to provide supplies", 
					_ => "unknown state", 
				};
				AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] NPC {npc.Name} is in village {settlement.Name}");
				string ownershipContextForAI3 = SettlementOwnershipTracker.Instance.GetOwnershipContextForAI(((MBObjectBase)settlement).StringId);
				string text54 = ((!string.IsNullOrEmpty(ownershipContextForAI3)) ? (", " + ownershipContextForAI3) : "");
				string text55 = $"located in the village of {settlement.Name} (of {text24}, {text27}, {text29}, {region3}, {text53}{text54})";
				string text56 = "Prosperity: " + text33 + "; Food: " + text36;
				string text57 = "Notables: " + text30 + "; " + text37 + "; " + text38 + "; " + text39;
				return text55 + ". " + text56 + ". " + text57 + ".";
			}
			string arg2 = (settlement.IsHideout ? "hideout" : "settlement");
			return $"located in {settlement.Name} ({arg2} in {region3}).";
		}
		if (npcParty != null)
		{
			string text58 = (npcParty.IsCurrentlyAtSea ? " sailing at sea" : " on land");
			(Settlement, float) nearestSettlementInfo3 = GetNearestSettlementInfo(npcParty);
			List<(Settlement, float)> list5 = new List<(Settlement, float)>();
			foreach (Settlement item3 in (List<Settlement>)(object)Campaign.Current.Settlements)
			{
				CampaignVec2 position = npcParty.Position;
				Vec2 val2 = (position).ToVec2();
				float num = (val2).Distance(item3.GetGatePosition());
				if (num <= 20f)
				{
					list5.Add((item3, num));
				}
			}
			if (list5.Count > 0)
			{
				list5 = (from x in list5
					group x by ((MBObjectBase)x.Settlement).StringId into g
					select g.First()).ToList();
				list5.Sort(((Settlement Settlement, float Distance) a, (Settlement Settlement, float Distance) b) => a.Distance.CompareTo(b.Distance));
				List<string> values = list5.Select<(Settlement, float), string>(delegate((Settlement Settlement, float Distance) x)
				{
					string text60 = (x.Item1.IsTown ? "city" : (x.Settlement.IsCastle ? "castle" : "village"));
					CultureObject culture6 = x.Settlement.Culture;
					string text61 = ((culture6 == null) ? null : ((object)((BasicCultureObject)culture6).Name)?.ToString()) ?? "unknown culture";
					IFaction mapFaction7 = x.Settlement.MapFaction;
					string text62 = ((mapFaction7 == null) ? null : ((object)mapFaction7.Name)?.ToString());
					string text63 = ((!string.IsNullOrEmpty(text62) && text62 != "no kingdom") ? ("kingdom of " + text62) : "not part of any kingdom");
					return $"{x.Settlement.Name} ({text60} of {text61}, {text63})";
				}).ToList();
				return "located patrolling near " + string.Join(" and ", values) + "," + text58;
			}
			return "located in the wilderness, far from any settlement," + text58;
		}
		if (npcParty != null)
		{
			string text59 = (npcParty.IsCurrentlyAtSea ? " sailing at sea" : " on land");
			return "in the wilderness, far from any settlement," + text59;
		}
		return "in the wilderness, far from any settlement";
	}

	private string GetProsperityDescription(float prosperity)
	{
		if (prosperity < 2000f)
		{
			return "struggling, with many in poverty";
		}
		if (prosperity <= 4000f)
		{
			return "fair, with modest means";
		}
		return "flourishing, with great wealth";
	}

	private string GetLoyaltyDescription(float loyalty, string ownerClan)
	{
		if (loyalty < 30f)
		{
			return "discontent, many resent " + ownerClan;
		}
		if (loyalty <= 70f)
		{
			return "mixed, some support " + ownerClan + ", others do not";
		}
		return "loyal, most hold " + ownerClan + " in high regard";
	}

	private string GetSecurityDescription(float security)
	{
		if (security < 30f)
		{
			return "dangerous, with rampant crime and unrest";
		}
		if (security <= 70f)
		{
			return "stable, though caution is advised";
		}
		return "safe, with peace and order prevailing";
	}

	private string GetFoodDescription(float foodStocks)
	{
		if (foodStocks < 50f)
		{
			return "scarce, many go hungry";
		}
		if (foodStocks <= 150f)
		{
			return "adequate, enough to sustain the people";
		}
		return "abundant, no one wants for food";
	}

	private string GetRegion(Settlement settlement)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Vec2 position2D = settlement.GetPosition2D();
		if (((MBObjectBase)settlement.Culture).StringId.Contains("vlandia"))
		{
			return "western plains";
		}
		if (((MBObjectBase)settlement.Culture).StringId.Contains("sturgia"))
		{
			return "northern forests";
		}
		if (((MBObjectBase)settlement.Culture).StringId.Contains("khuzait"))
		{
			return "eastern steppes";
		}
		if (((MBObjectBase)settlement.Culture).StringId.Contains("aserai"))
		{
			return "southern deserts";
		}
		if (((MBObjectBase)settlement.Culture).StringId.Contains("battania"))
		{
			return "central highlands";
		}
		if (((MBObjectBase)settlement.Culture).StringId.Contains("empire"))
		{
			return "imperial heartlands";
		}
		return "unknown region";
	}

	private string GetBoundVillagesDescription(Settlement settlement)
	{
		if (!((IEnumerable<Village>)settlement.BoundVillages).Any())
		{
			return "no bound villages";
		}
		List<string> values = ((IEnumerable<Village>)settlement.BoundVillages).Select(delegate(Village v)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected I4, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			VillageStates villageState = v.VillageState;
			string text = (int)villageState switch
			{
				0 => "prospering", 
				1 => "being raided", 
				4 => "looted and deserted", 
				2 => "forced to provide volunteers", 
				3 => "forced to provide supplies", 
				_ => "unknown state", 
			};
			object obj;
			if (v.TradeBound == null || v.TradeBound.ItemRoster.Count <= 0)
			{
				obj = "no notable production";
			}
			else
			{
				ItemRosterElement val = v.TradeBound.ItemRoster[0];
				EquipmentElement equipmentElement = (val).EquipmentElement;
				obj = "produces " + ((object)(equipmentElement).Item.Name).ToString();
			}
			string text2 = (string)obj;
			string text3 = (((IEnumerable<Hero>)((SettlementComponent)v).Settlement.Notables).Any() ? ("notables: " + string.Join(", ", ((IEnumerable<Hero>)((SettlementComponent)v).Settlement.Notables).Select((Hero n) => ((object)n.Name).ToString()))) : "no notables");
			return $"{((SettlementComponent)v).Name} ({text}, {text2}, {text3})";
		}).ToList();
		return "bound villages: " + string.Join("; ", values);
	}

	public void UpdateLocationType(NPCContext context, Hero npc)
	{
		MobileParty partyBelongedTo = npc.PartyBelongedTo;
		context.LocationType = GetLocationInfo(npc, partyBelongedTo);
	}

	public (Settlement Settlement, float Distance) GetNearestSettlementInfo(MobileParty party)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (party == null)
		{
			return (Settlement: null, Distance: float.MaxValue);
		}
		return GetNearestSettlementInfo(party.GetPosition2D());
	}

	public (Settlement Settlement, float Distance) GetNearestSettlementInfo(Vec2 position)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		Settlement item = null;
		float num = float.MaxValue;
		foreach (Settlement item2 in (List<Settlement>)(object)Settlement.All)
		{
			float num2 = (position).Distance(item2.GetPosition2D());
			if (num2 < num)
			{
				num = num2;
				item = item2;
			}
		}
		return (Settlement: item, Distance: num);
	}

	private string GetBasicProsperityDescription(float prosperity)
	{
		if (prosperity < 2000f)
		{
			return "The settlement appears to be struggling";
		}
		if (prosperity <= 4000f)
		{
			return "The settlement seems to be doing well";
		}
		return "The settlement appears to be very prosperous";
	}

	private bool ShouldNPCKnowAboutEvent(Hero npc, NPCContext context, string eventType, Settlement eventLocation = null, Hero eventParticipant = null, object extraData = null)
	{
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_0679: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null || context == null)
		{
			return false;
		}
		if (eventType == "WarDeclared")
		{
			return true;
		}
		bool flag = eventType == "Battle";
		bool flag2 = GlobalSettings<ModSettings>.Instance?.EnableDetailedInfoLogging ?? false;
		if (flag && flag2)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-KNOWLEDGE-CHECK] Checking if {npc.Name} should know about battle (access level: {context.InformationAccessLevel})");
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && !instance.RealisticInformationSpread && IsNPCDirectlyRelatedToEvent(npc, eventType, eventParticipant, extraData))
		{
			return true;
		}
		if (IsNPCDirectlyRelatedToEvent(npc, eventType, eventParticipant, extraData))
		{
			return true;
		}
		if (IsEventPlayerInvolved(eventType, extraData))
		{
			List<AIQuestInfo> activeAIQuests = context.ActiveAIQuests;
			if (activeAIQuests != null && activeAIQuests.Count > 0)
			{
				if (flag2)
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[QUEST-OVERRIDE] {npc.Name} has {context.ActiveAIQuests.Count} active quest(s) — always learns about player-involved {eventType}");
				}
				return true;
			}
		}
		if (IsEventPlayerInvolved(eventType, extraData))
		{
			List<AIQuestInfo> incomingAIQuests = context.IncomingAIQuests;
			if (incomingAIQuests != null && incomingAIQuests.Count > 0)
			{
				if (flag2)
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[QUEST-OVERRIDE] {npc.Name} is target/completer NPC in {context.IncomingAIQuests.Count} quest(s) — always learns about player-involved {eventType}");
				}
				return true;
			}
		}
		if (eventType == "Tournament" && extraData is TournamentData { Settlement: not null } tournamentData)
		{
			if (npc.CurrentSettlement == tournamentData.Settlement)
			{
				return true;
			}
			if (npc.PartyBelongedTo != null && npc.PartyBelongedTo.CurrentSettlement == tournamentData.Settlement)
			{
				return true;
			}
			if (npc.Clan != null && tournamentData.ParticipantHeroes != null)
			{
				foreach (Hero participantHero in tournamentData.ParticipantHeroes)
				{
					if (participantHero != null && participantHero.Clan != null && participantHero.Clan == npc.Clan)
					{
						return true;
					}
				}
			}
			if (npc.Clan != null && tournamentData.Winner != null && tournamentData.Winner.Clan != null && tournamentData.Winner.Clan == npc.Clan)
			{
				return true;
			}
		}
		if (eventParticipant != null)
		{
			if (npc.PartyBelongedTo != null && eventParticipant.PartyBelongedTo != null && npc.PartyBelongedTo == eventParticipant.PartyBelongedTo)
			{
				return true;
			}
			MobileParty partyBelongedTo = npc.PartyBelongedTo;
			if (((partyBelongedTo != null) ? partyBelongedTo.Army : null) != null)
			{
				MobileParty partyBelongedTo2 = eventParticipant.PartyBelongedTo;
				if (((partyBelongedTo2 != null) ? partyBelongedTo2.Army : null) != null && npc.PartyBelongedTo.Army == eventParticipant.PartyBelongedTo.Army)
				{
					return true;
				}
			}
		}
		Settlement val = npc.CurrentSettlement;
		MobileParty partyBelongedTo3 = npc.PartyBelongedTo;
		if (flag2)
		{
			string text = ((val != null) ? $"in settlement {val.Name}" : ((partyBelongedTo3 != null) ? $"in party {partyBelongedTo3.Name}" : "no location"));
			AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-DISTANCE-DEBUG] {npc.Name}: location={text}, hasParty={partyBelongedTo3 != null}, hasSettlement={val != null}");
		}
		if (val == null && partyBelongedTo3 != null)
		{
			(val, _) = GetNearestSettlementInfo(partyBelongedTo3);
			if (flag2)
			{
				AIInfluenceBehavior.Instance?.LogMessage(string.Format("[BATTLE-DISTANCE-DEBUG] {0}: using nearest settlement {1} for party location", npc.Name, ((val == null) ? null : ((object)val.Name)?.ToString()) ?? "none"));
			}
		}
		float num = 0f;
		if (eventType == "Battle" && extraData is BattleData battleData && battleData.Position != Vec2.Zero)
		{
			Vec2 position = battleData.Position;
			if (flag2)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-DISTANCE-DEBUG] {npc.Name}: battlePosition=({(position).X:F1}, {(position).Y:F1})");
			}
			if (partyBelongedTo3 != null)
			{
				CampaignVec2 position2 = partyBelongedTo3.Position;
				Vec2 val2 = (position2).ToVec2();
				num = (val2).Distance(position);
				if (flag2)
				{
					TextObject name = partyBelongedTo3.Name;
					object arg = partyBelongedTo3.MemberRoster.TotalManCount;
					Hero leaderHero = partyBelongedTo3.LeaderHero;
					string text2 = string.Format("{0} (size: {1}, leader: {2})", name, arg, ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? "none");
					string text3 = ((partyBelongedTo3.CurrentSettlement != null) ? ("in " + ((object)partyBelongedTo3.CurrentSettlement.Name).ToString()) : ((partyBelongedTo3.TargetSettlement != null) ? ("heading to " + ((object)partyBelongedTo3.TargetSettlement.Name).ToString()) : "in field"));
					AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-DISTANCE-DEBUG] {npc.Name}: party='{text2}', location='{text3}', npcPosition=({(val2).X:F1}, {(val2).Y:F1}), battlePosition=({(position).X:F1}, {(position).Y:F1}), distance={num:F1}");
				}
			}
			else if (val != null)
			{
				Vec2 position2D = val.GetPosition2D();
				num = (position2D).Distance(position);
				if (flag2)
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-DISTANCE-DEBUG] {npc.Name}: settlementPosition=({(position2D).X:F1}, {(position2D).Y:F1}), distance={num:F1}");
				}
			}
			else
			{
				if (flag2)
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-DISTANCE-DEBUG] {npc.Name}: ERROR - no party and no settlement found! Cannot calculate distance.");
				}
				num = float.MaxValue;
			}
		}
		else
		{
			if (eventType == "Battle" && flag2)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-DISTANCE-DEBUG] {npc.Name}: Battle event but no valid BattleData.Position! Using fallback logic.");
			}
			if (eventLocation != null && val != null)
			{
				num = GameVersionCompatibility.GetDistance(val, eventLocation);
			}
			else if (eventLocation != null && partyBelongedTo3 != null)
			{
				num = GameVersionCompatibility.GetDistance(partyBelongedTo3, eventLocation);
			}
		}
		float maxDistanceForEventType = GetMaxDistanceForEventType(eventType, context.InformationAccessLevel, npc, eventParticipant);
		if (num > maxDistanceForEventType)
		{
			if (IsNPCDirectlyRelatedToEvent(npc, eventType, eventParticipant, extraData))
			{
				return true;
			}
			return false;
		}
		if (!HasSocialAccessToEventType(context.InformationAccessLevel, eventType, npc, eventParticipant))
		{
			if (flag && flag2)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-KNOWLEDGE-CHECK] {npc.Name} blocked by social access level: {context.InformationAccessLevel}");
			}
			return false;
		}
		if (flag && flag2)
		{
			string arg2 = (IsEventPlayerInvolved(eventType, extraData) ? " (player involved)" : "");
			AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-KNOWLEDGE-CHECK] {npc.Name} WILL learn about battle{arg2}: passed all checks");
		}
		return true;
	}

	private float GetMaxDistanceForEventType(string eventType, string accessLevel, Hero npc = null, Hero eventParticipant = null)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null)
		{
			return 15f;
		}
		float num;
		switch (eventType.ToLower())
		{
		case "tournament":
		case "marriage":
		case "herokilled":
		case "prisonertaken":
		case "prisonerreleased":
			num = instance.LocalNewsDistance;
			break;
		case "wardeclared":
		case "battle":
		case "settlementownerchanged":
		case "worldevent":
			num = instance.RegionalNewsDistance;
			break;
		case "law":
		case "kingdomdecisionconcluded":
			num = GetPoliticalNewsDistance(accessLevel, npc, eventParticipant);
			break;
		default:
			num = instance.LocalNewsDistance;
			break;
		}
		if (eventType.ToLower() == "law" || eventType.ToLower() == "kingdomdecisionconcluded")
		{
			return num;
		}
		if (!(accessLevel == "high"))
		{
			if (accessLevel == "medium")
			{
				return num * instance.NobleDistanceMultiplier;
			}
			return num;
		}
		return num * instance.RoyalDistanceMultiplier;
	}

	private float GetPoliticalNewsDistance(string accessLevel, Hero npc, Hero eventParticipant)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null)
		{
			return 150f;
		}
		float num = instance.KingdomNewsDistance;
		bool flag = false;
		if (npc != null && eventParticipant != null && npc.MapFaction != null && eventParticipant.MapFaction != null)
		{
			flag = npc.MapFaction == eventParticipant.MapFaction;
		}
		if (flag)
		{
			num *= 1.5f;
		}
		if (!(accessLevel == "high"))
		{
			if (accessLevel == "medium")
			{
				return num * instance.NobleDistanceMultiplier;
			}
			return flag ? num : 0f;
		}
		return num * instance.RoyalDistanceMultiplier;
	}

	private bool HasSocialAccessToEventType(string accessLevel, string eventType, Hero npc = null, Hero eventParticipant = null)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableSocialFiltering)
		{
			return true;
		}
		switch (eventType.ToLower())
		{
		case "law":
		case "kingdomdecisionconcluded":
			return HasAccessToPoliticalNews(accessLevel, npc, eventParticipant);
		case "wardeclared":
			return true;
		case "tournament":
		case "marriage":
		case "battle":
		case "settlementownerchanged":
		case "herokilled":
			return true;
		default:
			return true;
		}
	}

	private bool HasAccessToPoliticalNews(string accessLevel, Hero npc, Hero eventParticipant)
	{
		if (accessLevel == "high" || accessLevel == "medium")
		{
			return true;
		}
		if (npc != null && eventParticipant != null && npc.MapFaction != null && eventParticipant.MapFaction != null)
		{
			return npc.MapFaction == eventParticipant.MapFaction;
		}
		return false;
	}

	private bool IsNPCDirectlyRelatedToEvent(Hero npc, string eventType, Hero eventParticipant, object extraData = null)
	{
		if (npc == null)
		{
			return false;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null)
		{
			return false;
		}
		if (extraData != null)
		{
			if (extraData is BattleData battleData)
			{
				if ((battleData.AttackerHeroIds != null && battleData.AttackerHeroIds.Contains(((MBObjectBase)npc).StringId)) || (battleData.DefenderHeroIds != null && battleData.DefenderHeroIds.Contains(((MBObjectBase)npc).StringId)))
				{
					return true;
				}
			}
			else
			{
				if (extraData is PrisonerEventData prisonerEventData)
				{
					string stringId = ((MBObjectBase)npc).StringId;
					Hero prisoner = prisonerEventData.Prisoner;
					if (!(stringId == ((prisoner != null) ? ((MBObjectBase)prisoner).StringId : null)))
					{
						string stringId2 = ((MBObjectBase)npc).StringId;
						Hero participant = prisonerEventData.Participant;
						if (!(stringId2 == ((participant != null) ? ((MBObjectBase)participant).StringId : null)))
						{
							goto IL_0449;
						}
					}
					return true;
				}
				if (extraData is SettlementCaptureData settlementCaptureData)
				{
					string stringId3 = ((MBObjectBase)npc).StringId;
					Hero newOwner = settlementCaptureData.NewOwner;
					if (!(stringId3 == ((newOwner != null) ? ((MBObjectBase)newOwner).StringId : null)))
					{
						string stringId4 = ((MBObjectBase)npc).StringId;
						Hero previousOwner = settlementCaptureData.PreviousOwner;
						if (!(stringId4 == ((previousOwner != null) ? ((MBObjectBase)previousOwner).StringId : null)))
						{
							if (npc.Clan != null && (npc.Clan == settlementCaptureData.NewClan || npc.Clan == settlementCaptureData.PreviousClan))
							{
								return true;
							}
							goto IL_0449;
						}
					}
					return true;
				}
				if (extraData is HeroKilledData heroKilledData)
				{
					string stringId5 = ((MBObjectBase)npc).StringId;
					Hero victim = heroKilledData.Victim;
					if (!(stringId5 == ((victim != null) ? ((MBObjectBase)victim).StringId : null)))
					{
						string stringId6 = ((MBObjectBase)npc).StringId;
						Hero killer = heroKilledData.Killer;
						if (!(stringId6 == ((killer != null) ? ((MBObjectBase)killer).StringId : null)))
						{
							goto IL_0449;
						}
					}
					return true;
				}
				if (extraData is MarriageData marriageData)
				{
					string stringId7 = ((MBObjectBase)npc).StringId;
					Hero proposer = marriageData.Proposer;
					if (!(stringId7 == ((proposer != null) ? ((MBObjectBase)proposer).StringId : null)))
					{
						string stringId8 = ((MBObjectBase)npc).StringId;
						Hero proposedTo = marriageData.ProposedTo;
						if (!(stringId8 == ((proposedTo != null) ? ((MBObjectBase)proposedTo).StringId : null)))
						{
							goto IL_0449;
						}
					}
					return true;
				}
				if (extraData is TournamentData tournamentData)
				{
					if (tournamentData.ParticipantIds != null && tournamentData.ParticipantIds.Contains(((MBObjectBase)npc).StringId))
					{
						return true;
					}
					if (tournamentData.Settlement != null)
					{
						if (npc.CurrentSettlement != null && npc.CurrentSettlement == tournamentData.Settlement)
						{
							return true;
						}
						if (npc.PartyBelongedTo != null && npc.PartyBelongedTo.CurrentSettlement == tournamentData.Settlement)
						{
							return true;
						}
					}
					if (npc.Clan != null)
					{
						if (tournamentData.ParticipantHeroes != null && tournamentData.ParticipantHeroes.Count > 0)
						{
							foreach (Hero participantHero in tournamentData.ParticipantHeroes)
							{
								if (participantHero != null && participantHero.Clan != null && participantHero.Clan == npc.Clan)
								{
									return true;
								}
							}
						}
						if (tournamentData.Winner != null && tournamentData.Winner.Clan != null && tournamentData.Winner.Clan == npc.Clan)
						{
							return true;
						}
					}
				}
				else if (extraData is WarDeclaredData warDeclaredData && (npc.MapFaction == warDeclaredData.Faction1 || npc.MapFaction == warDeclaredData.Faction2))
				{
					return true;
				}
			}
		}
		goto IL_0449;
		IL_0449:
		if (eventParticipant != null && ((MBObjectBase)npc).StringId == ((MBObjectBase)eventParticipant).StringId)
		{
			return true;
		}
		if (eventType == "Battle" && extraData is BattleData battleData2 && ((battleData2.AttackerHeroIds != null && battleData2.AttackerHeroIds.Contains(((MBObjectBase)npc).StringId)) || (battleData2.DefenderHeroIds != null && battleData2.DefenderHeroIds.Contains(((MBObjectBase)npc).StringId))))
		{
			return true;
		}
		if (eventParticipant != null)
		{
			if (IsRelated(npc, eventParticipant))
			{
				return true;
			}
			if (npc.Clan != null && eventParticipant.Clan != null && npc.Clan == eventParticipant.Clan)
			{
				return true;
			}
		}
		if (eventParticipant != null && npc.PartyBelongedTo != null && eventParticipant.PartyBelongedTo != null)
		{
			if (npc.PartyBelongedTo == eventParticipant.PartyBelongedTo)
			{
				return true;
			}
			if (npc.PartyBelongedTo.Army != null && npc.PartyBelongedTo.Army == eventParticipant.PartyBelongedTo.Army)
			{
				return true;
			}
			MapEvent mapEvent = npc.PartyBelongedTo.MapEvent;
			MapEvent mapEvent2 = eventParticipant.PartyBelongedTo.MapEvent;
			if (mapEvent != null && mapEvent2 != null && mapEvent == mapEvent2)
			{
				return true;
			}
		}
		return false;
	}

	private string GetReasonForKnowing(Hero npc, NPCContext context, string eventType, Settlement eventLocation, Hero eventParticipant, object extraData = null)
	{
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null)
		{
			return "settings unavailable";
		}
		if (instance.EnableRelationshipOverride && IsNPCDirectlyRelatedToEvent(npc, eventType, eventParticipant, extraData))
		{
			if (eventParticipant != null)
			{
				if (IsRelated(npc, eventParticipant))
				{
					return "blood relative";
				}
				int relation = npc.GetRelation(eventParticipant);
				if (npc.Clan == eventParticipant.Clan)
				{
					return "same clan";
				}
				if (relation > instance.RelationshipThreshold)
				{
					return $"friend (relation: {relation})";
				}
				if (relation < -instance.RelationshipThreshold)
				{
					return $"enemy (relation: {relation})";
				}
				if (npc.MapFaction == eventParticipant.MapFaction)
				{
					return "same faction";
				}
				if (FactionManager.IsAtWarAgainstFaction(npc.MapFaction, eventParticipant.MapFaction))
				{
					return "enemy faction";
				}
			}
			return "directly involved in event";
		}
		if (eventLocation != null || (eventType == "Battle" && extraData is BattleData))
		{
			float num = 0f;
			Settlement currentSettlement = npc.CurrentSettlement;
			MobileParty partyBelongedTo = npc.PartyBelongedTo;
			if (eventType == "Battle" && extraData is BattleData battleData && battleData.Position != Vec2.Zero)
			{
				Vec2 position = battleData.Position;
				if (partyBelongedTo != null)
				{
					CampaignVec2 position2 = partyBelongedTo.Position;
					Vec2 val = (position2).ToVec2();
					num = (val).Distance(position);
				}
				else if (currentSettlement != null)
				{
					Vec2 position2D = currentSettlement.GetPosition2D();
					num = (position2D).Distance(position);
				}
			}
			else if (eventLocation != null)
			{
				if (currentSettlement != null)
				{
					num = GameVersionCompatibility.GetDistance(currentSettlement, eventLocation);
				}
				else if (partyBelongedTo != null)
				{
					num = GameVersionCompatibility.GetDistance(partyBelongedTo, eventLocation);
				}
			}
			float maxDistanceForEventType = GetMaxDistanceForEventType(eventType, context.InformationAccessLevel, npc, eventParticipant);
			return $"close enough (distance: {num:F1}, max: {maxDistanceForEventType:F1}, status: {context.InformationAccessLevel})";
		}
		return "within information network";
	}

	private bool IsEventPlayerInvolved(string eventType, object extraData = null)
	{
		if (extraData is BattleData { IsPlayerInvolved: var isPlayerInvolved })
		{
			return isPlayerInvolved;
		}
		if (extraData is PrisonerEventData { IsPlayerInvolved: var isPlayerInvolved2 })
		{
			return isPlayerInvolved2;
		}
		if (extraData is SettlementCaptureData { PlayerInvolved: var playerInvolved })
		{
			return playerInvolved;
		}
		if (extraData is HeroKilledData { PlayerInvolved: var playerInvolved2 })
		{
			return playerInvolved2;
		}
		if (!(extraData is TournamentData { IsPlayerInvolved: var isPlayerInvolved3 }))
		{
			return false;
		}
		return isPlayerInvolved3;
	}

	private string GetReasonForNotKnowing(Hero npc, NPCContext context, string eventType, Settlement eventLocation, Hero eventParticipant, object extraData = null)
	{
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null)
		{
			return "settings unavailable";
		}
		if (IsNPCDirectlyRelatedToEvent(npc, eventType, eventParticipant, extraData))
		{
			return "close enough (direct participant)";
		}
		if (instance.EnableSocialFiltering && !HasSocialAccessToEventType(context.InformationAccessLevel, eventType, npc, eventParticipant))
		{
			if (eventType.ToLower() == "law" || eventType.ToLower() == "kingdomdecisionconcluded")
			{
				bool flag = ((npc != null) ? npc.MapFaction : null) == ((eventParticipant != null) ? eventParticipant.MapFaction : null);
				if (context.InformationAccessLevel == "low" && !flag)
				{
					return "insufficient social status (" + context.InformationAccessLevel + ") for foreign " + eventType;
				}
			}
			return "insufficient social status (" + context.InformationAccessLevel + ") for " + eventType;
		}
		if (eventLocation != null || (eventType == "Battle" && extraData is BattleData))
		{
			float num = 0f;
			Settlement currentSettlement = npc.CurrentSettlement;
			MobileParty partyBelongedTo = npc.PartyBelongedTo;
			if (eventType == "Battle" && extraData is BattleData battleData && battleData.Position != Vec2.Zero)
			{
				Vec2 position = battleData.Position;
				if (partyBelongedTo != null)
				{
					CampaignVec2 position2 = partyBelongedTo.Position;
					Vec2 val = (position2).ToVec2();
					num = (val).Distance(position);
				}
				else if (currentSettlement != null)
				{
					Vec2 position2D = currentSettlement.GetPosition2D();
					num = (position2D).Distance(position);
				}
			}
			else if (eventLocation != null)
			{
				if (currentSettlement != null)
				{
					num = GameVersionCompatibility.GetDistance(currentSettlement, eventLocation);
				}
				else if (partyBelongedTo != null)
				{
					num = GameVersionCompatibility.GetDistance(partyBelongedTo, eventLocation);
				}
			}
			float maxDistanceForEventType = GetMaxDistanceForEventType(eventType, context.InformationAccessLevel, npc, eventParticipant);
			if (num > maxDistanceForEventType)
			{
				return $"too far away (distance: {num:F1}, max: {maxDistanceForEventType:F1})";
			}
		}
		return "unknown reason";
	}

	public bool AddEventToNPCWithLogic(NPCContext context, Hero npc, CampaignEvent campaignEvent, Settlement eventLocation = null, Hero eventParticipant = null, bool deferSave = false, object extraData = null)
	{
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		bool flag = instance?.RealisticInformationSpread ?? true;
		bool flag2 = instance?.EnableDetailedInfoLogging ?? false;
		if (IsNPCDirectlyRelatedToEvent(npc, campaignEvent.Type, eventParticipant, extraData))
		{
			flag = false;
		}
		if (flag && !ShouldNPCKnowAboutEvent(npc, context, campaignEvent.Type, eventLocation, eventParticipant, extraData))
		{
			if (flag2)
			{
				string reasonForNotKnowing = GetReasonForNotKnowing(npc, context, campaignEvent.Type, eventLocation, eventParticipant, extraData);
				string text = (IsEventPlayerInvolved(campaignEvent.Type, extraData) ? " (player involved)" : "");
				AIInfluenceBehavior.Instance?.LogMessage($"[REALISTIC-BLOCKED] {npc.Name} (id:{((MBObjectBase)npc).StringId}) did NOT learn about {campaignEvent.Type}{text}: {reasonForNotKnowing}");
			}
			return false;
		}
		if (context.RecentEvents == null)
		{
			context.RecentEvents = new List<CampaignEvent>();
		}
		if (context.RecentEvents.Any(delegate(CampaignEvent e)
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (e.Type == campaignEvent.Type && e.Description == campaignEvent.Description)
			{
				CampaignTime val = e.Timestamp - campaignEvent.Timestamp;
				result = ((Math.Abs((val).ToHours) < 1.0) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}))
		{
			if (flag2)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[DUPLICATE] {npc.Name} (id:{((MBObjectBase)npc).StringId}) already knows about {campaignEvent.Type}");
			}
			return false;
		}
		float num = CalculateNewsDelay(npc, eventLocation);
		if (flag && num > 0f && IsNPCDirectlyRelatedToEvent(npc, campaignEvent.Type, eventParticipant, extraData))
		{
			num = 0f;
		}
		if (flag && num > 0f && instance != null && instance.NewsDelayHoursPerDistance > 0)
		{
			CampaignEvent delayedEvent = new CampaignEvent
			{
				Type = campaignEvent.Type,
				Description = campaignEvent.Description,
				Timestamp = campaignEvent.Timestamp
			};
			AddDelayedEventToNPC(context, npc, delayedEvent, num);
			if (flag2)
			{
				string reasonForKnowing = GetReasonForKnowing(npc, context, campaignEvent.Type, eventLocation, eventParticipant, extraData);
				AIInfluenceBehavior.Instance?.LogMessage($"[REALISTIC-DELAYED] {npc.Name} will learn about {campaignEvent.Type} in {num:F1} hours: {reasonForKnowing}");
			}
			return true;
		}
		context.RecentEvents.Add(campaignEvent);
		TrimRecentEvents(context);
		if (!deferSave)
		{
			if (!string.IsNullOrEmpty(context.StringId) && AIInfluenceBehavior.Instance != null)
			{
				string nPCFilePath = AIInfluenceBehavior.Instance.GetNPCFilePath(context.StringId);
				if (!string.IsNullOrEmpty(nPCFilePath))
				{
					AIInfluenceBehavior.Instance.SaveNPCContext(context.StringId, npc, context);
					string text2 = (flag ? "[REALISTIC]" : "[CLASSIC]");
					if (flag2 && flag)
					{
						string reasonForKnowing2 = GetReasonForKnowing(npc, context, campaignEvent.Type, eventLocation, eventParticipant, extraData);
						AIInfluenceBehavior.Instance.LogMessage($"{text2} {npc.Name} (id:{((MBObjectBase)npc).StringId}) learned about {campaignEvent.Type}: {campaignEvent.Description} - {reasonForKnowing2}");
					}
				}
			}
		}
		else if (flag2)
		{
			string arg = (flag ? "[REALISTIC-DEFERRED]" : "[CLASSIC-DEFERRED]");
			AIInfluenceBehavior.Instance?.LogMessage($"{arg} {npc.Name} learned about {campaignEvent.Type} (save deferred for batching)");
		}
		return true;
	}

	private float CalculateNewsDelay(Hero npc, Settlement eventLocation)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || instance.NewsDelayHoursPerDistance <= 0 || eventLocation == null)
		{
			return 0f;
		}
		Settlement currentSettlement = npc.CurrentSettlement;
		MobileParty partyBelongedTo = npc.PartyBelongedTo;
		float num = 0f;
		if (currentSettlement != null)
		{
			num = GameVersionCompatibility.GetDistance(currentSettlement, eventLocation);
		}
		else if (partyBelongedTo != null)
		{
			num = GameVersionCompatibility.GetDistance(partyBelongedTo, eventLocation);
		}
		float num2 = num * (float)instance.NewsDelayHoursPerDistance;
		if (num2 > 8760f)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[WARNING] News delay too large ({num2:F1}h = {num:F1} distance). Clamping to {8760f}h.");
			num2 = 8760f;
		}
		return num2;
	}

	public void TrimRecentEvents(NPCContext context)
	{
		if (context == null || context.RecentEvents == null || context.RecentEvents.Count == 0)
		{
			return;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		float maxAge = ((float?)instance?.RecentEventsLifetimeDays) ?? 30f;
		int count = instance?.MaxRecentEvents ?? 50;
		List<AIQuestInfo> activeAIQuests = context.ActiveAIQuests;
		int num;
		if (activeAIQuests == null || activeAIQuests.Count <= 0)
		{
			List<AIQuestInfo> incomingAIQuests = context.IncomingAIQuests;
			num = ((incomingAIQuests != null && incomingAIQuests.Count > 0) ? 1 : 0);
		}
		else
		{
			num = 1;
		}
		bool hasActiveQuests = (byte)num != 0;
		List<CampaignEvent> list = (from e in context.RecentEvents
			where e != null
			group e by new { e.Type, e.Description, e.EventTimeDays } into g
			select g.First() into e
			where hasActiveQuests || GetEventAge(e) <= (double)maxAge
			select e).OrderByDescending(delegate(CampaignEvent e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			double result;
			if (!(e.Timestamp != CampaignTime.Never))
			{
				result = e.EventTimeDays * 24.0;
			}
			else
			{
				CampaignTime timestamp = e.Timestamp;
				result = (timestamp).ToHours;
			}
			return result;
		}).Take(count).ToList();
		int num2 = context.RecentEvents.Count - list.Count;
		context.RecentEvents = list;
		if (num2 > 0 && instance != null && !instance.EnableDebugLogging)
		{
		}
	}

	private void AddDelayedEventToNPC(NPCContext context, Hero npc, CampaignEvent delayedEvent, float delayHours)
	{
		DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
		if (delayedTaskManager == null)
		{
			return;
		}
		double delaySeconds = delayHours * 3600f;
		string npcId = ((MBObjectBase)npc).StringId;
		delayedTaskManager.AddTask(delaySeconds, delegate
		{
			NPCContext nPCContext = AIInfluenceBehavior.Instance?.GetNPCContextByStringId(npcId);
			if (nPCContext != null)
			{
				if (nPCContext.RecentEvents == null)
				{
					nPCContext.RecentEvents = new List<CampaignEvent>();
				}
				if (!nPCContext.RecentEvents.Any((CampaignEvent e) => e.Type == delayedEvent.Type && e.Description == delayedEvent.Description))
				{
					nPCContext.RecentEvents.Add(delayedEvent);
					TrimRecentEvents(nPCContext);
					if (AIInfluenceBehavior.Instance != null)
					{
						string nPCFilePath = AIInfluenceBehavior.Instance.GetNPCFilePath(npcId);
						if (!string.IsNullOrEmpty(nPCFilePath))
						{
							Hero val = nPCContext.Hero;
							if (val == null || !val.IsAlive)
							{
								val = (nPCContext.Hero = AIInfluenceBehavior.Instance.GetHeroById(npcId));
							}
							if (val != null)
							{
								AIInfluenceBehavior.Instance.SaveNPCContext(npcId, val, nPCContext);
								ModSettings instance = GlobalSettings<ModSettings>.Instance;
								if (instance != null && instance.EnableDetailedInfoLogging)
								{
									AIInfluenceBehavior.Instance.LogMessage("[REALISTIC-ARRIVED] " + nPCContext.Name + " just learned about delayed " + delayedEvent.Type + ": " + delayedEvent.Description);
								}
							}
						}
					}
				}
			}
		});
	}

	internal HashSet<string> AddEventToDirectParticipantsImmediately(string eventType, CampaignEvent ev, Settlement loc, Hero part, HashSet<string> directParticipantIds, object extraData = null)
	{
		bool flag = GlobalSettings<ModSettings>.Instance?.EnableDetailedInfoLogging ?? false;
		if (eventType == "Battle" && flag)
		{
			string arg = (IsEventPlayerInvolved(eventType, extraData) ? " (player involved)" : "");
			AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-DIRECT] Processing {directParticipantIds?.Count ?? 0} direct participants immediately{arg}");
		}
		HashSet<string> hashSet = new HashSet<string>();
		if (directParticipantIds == null || directParticipantIds.Count == 0)
		{
			return hashSet;
		}
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance == null)
		{
			return hashSet;
		}
		foreach (string directParticipantId in directParticipantIds)
		{
			NPCContext nPCContext = instance.GetNPCContextByStringId(directParticipantId);
			if (nPCContext == null)
			{
				string nPCFilePath = instance.GetNPCFilePath(directParticipantId);
				if (string.IsNullOrEmpty(nPCFilePath) || !File.Exists(nPCFilePath))
				{
					continue;
				}
				nPCContext = instance.LoadNPCContext(directParticipantId);
				if (nPCContext == null)
				{
					continue;
				}
				Dictionary<string, NPCContext> nPCContexts = instance.GetNPCContexts();
				if (nPCContexts != null && !string.IsNullOrEmpty(nPCContext.StringId))
				{
					nPCContexts[nPCContext.StringId] = nPCContext;
				}
			}
			Hero val = nPCContext.Hero;
			if (val == null || !val.IsAlive)
			{
				val = instance.GetHeroById(directParticipantId);
				if (val == null || !val.IsAlive)
				{
					continue;
				}
				nPCContext.Hero = val;
			}
			EventProcessingTask task = new EventProcessingTask(eventType, ev, loc, part, new List<string> { directParticipantId }, defer: false, extraData);
			ProcessSingleNpcForEvent(val, nPCContext, task);
			instance.SaveNPCContextImmediate(directParticipantId, val, nPCContext);
			hashSet.Add(directParticipantId);
		}
		if (eventType == "Battle" && flag)
		{
			string arg2 = (IsEventPlayerInvolved(eventType, extraData) ? " (player involved)" : "");
			AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-DIRECT] Successfully processed {hashSet.Count} direct participants{arg2}");
		}
		return hashSet;
	}

	internal HashSet<string> GetRecentBattleParticipants(string capturerId, float maxTimeHours = 0.5f)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (_recentBattleParticipantsByCapturer.TryGetValue(capturerId, out (HashSet<string>, CampaignTime) value))
		{
			(HashSet<string>, CampaignTime) tuple = value;
			HashSet<string> item = tuple.Item1;
			CampaignTime item2 = tuple.Item2;
			CampaignTime val = CampaignTime.Now - item2;
			float num = (float)(val).ToHours;
			if (num <= maxTimeHours && item != null && item.Count > 0)
			{
				return new HashSet<string>(item);
			}
		}
		return new HashSet<string>();
	}

	public void QueueEventForInformedNPCs(CampaignEvent ev, Settlement loc, Hero part, List<string> customNpcIds = null, bool defer = false, object extra = null, HashSet<string> processedParticipantIds = null)
	{
		bool flag = GlobalSettings<ModSettings>.Instance?.EnableDetailedInfoLogging ?? false;
		HashSet<string> hashSet;
		if (customNpcIds != null)
		{
			hashSet = new HashSet<string>(customNpcIds);
			if (ev.Type == "Battle" && flag)
			{
				AIInfluenceBehavior.Instance?.LogMessage(string.Format("[NPC-LIST] Custom NPC.json files to be checked for event ({0}): {1}", hashSet.Count, string.Join(", ", hashSet)));
			}
		}
		else
		{
			Dictionary<string, NPCContext> dictionary = AIInfluenceBehavior.Instance?.GetNPCContexts();
			if (dictionary != null && ev.Type == "Battle" && flag)
			{
				List<string> list = dictionary.Keys.ToList();
				AIInfluenceBehavior.Instance?.LogMessage(string.Format("[NPC-LIST] All NPC.json files ({0}): {1}", list.Count, string.Join(", ", list)));
			}
			hashSet = ((dictionary != null) ? new HashSet<string>(dictionary.Keys.ToList()) : new HashSet<string>());
			if (ev.Type == "Battle" && flag)
			{
				AIInfluenceBehavior.Instance?.LogMessage(string.Format("[NPC-LIST] NPC.json files to be checked for event ({0}): {1}", hashSet.Count, string.Join(", ", hashSet)));
			}
		}
		HashSet<string> hashSet2 = processedParticipantIds ?? new HashSet<string>();
		if (processedParticipantIds == null)
		{
			if (extra is BattleData battleData)
			{
				if (battleData.AttackerHeroIds != null)
				{
					hashSet2.UnionWith(battleData.AttackerHeroIds);
				}
				if (battleData.DefenderHeroIds != null)
				{
					hashSet2.UnionWith(battleData.DefenderHeroIds);
				}
			}
			else if (extra is PrisonerEventData prisonerEventData)
			{
				if (prisonerEventData.Prisoner != null)
				{
					hashSet2.Add(((MBObjectBase)prisonerEventData.Prisoner).StringId);
				}
				if (prisonerEventData.Participant != null)
				{
					hashSet2.Add(((MBObjectBase)prisonerEventData.Participant).StringId);
				}
			}
			else if (extra is SettlementCaptureData settlementCaptureData)
			{
				if (settlementCaptureData.NewOwner != null)
				{
					hashSet2.Add(((MBObjectBase)settlementCaptureData.NewOwner).StringId);
				}
				if (settlementCaptureData.PreviousOwner != null)
				{
					hashSet2.Add(((MBObjectBase)settlementCaptureData.PreviousOwner).StringId);
				}
			}
			else if (extra is HeroKilledData heroKilledData)
			{
				if (heroKilledData.Victim != null)
				{
					hashSet2.Add(((MBObjectBase)heroKilledData.Victim).StringId);
				}
				if (heroKilledData.Killer != null)
				{
					hashSet2.Add(((MBObjectBase)heroKilledData.Killer).StringId);
				}
			}
			else if (extra is MarriageData marriageData)
			{
				if (marriageData.Proposer != null)
				{
					hashSet2.Add(((MBObjectBase)marriageData.Proposer).StringId);
				}
				if (marriageData.ProposedTo != null)
				{
					hashSet2.Add(((MBObjectBase)marriageData.ProposedTo).StringId);
				}
			}
			else if (extra is TournamentData { ParticipantIds: not null } tournamentData)
			{
				hashSet2.UnionWith(tournamentData.ParticipantIds);
			}
		}
		int count = hashSet.Count;
		if (!(extra is WarDeclaredData))
		{
			hashSet.ExceptWith(hashSet2);
		}
		int count2 = hashSet.Count;
		if (ev.Type == "Battle" && flag)
		{
			string arg = (IsEventPlayerInvolved(ev.Type, extra) ? " (player involved)" : "");
			AIInfluenceBehavior.Instance?.LogMessage($"[BATTLE-QUEUE] Battle queued for {count2} NPCs (excluded {count - count2} direct participants){arg}");
		}
		_pendingEventTasks.Enqueue(new EventProcessingTask(ev.Type, ev, loc, part, hashSet.ToList(), defer, extra));
	}

	public void InformNPCsAboutWorldEvent(string eventTitle, string eventDescription, Settlement eventLocation = null, List<string> involvedFactions = null)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		CampaignEvent ev = new CampaignEvent
		{
			Type = "WorldEvent",
			Description = eventDescription,
			Timestamp = CampaignTime.Now
		};
		Hero part = null;
		if (involvedFactions != null && involvedFactions.Any())
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => involvedFactions.Contains(((object)k.Name).ToString())));
			part = ((val != null) ? val.Leader : null);
		}
		QueueEventForInformedNPCs(ev, eventLocation, part);
		AIInfluenceBehavior.Instance?.LogMessage("[WORLD_EVENT] Event: '" + eventTitle + "' queued for background distribution.");
	}

	private (NPCContext context, Hero hero) FindNPCContextByStringId(string stringId)
	{
		if (string.IsNullOrEmpty(stringId))
		{
			return (context: null, hero: null);
		}
		NPCContext nPCContext = AIInfluenceBehavior.Instance?.GetNPCContextByStringId(stringId);
		if (nPCContext != null)
		{
			Hero val = nPCContext.Hero;
			if (val == null || !val.IsAlive)
			{
				val = (nPCContext.Hero = AIInfluenceBehavior.Instance.GetHeroById(stringId));
			}
			return (context: nPCContext, hero: val);
		}
		return (context: null, hero: null);
	}

	public static string GetOtherPlayerPrisonersInfo(Hero npc)
	{
		List<Hero> source = (from t in (IEnumerable<TroopRosterElement>)MobileParty.MainParty.PrisonRoster.GetTroopRoster()
			where ((BasicCharacterObject)t.Character).IsHero && t.Character.HeroObject.IsLord
			select t.Character.HeroObject).ToList();
		List<Hero> list = source.Where((Hero h) => h != npc).ToList();
		if (!list.Any())
		{
			return "There are no other lords in the player's captivity.";
		}
		List<Hero> list2 = list.Where((Hero h) => IsRelated(npc, h)).ToList();
		List<Hero> list3 = (from h in list.Except(list2)
			where npc.GetRelation(h) > 40
			select h).ToList();
		List<Hero> source2 = list.Except(list2).Except(list3).ToList();
		List<string> list4 = new List<string>();
		if (list2.Any())
		{
			List<string> list5 = new List<string>();
			foreach (Hero item in list2)
			{
				string text = ((object)item.Name).ToString();
				string stringId = ((MBObjectBase)item).StringId;
				if (npc.Father == item)
				{
					list5.Add("your father: " + text + " (id:" + stringId + ")");
				}
				else if (npc.Mother == item)
				{
					list5.Add("your mother: " + text + " (id:" + stringId + ")");
				}
				else if (npc.Spouse == item)
				{
					list5.Add("your spouse: " + text + " (id:" + stringId + ")");
				}
				else if (npc.Children != null && ((List<Hero>)(object)npc.Children).Contains(item))
				{
					list5.Add("your child: " + text + " (id:" + stringId + ")");
				}
				else if (npc.Siblings != null && npc.Siblings.Contains(item))
				{
					list5.Add("your sibling: " + text + " (id:" + stringId + ")");
				}
				else if (item.Father == npc)
				{
					list5.Add("your child: " + text + " (id:" + stringId + ")");
				}
				else if (item.Mother == npc)
				{
					list5.Add("your child: " + text + " (id:" + stringId + ")");
				}
				else if (item.Spouse == npc)
				{
					list5.Add("your spouse: " + text + " (id:" + stringId + ")");
				}
				else if (item.Children != null && ((List<Hero>)(object)item.Children).Contains(npc))
				{
					list5.Add("your parent: " + text + " (id:" + stringId + ")");
				}
				else if (item.Siblings != null && item.Siblings.Contains(npc))
				{
					list5.Add("your sibling: " + text + " (id:" + stringId + ")");
				}
				else
				{
					list5.Add("your relative: " + text + " (id:" + stringId + ")");
				}
			}
			list4.Add("Among the prisoners are: " + string.Join(", ", list5));
		}
		if (list3.Any())
		{
			list4.Add("Also in captivity: your friends " + string.Join(", ", list3.Select((Hero r) => $"{r.Name} (id:{((MBObjectBase)r).StringId})")));
		}
		if (source2.Any())
		{
			list4.Add("Other lords in captivity: " + string.Join(", ", source2.Select((Hero r) => $"{r.Name} (id:{((MBObjectBase)r).StringId})")));
		}
		return string.Join(". ", list4);
	}

	public static string GetNPCPrisonersInfo(Hero npc)
	{
		if (npc == null || npc.PartyBelongedTo == null)
		{
			return "none";
		}
		MobileParty partyBelongedTo = npc.PartyBelongedTo;
		MBList<TroopRosterElement> troopRoster = partyBelongedTo.PrisonRoster.GetTroopRoster();
		if (troopRoster == null || !((IEnumerable<TroopRosterElement>)troopRoster).Any())
		{
			return "none";
		}
		List<string> list = new List<string>();
		List<Hero> list2 = (from t in (IEnumerable<TroopRosterElement>)troopRoster
			where ((BasicCharacterObject)t.Character).IsHero && t.Character.HeroObject != null
			select t.Character.HeroObject).ToList();
		if (list2.Any())
		{
			List<Hero> list3 = list2.Where((Hero h) => IsRelated(npc, h)).ToList();
			List<Hero> list4 = (from h in list2.Except(list3)
				where npc.GetRelation(h) > 40
				select h).ToList();
			List<Hero> source = list2.Except(list3).Except(list4).ToList();
			if (list3.Any())
			{
				List<string> list5 = new List<string>();
				foreach (Hero item in list3)
				{
					string text = ((object)item.Name).ToString();
					string stringId = ((MBObjectBase)item).StringId;
					string relationString = GetRelationString(npc, item);
					list5.Add(relationString + ": " + text + " (id:" + stringId + ")");
				}
				list.Add(string.Join(", ", list5) ?? "");
			}
			if (list4.Any())
			{
				list.Add(string.Join(", ", list4.Select((Hero r) => $"your friend: {r.Name} (id:{((MBObjectBase)r).StringId})")) ?? "");
			}
			if (source.Any())
			{
				list.Add(string.Join(", ", source.Select((Hero r) => $"{r.Name} (id:{((MBObjectBase)r).StringId})")) ?? "");
			}
		}
		var source2 = (from t in (IEnumerable<TroopRosterElement>)troopRoster
			where !((BasicCharacterObject)t.Character).IsHero
			group t by ((MBObjectBase)t.Character).StringId into g
			select new
			{
				StringId = g.Key,
				Name = ((object)((BasicCharacterObject)g.First().Character).Name).ToString(),
				Count = g.Sum((TroopRosterElement t) => (t).Number)
			}).ToList();
		if (source2.Any())
		{
			IEnumerable<string> values = source2.Select(p => $"{p.Name} (id:{p.StringId}, count:{p.Count})");
			list.Add("Regular prisoners: " + string.Join(", ", values));
		}
		return list.Any() ? string.Join(". ", list) : "none";
	}

	private static string GetRelationString(Hero npc, Hero rel)
	{
		if (npc.Father == rel)
		{
			return "your father";
		}
		if (npc.Mother == rel)
		{
			return "your mother";
		}
		if (npc.Spouse == rel)
		{
			return "your spouse";
		}
		if (npc.Children != null && ((List<Hero>)(object)npc.Children).Contains(rel))
		{
			return "your child";
		}
		if (npc.Siblings != null && npc.Siblings.Contains(rel))
		{
			return "your sibling";
		}
		if (rel.Father == npc)
		{
			return "your child";
		}
		if (rel.Mother == npc)
		{
			return "your child";
		}
		if (rel.Spouse == npc)
		{
			return "your spouse";
		}
		if (rel.Children != null && ((List<Hero>)(object)rel.Children).Contains(npc))
		{
			return "your parent";
		}
		if (rel.Siblings != null && rel.Siblings.Contains(npc))
		{
			return "your sibling";
		}
		return "your relative";
	}

	private static bool IsRelated(Hero a, Hero b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		return a == b || a.Spouse == b || ((List<Hero>)(object)a.Children).Contains(b) || ((List<Hero>)(object)b.Children).Contains(a) || a.Father == b || b.Father == a || a.Mother == b || b.Mother == a || a.Siblings.Contains(b) || b.Siblings.Contains(a);
	}

	private bool IsHeroOnSide(Hero hero, BattleSideEnum side, MapEvent mapEvent)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null || mapEvent == null)
		{
			return false;
		}
		foreach (MapEventParty item in (List<MapEventParty>)(object)mapEvent.PartiesOnSide(side))
		{
			PartyBase party = item.Party;
			if (party == null)
			{
				continue;
			}
			if (((IEnumerable<TroopRosterElement>)party.MemberRoster.GetTroopRoster()).Any((TroopRosterElement t) => ((BasicCharacterObject)t.Character).IsHero && t.Character.HeroObject == hero))
			{
				return true;
			}
			if (party.MobileParty != null && party.MobileParty.LeaderHero == hero)
			{
				return true;
			}
			if (party.MobileParty == null || party.MobileParty.Army == null)
			{
				continue;
			}
			foreach (MobileParty item2 in (List<MobileParty>)(object)party.MobileParty.Army.Parties)
			{
				if (item2.LeaderHero == hero)
				{
					return true;
				}
				if (((IEnumerable<TroopRosterElement>)item2.MemberRoster.GetTroopRoster()).Any((TroopRosterElement t) => ((BasicCharacterObject)t.Character).IsHero && t.Character.HeroObject == hero))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void AddDeathRecord(Hero victim, Hero killer, KillCharacterActionDetail detail)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		DeathRecord deathRecord = new DeathRecord
		{
			Victim = victim,
			Killer = killer,
			DeathDetail = detail,
			DeathTime = CampaignTime.Now,
			DeathCause = GetDeathCauseDescription(detail, killer),
			KillerName = (((killer == null) ? null : ((object)killer.Name)?.ToString()) ?? GetKillerNameFromDetail(detail)),
			KillerStringId = (((killer != null) ? ((MBObjectBase)killer).StringId : null) ?? "unknown")
		};
		_recentDeaths.Add(deathRecord);
		_recentDeaths.RemoveAll(delegate(DeathRecord d)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime val = CampaignTime.Now - d.DeathTime;
			return (val).ToDays > 7.0;
		});
		if (_recentDeaths.Count > 10)
		{
			_recentDeaths.RemoveRange(0, _recentDeaths.Count - 10);
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[DEATH_RECORD] Recorded death of {victim.Name}: {deathRecord.DeathCause} by {deathRecord.KillerName}");
	}

	public List<DeathRecord> GetRecentDeaths()
	{
		return (from d in _recentDeaths.Where(delegate(DeathRecord d)
			{
				//IL_0000: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime val = CampaignTime.Now - d.DeathTime;
				return (val).ToDays <= 20.0;
			})
			orderby d.DeathTime descending
			select d).Take(5).ToList();
	}

	public DeathRecord GetDeathRecordForHero(Hero hero)
	{
		return _recentDeaths.FirstOrDefault((DeathRecord d) => d.Victim == hero);
	}

	public void AddMarriageRecord(Hero proposer, Hero proposedTo)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		Hero val = (proposer.IsFemale ? proposedTo : proposer);
		Hero val2 = (proposer.IsFemale ? proposer : proposedTo);
		string marriagePoliticalSignificance = GetMarriagePoliticalSignificance(val, val2);
		MarriageRecord item = new MarriageRecord
		{
			Husband = val,
			Wife = val2,
			MarriageTime = CampaignTime.Now,
			PoliticalSignificance = marriagePoliticalSignificance
		};
		_recentMarriages.Add(item);
		if (_recentMarriages.Count > 20)
		{
			_recentMarriages.RemoveAt(0);
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] Marriage record added: {val.Name} and {val2.Name}. Total marriages tracked: {_recentMarriages.Count}");
	}

	public List<MarriageRecord> GetRecentMarriages(int daysThreshold = 60, int maxCount = 4)
	{
		return (from m in _recentMarriages.Where(delegate(MarriageRecord m)
			{
				//IL_0000: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime val = CampaignTime.Now - m.MarriageTime;
				return (val).ToDays <= (double)daysThreshold;
			})
			orderby m.MarriageTime descending
			select m).Take(maxCount).ToList();
	}

	private string GetMarriagePoliticalSignificance(Hero husband, Hero wife)
	{
		object obj;
		if (husband == null)
		{
			obj = null;
		}
		else
		{
			Clan clan = husband.Clan;
			obj = ((clan != null) ? clan.Kingdom : null);
		}
		if (obj != null)
		{
			object obj2;
			if (wife == null)
			{
				obj2 = null;
			}
			else
			{
				Clan clan2 = wife.Clan;
				obj2 = ((clan2 != null) ? clan2.Kingdom : null);
			}
			if (obj2 != null)
			{
				if (husband.Clan.Kingdom == wife.Clan.Kingdom)
				{
					return "Internal alliance within kingdom";
				}
				return "Political alliance between kingdoms";
			}
		}
		if (((husband != null) ? husband.Clan : null) != null && ((wife != null) ? wife.Clan : null) != null && husband.Clan != wife.Clan)
		{
			return "Clan alliance";
		}
		return "Personal union";
	}

	private string GetKillerNameFromDetail(KillCharacterActionDetail detail)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected I4, but got Unknown
		if ((int)detail != 1)
		{
			return ((int)detail - 4) switch
			{
				0 => "Enemy forces", 
				2 => "Executioner", 
				4 => "Unknown", 
				_ => "Unknown", 
			};
		}
		return "Unknown murderer";
	}

	public static string GetPreviousRulerInfo(Kingdom kingdom, Hero newRuler)
	{
		try
		{
			string previousLeaderInfo = KingdomLeadershipTracker.Instance.GetPreviousLeaderInfo(((MBObjectBase)kingdom).StringId, newRuler);
			if (!string.IsNullOrEmpty(previousLeaderInfo))
			{
				return previousLeaderInfo;
			}
			List<Hero> source = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Concat((IEnumerable<Hero>)Hero.DeadOrDisabledHeroes).ToList();
			List<Hero> source2 = source.Where((Hero h) => h.Clan != null && h.Clan.Kingdom == kingdom && h.Clan.Leader == h && h != newRuler && !h.IsAlive).ToList();
			if (!source2.Any())
			{
				return $"No previous ruler information available for {kingdom.Name} (id:{((MBObjectBase)kingdom).StringId})";
			}
			Hero val = source2.First();
			string relationshipDescription = GetRelationshipDescription(newRuler, val);
			string text = ((object)val.Name).ToString();
			string stringId = ((MBObjectBase)val).StringId;
			string text2 = (val.IsHumanPlayerCharacter ? " (player)" : "");
			string text3 = text + " (id:" + stringId + ")" + text2;
			if (val.Clan != null)
			{
				text3 += $" of {val.Clan.Name} (clan_id:{((MBObjectBase)val.Clan).StringId})";
			}
			return text3 + " died. " + relationshipDescription;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GetPreviousRulerInfo: " + ex.Message);
			return "Previous ruler information unavailable";
		}
	}

	public static string GetRelationshipText(Hero a, Hero b)
	{
		return GetRelationshipDescription(a, b);
	}

	private static string GetRelationshipDescription(Hero a, Hero b)
	{
		if (a == null || b == null)
		{
			return "No relationship";
		}
		string text = ((object)a.Name).ToString();
		string stringId = ((MBObjectBase)a).StringId;
		string text2 = ((object)b.Name).ToString();
		string stringId2 = ((MBObjectBase)b).StringId;
		if (a == b)
		{
			return "Same person";
		}
		if (a.Spouse == b)
		{
			return text + " (id:" + stringId + ") is married to " + text2 + " (id:" + stringId2 + ")";
		}
		if (a.Father == b)
		{
			return text + " (id:" + stringId + ") is the son of " + text2 + " (id:" + stringId2 + ")";
		}
		if (a.Mother == b)
		{
			return text + " (id:" + stringId + ") is the son of " + text2 + " (id:" + stringId2 + ")";
		}
		if (b.Father == a)
		{
			return text + " (id:" + stringId + ") is the father of " + text2 + " (id:" + stringId2 + ")";
		}
		if (b.Mother == a)
		{
			return text + " (id:" + stringId + ") is the mother of " + text2 + " (id:" + stringId2 + ")";
		}
		if (((List<Hero>)(object)a.Children).Contains(b))
		{
			return text + " (id:" + stringId + ") is the parent of " + text2 + " (id:" + stringId2 + ")";
		}
		if (((List<Hero>)(object)b.Children).Contains(a))
		{
			return text + " (id:" + stringId + ") is the child of " + text2 + " (id:" + stringId2 + ")";
		}
		if (a.Siblings.Contains(b))
		{
			return text + " (id:" + stringId + ") and " + text2 + " (id:" + stringId2 + ") are siblings";
		}
		if (b.Siblings.Contains(a))
		{
			return text + " (id:" + stringId + ") and " + text2 + " (id:" + stringId2 + ") are siblings";
		}
		if (a.Father != null && b.Father != null && a.Father == b.Father)
		{
			return text + " (id:" + stringId + ") and " + text2 + " (id:" + stringId2 + ") are half-brothers (same father)";
		}
		if (a.Mother != null && b.Mother != null && a.Mother == b.Mother)
		{
			return text + " (id:" + stringId + ") and " + text2 + " (id:" + stringId2 + ") are half-brothers (same mother)";
		}
		return "No known relationship";
	}
}
