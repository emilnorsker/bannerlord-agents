using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.Util;
using SandBox.Missions.MissionLogics;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.AgentOrigins;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.SettlementCombat;

public class PlayerReinforcementMissionLogic : MissionLogic
{
	private class SummonTroopInfo
	{
		public CharacterObject Character { get; }

		public int Count { get; }

		public MobileParty SourceParty { get; }

		public SummonTroopInfo(CharacterObject character, int count, MobileParty sourceParty = null)
		{
			Character = character;
			Count = count;
			SourceParty = sourceParty;
		}
	}

	private readonly AIInfluenceBehavior _behavior;

	private readonly SettlementCombatLogger _logger;

	private SettlementCombatManager _combatManager;

	private DefenderSpawner _defenderSpawner;

	private bool _messageShown = false;

	private bool _followModeHintShown = false;

	private bool _canSummonTroops = false;

	private bool _previousCanSummonTroops = false;

	private int _totalSummoned = 0;

	private Vec3 _playerInitialSpawnPosition = Vec3.Zero;

	private Vec2 _playerInitialForward2D = Vec2.Zero;

	private HashSet<Agent> _summonedAgents = new HashSet<Agent>();

	private Dictionary<Agent, MobileParty> _agentToPartyMap = new Dictionary<Agent, MobileParty>();

	private bool _playerTeamInitialized = false;

	private SettlementOrderProvider _orderProvider = null;

	private const int TROOPS_PER_SUMMON = 10;

	private const int MAX_TROOPS_PER_SIDE_LARGE = 75;

	private const int MAX_TROOPS_PER_SIDE_SMALL = 5;

	private bool _isAllTroopsSummoned = false;

	private List<Vec3> _ambushSpawnPoints = null;

	private int _ambushSpawnIndex = 0;

	private const int AMBUSH_POINT_COUNT = 4;

	private const float AMBUSH_SCATTER_RADIUS = 5f;

	private bool _loggedRestrictedLocation = false;

	private bool _loggedNotCityOrCastle = false;

	private bool _loggedCombatNotActive = false;

	private bool _loggedPromptNotReady = false;

	private static readonly string[] MAIN_GATE_SPAWN_TAGS = new string[5] { "spawnpoint_player_outside", "spawnpoint_player", "sp_outside_near_town_main_gate", "sp_player", "sp_player_conversation" };

	private bool _onMissionTickCalled = false;

	public PlayerReinforcementMissionLogic(AIInfluenceBehavior behavior)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		_behavior = behavior;
		_logger = SettlementCombatLogger.Instance;
		_combatManager = _behavior?.GetSettlementCombatManager();
		_defenderSpawner = _combatManager?.GetDefenderSpawner();
		_behavior.LogMessage("[PLAYER_REINFORCEMENT] Constructor called");
		_logger.Log("PlayerReinforcementMissionLogic constructor called");
		_canSummonTroops = false;
		_previousCanSummonTroops = false;
		_messageShown = false;
		_logger.Log("PlayerReinforcementMissionLogic: Flags initialized (will check in OnBehaviorInitialize)");
	}

	public override void OnRemoveBehavior()
	{
		base.OnRemoveBehavior();
		try
		{
			if (_orderProvider != null)
			{
				VisualOrderFactory.UnregisterProvider((VisualOrderProvider)(object)_orderProvider);
				_logger.Log("SettlementOrderProvider unregistered");
				_orderProvider = null;
			}
			_summonedAgents.Clear();
			_agentToPartyMap.Clear();
			_logger.Log("PlayerReinforcementMissionLogic: Cleanup completed");
		}
		catch (Exception ex)
		{
			_logger.LogError("OnRemoveBehavior", ex.Message, ex);
		}
	}

	public override void OnBehaviorInitialize()
	{
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		base.OnBehaviorInitialize();
		try
		{
			_logger.Log("=== PlayerReinforcementMissionLogic.OnBehaviorInitialize ===");
			_behavior.LogMessage("[PLAYER_REINFORCEMENT] OnBehaviorInitialize called");
			_canSummonTroops = CanSummonTroopsInThisMission();
			_previousCanSummonTroops = _canSummonTroops;
			_logger.Log($"_canSummonTroops (OnBehaviorInitialize) = {_canSummonTroops}");
			_behavior.LogMessage($"[PLAYER_REINFORCEMENT] _canSummonTroops = {_canSummonTroops}");
			_logger.Log("Note: If this is false during transition, it will become true in OnMissionTick when combat is restored");
			if (_canSummonTroops)
			{
				_logger.Log("Player reinforcement system activated for this mission");
				_behavior.LogMessage("[PLAYER_REINFORCEMENT] System ACTIVATED");
				if (Agent.Main != null)
				{
					_playerInitialSpawnPosition = Agent.Main.Position;
					Vec3 lookDirection = Agent.Main.LookDirection;
					_playerInitialForward2D = (lookDirection).AsVec2;
					_logger.Log($"Player initial spawn position saved in OnBehaviorInitialize: {_playerInitialSpawnPosition}");
					_behavior.LogMessage($"[PLAYER_REINFORCEMENT] Position saved: {_playerInitialSpawnPosition}");
				}
				else
				{
					_logger.Log("Agent.Main is NULL in OnBehaviorInitialize - will save position later");
					_behavior.LogMessage("[PLAYER_REINFORCEMENT] Agent.Main is NULL - will save later");
				}
			}
			else
			{
				_logger.Log("Player reinforcement system NOT available in this mission type");
				_behavior.LogMessage("[PLAYER_REINFORCEMENT] System NOT AVAILABLE (wrong mission type)");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("PlayerReinforcementMissionLogic.OnBehaviorInitialize", ex.Message, ex);
			_behavior.LogMessage("[PLAYER_REINFORCEMENT] ERROR in OnBehaviorInitialize: " + ex.Message);
		}
	}

	public override void OnMissionTick(float dt)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		base.OnMissionTick(dt);
		try
		{
			if (Settlement.CurrentSettlement == null || PlayerEncounter.EncounteredBattle != null)
			{
				return;
			}
			if (!_onMissionTickCalled)
			{
				_behavior.LogMessage("[PLAYER_REINFORCEMENT] OnMissionTick called for the FIRST time!");
				_onMissionTickCalled = true;
			}
			_canSummonTroops = CanSummonTroopsInThisMission();
			if (_canSummonTroops && !_previousCanSummonTroops)
			{
				_logger.Log("=== SUMMON TROOPS NOW AVAILABLE (state changed from false to true) ===");
				_logger.Log($"  _messageShown was: {_messageShown}");
				_messageShown = false;
				_logger.Log($"  _messageShown reset to: {_messageShown}");
				_logger.Log("  Hint will be shown on next tick when Agent.Main is active");
			}
			_previousCanSummonTroops = _canSummonTroops;
			if (!_canSummonTroops)
			{
				return;
			}
			if (_playerInitialSpawnPosition == Vec3.Zero && Agent.Main != null && Agent.Main.IsActive())
			{
				_playerInitialSpawnPosition = Agent.Main.Position;
				Vec3 lookDirection = Agent.Main.LookDirection;
				_playerInitialForward2D = (lookDirection).AsVec2;
				_logger.Log($"Player initial spawn position saved in OnMissionTick: {_playerInitialSpawnPosition}");
				_behavior.LogMessage($"[PLAYER_REINFORCEMENT] Initial position saved: {_playerInitialSpawnPosition}");
			}
			if (_canSummonTroops && !_playerTeamInitialized && Agent.Main != null && Agent.Main.IsActive())
			{
				InitializePlayerTeamForControl();
			}
			if (!_messageShown && Agent.Main != null && Agent.Main.IsActive())
			{
				_logger.Log("=== CONDITIONS MET FOR SHOWING HINT ===");
				_logger.Log($"  _messageShown: {_messageShown}");
				_logger.Log("  Agent.Main: " + ((Agent.Main != null) ? "Present" : "NULL"));
				_logger.Log($"  Agent.Main.IsActive: {Agent.Main.IsActive()}");
				_logger.Log("Showing summon troops hint to player");
				_behavior.LogMessage("[PLAYER_REINFORCEMENT] Showing hint to player NOW");
				ShowSummonHint();
				_messageShown = true;
				_behavior.LogMessage("[PLAYER_REINFORCEMENT] Hint shown successfully");
			}
			else if (!_messageShown)
			{
				_logger.Log(string.Format("Cannot show hint yet: _messageShown={0}, Agent.Main={1}, IsActive={2}", _messageShown, (Agent.Main != null) ? "Present" : "NULL", (Agent.Main != null) ? Agent.Main.IsActive().ToString() : "N/A"));
			}
			CleanupDeadAgents();
			bool flag = Input.IsKeyDown((InputKey)29) || Input.IsKeyDown((InputKey)157);
			bool flag2 = Input.IsKeyDown((InputKey)56) || Input.IsKeyDown((InputKey)184);
			bool flag3 = Input.IsKeyPressed((InputKey)45);
			if (flag3 && flag)
			{
				_logger.Log($"[SUMMON] Keys pressed! CTRL={flag}, ALT={flag2}, X={flag3}");
				_behavior.LogMessage($"[PLAYER_REINFORCEMENT] Key pressed! CTRL={flag}, ALT={flag2}, X={flag3}");
				if (flag2)
				{
					_logger.Log("[SUMMON] Calling SummonAllPlayerTroops (CTRL+ALT+X)");
					_behavior.LogMessage("[PLAYER_REINFORCEMENT] Calling SummonAllPlayerTroops");
					SummonAllPlayerTroops();
				}
				else
				{
					_logger.Log("[SUMMON] Calling SummonPlayerTroops (CTRL+X)");
					_behavior.LogMessage("[PLAYER_REINFORCEMENT] Calling SummonPlayerTroops (10 units)");
					SummonPlayerTroops();
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("PlayerReinforcementMissionLogic.OnMissionTick", ex.Message, ex);
		}
	}

	public bool IsSummonedTroop(Agent agent)
	{
		return _summonedAgents.Contains(agent);
	}

	public bool HasActiveSummonedTroops()
	{
		try
		{
			if (_summonedAgents == null || _summonedAgents.Count == 0)
			{
				return false;
			}
			List<Agent> source = _summonedAgents.ToList();
			return source.Any((Agent a) => a != null && a.IsActive());
		}
		catch
		{
			return false;
		}
	}

	public int GetSummonedTroopsCount()
	{
		try
		{
			List<Agent> list = (from a in _summonedAgents.ToList()
				where a == null || !a.IsActive()
				select a).ToList();
			foreach (Agent item in list)
			{
				_summonedAgents.Remove(item);
				_agentToPartyMap.Remove(item);
			}
			return _summonedAgents.Count;
		}
		catch
		{
			return 0;
		}
	}

	public string GetSummonedTroopsInfo()
	{
		try
		{
			List<Agent> source = _summonedAgents.ToList();
			List<Agent> list = source.Where((Agent a) => a == null || !a.IsActive()).ToList();
			foreach (Agent item2 in list)
			{
				_summonedAgents.Remove(item2);
				_agentToPartyMap.Remove(item2);
			}
			if (_summonedAgents.Count == 0)
			{
				return "none";
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			List<string> list2 = new List<string>();
			List<Agent> list3 = _summonedAgents.ToList();
			foreach (Agent item3 in list3)
			{
				if (item3.Character == null)
				{
					continue;
				}
				BasicCharacterObject character = item3.Character;
				CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
				if (val != null && ((BasicCharacterObject)val).IsHero)
				{
					string item = $"{((BasicCharacterObject)val).Name} (id:{((MBObjectBase)val).StringId})";
					if (!list2.Contains(item))
					{
						list2.Add(item);
					}
				}
				else
				{
					string key = ((object)item3.Character.Name)?.ToString() ?? "Unknown";
					if (dictionary.ContainsKey(key))
					{
						dictionary[key]++;
					}
					else
					{
						dictionary[key] = 1;
					}
				}
			}
			List<string> list4 = new List<string>();
			list4.AddRange(list2);
			foreach (KeyValuePair<string, int> item4 in dictionary.OrderByDescending((KeyValuePair<string, int> x) => x.Value))
			{
				list4.Add($"{item4.Key} x{item4.Value} (player's summoned troops)");
			}
			return string.Join(", ", list4);
		}
		catch (Exception ex)
		{
			_logger.LogError("GetSummonedTroopsInfo", ex.Message, ex);
			return "error";
		}
	}

	private bool CanSummonTroopsInThisMission()
	{
		try
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement == null)
			{
				return false;
			}
			MobileParty mainParty = MobileParty.MainParty;
			if (mainParty == null || mainParty.MemberRoster == null)
			{
				return false;
			}
			Mission current = Mission.Current;
			string text = ((current != null) ? current.SceneName : null) ?? "";
			bool flag = text.Contains("tavern") || text.Contains("Tavern");
			bool flag2 = text.Contains("arena") || text.Contains("Arena");
			bool flag3 = text.Contains("lordshall") || text.Contains("LordsHall") || (text.Contains("keep") && text.Contains("interior")) || (text.Contains("Keep") && text.Contains("interior"));
			bool flag4 = text.Contains("prison") || text.Contains("Prison");
			bool flag5 = text.Contains("dungeon") || text.Contains("Dungeon");
			if (flag || flag2 || flag3 || flag4 || flag5)
			{
				if (!_loggedRestrictedLocation)
				{
					_logger.Log($"Cannot summon troops in this location: tavern={flag}, arena={flag2}, lordsHall={flag3}, prison={flag4}, dungeon={flag5}");
					_loggedRestrictedLocation = true;
				}
				return false;
			}
			_loggedRestrictedLocation = false;
			bool flag6 = currentSettlement.IsTown || currentSettlement.IsCastle;
			bool isVillage = currentSettlement.IsVillage;
			if (!flag6 && !isVillage)
			{
				if (!_loggedNotCityOrCastle)
				{
					_logger.Log($"Cannot summon troops: unsupported settlement type (isTown={currentSettlement.IsTown}, isCastle={currentSettlement.IsCastle}, isVillage={currentSettlement.IsVillage})");
					_loggedNotCityOrCastle = true;
				}
				return false;
			}
			if (isVillage)
			{
				_loggedNotCityOrCastle = false;
				_loggedCombatNotActive = false;
				_loggedPromptNotReady = false;
				return true;
			}
			_loggedNotCityOrCastle = false;
			SettlementCombatManager combatManager = _combatManager;
			if (combatManager == null || !combatManager.IsActiveCombat())
			{
				if (!_loggedCombatNotActive)
				{
					_logger.Log("Cannot summon troops: combat is not active");
					_loggedCombatNotActive = true;
				}
				return false;
			}
			_loggedCombatNotActive = false;
			SettlementCombatManager combatManager2 = _combatManager;
			if (combatManager2 == null || !combatManager2.IsCombatPromptReady())
			{
				if (!_loggedPromptNotReady)
				{
					_logger.Log("Cannot summon troops: AI combat prompt not ready yet");
					_loggedPromptNotReady = true;
				}
				return false;
			}
			_loggedPromptNotReady = false;
			return true;
		}
		catch (Exception ex)
		{
			_logger.LogError("CanSummonTroopsInThisMission", ex.Message, ex);
			return false;
		}
	}

	private void SummonPlayerTroops()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int sourcePartyCount;
			List<(TroopRosterElement, MobileParty)> troopElementsWithParty = GetTroopElementsWithParty(out sourcePartyCount);
			if (troopElementsWithParty.Count == 0)
			{
				ShowMessage(((object)new TextObject("{=AIInfluence_SummonTroops_NoTroopsAvailable}You have no troops to summon.", (Dictionary<string, object>)null)).ToString(), ExtraColors.RedAIInfluence);
				return;
			}
			Dictionary<CharacterObject, MobileParty> dictionary = new Dictionary<CharacterObject, MobileParty>();
			foreach (var (val, value) in troopElementsWithParty)
			{
				if (val.Character != null && !dictionary.ContainsKey(val.Character))
				{
					dictionary[val.Character] = value;
				}
			}
			List<TroopRosterElement> rosterElements = troopElementsWithParty.Select<(TroopRosterElement, MobileParty), TroopRosterElement>(((TroopRosterElement Element, MobileParty Party) x) => x.Element).ToList();
			List<SummonTroopInfo> troopsToSummon = GetTroopsToSummon(rosterElements, 10, dictionary);
			if (troopsToSummon.Count == 0)
			{
				ShowMessage(((object)new TextObject("{=AIInfluence_SummonTroops_NoMoreTroops}You have no more troops left to summon.", (Dictionary<string, object>)null)).ToString(), ExtraColors.RedAIInfluence);
				return;
			}
			_logger.Log($"[SUMMON] Troop sources: {sourcePartyCount} parties, candidates: {troopsToSummon.Count}");
			int num = 0;
			foreach (SummonTroopInfo item in troopsToSummon)
			{
				if (num >= 10)
				{
					break;
				}
				int num2 = Math.Min(item.Count, 10 - num);
				for (int num3 = 0; num3 < num2; num3++)
				{
					if (SpawnPlayerTroop(item.Character, spawnFromBoundary: false, item.SourceParty))
					{
						num++;
						if (num >= 10)
						{
							break;
						}
					}
				}
			}
			_totalSummoned += num;
			if (num > 0)
			{
				CharacterObject val2 = troopsToSummon.FirstOrDefault()?.Character;
				TextObject val3 = new TextObject("{=AIInfluence_PlayerTroopsSummoned}\"To battle! Stand with me!\"", (Dictionary<string, object>)null);
				MBInformationManager.AddQuickInformation(val3, 3000, (BasicCharacterObject)(object)val2, (Equipment)null, "");
				_logger.Log($"Player summoned {num} troops (Total: {_totalSummoned})");
				SelectFormationsWithTroops();
				if (!_followModeHintShown)
				{
					ShowMessage(((object)new TextObject("{=AIInfluence_SummonTroops_FollowModeHint}Hint: F1–F4 select formations, hold F1 for orders.", (Dictionary<string, object>)null)).ToString(), ExtraColors.GreenAIInfluence);
					_followModeHintShown = true;
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SummonPlayerTroops", ex.Message, ex);
		}
	}

	private void SummonAllPlayerTroops()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int sourcePartyCount;
			List<(TroopRosterElement, MobileParty)> troopElementsWithParty = GetTroopElementsWithParty(out sourcePartyCount);
			if (troopElementsWithParty.Count == 0)
			{
				ShowMessage(((object)new TextObject("{=AIInfluence_SummonTroops_NoTroopsAvailable}You have no troops to summon.", (Dictionary<string, object>)null)).ToString(), ExtraColors.RedAIInfluence);
				return;
			}
			Dictionary<CharacterObject, MobileParty> dictionary = new Dictionary<CharacterObject, MobileParty>();
			foreach (var (val, value) in troopElementsWithParty)
			{
				if (val.Character != null && !dictionary.ContainsKey(val.Character))
				{
					dictionary[val.Character] = value;
				}
			}
			List<TroopRosterElement> rosterElements = troopElementsWithParty.Select<(TroopRosterElement, MobileParty), TroopRosterElement>(((TroopRosterElement Element, MobileParty Party) x) => x.Element).ToList();
			List<SummonTroopInfo> troopsToSummon = GetTroopsToSummon(rosterElements, int.MaxValue, dictionary);
			if (troopsToSummon.Count == 0)
			{
				ShowMessage(((object)new TextObject("{=AIInfluence_SummonTroops_NoTroopsAvailable}You have no troops to summon.", (Dictionary<string, object>)null)).ToString(), ExtraColors.RedAIInfluence);
				return;
			}
			_isAllTroopsSummoned = true;
			_ambushSpawnPoints = null;
			_ambushSpawnIndex = 0;
			_logger.Log("[ALL_TROOPS] System activated: excess troops will go to reserve, ambush points will be recalculated");
			_logger.Log($"[ALL_TROOPS] Troop sources: {sourcePartyCount} parties, candidates: {troopsToSummon.Count}");
			int num = 0;
			int num2 = 0;
			foreach (SummonTroopInfo item in troopsToSummon)
			{
				for (int num3 = 0; num3 < item.Count; num3++)
				{
					if (SpawnPlayerTroop(item.Character, spawnFromBoundary: true, item.SourceParty))
					{
						num++;
						continue;
					}
					int maxTroopsPerSide = GetMaxTroopsPerSide();
					if (CountActivePlayerTroops() >= maxTroopsPerSide)
					{
						num2++;
					}
				}
			}
			_totalSummoned += num;
			if (num > 0 || num2 > 0)
			{
				CharacterObject val2 = troopsToSummon.FirstOrDefault()?.Character;
				int maxTroopsPerSide2 = GetMaxTroopsPerSide();
				if (num2 > 0)
				{
					TextObject val3 = new TextObject("{=AIInfluence_PlayerAllTroopsSummonedWithReserve}\"All forces, rally to me! ({SPAWNED} ready, {RESERVED} in reserve)\"", (Dictionary<string, object>)null);
					val3.SetTextVariable("SPAWNED", num);
					val3.SetTextVariable("RESERVED", num2);
					MBInformationManager.AddQuickInformation(val3, 3000, (BasicCharacterObject)(object)val2, (Equipment)null, "");
					_logger.Log($"Player troops: {num} spawned, {num2} in reserve (total: {_totalSummoned})");
				}
				else
				{
					TextObject val4 = new TextObject("{=AIInfluence_PlayerAllTroopsSummoned}\"Warriors, to arms! Victory or death!\"", (Dictionary<string, object>)null);
					MBInformationManager.AddQuickInformation(val4, 3000, (BasicCharacterObject)(object)val2, (Equipment)null, "");
					_logger.Log($"Player summoned ALL troops from boundary (total: {_totalSummoned})");
				}
				SelectFormationsWithTroops();
				if (!_followModeHintShown)
				{
					ShowMessage(((object)new TextObject("{=AIInfluence_SummonTroops_FollowModeHint}Hint: F1–F4 select formations, hold F1 for orders.", (Dictionary<string, object>)null)).ToString(), ExtraColors.GreenAIInfluence);
					_followModeHintShown = true;
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SummonAllPlayerTroops", ex.Message, ex);
		}
	}

	private List<MobileParty> GetTroopSourceParties()
	{
		List<MobileParty> result = new List<MobileParty>();
		try
		{
			MobileParty mainParty = MobileParty.MainParty;
			if (mainParty == null)
			{
				return result;
			}
			HashSet<MobileParty> visited = new HashSet<MobileParty>();
			AddParty(mainParty);
			Army army = mainParty.Army;
			if (army != null && army.LeaderParty == mainParty)
			{
				foreach (MobileParty item in (List<MobileParty>)(object)army.Parties)
				{
					if (item != null && item != mainParty)
					{
						AddParty(item);
					}
				}
			}
			if (mainParty.AttachedParties != null)
			{
				foreach (MobileParty item2 in (List<MobileParty>)(object)mainParty.AttachedParties)
				{
					if (item2 != null && item2 != mainParty)
					{
						AddParty(item2);
					}
				}
			}
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement != null && AIActionManager.Instance != null)
			{
				List<Hero> heroesFollowingPlayerInSettlement = AIActionManager.Instance.GetHeroesFollowingPlayerInSettlement(currentSettlement);
				foreach (Hero item3 in heroesFollowingPlayerInSettlement)
				{
					if (item3 == null || item3.PartyBelongedTo == null || item3.PartyBelongedTo == mainParty || visited.Contains(item3.PartyBelongedTo))
					{
						continue;
					}
					AddParty(item3.PartyBelongedTo);
					_logger.Log($"[PLAYER_REINFORCEMENT] Added following lord's party: {item3.Name} ({item3.PartyBelongedTo.Name})");
					if (item3.PartyBelongedTo.Army == null || item3.PartyBelongedTo.Army.LeaderParty != item3.PartyBelongedTo)
					{
						continue;
					}
					foreach (MobileParty item4 in (List<MobileParty>)(object)item3.PartyBelongedTo.Army.Parties)
					{
						if (item4 != null && item4 != item3.PartyBelongedTo)
						{
							AddParty(item4);
							_logger.Log($"[PLAYER_REINFORCEMENT] Added army party from following lord: {item4.Name}");
						}
					}
				}
			}
			void AddParty(MobileParty party)
			{
				if (party != null && party.MemberRoster != null && visited.Add(party) && party.MemberRoster.TotalManCount > 0)
				{
					result.Add(party);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("GetTroopSourceParties", ex.Message, ex);
		}
		return result;
	}

	private List<TroopRosterElement> GetTroopElementsIncludingArmy(out int sourcePartyCount)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		List<TroopRosterElement> list = new List<TroopRosterElement>();
		sourcePartyCount = 0;
		try
		{
			List<MobileParty> troopSourceParties = GetTroopSourceParties();
			sourcePartyCount = troopSourceParties.Count;
			foreach (MobileParty item in troopSourceParties)
			{
				TroopRoster memberRoster = item.MemberRoster;
				if (memberRoster == null)
				{
					continue;
				}
				foreach (TroopRosterElement item2 in (List<TroopRosterElement>)(object)memberRoster.GetTroopRoster())
				{
					TroopRosterElement current2 = item2;
					if (current2.Character != null && (current2).Number > 0)
					{
						list.Add(current2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("GetTroopElementsIncludingArmy", ex.Message, ex);
		}
		return list;
	}

	private List<(TroopRosterElement Element, MobileParty Party)> GetTroopElementsWithParty(out int sourcePartyCount)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		List<(TroopRosterElement, MobileParty)> list = new List<(TroopRosterElement, MobileParty)>();
		sourcePartyCount = 0;
		try
		{
			List<MobileParty> troopSourceParties = GetTroopSourceParties();
			sourcePartyCount = troopSourceParties.Count;
			foreach (MobileParty item in troopSourceParties)
			{
				TroopRoster memberRoster = item.MemberRoster;
				if (memberRoster == null)
				{
					continue;
				}
				foreach (TroopRosterElement item2 in (List<TroopRosterElement>)(object)memberRoster.GetTroopRoster())
				{
					TroopRosterElement current2 = item2;
					if (current2.Character != null && (current2).Number > 0)
					{
						list.Add((current2, item));
					}
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("GetTroopElementsWithParty", ex.Message, ex);
		}
		return list;
	}

	private List<SummonTroopInfo> GetTroopsToSummon(IEnumerable<TroopRosterElement> rosterElements, int maxCount, Dictionary<CharacterObject, MobileParty> characterToPartyMap = null)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		List<SummonTroopInfo> list = new List<SummonTroopInfo>();
		try
		{
			List<Agent> list2 = (from a in _summonedAgents.ToList()
				where a == null || !a.IsActive()
				select a).ToList();
			foreach (Agent item in list2)
			{
				_summonedAgents.Remove(item);
				_agentToPartyMap.Remove(item);
			}
			List<TroopRosterElement> list3 = rosterElements?.Where((TroopRosterElement element) => element.Character != null && (element).Number > 0).ToList() ?? new List<TroopRosterElement>();
			if (list3.Count == 0)
			{
				return list;
			}
			Dictionary<CharacterObject, int> dictionary = new Dictionary<CharacterObject, int>();
			foreach (TroopRosterElement item2 in list3)
			{
				TroopRosterElement current2 = item2;
				if (!dictionary.TryGetValue(current2.Character, out var value))
				{
					dictionary[current2.Character] = (current2).Number;
				}
				else
				{
					dictionary[current2.Character] = value + (current2).Number;
				}
			}
			bool flag = maxCount == int.MaxValue;
			int num = (flag ? int.MaxValue : Math.Max(0, maxCount));
			List<CharacterObject> list4 = dictionary.Keys.Where((CharacterObject character) => ((BasicCharacterObject)character).IsHero && character.HeroObject != null && character.HeroObject.IsPlayerCompanion).ToList();
			foreach (CharacterObject item3 in list4)
			{
				if (!flag && num <= 0)
				{
					break;
				}
				if (!IsHeroAlreadySummoned(item3))
				{
					MobileParty sourceParty = null;
					if (characterToPartyMap != null && characterToPartyMap.TryGetValue(item3, out var value2))
					{
						sourceParty = value2;
					}
					list.Add(new SummonTroopInfo(item3, 1, sourceParty));
					if (!flag)
					{
						num--;
					}
				}
				dictionary.Remove(item3);
			}
			List<KeyValuePair<CharacterObject, int>> list5 = (from kvp in dictionary
				where kvp.Key != null && !((BasicCharacterObject)kvp.Key).IsHero
				orderby kvp.Key.Tier descending, ((BasicCharacterObject)kvp.Key).Level descending, kvp.Value descending
				select kvp).ToList();
			foreach (KeyValuePair<CharacterObject, int> item4 in list5)
			{
				if (!flag && num <= 0)
				{
					break;
				}
				CharacterObject key = item4.Key;
				int value3 = item4.Value;
				int summonedCountForTroop = GetSummonedCountForTroop(key);
				int num2 = value3 - summonedCountForTroop;
				if (num2 <= 0)
				{
					continue;
				}
				int num3 = (flag ? num2 : Math.Min(num2, num));
				if (num3 > 0)
				{
					MobileParty sourceParty2 = null;
					if (characterToPartyMap != null && characterToPartyMap.TryGetValue(key, out var value4))
					{
						sourceParty2 = value4;
					}
					list.Add(new SummonTroopInfo(key, num3, sourceParty2));
					if (!flag)
					{
						num -= num3;
					}
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("GetTroopsToSummon", ex.Message, ex);
		}
		return list;
	}

	private bool IsHeroAlreadySummoned(CharacterObject character)
	{
		try
		{
			if (Mission.Current == null || !((BasicCharacterObject)character).IsHero)
			{
				return false;
			}
			return _summonedAgents.Any((Agent a) => a != null && a.IsActive() && a.Character != null && ((MBObjectBase)a.Character).StringId == ((MBObjectBase)character).StringId);
		}
		catch
		{
			return false;
		}
	}

	private int GetSummonedCountForTroop(CharacterObject character)
	{
		try
		{
			if (((BasicCharacterObject)character).IsHero)
			{
				return IsHeroAlreadySummoned(character) ? 1 : 0;
			}
			return _summonedAgents.Count((Agent a) => a != null && a.IsActive() && a.Character != null && ((MBObjectBase)a.Character).StringId == ((MBObjectBase)character).StringId);
		}
		catch
		{
			return 0;
		}
	}

	private void InitializePlayerTeamForControl()
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (_playerTeamInitialized)
			{
				return;
			}
			Mission current = Mission.Current;
			Team val = ((current != null) ? current.PlayerTeam : null);
			if (val == null || Agent.Main == null)
			{
				_logger.Log("Cannot initialize player team: PlayerTeam or Agent.Main is null");
				return;
			}
			_logger.Log("=== Initializing Player Team for Troop Control ===");
			val.SetPlayerRole(true, false);
			_logger.Log($"PlayerTeam.IsPlayerGeneral = {val.IsPlayerGeneral}");
			val.PlayerOrderController.Owner = Agent.Main;
			_logger.Log("PlayerOrderController.Owner = Agent.Main");
			foreach (Formation item in (List<Formation>)(object)val.FormationsIncludingEmpty)
			{
				item.PlayerOwner = Agent.Main;
				item.SetControlledByAI(false, false);
				_logger.Log($"Formation {item.FormationIndex} configured");
			}
			AddCriticalMissionBehaviors();
			if (_orderProvider == null)
			{
				_orderProvider = new SettlementOrderProvider();
				VisualOrderFactory.RegisterProvider((VisualOrderProvider)(object)_orderProvider);
				_logger.Log("!!! SettlementOrderProvider REGISTERED !!!");
			}
			_playerTeamInitialized = true;
			_logger.Log("=== Player Team Control Initialized ===");
		}
		catch (Exception ex)
		{
			_logger.LogError("InitializePlayerTeamForControl", ex.Message, ex);
		}
	}

	private void AddCriticalMissionBehaviors()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		try
		{
			_logger.Log("=== Adding critical MissionBehaviors ===");
			if (Mission.Current.GetMissionBehavior<AgentHumanAILogic>() == null)
			{
				AgentHumanAILogic val = new AgentHumanAILogic();
				Mission.Current.AddMissionBehavior((MissionBehavior)(object)val);
				((MissionBehavior)val).OnBehaviorInitialize();
				foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
				{
					if (item != null && item.IsActive() && item.IsAIControlled && item.IsHuman && item.HumanAIComponent == null)
					{
						item.AddComponent((AgentComponent)new HumanAIComponent(item));
					}
				}
				_logger.Log("✓ AgentHumanAILogic added");
			}
			if (Mission.Current.GetMissionBehavior<MountAgentLogic>() == null)
			{
				MountAgentLogic val2 = new MountAgentLogic();
				Mission.Current.AddMissionBehavior((MissionBehavior)(object)val2);
				((MissionBehavior)val2).OnBehaviorInitialize();
				_logger.Log("✓ MountAgentLogic added");
			}
			if (Mission.Current.GetMissionBehavior<AssignPlayerRoleInTeamMissionController>() == null)
			{
				AssignPlayerRoleInTeamMissionController val3 = new AssignPlayerRoleInTeamMissionController(true, false, false, (List<string>)null);
				Mission.Current.AddMissionBehavior((MissionBehavior)(object)val3);
				((MissionBehavior)val3).OnBehaviorInitialize();
				_logger.Log("✓ AssignPlayerRoleInTeamMissionController added");
			}
			_logger.Log("=== All critical MissionBehaviors added ===");
		}
		catch (Exception ex)
		{
			_logger.LogError("AddCriticalMissionBehaviors", ex.Message, ex);
		}
	}

	private void SelectFormationsWithTroops()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Mission current = Mission.Current;
			Team val = ((current != null) ? current.PlayerTeam : null);
			if (val == null)
			{
				return;
			}
			_logger.Log("=== Selecting formations with troops ===");
			List<Formation> list = ((IEnumerable<Formation>)val.FormationsIncludingEmpty).Where((Formation f) => f != null && f.CountOfUnits > 0).ToList();
			_logger.Log($"Formations with units: {list.Count}");
			foreach (Formation item in list)
			{
				_logger.Log($"  - {item.FormationIndex}: {item.CountOfUnits} units");
			}
			if (list.Count > 0)
			{
				val.PlayerOrderController.SelectAllFormations(false);
				_logger.Log($"Total selected formations: {((List<Formation>)(object)val.PlayerOrderController.SelectedFormations).Count}");
				TextObject val2 = new TextObject("{=AIInfluence_SummonTroops_FormationsReady}Done: {COUNT} formations are ready for commands.", (Dictionary<string, object>)null);
				val2.SetTextVariable("COUNT", list.Count);
				ShowMessage(((object)val2).ToString(), ExtraColors.GreenAIInfluence);
			}
			else
			{
				_logger.Log("WARNING: No formations with units found!");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SelectFormationsWithTroops", ex.Message, ex);
		}
	}

	private bool SpawnPlayerTroop(CharacterObject character, bool spawnFromBoundary, MobileParty sourceParty = null)
	{
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || Agent.Main == null || character == null)
			{
				return false;
			}
			if (!_playerTeamInitialized)
			{
				InitializePlayerTeamForControl();
			}
			int num = CountActivePlayerTroops();
			int maxTroopsPerSide = GetMaxTroopsPerSide();
			if (num >= maxTroopsPerSide)
			{
				if (_isAllTroopsSummoned && _defenderSpawner != null)
				{
					_defenderSpawner.AddToPlayerReserve(character, sourceParty ?? MobileParty.MainParty);
					_logger.Log($"[LIMIT] Player troop '{((BasicCharacterObject)character).Name}' added to reserve (current: {num}/{maxTroopsPerSide})");
					return false;
				}
				_logger.Log($"[LIMIT] Cannot spawn more player troops! Limit reached: {num}/{maxTroopsPerSide}");
				return false;
			}
			Settlement val = _combatManager?.GetActiveCombatSettlement() ?? Settlement.CurrentSettlement;
			Mission current = Mission.Current;
			string text = ((current == null) ? null : current.SceneName?.ToLower()) ?? "";
			bool flag = val != null && (val.IsTown || val.IsCastle || val.IsVillage) && ((_combatManager != null && _combatManager.IsCurrentLocationLargeOutdoor()) || text.Contains("center") || text.Contains("town") || text.Contains("market") || text.Contains("village"));
			Vec3 val2 = ((spawnFromBoundary && flag) ? GetBoundarySpawnPosition() : GetLocalSpawnPosition());
			MobileParty mainParty = MobileParty.MainParty;
			if (((mainParty != null) ? mainParty.Party : null) == null)
			{
				_logger.Log("ERROR: MobileParty.MainParty or Party is null");
				return false;
			}
			if (((BasicCharacterObject)character).Equipment == null)
			{
				_logger.Log($"ERROR: Character {((BasicCharacterObject)character).Name} has null Equipment, skipping spawn");
				return false;
			}
			Team playerTeam = Mission.Current.PlayerTeam;
			if (playerTeam == null)
			{
				_logger.Log("ERROR: PlayerTeam is null");
				return false;
			}
			IAgentOriginBase val3 = (IAgentOriginBase)new PartyAgentOrigin(mainParty.Party, character, -1, default(UniqueTroopDescriptor), false, false);
			Vec2 val4 = ((Agent.Main != null && Agent.Main.IsActive()) ? Agent.Main.GetMovementDirection() : Vec2.Forward);
			bool flag2 = !flag;
			AgentBuildData val5 = new AgentBuildData((BasicCharacterObject)(object)character).Team(playerTeam).TroopOrigin(val3).InitialPosition(ref val2)
				.InitialDirection(ref val4)
				.Equipment(((BasicCharacterObject)character).Equipment)
				.NoHorses(flag2)
				.Controller((AgentControllerType)1)
				.ClothingColor1(playerTeam.Color)
				.ClothingColor2(playerTeam.Color2);
			Agent val6 = Mission.Current.SpawnAgent(val5, false);
			if (val6 != null)
			{
				Formation formationForCharacter = GetFormationForCharacter(character);
				if (formationForCharacter != null)
				{
					val6.Formation = formationForCharacter;
				}
				if (_combatManager != null && _combatManager.IsActiveCombat())
				{
					WieldBestWeapon(val6);
					val6.SetWatchState((WatchState)2);
					_logger.Log("Troop spawned during combat - armed and set to combat mode");
				}
				_summonedAgents.Add(val6);
				if (sourceParty != null)
				{
					_agentToPartyMap[val6] = sourceParty;
					_logger.Log($"[SUMMON] Agent {val6.Name} spawned from party {sourceParty.Name}");
				}
				else
				{
					_agentToPartyMap[val6] = MobileParty.MainParty;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnPlayerTroop", ex.Message, ex);
			return false;
		}
	}

	private Formation GetFormationForCharacter(CharacterObject character)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Mission current = Mission.Current;
			Team val = ((current != null) ? current.PlayerTeam : null);
			if (val == null)
			{
				return null;
			}
			FormationClass val2 = (((BasicCharacterObject)character).IsMounted ? ((!((BasicCharacterObject)character).IsRanged) ? ((FormationClass)2) : ((FormationClass)3)) : ((!((BasicCharacterObject)character).IsRanged) ? ((FormationClass)0) : ((FormationClass)1)));
			return val.GetFormation(val2);
		}
		catch (Exception ex)
		{
			_logger.LogError("GetFormationForCharacter", ex.Message, ex);
			Mission current2 = Mission.Current;
			object result;
			if (current2 == null)
			{
				result = null;
			}
			else
			{
				Team playerTeam = current2.PlayerTeam;
				result = ((playerTeam != null) ? playerTeam.GetFormation((FormationClass)0) : null);
			}
			return (Formation)result;
		}
	}

	private Vec3 GetLocalSpawnPosition()
	{
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || (NativeObject)(object)Mission.Current.Scene == (NativeObject)null)
			{
				return Vec3.Zero;
			}
			Random random = new Random(Guid.NewGuid().GetHashCode());
			Vec3 val = Vec3.Zero;
			bool flag = false;
			string[] array = new string[5] { "spawnpoint_player", "spawnpoint_player_outside", "sp_outside_near_town_main_gate", "sp_player_conversation", "sp_player" };
			string[] array2 = array;
			foreach (string text in array2)
			{
				GameEntity val2 = Mission.Current.Scene.FindEntityWithTag(text);
				if (val2 != (GameEntity)null)
				{
					MatrixFrame globalFrame = val2.GetGlobalFrame();
					val = globalFrame.origin;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Vec2 val3;
				if (!(_playerInitialSpawnPosition != Vec3.Zero))
				{
					Agent main = Agent.Main;
					val3 = ((main != null) ? main.Position : Vec3.Zero);
				}
				else
				{
					val3 = _playerInitialSpawnPosition;
				}
				val = (Vec3)val3;
				_logger.Log($"No spawn point tag found, using saved/current position: {val}");
			}
			if (TryGetMainGateSpawnPosition(out var spawnPosition))
			{
				_logger.Log($"Using main gate spawn for player troop: {spawnPosition}");
				_playerInitialSpawnPosition = spawnPosition;
				return spawnPosition;
			}
			Vec2 val4 = _playerInitialForward2D;
			if ((val4).LengthSquared < 0.001f)
			{
				Vec2 val5;
				if (Agent.Main == null)
				{
					val5 = new Vec2(0f, 1f);
				}
				else
				{
					Vec3 lookDirection = Agent.Main.LookDirection;
					val5 = (lookDirection).AsVec2;
				}
				val4 = (Vec2)val5;
			}
			if ((val4).LengthSquared > 0.001f)
			{
				(val4).Normalize();
			}
			Vec2 val6 = default(Vec2);
			val6 = new Vec2(val4.y, 0f - val4.x);
			Scene scene = Mission.Current.Scene;
			Vec3 val8 = default(Vec3);
			WorldPosition val9 = default(WorldPosition);
			WorldPosition val10 = default(WorldPosition);
			float num3 = default(float);
			for (int j = 0; j < 10; j++)
			{
				float num = 8f + (float)(random.NextDouble() * 12.0);
				float num2 = (float)(random.NextDouble() * 10.0) - 5f;
				Vec2 val7 = (val).AsVec2 - val4 * num + val6 * num2;
				float z = val.z;
				scene.GetHeightAtPoint(val7, (BodyFlags)544321929, ref z);
				val8 = new Vec3(val7.x, val7.y, z, -1f);
				bool flag2 = true;
				if (Agent.Main != null && Agent.Main.IsActive())
				{
					try
					{
						val9 = new WorldPosition(scene, UIntPtr.Zero, Agent.Main.Position, false);
						val10 = new WorldPosition(scene, UIntPtr.Zero, val8, false);
						flag2 = scene.GetPathDistanceBetweenPositions(ref val9, ref val10, 0f, ref num3) && num3 >= 0f && num3 < 100f;
					}
					catch
					{
					}
				}
				if (flag2 && IsPositionFlat(Mission.Current, val8))
				{
					_logger.Log($"Local spawn at {val8} (back {num:F1}, lateral {num2:F1}, attempt {j})");
					return val8;
				}
			}
			Agent main2 = Agent.Main;
			Vec3 val11 = ((main2 != null) ? main2.Position : val);
			_logger.Log($"Local spawn fallback to player position: {val11}");
			return val11;
		}
		catch (Exception ex)
		{
			_logger.LogError("GetLocalSpawnPosition", ex.Message, ex);
			Agent main3 = Agent.Main;
			return (main3 != null) ? main3.Position : Vec3.Zero;
		}
	}

	private Vec3 GetBoundarySpawnPosition()
	{
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Mission current = Mission.Current;
			if (current == null || (NativeObject)(object)current.Scene == (NativeObject)null || Agent.Main == null)
			{
				return Vec3.Zero;
			}
			if (_ambushSpawnPoints == null || _ambushSpawnPoints.Count == 0)
			{
				_ambushSpawnPoints = CalculateAmbushSpawnPoints(current);
				_ambushSpawnIndex = 0;
			}
			if (_ambushSpawnPoints.Count == 0)
			{
				_logger.Log("[AMBUSH] No valid ambush points found, using local spawn fallback");
				return GetLocalSpawnPosition();
			}
			Vec3 val = _ambushSpawnPoints[_ambushSpawnIndex % _ambushSpawnPoints.Count];
			_ambushSpawnIndex++;
			Random random = new Random(Guid.NewGuid().GetHashCode());
			float num = (float)(random.NextDouble() * Math.PI * 2.0);
			float num2 = (float)(random.NextDouble() * 5.0);
			Vec2 val2 = default(Vec2);
			val2 = new Vec2((float)Math.Cos(num) * num2, (float)Math.Sin(num) * num2);
			Vec2 val3 = (val).AsVec2 + val2;
			float num3 = 0f;
			current.Scene.GetHeightAtPoint(val3, (BodyFlags)544321929, ref num3);
			Vec3 val4 = default(Vec3);
			val4 = new Vec3(val3.x, val3.y, num3, -1f);
			_logger.Log($"[AMBUSH] Spawning at point #{(_ambushSpawnIndex - 1) % _ambushSpawnPoints.Count} with scatter: {val4}");
			return val4;
		}
		catch (Exception ex)
		{
			_logger.LogError("GetBoundarySpawnPosition", ex.Message, ex);
			Agent main = Agent.Main;
			return (main != null) ? main.Position : Vec3.Zero;
		}
	}

	private List<Vec3> CalculateAmbushSpawnPoints(Mission mission)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		List<Vec3> list = new List<Vec3>();
		try
		{
			Vec3 position = Agent.Main.Position;
			Vec2 asVec = (position).AsVec2;
			Random random = new Random(Guid.NewGuid().GetHashCode());
			float num = (float)(random.NextDouble() * Math.PI * 2.0);
			float num2 = (float)Math.PI / 2f;
			Vec2 val2 = default(Vec2);
			Vec3 val6 = default(Vec3);
			WorldPosition val7 = default(WorldPosition);
			WorldPosition val8 = default(WorldPosition);
			float num7 = default(float);
			for (int i = 0; i < 4; i++)
			{
				float num3 = num + num2 * (float)i;
				Vec3 val = Vec3.Zero;
				bool flag = false;
				for (int j = 0; j < 5; j++)
				{
					float num4 = num3 + (float)((random.NextDouble() - 0.5) * (double)num2 * 0.4);
					val2 = new Vec2((float)Math.Cos(num4), (float)Math.Sin(num4));
					Vec2 val3 = asVec + val2 * 50f;
					Vec2 closestBoundaryPosition = mission.GetClosestBoundaryPosition(val3);
					float num5 = 6f + (float)(random.NextDouble() * 6.0);
					Vec2 val4 = asVec - closestBoundaryPosition;
					if ((val4).LengthSquared > 0.001f)
					{
						val4 = (val4).Normalized();
					}
					else
					{
						val4 = new Vec2(0f - (float)Math.Cos(num4), 0f - (float)Math.Sin(num4));
					}
					Vec2 val5 = closestBoundaryPosition + val4 * num5;
					float num6 = 0f;
					mission.Scene.GetHeightAtPoint(val5, (BodyFlags)544321929, ref num6);
					val6 = new Vec3(val5.x, val5.y, num6, -1f);
					if (IsPositionFlat(mission, val6))
					{
						bool flag2 = true;
						try
						{
							val7 = new WorldPosition(mission.Scene, UIntPtr.Zero, Agent.Main.Position, false);
							val8 = new WorldPosition(mission.Scene, UIntPtr.Zero, val6, false);
							flag2 = mission.Scene.GetPathDistanceBetweenPositions(ref val7, ref val8, 0f, ref num7) && num7 >= 0f && num7 < 300f;
						}
						catch
						{
							flag2 = true;
						}
						if (flag2)
						{
							val = val6;
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					list.Add(val);
					_logger.Log($"[AMBUSH] Point #{i}: {val} (angle {Math.Round((double)(num3 * 180f) / Math.PI)}°)");
				}
			}
			if (list.Count == 0)
			{
				_logger.Log("[AMBUSH] Failed to find any ambush points, trying main gate fallback");
				if (TryGetMainGateSpawnPosition(out var spawnPosition))
				{
					list.Add(spawnPosition);
				}
			}
			_logger.Log($"[AMBUSH] Calculated {list.Count} ambush spawn points");
		}
		catch (Exception ex)
		{
			_logger.LogError("CalculateAmbushSpawnPoints", ex.Message, ex);
		}
		return list;
	}

	private bool TryGetMainGateSpawnPosition(out Vec3 spawnPosition)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		spawnPosition = Vec3.Zero;
		try
		{
			Mission current = Mission.Current;
			if (current == null || (NativeObject)(object)current.Scene == (NativeObject)null)
			{
				return false;
			}
			GameEntity val = current.Scene.FindEntityWithTag("spawnpoint_player_outside");
			if (val == (GameEntity)null)
			{
				val = current.Scene.FindEntityWithTag("sp_outside_near_town_main_gate");
			}
			if (val == (GameEntity)null)
			{
				val = current.Scene.FindEntityWithTag("spawnpoint_player");
			}
			if (val == (GameEntity)null)
			{
				return false;
			}
			MatrixFrame globalFrame = val.GetGlobalFrame();
			Vec3 val2 = globalFrame.rotation.f;
			if ((val2).LengthSquared < 0.001f)
			{
				val2 = globalFrame.rotation.s;
			}
			if ((val2).LengthSquared < 0.001f)
			{
				val2 = Vec3.Forward;
			}
			(val2).Normalize();
			Vec3 s = globalFrame.rotation.s;
			if ((s).LengthSquared < 0.001f)
			{
				s = new Vec3(val2.y, 0f - val2.x, 0f, -1f);
			}
			(s).Normalize();
			Random random = new Random(Guid.NewGuid().GetHashCode());
			float num = 25f;
			float num2 = (float)(random.NextDouble() * 8.0) - 4f;
			Vec3 val3 = globalFrame.origin - val2 * num + s * num2;
			float z = val3.z;
			current.Scene.GetHeightAtPoint((val3).AsVec2, (BodyFlags)544321929, ref z);
			val3.z = z;
			spawnPosition = val3;
			_playerInitialForward2D = new Vec2(val2.x, val2.y);
			_playerInitialSpawnPosition = spawnPosition;
			_logger.Log($"[PLAYER_REINFORCEMENT] Main gate spawn resolved at {spawnPosition} (offset 25m behind gate)");
			return true;
		}
		catch (Exception ex)
		{
			_logger.LogError("TryGetMainGateSpawnPosition", ex.Message, ex);
			return false;
		}
	}

	private bool IsPositionFlat(Mission mission, Vec3 position)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			float num = 2f;
			float z = position.z;
			Vec2[] array = (Vec2[])(object)new Vec2[4]
			{
				new Vec2(position.x + num, position.y),
				new Vec2(position.x - num, position.y),
				new Vec2(position.x, position.y + num),
				new Vec2(position.x, position.y - num)
			};
			float num2 = 0f;
			Vec2[] array2 = array;
			foreach (Vec2 val in array2)
			{
				float num3 = 0f;
				mission.Scene.GetHeightAtPoint(val, (BodyFlags)544321929, ref num3);
				float num4 = Math.Abs(num3 - z);
				if (num4 > num2)
				{
					num2 = num4;
				}
			}
			return num2 <= 3f;
		}
		catch
		{
			return true;
		}
	}

	private void CleanupDeadAgents()
	{
		try
		{
			if (_summonedAgents.Count == 0)
			{
				return;
			}
			List<Agent> list = _summonedAgents.Where((Agent a) => a == null || !a.IsActive()).ToList();
			foreach (Agent item in list)
			{
				_summonedAgents.Remove(item);
				_agentToPartyMap.Remove(item);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CleanupDeadAgents", ex.Message, ex);
		}
	}

	private void ShowSummonHint()
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		try
		{
			_logger.Log("=== ShowSummonHint called ===");
			SettlementCombatLogger logger = _logger;
			Settlement currentSettlement = Settlement.CurrentSettlement;
			logger.Log("  Settlement: " + (((currentSettlement == null) ? null : ((object)currentSettlement.Name)?.ToString()) ?? "NULL"));
			SettlementCombatLogger logger2 = _logger;
			Mission current = Mission.Current;
			logger2.Log("  Mission: " + (((current != null) ? current.SceneName : null) ?? "NULL"));
			_logger.Log($"  Combat active: {_combatManager?.IsActiveCombat() ?? false}");
			TextObject val = new TextObject("{=AIInfluence_SummonTroopsHint_1}You can summon your troops:", (Dictionary<string, object>)null);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
			_logger.Log("  Message 1: " + ((object)val).ToString());
			TextObject val2 = new TextObject("{=AIInfluence_SummonTroopsHint_2}CTRL + X - 10 troops", (Dictionary<string, object>)null);
			InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), Colors.Gray));
			_logger.Log("  Message 2: " + ((object)val2).ToString());
			TextObject val3 = new TextObject("{=AIInfluence_SummonTroopsHint_3}CTRL + ALT + X - all troops (coming from settlement outskirts)", (Dictionary<string, object>)null);
			InformationManager.DisplayMessage(new InformationMessage(((object)val3).ToString(), Colors.Gray));
			_logger.Log("  Message 3: " + ((object)val3).ToString());
			_logger.Log("=== Summon troops hint displayed successfully (3 messages) ===");
		}
		catch (Exception ex)
		{
			_logger.LogError("ShowSummonHint", ex.Message, ex);
		}
	}

	private void ShowMessage(string message, Color color)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		try
		{
			InformationManager.DisplayMessage(new InformationMessage(message, color));
		}
		catch (Exception ex)
		{
			_logger.LogError("ShowMessage", ex.Message, ex);
		}
	}

	private int GetMaxTroopsPerSide()
	{
		try
		{
			if (Mission.Current == null)
			{
				return 75;
			}
			string text = Mission.Current.SceneName?.ToLower() ?? "";
			return (text.Contains("lordshall") || (text.Contains("lord") && text.Contains("hall")) || text.Contains("tavern") || text.Contains("arena") || text.Contains("prison") || text.Contains("dungeon") || (text.Contains("keep") && !text.Contains("market"))) ? 5 : 75;
		}
		catch
		{
			return 75;
		}
	}

	private int CountActivePlayerTroops()
	{
		try
		{
			if (Mission.Current == null || Mission.Current.PlayerTeam == null)
			{
				return 0;
			}
			return ((IEnumerable<Agent>)Mission.Current.Agents).Count((Agent a) => a != null && a.IsActive() && a.IsHuman && a.Team == Mission.Current.PlayerTeam);
		}
		catch
		{
			return 0;
		}
	}

	private void WieldBestWeapon(Agent agent)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Invalid comparison between Unknown and I4
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Invalid comparison between Unknown and I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Invalid comparison between Unknown and I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Invalid comparison between Unknown and I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Invalid comparison between Unknown and I4
		try
		{
			if (agent == null || !agent.IsActive())
			{
				return;
			}
			EquipmentIndex val = (EquipmentIndex)(-1);
			for (EquipmentIndex val2 = (EquipmentIndex)0; (int)val2 < 5; val2 = (EquipmentIndex)(val2 + 1))
			{
				MissionWeapon val3 = agent.Equipment[val2];
				if (!(val3).IsEmpty)
				{
					val3 = agent.Equipment[val2];
					WeaponClass weaponClass = (val3).CurrentUsageItem.WeaponClass;
					if ((int)weaponClass == 2 || (int)weaponClass == 3 || (int)weaponClass == 4 || (int)weaponClass == 5 || (int)weaponClass == 6 || (int)weaponClass == 8 || (int)weaponClass == 7 || (int)weaponClass == 1 || (int)weaponClass == 9 || (int)weaponClass == 10 || (int)weaponClass == 11)
					{
						val = val2;
						break;
					}
					if ((int)val == -1)
					{
						val = val2;
					}
				}
			}
			if ((int)val != -1)
			{
				agent.TryToWieldWeaponInSlot(val, (WeaponWieldActionType)2, false);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("WieldBestWeapon", ex.Message, ex);
		}
	}

	public int TransferLordTroopsToDefenderTeam(Hero lord)
	{
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		try
		{
			if (lord == null || Mission.Current == null || Mission.Current.DefenderTeam == null)
			{
				_logger.Log("[TRANSFER] Cannot transfer troops - lord, mission or DefenderTeam is null");
				return 0;
			}
			MobileParty partyBelongedTo = lord.PartyBelongedTo;
			if (partyBelongedTo == null)
			{
				_logger.Log($"[TRANSFER] Lord {lord.Name} has no party");
				return 0;
			}
			_logger.Log($"[TRANSFER] Looking for troops from lord {lord.Name} (party: {partyBelongedTo.Name})");
			List<Agent> list = new List<Agent>();
			foreach (KeyValuePair<Agent, MobileParty> item in _agentToPartyMap.ToList())
			{
				Agent key = item.Key;
				MobileParty value = item.Value;
				if (key != null && key.IsActive() && key.Team == Mission.Current.PlayerTeam)
				{
					bool flag = value == partyBelongedTo;
					bool flag2 = partyBelongedTo.Army != null && partyBelongedTo.Army.LeaderParty == partyBelongedTo && value != null && value.Army == partyBelongedTo.Army;
					if (flag || flag2)
					{
						list.Add(key);
						_logger.Log("[TRANSFER] Found agent " + key.Name + " from " + (flag ? "lord party" : "lord army"));
					}
				}
			}
			foreach (Agent item2 in list)
			{
				try
				{
					if (item2 != null && item2.IsActive())
					{
						item2.SetTeam(Mission.Current.DefenderTeam, true);
						item2.SetWatchState((WatchState)2);
						WieldBestWeapon(item2);
						if (Agent.Main != null)
						{
							item2.SetLookAgent(Agent.Main);
							item2.SetAgentFlags((AgentFlag)((int)item2.GetAgentFlags() | 8 | 0x10));
						}
						num++;
						_logger.Log("[TRANSFER] Agent " + item2.Name + " transferred to DefenderTeam");
					}
				}
				catch (Exception ex)
				{
					_logger.LogError("[TRANSFER] Error transferring agent " + ((item2 != null) ? item2.Name : null), ex.Message, ex);
				}
			}
			_logger.Log($"[TRANSFER] Transferred {num} troops from lord {lord.Name} to DefenderTeam");
		}
		catch (Exception ex2)
		{
			_logger.LogError("TransferLordTroopsToDefenderTeam", ex2.Message, ex2);
		}
		return num;
	}
}
