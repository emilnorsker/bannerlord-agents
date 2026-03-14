using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.AgentOrigins;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.SettlementCombat;

public class DefenderSpawner
{
	private readonly AIInfluenceBehavior _behavior;

	private readonly SettlementCombatLogger _logger;

	private readonly Random _random = new Random();

	private CombatStatistics _statistics;

	private int _pendingSimpleDefenders = 0;

	private int _pendingMilitia = 0;

	private int _pendingGuards = 0;

	private int _pendingLords = 0;

	private bool _simpleDefendersScheduled = false;

	private bool _militiaScheduled = false;

	private bool _guardsScheduled = false;

	private CampaignTime? _guardsSpawnScheduledTime = null;

	private float _guardsSpawnDelay = 0f;

	private const int MAX_TROOPS_PER_SIDE_LARGE = 75;

	private const int MAX_TOTAL_TROOPS_LARGE = 150;

	private const int MAX_TROOPS_PER_SIDE_SMALL = 5;

	private const int MAX_TOTAL_TROOPS_SMALL = 10;

	private Queue<(CharacterObject Troop, MobileParty Party)> _playerSideReserve = new Queue<(CharacterObject, MobileParty)>();

	private Queue<(CharacterObject Troop, MobileParty Party)> _enemySideReserve = new Queue<(CharacterObject, MobileParty)>();

	private readonly HashSet<int> _spawnedPlayerAgents = new HashSet<int>();

	private readonly HashSet<int> _spawnedEnemyAgents = new HashSet<int>();

	private readonly Dictionary<MobileParty, string> _partyToLordId = new Dictionary<MobileParty, string>();

	private float _lastReinforcementCheck = 0f;

	private const float REINFORCEMENT_CHECK_INTERVAL = 60f;

	private ActiveCombat _currentCombat = null;

	private const float MIN_DISTANCE_FROM_PLAYER_FOR_CITY_SPAWN = 70f;

	private static readonly string[] CITY_GUARD_SPAWN_TAGS = new string[15]
	{
		"sp_guard", "sp_guard_patrol", "sp_guard_castle", "sp_prison_guard", "sp_guard_unarmed", "sp_player_conversation", "sp_player_conversation_alley_1", "sp_player_conversation_alley_2", "sp_player_conversation_alley_3", "sp_player_conversation_workshop_1",
		"sp_player_conversation_workshop_2", "sp_player_conversation_workshop_3", "center_conversation_point", "sp_outside_near_town_main_gate", "spawnpoint_player_outside"
	};

	private Mission _cachedMissionForCitySpawnPoints = null;

	private readonly List<GameEntity> _cachedCityGuardSpawnPoints = new List<GameEntity>();

	private static readonly string[] MAIN_GATE_SPAWN_TAGS = new string[5] { "spawnpoint_player_outside", "spawnpoint_player", "sp_outside_near_town_main_gate", "sp_player", "sp_player_conversation" };

	private const float MAIN_STREET_RETRY_SECONDS = 5f;

	private const int MAIN_STREET_MAX_RETRIES = 120;

	public DefenderSpawner(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
		_logger = SettlementCombatLogger.Instance;
	}

	private int GetMaxTroopsPerSide()
	{
		if (_currentCombat == null)
		{
			return 75;
		}
		return (_currentCombat.LocationType == LocationType.SmallIndoor) ? 5 : 75;
	}

	public void SetStatistics(CombatStatistics statistics)
	{
		_statistics = statistics;
	}

	public void OnTick(float dt)
	{
		if (_currentCombat != null && Mission.Current != null)
		{
			_lastReinforcementCheck += dt;
			if (_lastReinforcementCheck >= 60f)
			{
				_lastReinforcementCheck = 0f;
				CheckAndSpawnReinforcements();
			}
		}
	}

	public void SpawnGuardsForTransition(ActiveCombat combat, int count)
	{
		try
		{
			if (Mission.Current == null || combat == null)
			{
				return;
			}
			if (combat.Analysis != null && !combat.Analysis.NeedsDefenders)
			{
				_logger.Log("SpawnGuardsForTransition: needs_defenders = false, skipping guard spawn");
				return;
			}
			_logger.Log($"Spawning {count} guards for location transition");
			_logger.Log($"  Current location type: {combat.LocationType}");
			_logger.Log($"  Max troops per side: {GetMaxTroopsPerSide()}");
			_currentCombat = combat;
			Settlement settlement = combat.Settlement;
			List<CharacterObject> guardTemplates = GetGuardTemplates(settlement);
			if (guardTemplates == null || !guardTemplates.Any())
			{
				_logger.Log("No guard templates available for transition spawn");
				return;
			}
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				CharacterObject val = guardTemplates[i % guardTemplates.Count];
				int num2 = CountActiveTroopsOnSide(playerSide: false);
				int maxTroopsPerSide = GetMaxTroopsPerSide();
				_logger.Log($"  Transition spawn attempt {i + 1}/{count}: current troops={num2}, max={maxTroopsPerSide}");
				if (num2 >= maxTroopsPerSide)
				{
					_logger.Log("  LIMIT REACHED: Adding to reserve instead of spawning");
					_enemySideReserve.Enqueue((val, null));
				}
				else
				{
					SpawnDefenderAgent(val, combat, "Guard (Transition)");
					num++;
				}
			}
			_logger.Log($"Transition spawn completed: {num}/{count} guards spawned (rest in reserve if any)");
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnGuardsForTransition", ex.Message, ex);
		}
	}

	public void AddToPlayerReserve(CharacterObject character, MobileParty sourceParty = null)
	{
		try
		{
			if (character != null)
			{
				_playerSideReserve.Enqueue((character, sourceParty));
				_logger.Log($"[PLAYER_RESERVE] '{((BasicCharacterObject)character).Name}' added to player reserve (total: {_playerSideReserve.Count})");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("AddToPlayerReserve", ex.Message, ex);
		}
	}

	public void ClearCombat()
	{
		_currentCombat = null;
		_playerSideReserve.Clear();
		_enemySideReserve.Clear();
		_spawnedPlayerAgents.Clear();
		_spawnedEnemyAgents.Clear();
		_partyToLordId.Clear();
		_lastReinforcementCheck = 0f;
		_cachedCityGuardSpawnPoints.Clear();
		_cachedMissionForCitySpawnPoints = null;
		_logger.Log("DefenderSpawner combat data cleared");
	}

	private void RegisterSpawnedAgent(Agent agent, bool onPlayerSide)
	{
		if (agent != null)
		{
			HashSet<int> hashSet = (onPlayerSide ? _spawnedPlayerAgents : _spawnedEnemyAgents);
			hashSet.Add(agent.Index);
		}
	}

	private float GetRandomDelay(float minSeconds, float maxSeconds)
	{
		if (maxSeconds <= minSeconds)
		{
			return minSeconds;
		}
		double num = maxSeconds - minSeconds;
		return minSeconds + (float)(_random.NextDouble() * num);
	}

	public bool HasPendingSpawns()
	{
		bool flag = _pendingSimpleDefenders > 0 || _pendingMilitia > 0 || _pendingGuards > 0 || _pendingLords > 0;
		bool flag2 = _enemySideReserve.Count > 0;
		return flag || flag2;
	}

	public string GetPendingSpawnsInfo()
	{
		return $"SimpleDefenders:{_pendingSimpleDefenders}, Militia:{_pendingMilitia}, Guards:{_pendingGuards}, Lords:{_pendingLords}, EnemyReserve:{_enemySideReserve.Count}";
	}

	public void SpawnDefenders(ActiveCombat combat)
	{
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_currentCombat = combat;
			CombatSituationAnalysis analysis = combat.Analysis;
			int desiredSimpleDefenders = 0;
			int num = 0;
			int desiredGuards = 0;
			_logger.Log($"Location type: {combat.LocationType}");
			_logger.Log($"Settlement type: Town={combat.Settlement.IsTown}, Castle={combat.Settlement.IsCastle}, Village={combat.Settlement.IsVillage}");
			bool flag = combat.LocationType == LocationType.SmallIndoor;
			bool isVillage = combat.Settlement.IsVillage;
			bool flag2 = combat.Settlement.IsTown || combat.Settlement.IsCastle;
			if (flag)
			{
				_logger.Log("SMALL LOCATION (lordshall/tavern): Will spawn ONLY guards");
			}
			else if (isVillage)
			{
				_logger.Log("VILLAGE: Will spawn simple defenders + militia (NO guards)");
			}
			else if (flag2)
			{
				_logger.Log("CITY/CASTLE: Will spawn ONLY guards (NO simple defenders or militia)");
			}
			if (isVillage && !flag)
			{
				int num2 = CalculateVillageDefenderCount(combat.Settlement);
				desiredSimpleDefenders = (int)Math.Round((float)num2 * 0.6f, MidpointRounding.AwayFromZero);
				desiredSimpleDefenders = Math.Max(0, desiredSimpleDefenders);
				num = Math.Max(0, num2 - desiredSimpleDefenders);
				_logger.Log($"Village defender distribution: Total={num2}, Simple={desiredSimpleDefenders}, Militia={num}");
			}
			else if ((flag2 || flag) && combat.Settlement != null)
			{
				desiredGuards = CalculateCityGuardCount(combat.Settlement);
				_logger.Log($"City/Castle guard count based on garrison: {desiredGuards}");
			}
			_logger.Log($"Spawning defenders (calculated): SimpleDefenders={desiredSimpleDefenders}, Militia={num}, Guards={desiredGuards}, Lords={(analysis?.Lords?.Count).GetValueOrDefault()}");
			if (desiredSimpleDefenders > 0 && isVillage && !flag)
			{
				float simpleDefendersDelay = GetRandomDelay(30f, 60f);
				_pendingSimpleDefenders = desiredSimpleDefenders;
				_simpleDefendersScheduled = true;
				_logger.Log($"Scheduling simple defenders spawn: {desiredSimpleDefenders} defenders in {simpleDefendersDelay:F1} seconds");
				_behavior.GetDelayedTaskManager().AddTask(simpleDefendersDelay, delegate
				{
					_logger.Log($"Simple defenders spawn task executing (after {simpleDefendersDelay:F1}s delay)");
					SpawnSimpleDefenders(combat, desiredSimpleDefenders);
					_simpleDefendersScheduled = false;
				});
			}
			else if (desiredSimpleDefenders > 0)
			{
				_logger.Log($"Simple defenders ({desiredSimpleDefenders}) skipped - NOT A VILLAGE (only guards allowed in cities/castles/small locations)");
			}
			if (num > 0 && isVillage && !flag)
			{
				MilitiaPartyComponent militiaPartyComponent = combat.Settlement.MilitiaPartyComponent;
				int? obj;
				if (militiaPartyComponent == null)
				{
					obj = null;
				}
				else
				{
					MobileParty mobileParty = ((PartyComponent)militiaPartyComponent).MobileParty;
					if (mobileParty == null)
					{
						obj = null;
					}
					else
					{
						TroopRoster memberRoster = mobileParty.MemberRoster;
						obj = ((memberRoster != null) ? new int?(memberRoster.TotalManCount) : ((int?)null));
					}
				}
				int? num3 = obj;
				int valueOrDefault = num3.GetValueOrDefault();
				int actualMilitiaCount = Math.Min(num, valueOrDefault);
				if (actualMilitiaCount != num)
				{
					_logger.Log($"Militia count limited: desired {num}, but only {valueOrDefault} available. Spawning {actualMilitiaCount}");
				}
				if (actualMilitiaCount > 0)
				{
					float militiaDelay = GetRandomDelay(90f, 150f);
					_pendingMilitia = actualMilitiaCount;
					_militiaScheduled = true;
					_logger.Log($"Scheduling militia spawn: {actualMilitiaCount} militia in {militiaDelay:F1} seconds");
					_behavior.GetDelayedTaskManager().AddTask(militiaDelay, delegate
					{
						_logger.Log($"Militia spawn task executing (after {militiaDelay:F1}s delay)");
						SpawnMilitia(combat, actualMilitiaCount);
						_militiaScheduled = false;
					});
				}
			}
			else if (num > 0)
			{
				_logger.Log($"Militia ({num}) skipped - NOT A VILLAGE (only guards allowed in cities/castles/small locations)");
			}
			bool flag3 = flag || flag2;
			if (desiredGuards > 0 && flag3)
			{
				float randomDelay = GetRandomDelay(80f, 150f);
				_pendingGuards = desiredGuards;
				_guardsScheduled = true;
				_guardsSpawnScheduledTime = CampaignTime.Now;
				_guardsSpawnDelay = randomDelay;
				if (flag)
				{
					_logger.Log($"SMALL LOCATION: Guards ({desiredGuards}) will arrive in waves of {5}");
					_logger.Log($"  First wave in {randomDelay:F1} seconds, then every 60 seconds until all spawned");
					ExecuteWhenOnMainStreet(combat, randomDelay, delegate
					{
						int num4 = Math.Min(5, _pendingGuards);
						_logger.Log($"Guards wave 1: Spawning {num4} guards");
						SpawnGuards(combat, num4);
						_pendingGuards -= num4;
						_logger.Log($"Guards remaining to spawn: {_pendingGuards}");
						_guardsScheduled = _pendingGuards > 0;
						if (!_guardsScheduled)
						{
							_guardsSpawnScheduledTime = null;
							_guardsSpawnDelay = 0f;
						}
					}, "GuardsWave1_Small");
				}
				else
				{
					ExecuteWhenOnMainStreet(combat, randomDelay, delegate
					{
						SpawnGuards(combat, desiredGuards);
						_guardsScheduled = false;
						_guardsSpawnScheduledTime = null;
					}, "GuardsSpawn_Large");
					_logger.Log($"Guards ({desiredGuards}) will arrive in {randomDelay:F1} seconds");
				}
			}
			else if (desiredGuards > 0 && !flag3)
			{
				_logger.Log($"Guards ({desiredGuards}) skipped - VILLAGE (only simple defenders and militia allowed)");
			}
			if (analysis?.Lords != null && analysis.Lords.Any())
			{
				_pendingLords = analysis.Lords.Count;
				_logger.Log($"Scheduling {_pendingLords} lord spawns with calculated delays");
				SpawnLordsWithCalculatedDelay(combat, analysis.Lords);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnDefenders", ex.Message, ex);
		}
	}

	private void SpawnSimpleDefenders(ActiveCombat combat, int count)
	{
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		try
		{
			_logger.Log($"SpawnSimpleDefenders called - attempting to spawn {count} simple defenders");
			if (Mission.Current == null)
			{
				_logger.Log("ERROR: No active mission when spawning simple defenders");
				return;
			}
			Settlement settlement = combat.Settlement;
			SettlementCombatLogger logger = _logger;
			TextObject name = settlement.Name;
			IFaction mapFaction = settlement.MapFaction;
			object obj;
			if (mapFaction == null)
			{
				obj = null;
			}
			else
			{
				CultureObject culture = mapFaction.Culture;
				obj = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString());
			}
			if (obj == null)
			{
				CultureObject culture2 = settlement.Culture;
				obj = ((culture2 == null) ? null : ((object)((BasicCultureObject)culture2).Name)?.ToString()) ?? "Unknown";
			}
			logger.Log($"Settlement: {name}, Culture: {obj}");
			List<CharacterObject> simpleDefenderTemplates = GetSimpleDefenderTemplates(settlement);
			if (simpleDefenderTemplates == null || !simpleDefenderTemplates.Any())
			{
				_logger.Log($"ERROR: Could not find simple defender templates for {settlement.Name}");
				return;
			}
			_logger.Log($"Found {simpleDefenderTemplates.Count} different simple defender templates for spawning");
			for (int i = 0; i < count; i++)
			{
				CharacterObject character = simpleDefenderTemplates[i % simpleDefenderTemplates.Count];
				TrySpawnDefenderWithLimit(character, combat, "SimpleDefender", onPlayerSide: false, isLocal: true);
			}
			_logger.LogDefendersSpawned("SimpleDefenders", count, ((MBObjectBase)settlement).StringId);
			_logger.Log($"Simple defenders spawn completed: {count} units spawned using {simpleDefenderTemplates.Count} different templates");
			_pendingSimpleDefenders = Math.Max(0, _pendingSimpleDefenders - count);
			TextObject val = new TextObject("{=AIInfluence_SimpleDefendersArrived}Local defenders have arrived!", (Dictionary<string, object>)null);
			MBInformationManager.AddQuickInformation(val, 3000, (BasicCharacterObject)(object)simpleDefenderTemplates[0], (Equipment)null, "");
			if (_statistics != null)
			{
				_statistics.RecordSimpleDefendersArrival(count);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnSimpleDefenders", ex.Message, ex);
		}
	}

	private void SpawnMilitia(ActiveCombat combat, int count)
	{
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		try
		{
			_logger.Log($"SpawnMilitia called - attempting to spawn {count} militia");
			if (Mission.Current == null)
			{
				_logger.Log("ERROR: No active mission when spawning militia");
				return;
			}
			Settlement settlement = combat.Settlement;
			SettlementCombatLogger logger = _logger;
			TextObject name = settlement.Name;
			IFaction mapFaction = settlement.MapFaction;
			object obj;
			if (mapFaction == null)
			{
				obj = null;
			}
			else
			{
				CultureObject culture = mapFaction.Culture;
				obj = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString());
			}
			if (obj == null)
			{
				CultureObject culture2 = settlement.Culture;
				obj = ((culture2 == null) ? null : ((object)((BasicCultureObject)culture2).Name)?.ToString()) ?? "Unknown";
			}
			logger.Log($"Settlement: {name}, Culture: {obj}");
			List<CharacterObject> militiaTemplates = GetMilitiaTemplates(settlement);
			if (militiaTemplates == null || !militiaTemplates.Any())
			{
				_logger.Log($"ERROR: Could not find militia templates for {settlement.Name}");
				return;
			}
			_logger.Log($"Found {militiaTemplates.Count} different militia templates for spawning");
			for (int i = 0; i < count; i++)
			{
				CharacterObject character = militiaTemplates[i % militiaTemplates.Count];
				TrySpawnDefenderWithLimit(character, combat, "Militia");
			}
			_logger.LogDefendersSpawned("Militia", count, ((MBObjectBase)settlement).StringId);
			_logger.Log($"Militia spawn completed: {count} units spawned using {militiaTemplates.Count} different templates");
			_pendingMilitia = Math.Max(0, _pendingMilitia - count);
			TextObject val = new TextObject("{=AIInfluence_MilitiaArrived}Militia reinforcements have arrived!", (Dictionary<string, object>)null);
			MBInformationManager.AddQuickInformation(val, 3000, (BasicCharacterObject)(object)militiaTemplates[0], (Equipment)null, "");
			if (_statistics != null)
			{
				_statistics.RecordMilitiaArrival(count);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnMilitia", ex.Message, ex);
		}
	}

	private void SpawnGuards(ActiveCombat combat, int count)
	{
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		try
		{
			if (Mission.Current == null)
			{
				_logger.Log("No active mission, cannot spawn guards");
				return;
			}
			Settlement settlement = combat.Settlement;
			bool isIndoor = combat.LocationType == LocationType.SmallIndoor;
			List<CharacterObject> guardTemplates = GetGuardTemplates(settlement, 5, isIndoor);
			if (guardTemplates == null || !guardTemplates.Any())
			{
				_logger.Log($"Could not find guard templates for {settlement.Name}");
				return;
			}
			_logger.Log($"Found {guardTemplates.Count} different guard templates for spawning");
			for (int i = 0; i < count; i++)
			{
				CharacterObject character = guardTemplates[i % guardTemplates.Count];
				TrySpawnDefenderWithLimit(character, combat, "Guard");
			}
			_logger.LogDefendersSpawned("Guards", count, ((MBObjectBase)settlement).StringId);
			_logger.Log($"Guards spawn completed: {count} units spawned using {guardTemplates.Count} different templates");
			TextObject val = new TextObject("{=AIInfluence_GuardsArrived}Elite guards have arrived to defend the settlement!", (Dictionary<string, object>)null);
			MBInformationManager.AddQuickInformation(val, 3000, (BasicCharacterObject)(object)guardTemplates[0], (Equipment)null, "");
			if (_statistics != null)
			{
				_statistics.RecordGuardsArrival(count);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnGuards", ex.Message, ex);
		}
	}

	private void SpawnLordsWithCalculatedDelay(ActiveCombat combat, List<LordIntervention> lords)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Settlement settlement = combat.Settlement;
			foreach (LordIntervention lordInfo in lords)
			{
				Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == lordInfo.StringId));
				if (val == null || val.IsDead || val.PartyBelongedTo == null)
				{
					_logger.Log("Lord " + lordInfo.StringId + " not found, dead, or has no party - skipping");
					continue;
				}
				CampaignVec2 position = val.PartyBelongedTo.Position;
				float num = (position).Distance(settlement.Position);
				if (num > 12f)
				{
					_logger.Log($"Lord {val.Name} is too far ({num:F1} units) - skipping");
					continue;
				}
				float num2 = 60f + num * 20f;
				_logger.Log($"Lord {val.Name} (id:{lordInfo.StringId}) will arrive in {num2:F0} seconds (distance: {num:F1} units)");
				_logger.Log("  - Side: " + lordInfo.Side);
				_logger.Log("  - Reason: " + lordInfo.InterventionReason);
				_logger.Log("  - Will say: \"" + lordInfo.ArrivalPhrase + "\"");
				Hero lord = val;
				LordIntervention lordInfo2 = lordInfo;
				ScheduleLordSpawn(lord, lordInfo2, combat, num2);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnLordsWithCalculatedDelay", ex.Message, ex);
		}
	}

	private void ExecuteWhenOnMainStreet(ActiveCombat combat, float delay, Action action, string taskName, Action onCancel = null, int retryCount = 0)
	{
		_behavior.GetDelayedTaskManager()?.AddTask(delay, delegate
		{
			try
			{
				if (Mission.Current == null || _currentCombat == null || _currentCombat != combat)
				{
					_logger.Log("[" + taskName + "] cancelled: mission or combat ended");
					onCancel?.Invoke();
				}
				else if (!IsPlayerOnMainStreet())
				{
					if (retryCount >= 120)
					{
						_logger.Log("[" + taskName + "] cancelled: player never returned to main street");
						onCancel?.Invoke();
					}
					else
					{
						_logger.Log($"[{taskName}] deferred: player not on main street (retry {retryCount + 1})");
						ExecuteWhenOnMainStreet(combat, 5f, action, taskName, onCancel, retryCount + 1);
					}
				}
				else
				{
					action();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(taskName, ex.Message, ex);
				onCancel?.Invoke();
			}
		});
	}

	private void ScheduleLordSpawn(Hero lord, LordIntervention lordInfo, ActiveCombat combat, float initialDelay)
	{
		Action decrementPending = delegate
		{
			if (_pendingLords > 0)
			{
				_pendingLords--;
			}
		};
		ActiveCombat combat2 = combat;
		Action action = delegate
		{
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			if (combat.Analysis == null)
			{
				SettlementCombatLogger logger = _logger;
				Hero obj2 = lord;
				logger.Log($"Lord {((obj2 != null) ? obj2.Name : null)} spawn cancelled: analysis is null");
				decrementPending();
			}
			else
			{
				SpawnLord(lord, lordInfo, combat);
				if (!string.IsNullOrEmpty(lordInfo.ArrivalPhrase))
				{
					Hero obj3 = lord;
					if (((obj3 != null) ? obj3.CharacterObject : null) != null)
					{
						TextObject val = new TextObject(lordInfo.ArrivalPhrase, (Dictionary<string, object>)null);
						MBInformationManager.AddQuickInformation(val, 4000, (BasicCharacterObject)(object)lord.CharacterObject, (Equipment)null, "");
					}
				}
				decrementPending();
				SettlementCombatLogger logger2 = _logger;
				Hero obj4 = lord;
				logger2.Log($"Lord {((obj4 != null) ? obj4.Name : null)} arrived successfully");
			}
		};
		Hero obj = lord;
		ExecuteWhenOnMainStreet(combat2, initialDelay, action, $"LordSpawn_{((obj != null) ? obj.Name : null)}", decrementPending);
	}

	private bool IsPlayerOnMainStreet()
	{
		try
		{
			Mission current = Mission.Current;
			string text = ((current == null) ? null : current.SceneName?.ToLower()) ?? "";
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (text.Contains("tavern") || text.Contains("lordshall") || text.Contains("prison") || text.Contains("dungeon") || text.Contains("arena") || (text.Contains("keep") && text.Contains("interior")))
			{
				return false;
			}
			return text.Contains("center") || text.Contains("town") || text.Contains("castle") || text.Contains("village") || text.Contains("market");
		}
		catch
		{
			return false;
		}
	}

	private void SpawnLord(Hero lord, LordIntervention lordInfo, ActiveCombat combat)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || lord == null || lordInfo == null || combat == null)
			{
				return;
			}
			if (lord.CharacterObject == null)
			{
				_logger.Log($"ERROR: Lord {lord.Name} has null CharacterObject, skipping spawn");
				return;
			}
			if (combat.Analysis == null || combat.Settlement == null)
			{
				_logger.Log($"ERROR: Combat analysis or settlement is null when spawning lord {lord.Name}");
				return;
			}
			bool flag = lordInfo.Side == "player_side";
			_logger.Log(string.Format("Spawning lord {0} on {1} side", lord.Name, flag ? "player's" : "NPC's"));
			if (lord.PartyBelongedTo != null && combat.Settlement != null)
			{
				lord.PartyBelongedTo.Position = combat.Settlement.GatePosition;
				_logger.Log($"Lord {lord.Name} teleported to {combat.Settlement.Name} on world map (position: {combat.Settlement.GatePosition})");
			}
			if (lord.PartyBelongedTo != null)
			{
				_partyToLordId[lord.PartyBelongedTo] = ((MBObjectBase)lord).StringId;
			}
			SpawnDefenderAgent(lord.CharacterObject, combat, "Lord", flag, isLocal: false, lord.PartyBelongedTo);
			int num = 0;
			if (lord.PartyBelongedTo != null)
			{
				List<CharacterObject> allLordTroops = GetAllLordTroops(lord);
				num = allLordTroops.Count;
				_logger.Log($"Lord {lord.Name} has {num} troops total");
				Queue<(CharacterObject, MobileParty)> queue = (flag ? _playerSideReserve : _enemySideReserve);
				foreach (CharacterObject item in allLordTroops)
				{
					queue.Enqueue((item, lord.PartyBelongedTo));
				}
				_logger.Log(string.Format("Added {0} troops to {1} side reserve", num, flag ? "player" : "enemy"));
				SpawnInitialTroopsForLord(combat, flag);
				_logger.LogLordSpawned(((object)lord.Name)?.ToString(), ((MBObjectBase)lord).StringId, num, ((MBObjectBase)combat.Settlement).StringId);
			}
			if (_statistics != null)
			{
				_statistics.RecordLordArrival(((MBObjectBase)lord).StringId, ((object)lord.Name)?.ToString(), flag, num);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnLord", ex.Message, ex);
		}
	}

	public void SpawnLordTroopsForHostileCompanion(Hero lord, ActiveCombat combat)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (lord == null || combat == null || Mission.Current == null)
			{
				_logger.Log("ERROR: Cannot spawn lord troops - lord, combat or mission is null");
				return;
			}
			if (lord.IsWanderer || lord.Clan == null || lord.Clan == Clan.PlayerClan)
			{
				_logger.Log($"Hero {lord.Name} is not a lord (wanderer or player clan), skipping troop summon");
				return;
			}
			List<CharacterObject> lordTroopsIncludingArmy = GetLordTroopsIncludingArmy(lord);
			if (lordTroopsIncludingArmy == null || lordTroopsIncludingArmy.Count == 0)
			{
				_logger.Log($"Lord {lord.Name} has no troops to summon");
				return;
			}
			_logger.Log($"Summoning {lordTroopsIncludingArmy.Count} troops for hostile lord {lord.Name}");
			Vec3 spawnPosition = GetSpawnPosition(Mission.Current, Agent.Main);
			SpawnDefendersAtPosition(lordTroopsIncludingArmy, combat, spawnPosition, $"Lord {lord.Name} troops", ignoreSideLimit: false, lord.PartyBelongedTo);
			_logger.Log($"Successfully summoned {lordTroopsIncludingArmy.Count} troops for hostile lord {lord.Name}");
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnLordTroopsForHostileCompanion", ex.Message, ex);
		}
	}

	public void SpawnDefenderAgentFromBoundary(CharacterObject character, ActiveCombat combat, string role, bool onPlayerSide = false, MobileParty sourceParty = null)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Mission current = Mission.Current;
			if (current == null || combat == null || combat.Analysis == null)
			{
				_logger.Log("ERROR: Mission, combat, or Analysis is NULL");
				return;
			}
			if (character == null || ((BasicCharacterObject)character).Equipment == null)
			{
				_logger.Log("ERROR: Character or Equipment is NULL for " + role);
				return;
			}
			Hero aggressor = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == combat.Analysis.AggressorStringId));
			Agent val = ((aggressor != null) ? ((IEnumerable<Agent>)current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.Character != null && (object)a.Character == aggressor.CharacterObject && a.IsActive())) : null);
			Vec3 spawnPosition = GetSpawnPosition(current, val);
			_logger.Log($"Spawning {role} from BOUNDARY at {spawnPosition}");
			Vec2 val2 = Vec2.Forward;
			if (val != null && val.IsActive())
			{
				Vec3 position = val.Position;
				Vec2 val3 = (position).AsVec2 - (spawnPosition).AsVec2;
				if ((val3).LengthSquared > 0.001f)
				{
					val2 = (val3).Normalized();
				}
			}
			Team val4 = (onPlayerSide ? current.PlayerTeam : current.DefenderTeam);
			if (val4 == null)
			{
				_logger.Log("ERROR: agentTeam is NULL");
				return;
			}
			IAgentOriginBase obj;
			if (((sourceParty != null) ? sourceParty.Party : null) == null)
			{
				IAgentOriginBase val5 = (IAgentOriginBase)new SimpleAgentOrigin((BasicCharacterObject)(object)character, -1, (Banner)null, default(UniqueTroopDescriptor));
				obj = val5;
			}
			else
			{
				IAgentOriginBase val5 = (IAgentOriginBase)new PartyAgentOrigin(sourceParty.Party, character, -1, default(UniqueTroopDescriptor), false, false);
				obj = val5;
			}
			IAgentOriginBase val6 = obj;
			bool flag = combat.LocationType == LocationType.SmallIndoor;
			AgentBuildData val7 = new AgentBuildData((BasicCharacterObject)(object)character).Team(val4).TroopOrigin(val6).InitialPosition(ref spawnPosition)
				.InitialDirection(ref val2)
				.Equipment(((BasicCharacterObject)character).Equipment)
				.NoHorses(flag)
				.ClothingColor1(val4.Color)
				.ClothingColor2(val4.Color2);
			Agent val8 = current.SpawnAgent(val7, false);
			if (val8 != null)
			{
				val8.SetWatchState((WatchState)2);
				TryEquipWeapon(val8);
				if (val != null && val8.IsAIControlled)
				{
					val8.SetLookAgent(val);
					val8.SetAgentFlags((AgentFlag)((int)val8.GetAgentFlags() | 8 | 0x10));
				}
				RegisterSpawnedAgent(val8, onPlayerSide);
				if (sourceParty != null && _partyToLordId.TryGetValue(sourceParty, out var value) && _statistics != null)
				{
					_statistics.RegisterLordTroop(val8.Index, value);
				}
				_logger.Log("Successfully spawned " + role + " from boundary: " + val8.Name);
			}
			else
			{
				_logger.Log("ERROR: SpawnAgent returned NULL for " + role);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnDefenderAgentFromBoundary", ex.Message, ex);
		}
	}

	public void SpawnDefendersAtPosition(List<CharacterObject> characters, ActiveCombat combat, Vec3 position, string rolePrefix, bool ignoreSideLimit = false, MobileParty sourceParty = null)
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (characters == null || characters.Count == 0 || Mission.Current == null || combat == null)
			{
				return;
			}
			_currentCombat = combat;
			int num = 0;
			Vec3 val2 = default(Vec3);
			for (int i = 0; i < characters.Count; i++)
			{
				CharacterObject val = characters[i];
				if (val != null)
				{
					int num2 = CountActiveTroopsOnSide(playerSide: false);
					int maxTroopsPerSide = GetMaxTroopsPerSide();
					if (!ignoreSideLimit && num2 >= maxTroopsPerSide)
					{
						_enemySideReserve.Enqueue((val, sourceParty));
						_logger.Log($"[LIMIT] {rolePrefix} added to enemy reserve (current: {num2}/{maxTroopsPerSide})");
						continue;
					}
					float num3 = (float)(_random.NextDouble() * Math.PI * 2.0);
					float num4 = (float)(_random.NextDouble() * 2.0);
					val2 = new Vec3((float)Math.Cos(num3) * num4, (float)Math.Sin(num3) * num4, 0f, -1f);
					Vec3 position2 = position + val2;
					SpawnDefenderAgentAtPosition(val, combat, position2, rolePrefix ?? "", onPlayerSide: false, sourceParty);
					num++;
				}
			}
			if (num > 0)
			{
				_logger.Log($"Spawned {num}/{characters.Count} '{rolePrefix}' at specified position (rest added to reserve if any)");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnDefendersAtPosition", ex.Message, ex);
		}
	}

	private void SpawnDefenderAgentAtPosition(CharacterObject character, ActiveCombat combat, Vec3 position, string role, bool onPlayerSide = false, MobileParty sourceParty = null)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Expected O, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Mission current = Mission.Current;
			if (current == null || character == null || combat == null)
			{
				return;
			}
			float z = position.z;
			current.Scene.GetHeightAtPoint((position).AsVec2, (BodyFlags)544321929, ref z);
			Vec3 val = default(Vec3);
			val = new Vec3(position.x, position.y, z, -1f);
			Vec3 position2;
			if (!IsSpawnPositionValid(current, val))
			{
				_logger.Log($"WARNING: Invalid spawn position for {role} at {val}, attempting fallback");
				bool flag = false;
				if (Agent.Main == null || !Agent.Main.IsActive())
				{
					_logger.Log("ERROR: Cannot find valid spawn position for " + role + " (no player), aborting spawn");
					return;
				}
				position2 = Agent.Main.Position;
				Vec2 asVec = (position2).AsVec2;
				Vec3 val3 = default(Vec3);
				for (int i = 0; i < 8; i++)
				{
					float num = (float)(_random.NextDouble() * Math.PI * 2.0);
					float num2 = 5f + (float)(_random.NextDouble() * 10.0);
					Vec2 val2 = asVec + new Vec2((float)Math.Cos(num) * num2, (float)Math.Sin(num) * num2);
					float num3 = 0f;
					current.Scene.GetHeightAtPoint(val2, (BodyFlags)544321929, ref num3);
					val3 = new Vec3(val2.x, val2.y, num3, -1f);
					if (IsSpawnPositionValid(current, val3))
					{
						val = val3;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					val = Agent.Main.Position + new Vec3(5f, 5f, 0f, -1f);
					float z2 = val.z;
					current.Scene.GetHeightAtPoint((val).AsVec2, (BodyFlags)544321929, ref z2);
					val.z = z2;
					_logger.Log("Using last-resort player-offset spawn for " + role);
				}
			}
			Agent val4 = null;
			if (combat.Analysis != null && !string.IsNullOrEmpty(combat.Analysis.AggressorStringId))
			{
				Hero aggressorHero = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == combat.Analysis.AggressorStringId));
				if (aggressorHero != null)
				{
					val4 = ((IEnumerable<Agent>)current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsActive() && a.Character != null && (object)a.Character == aggressorHero.CharacterObject));
				}
			}
			Vec2 val5 = Vec2.Forward;
			if (val4 != null && val4.IsActive())
			{
				position2 = val4.Position;
				Vec2 val6 = (position2).AsVec2 - (val).AsVec2;
				if ((val6).LengthSquared > 0.001f)
				{
					val5 = (val6).Normalized();
				}
			}
			Team val7 = (onPlayerSide ? current.PlayerTeam : current.DefenderTeam);
			if (val7 == null)
			{
				_logger.Log("ERROR: agentTeam is NULL when spawning " + role + " at position");
				return;
			}
			if (((BasicCharacterObject)character).Equipment == null)
			{
				_logger.Log($"ERROR: Character {((character != null) ? ((BasicCharacterObject)character).Name : null)} has NULL equipment");
				return;
			}
			IAgentOriginBase obj;
			if (((sourceParty != null) ? sourceParty.Party : null) == null)
			{
				IAgentOriginBase val8 = (IAgentOriginBase)new SimpleAgentOrigin((BasicCharacterObject)(object)character, -1, (Banner)null, default(UniqueTroopDescriptor));
				obj = val8;
			}
			else
			{
				IAgentOriginBase val8 = (IAgentOriginBase)new PartyAgentOrigin(sourceParty.Party, character, -1, default(UniqueTroopDescriptor), false, false);
				obj = val8;
			}
			IAgentOriginBase val9 = obj;
			bool flag2 = combat.LocationType == LocationType.SmallIndoor;
			AgentBuildData val10 = new AgentBuildData((BasicCharacterObject)(object)character).Team(val7).TroopOrigin(val9).InitialPosition(ref val)
				.InitialDirection(ref val5)
				.Equipment(((BasicCharacterObject)character).Equipment)
				.NoHorses(flag2)
				.ClothingColor1(val7.Color)
				.ClothingColor2(val7.Color2);
			Agent val11 = current.SpawnAgent(val10, false);
			if (val11 != null)
			{
				val11.SetWatchState((WatchState)2);
				TryEquipWeapon(val11);
				if (val4 != null && val11.IsAIControlled)
				{
					val11.SetLookAgent(val4);
					val11.SetAgentFlags((AgentFlag)((int)val11.GetAgentFlags() | 8 | 0x10));
				}
				RegisterSpawnedAgent(val11, onPlayerSide);
				if (sourceParty != null && _partyToLordId.TryGetValue(sourceParty, out var value) && _statistics != null)
				{
					_statistics.RegisterLordTroop(val11.Index, value);
				}
				_logger.Log("Successfully spawned " + role + " at position: " + val11.Name);
			}
			else
			{
				_logger.Log("ERROR: SpawnAgent returned NULL for " + role + " at position");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnDefenderAgentAtPosition", ex.Message, ex);
		}
	}

	private void TrySpawnDefenderWithLimit(CharacterObject character, ActiveCombat combat, string role, bool onPlayerSide = false, bool isLocal = false, MobileParty sourceParty = null)
	{
		try
		{
			int num = CountActiveTroopsOnSide(onPlayerSide);
			int maxTroopsPerSide = GetMaxTroopsPerSide();
			if (num >= maxTroopsPerSide)
			{
				Queue<(CharacterObject, MobileParty)> queue = (onPlayerSide ? _playerSideReserve : _enemySideReserve);
				queue.Enqueue((character, sourceParty));
				_logger.Log(string.Format("[LIMIT] {0} added to {1} reserve (current: {2}/{3})", role, onPlayerSide ? "player" : "enemy", num, maxTroopsPerSide));
			}
			else
			{
				SpawnDefenderAgent(character, combat, role, onPlayerSide, isLocal, sourceParty);
				if (combat.LocationType == LocationType.SmallIndoor && !onPlayerSide)
				{
					combat.DefendersSpawnedInSmallLocation++;
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("TrySpawnDefenderWithLimit", ex.Message, ex);
		}
	}

	private void SpawnDefenderAgent(CharacterObject character, ActiveCombat combat, string role, bool onPlayerSide = false, bool isLocal = false, MobileParty sourceParty = null)
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Mission current = Mission.Current;
			if (current == null)
			{
				_logger.Log("ERROR: Mission.Current is NULL when spawning " + role);
				return;
			}
			if (combat.Analysis == null)
			{
				_logger.Log("ERROR: Combat.Analysis is NULL when spawning " + role);
				return;
			}
			Hero aggressor = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == combat.Analysis.AggressorStringId));
			Agent val = null;
			if (aggressor != null)
			{
				val = ((IEnumerable<Agent>)current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.Character != null && (object)a.Character == aggressor.CharacterObject && a.IsActive()));
			}
			Vec3 val2 = Vec3.Zero;
			bool flag = false;
			Vec2 val3 = Vec2.Forward;
			bool flag2 = false;
			bool flag3 = false;
			if (combat.Settlement != null && (combat.Settlement.IsTown || combat.Settlement.IsCastle) && !string.IsNullOrEmpty(role) && role.IndexOf("lord", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				flag3 = true;
			}
			if (flag3)
			{
				if (TryGetPlayerEntranceSpawn(current, out var spawnPosition, out var forward2D))
				{
					val2 = spawnPosition;
					flag = true;
					val3 = forward2D;
					flag2 = (forward2D).LengthSquared > 0.001f;
					_logger.Log("  Using PLAYER ENTRANCE spawn (city entrance point)");
				}
				else
				{
					_logger.Log("  Player entrance spawn not found, falling back to standard logic");
				}
			}
			if (!flag && isLocal)
			{
				_logger.Log("  Using LOCAL spawn (40-80m from player)");
				val2 = GetLocalSpawnPosition(current, val);
				flag = true;
			}
			else if (!flag && combat.LocationType == LocationType.SmallIndoor)
			{
				val2 = GetEntranceSpawnPosition(current);
				flag = true;
			}
			else if (!flag)
			{
				bool flag4 = combat.Settlement != null && (combat.Settlement.IsTown || combat.Settlement.IsCastle);
				val2 = ((!(!onPlayerSide && flag4)) ? GetSpawnPosition(current, val) : GetCityGuardSpawnPosition(current, val));
			}
			if (!IsSpawnPositionValid(current, val2))
			{
				_logger.Log("WARNING: Invalid spawn position for " + role + ", attempting fallback");
				Vec3 spawnPosition2 = GetSpawnPosition(current, val);
				if (IsSpawnPositionValid(current, spawnPosition2))
				{
					val2 = spawnPosition2;
					_logger.Log("Using boundary fallback position for " + role);
				}
				else if (IsSpawnPositionValid(current, spawnPosition2, checkPathAccessibility: false, checkSlope: false))
				{
					val2 = spawnPosition2;
					_logger.Log("Using boundary fallback (no path check) for " + role);
				}
				else
				{
					if (Agent.Main == null || !Agent.Main.IsActive())
					{
						_logger.Log("ERROR: Cannot find valid spawn position for " + role + ", aborting spawn");
						return;
					}
					val2 = Agent.Main.Position + new Vec3(10f, 10f, 0f, -1f);
					float z = val2.z;
					current.Scene.GetHeightAtPoint((val2).AsVec2, (BodyFlags)544321929, ref z);
					val2.z = z;
					_logger.Log("Using emergency fallback position (player + offset) for " + role);
				}
			}
			Vec2 val4 = Vec2.Forward;
			if (val != null && val.IsActive())
			{
				Vec3 position = val.Position;
				Vec2 val5 = (position).AsVec2 - (val2).AsVec2;
				if ((val5).LengthSquared > 0.001f)
				{
					val4 = (val5).Normalized();
				}
			}
			else if (flag2 && (val3).LengthSquared > 0.001f)
			{
				val4 = (val3).Normalized();
			}
			Team val6 = (onPlayerSide ? current.PlayerTeam : current.DefenderTeam);
			if (val6 == null)
			{
				_logger.Log($"ERROR: agentTeam is NULL when spawning {role} (PlayerTeam={current.PlayerTeam != null}, DefenderTeam={current.DefenderTeam != null})");
				return;
			}
			if (((BasicCharacterObject)character).Equipment == null)
			{
				_logger.Log($"ERROR: Character {((BasicCharacterObject)character).Name} has NULL equipment");
				return;
			}
			IAgentOriginBase obj;
			if (((sourceParty != null) ? sourceParty.Party : null) == null)
			{
				IAgentOriginBase val7 = (IAgentOriginBase)new SimpleAgentOrigin((BasicCharacterObject)(object)character, -1, (Banner)null, default(UniqueTroopDescriptor));
				obj = val7;
			}
			else
			{
				IAgentOriginBase val7 = (IAgentOriginBase)new PartyAgentOrigin(sourceParty.Party, character, -1, default(UniqueTroopDescriptor), false, false);
				obj = val7;
			}
			IAgentOriginBase val8 = obj;
			bool flag5 = combat.LocationType == LocationType.SmallIndoor;
			AgentBuildData val9 = new AgentBuildData((BasicCharacterObject)(object)character).Team(val6).TroopOrigin(val8).InitialPosition(ref val2)
				.InitialDirection(ref val4)
				.Equipment(((BasicCharacterObject)character).Equipment)
				.NoHorses(flag5)
				.ClothingColor1(val6.Color)
				.ClothingColor2(val6.Color2);
			Agent val10 = current.SpawnAgent(val9, false);
			if (val10 != null)
			{
				val10.SetWatchState((WatchState)2);
				TryEquipWeapon(val10);
				if (val != null && val10.IsAIControlled)
				{
					val10.SetLookAgent(val);
					val10.SetAgentFlags((AgentFlag)((int)val10.GetAgentFlags() | 8 | 0x10));
				}
				RegisterSpawnedAgent(val10, onPlayerSide);
				if (sourceParty != null && _partyToLordId.TryGetValue(sourceParty, out var value) && _statistics != null)
				{
					_statistics.RegisterLordTroop(val10.Index, value);
				}
			}
			else
			{
				_logger.Log("ERROR: SpawnAgent returned NULL for " + role);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnDefenderAgent", ex.Message, ex);
		}
	}

	private bool TryGetPlayerEntranceSpawn(Mission mission, out Vec3 spawnPosition, out Vec2 forward2D)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		spawnPosition = Vec3.Zero;
		forward2D = Vec2.Forward;
		try
		{
			if (mission == null || (NativeObject)(object)mission.Scene == (NativeObject)null)
			{
				return false;
			}
			GameEntity val = mission.Scene.FindEntityWithTag("spawnpoint_player_outside");
			if (val == (GameEntity)null)
			{
				val = mission.Scene.FindEntityWithTag("sp_player_conversation");
			}
			if (val == (GameEntity)null)
			{
				string[] mAIN_GATE_SPAWN_TAGS = MAIN_GATE_SPAWN_TAGS;
				foreach (string text in mAIN_GATE_SPAWN_TAGS)
				{
					val = mission.Scene.FindEntityWithTag(text);
					if (val != (GameEntity)null)
					{
						break;
					}
				}
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
			float num = 25f;
			for (int j = 0; j < 3; j++)
			{
				float num2 = (float)(_random.NextDouble() * 8.0) - 4f;
				Vec3 val3 = globalFrame.origin - val2 * num + s * num2;
				float z = val3.z;
				mission.Scene.GetHeightAtPoint((val3).AsVec2, (BodyFlags)544321929, ref z);
				val3.z = z;
				if (IsSpawnPositionValid(mission, val3, checkPathAccessibility: false))
				{
					spawnPosition = val3;
					forward2D = new Vec2(val2.x, val2.y);
					return true;
				}
			}
			_logger.Log("Warning: Could not find valid entrance spawn position, using first attempt");
			float num3 = 0f;
			Vec3 val4 = globalFrame.origin - val2 * num + s * num3;
			float z2 = val4.z;
			mission.Scene.GetHeightAtPoint((val4).AsVec2, (BodyFlags)544321929, ref z2);
			val4.z = z2;
			spawnPosition = val4;
			forward2D = new Vec2(val2.x, val2.y);
			return true;
		}
		catch (Exception ex)
		{
			_logger.LogError("TryGetMainGateSpawnPosition", ex.Message, ex);
			return false;
		}
	}

	private List<CharacterObject> GetSimpleDefenderTemplates(Settlement settlement, int maxVariants = 5)
	{
		IFaction mapFaction = settlement.MapFaction;
		CultureObject culture = ((mapFaction != null) ? mapFaction.Culture : null) ?? settlement.Culture;
		if (culture == null)
		{
			_logger.Log($"ERROR: No culture found for simple defenders in {settlement.Name}");
			return new List<CharacterObject>();
		}
		_logger.Log($"Looking for simple defender templates (1-2 tier) with culture: {((BasicCultureObject)culture).Name}");
		List<CharacterObject> list = ((IEnumerable<CharacterObject>)MBObjectManager.Instance.GetObjectTypeList<CharacterObject>()).Where((CharacterObject c) => c.Culture == culture && (int)c.Occupation == 7 && c.Tier >= 1 && c.Tier <= 2 && !((BasicCharacterObject)c).IsHero && !((BasicCharacterObject)c).IsMounted).Take(maxVariants).ToList();
		if (list.Any())
		{
			_logger.Log($"Found {list.Count} simple defender variants");
			foreach (CharacterObject item in list)
			{
				_logger.Log($"  - {((BasicCharacterObject)item).Name} (Tier {item.Tier})");
			}
		}
		else
		{
			_logger.Log($"WARNING: No simple defenders found for culture {((BasicCultureObject)culture).Name}");
		}
		return list;
	}

	private List<CharacterObject> GetMilitiaTemplates(Settlement settlement, int maxVariants = 5)
	{
		IFaction mapFaction = settlement.MapFaction;
		CultureObject val = ((mapFaction != null) ? mapFaction.Culture : null) ?? settlement.Culture;
		if (val == null)
		{
			_logger.Log($"ERROR: No culture found for {settlement.Name}");
			return new List<CharacterObject>();
		}
		_logger.Log($"Looking for militia templates with culture: {((BasicCultureObject)val).Name}");
		List<CharacterObject> list = new List<CharacterObject>();
		if (val.MeleeMilitiaTroop != null)
		{
			list.Add(val.MeleeMilitiaTroop);
			_logger.Log($"  - Added MeleeMilitiaTroop: {((BasicCharacterObject)val.MeleeMilitiaTroop).Name}");
		}
		if (val.MeleeEliteMilitiaTroop != null)
		{
			list.Add(val.MeleeEliteMilitiaTroop);
			_logger.Log($"  - Added MeleeEliteMilitiaTroop: {((BasicCharacterObject)val.MeleeEliteMilitiaTroop).Name}");
		}
		if (val.RangedMilitiaTroop != null)
		{
			list.Add(val.RangedMilitiaTroop);
			_logger.Log($"  - Added RangedMilitiaTroop: {((BasicCharacterObject)val.RangedMilitiaTroop).Name}");
		}
		if (val.RangedEliteMilitiaTroop != null)
		{
			list.Add(val.RangedEliteMilitiaTroop);
			_logger.Log($"  - Added RangedEliteMilitiaTroop: {((BasicCharacterObject)val.RangedEliteMilitiaTroop).Name}");
		}
		if (list.Any())
		{
			_logger.Log($"Found {list.Count} militia templates for culture {((BasicCultureObject)val).Name}");
		}
		else
		{
			_logger.Log($"WARNING: No militia templates found for culture {((BasicCultureObject)val).Name} (all fields are null)");
		}
		return list;
	}

	private List<CharacterObject> GetGuardTemplates(Settlement settlement, int maxVariants = 5, bool isIndoor = false)
	{
		List<CharacterObject> list = new List<CharacterObject>();
		try
		{
			Town town = settlement.Town;
			MobileParty val = ((town != null) ? ((Fief)town).GarrisonParty : null);
			if (((val != null) ? val.MemberRoster : null) != null && val.MemberRoster.Count > 0)
			{
				_logger.Log(string.Format("Selecting guard templates from garrison roster of {0}{1}", settlement.Name, isIndoor ? " (INDOOR: no cavalry/archers)" : ""));
				var list2 = (from e in (IEnumerable<TroopRosterElement>)val.MemberRoster.GetTroopRoster()
					where e.Character != null && !((BasicCharacterObject)e.Character).IsHero && (e).Number > 0
					where !isIndoor || (!((BasicCharacterObject)e.Character).IsMounted && !((BasicCharacterObject)e.Character).IsRanged)
					select new
					{
						Character = e.Character,
						Count = (e).Number
					}).ToList();
				if (list2.Count > 0)
				{
					var list3 = (from c in list2
						orderby c.Character.Tier descending, c.Count descending
						select c).ThenBy(_ => _random.NextDouble()).ToList();
					foreach (var entry in list3)
					{
						if (!list.Any((CharacterObject ch) => ch == entry.Character))
						{
							list.Add(entry.Character);
							_logger.Log($"  [Garrison] {((BasicCharacterObject)entry.Character).Name} (Tier {entry.Character.Tier}, Count {entry.Count}) added to guard pool");
							if (list.Count >= maxVariants)
							{
								break;
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("GetGuardTemplates(Garrison)", ex.Message, ex);
		}
		if (list.Count >= maxVariants)
		{
			return list;
		}
		IFaction mapFaction = settlement.MapFaction;
		CultureObject culture = ((mapFaction != null) ? mapFaction.Culture : null) ?? settlement.Culture;
		if (culture == null)
		{
			_logger.Log($"ERROR: No culture found for guards in {settlement.Name}");
			return list;
		}
		if (list.Count > 0)
		{
			_logger.Log($"Guard pool lacks variety ({list.Count}/{maxVariants}); filling with cultural templates (Tier 4-6)");
		}
		else
		{
			_logger.Log("Garrison roster empty or unsuitable. Falling back to cultural templates (Tier 4-6)");
		}
		List<CharacterObject> list4 = (from c in (IEnumerable<CharacterObject>)MBObjectManager.Instance.GetObjectTypeList<CharacterObject>()
			where c.Culture == culture && (int)c.Occupation == 7 && c.Tier >= 4 && c.Tier <= 6 && !((BasicCharacterObject)c).IsHero && (!isIndoor || (!((BasicCharacterObject)c).IsMounted && !((BasicCharacterObject)c).IsRanged))
			orderby c.Tier descending
			select c).ThenBy((CharacterObject _) => _random.NextDouble()).ToList();
		foreach (CharacterObject troop in list4)
		{
			if (!list.Any((CharacterObject ch) => ch == troop))
			{
				list.Add(troop);
				_logger.Log($"  [Fallback] {((BasicCharacterObject)troop).Name} (Tier {troop.Tier}) added to guard pool");
				if (list.Count >= maxVariants)
				{
					break;
				}
			}
		}
		if (list.Count == 0)
		{
			if (isIndoor)
			{
				_logger.Log("WARNING: No infantry guards found for indoor location, retrying without filter");
				return GetGuardTemplates(settlement, maxVariants);
			}
			_logger.Log($"WARNING: No guards found for culture {((BasicCultureObject)culture).Name}");
		}
		return list;
	}

	private List<CharacterObject> GetAllLordTroops(Hero lord)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		List<CharacterObject> list = new List<CharacterObject>();
		MobileParty partyBelongedTo = lord.PartyBelongedTo;
		if (((partyBelongedTo != null) ? partyBelongedTo.MemberRoster : null) == null)
		{
			return list;
		}
		TroopRoster memberRoster = lord.PartyBelongedTo.MemberRoster;
		foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)memberRoster.GetTroopRoster())
		{
			TroopRosterElement current = item;
			if (current.Character != null && !((BasicCharacterObject)current.Character).IsHero)
			{
				for (int i = 0; i < (current).Number; i++)
				{
					list.Add(current.Character);
				}
			}
		}
		return ArrangeTroopsByTierAndRole(list);
	}

	public List<CharacterObject> GetLordTroopsIncludingArmy(Hero lord)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		List<CharacterObject> list = new List<CharacterObject>();
		try
		{
			if (lord == null)
			{
				return list;
			}
			MobileParty partyBelongedTo = lord.PartyBelongedTo;
			if (((partyBelongedTo != null) ? partyBelongedTo.MemberRoster : null) != null)
			{
				TroopRoster memberRoster = lord.PartyBelongedTo.MemberRoster;
				foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)memberRoster.GetTroopRoster())
				{
					TroopRosterElement current = item;
					if (current.Character != null && !((BasicCharacterObject)current.Character).IsHero)
					{
						for (int i = 0; i < (current).Number; i++)
						{
							list.Add(current.Character);
						}
					}
				}
			}
			if (lord.PartyBelongedTo != null && lord.PartyBelongedTo.Army != null)
			{
				Army army = lord.PartyBelongedTo.Army;
				if (army.LeaderParty == lord.PartyBelongedTo)
				{
					_logger.Log($"Lord {lord.Name} is army leader, getting troops from all army parties");
					foreach (MobileParty item2 in (List<MobileParty>)(object)army.Parties)
					{
						if (item2 == null || item2.MemberRoster == null || item2 == lord.PartyBelongedTo)
						{
							continue;
						}
						TroopRoster memberRoster2 = item2.MemberRoster;
						foreach (TroopRosterElement item3 in (List<TroopRosterElement>)(object)memberRoster2.GetTroopRoster())
						{
							TroopRosterElement current3 = item3;
							if (current3.Character != null && !((BasicCharacterObject)current3.Character).IsHero)
							{
								for (int j = 0; j < (current3).Number; j++)
								{
									list.Add(current3.Character);
								}
							}
						}
					}
				}
			}
			_logger.Log($"Total troops for lord {lord.Name}: {list.Count}");
			return ArrangeTroopsByTierAndRole(list);
		}
		catch (Exception ex)
		{
			_logger.LogError("GetLordTroopsIncludingArmy", ex.Message, ex);
			return list;
		}
	}

	private List<CharacterObject> ArrangeTroopsByTierAndRole(List<CharacterObject> troops)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		if (troops == null || troops.Count <= 1)
		{
			return troops ?? new List<CharacterObject>();
		}
		Dictionary<FormationClass, List<CharacterObject>> dictionary = new Dictionary<FormationClass, List<CharacterObject>>();
		foreach (CharacterObject troop in troops)
		{
			FormationClass key = DetermineFormationClass(troop);
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = (dictionary[key] = new List<CharacterObject>());
			}
			value.Add(troop);
		}
		List<FormationClass> list2 = dictionary.Keys.OrderBy((FormationClass f) => (int)f).ToList();
		foreach (FormationClass item in list2)
		{
			List<CharacterObject> value2 = dictionary[item].OrderByDescending((CharacterObject t) => t.Tier).ThenBy((CharacterObject _) => _random.NextDouble()).ToList();
			dictionary[item] = value2;
		}
		List<CharacterObject> list3 = new List<CharacterObject>(troops.Count);
		FormationClass val = (FormationClass)8;
		int num = 0;
		while (dictionary.Values.Any((List<CharacterObject> l) => l.Count > 0))
		{
			CharacterObject val2 = null;
			FormationClass val3 = (FormationClass)8;
			float num2 = float.MinValue;
			foreach (FormationClass item2 in list2)
			{
				List<CharacterObject> value3;
				List<CharacterObject> list4 = (dictionary.TryGetValue(item2, out value3) ? value3 : null);
				if (list4 != null && list4.Count != 0)
				{
					CharacterObject val4 = list4[0];
					float num3 = (float)val4.Tier + (float)_random.NextDouble() * 0.25f;
					if (item2 == val && num >= 2)
					{
						num3 -= 2f;
					}
					if (num3 > num2)
					{
						num2 = num3;
						val2 = val4;
						val3 = item2;
					}
				}
			}
			if (val2 == null)
			{
				break;
			}
			dictionary[val3].RemoveAt(0);
			list3.Add(val2);
			if (val3 == val)
			{
				num++;
				continue;
			}
			val = val3;
			num = 1;
		}
		return list3;
	}

	private FormationClass DetermineFormationClass(CharacterObject character)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (character == null)
		{
			return (FormationClass)0;
		}
		if (((BasicCharacterObject)character).IsMounted)
		{
			return (FormationClass)(((BasicCharacterObject)character).IsRanged ? 3 : 2);
		}
		return (FormationClass)(((BasicCharacterObject)character).IsRanged ? 1 : 0);
	}

	private void SpawnInitialTroopsForLord(ActiveCombat combat, bool onPlayerSide)
	{
		try
		{
			Queue<(CharacterObject, MobileParty)> queue = (onPlayerSide ? _playerSideReserve : _enemySideReserve);
			int num = 0;
			int num2 = CountActiveTroopsOnSide(onPlayerSide);
			int maxTroopsPerSide = GetMaxTroopsPerSide();
			while (queue.Count > 0 && num2 < maxTroopsPerSide)
			{
				var (character, sourceParty) = queue.Dequeue();
				SpawnDefenderAgent(character, combat, "Lord's Troop", onPlayerSide, isLocal: false, sourceParty);
				num++;
				num2++;
			}
			_logger.Log(string.Format("Spawned {0} initial troops for lord on {1} side. Remaining in reserve: {2}", num, onPlayerSide ? "player" : "enemy", queue.Count));
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnInitialTroopsForLord", ex.Message, ex);
		}
	}

	private void CheckAndSpawnReinforcements()
	{
		try
		{
			if (_currentCombat != null && Mission.Current != null)
			{
				_logger.Log("=== Checking for reinforcements ===");
				CheckAndSpawnForSide(playerSide: true);
				CheckAndSpawnForSide(playerSide: false);
				if (_currentCombat != null && _currentCombat.LocationType == LocationType.SmallIndoor && _pendingGuards > 0)
				{
					int num = Math.Min(5, _pendingGuards);
					_logger.Log("=== GUARDS WAVE SPAWN ===");
					_logger.Log($"  Pending guards: {_pendingGuards}");
					_logger.Log($"  Spawning next wave: {num} guards");
					SpawnGuards(_currentCombat, num);
					_pendingGuards -= num;
					_logger.Log($"  Guards remaining: {_pendingGuards}");
					_guardsScheduled = _pendingGuards > 0;
				}
				CheckAndClearPendingCounters();
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CheckAndSpawnReinforcements", ex.Message, ex);
		}
	}

	private void CheckAndClearPendingCounters()
	{
		try
		{
			if (_playerSideReserve.Count == 0 && _enemySideReserve.Count == 0)
			{
				if (_pendingSimpleDefenders > 0 && !_simpleDefendersScheduled)
				{
					_logger.Log($"All simple defenders fully spawned (pending was: {_pendingSimpleDefenders}), clearing counter");
					_pendingSimpleDefenders = 0;
				}
				if (_pendingMilitia > 0 && !_militiaScheduled)
				{
					_logger.Log($"All militia fully spawned (pending was: {_pendingMilitia}), clearing counter");
					_pendingMilitia = 0;
				}
				if (_pendingGuards > 0 && !_guardsScheduled)
				{
					_logger.Log($"All guards fully spawned (pending was: {_pendingGuards}), clearing counter");
					_pendingGuards = 0;
					_guardsSpawnScheduledTime = null;
					_guardsSpawnDelay = 0f;
				}
			}
			else
			{
				_logger.Log($"Reserves not empty yet: Player={_playerSideReserve.Count}, Enemy={_enemySideReserve.Count} - keeping pending counters active");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CheckAndClearPendingCounters", ex.Message, ex);
		}
	}

	private void CheckAndSpawnForSide(bool playerSide)
	{
		try
		{
			Queue<(CharacterObject, MobileParty)> queue = (playerSide ? _playerSideReserve : _enemySideReserve);
			if (queue.Count == 0)
			{
				return;
			}
			int num = CountActiveTroopsOnSide(playerSide);
			int maxTroopsPerSide = GetMaxTroopsPerSide();
			int num2 = maxTroopsPerSide - num;
			if (num2 > 0)
			{
				_logger.Log(string.Format("[{0} SIDE] Current: {1}, Reserve: {2}, Available slots: {3}", playerSide ? "PLAYER" : "ENEMY", num, queue.Count, num2));
				int num3 = 0;
				while (queue.Count > 0 && num3 < num2)
				{
					var (character, sourceParty) = queue.Dequeue();
					SpawnDefenderAgent(character, _currentCombat, "Reinforcement", playerSide, isLocal: false, sourceParty);
					num3++;
				}
				_logger.Log(string.Format("Spawned {0} reinforcements for {1} side", num3, playerSide ? "player" : "enemy"));
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CheckAndSpawnForSide", ex.Message, ex);
		}
	}

	private int CountActiveTroopsOnSide(bool playerSide)
	{
		try
		{
			if (Mission.Current == null)
			{
				return 0;
			}
			Team val = (playerSide ? Mission.Current.PlayerTeam : Mission.Current.DefenderTeam);
			if (val == null)
			{
				return 0;
			}
			HashSet<int> hashSet = (playerSide ? _spawnedPlayerAgents : _spawnedEnemyAgents);
			if (hashSet.Count == 0)
			{
				return 0;
			}
			HashSet<int> aliveIndices = new HashSet<int>();
			int num = 0;
			foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
			{
				if (item != null && item.IsActive() && item.IsHuman && item.Team == val && hashSet.Contains(item.Index))
				{
					num++;
					aliveIndices.Add(item.Index);
				}
			}
			if (aliveIndices.Count != hashSet.Count)
			{
				hashSet.RemoveWhere((int index) => !aliveIndices.Contains(index));
			}
			return num;
		}
		catch
		{
			return 0;
		}
	}

	private Vec3 GetLocalSpawnPosition(Mission mission, Agent targetAgent)
	{
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Vec3 position;
			Vec2 asVec = default(Vec2);
			if (Agent.Main != null)
			{
				position = Agent.Main.Position;
				asVec = (position).AsVec2;
			}
			else if (targetAgent != null)
			{
				position = targetAgent.Position;
				asVec = (position).AsVec2;
			}
			else
			{
				asVec = new Vec2(0f, 0f);
			}
			Vec2 val = default(Vec2);
			Vec3 val3 = default(Vec3);
			for (int i = 0; i < 15; i++)
			{
				float num = (float)(_random.NextDouble() * Math.PI * 2.0);
				float num2 = Math.Max(10f, 40f - (float)i * 3f);
				float num3 = Math.Max(30f, 80f - (float)i * 5f);
				float num4 = num2 + (float)(_random.NextDouble() * (double)(num3 - num2));
				val = new Vec2((float)Math.Cos(num) * num4, (float)Math.Sin(num) * num4);
				Vec2 val2 = asVec + val;
				float num5 = 0f;
				mission.Scene.GetHeightAtPoint(val2, (BodyFlags)544321929, ref num5);
				val3 = new Vec3(val2.x, val2.y, num5, -1f);
				if (IsSpawnPositionValid(mission, val3))
				{
					return val3;
				}
			}
			_logger.Log("Warning: Could not find valid local spawn position after 15 attempts, trying near-player fallback");
			if (Agent.Main != null && Agent.Main.IsActive())
			{
				Vec3 val5 = default(Vec3);
				for (int j = 0; j < 8; j++)
				{
					float num6 = (float)(_random.NextDouble() * Math.PI * 2.0);
					float num7 = 8f + (float)(_random.NextDouble() * 15.0);
					Vec2 val4 = asVec + new Vec2((float)Math.Cos(num6) * num7, (float)Math.Sin(num6) * num7);
					float num8 = 0f;
					mission.Scene.GetHeightAtPoint(val4, (BodyFlags)544321929, ref num8);
					val5 = new Vec3(val4.x, val4.y, num8, -1f);
					if (IsSpawnPositionValid(mission, val5))
					{
						_logger.Log($"Using near-player fallback spawn at {val5}");
						return val5;
					}
				}
				Vec3 val6 = Agent.Main.Position + new Vec3(5f, 5f, 0f, -1f);
				float z = val6.z;
				mission.Scene.GetHeightAtPoint((val6).AsVec2, (BodyFlags)544321929, ref z);
				return new Vec3(val6.x, val6.y, z, -1f);
			}
			return new Vec3(0f, 0f, 0f, -1f);
		}
		catch (Exception ex)
		{
			_logger.LogError("GetLocalSpawnPosition", ex.Message, ex);
			if (Agent.Main != null)
			{
				return Agent.Main.Position + new Vec3(15f, 0f, 0f, -1f);
			}
			return new Vec3(0f, 0f, 0f, -1f);
		}
	}

	private Vec3 GetEntranceSpawnPosition(Mission mission)
	{
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (mission == null || (NativeObject)(object)mission.Scene == (NativeObject)null)
			{
				return Vec3.Zero;
			}
			List<GameEntity> list = mission.Scene.FindEntitiesWithTag("sp_player_conversation").ToList();
			if (list != null && list.Count > 0)
			{
				foreach (GameEntity item in list)
				{
					if (!(item == (GameEntity)null) && !item.IsGhostObject())
					{
						MatrixFrame globalFrame = item.GetGlobalFrame();
						Vec3 origin = globalFrame.origin;
						float z = origin.z;
						mission.Scene.GetHeightAtPoint((origin).AsVec2, (BodyFlags)544321929, ref z);
						origin.z = z;
						if (IsSpawnPositionValid(mission, origin, checkPathAccessibility: false))
						{
							_logger.Log($"Using sp_player_conversation spawn point: {origin}");
							return origin;
						}
					}
				}
				_logger.Log("Warning: No valid sp_player_conversation spawn point found, using first available");
				GameEntity val = ((IEnumerable<GameEntity>)list).FirstOrDefault((Func<GameEntity, bool>)((GameEntity e) => e != (GameEntity)null && !e.IsGhostObject())) ?? list.First();
				MatrixFrame globalFrame2 = val.GetGlobalFrame();
				Vec3 origin2 = globalFrame2.origin;
				float z2 = origin2.z;
				mission.Scene.GetHeightAtPoint((origin2).AsVec2, (BodyFlags)544321929, ref z2);
				origin2.z = z2;
				return origin2;
			}
			_logger.Log("sp_player_conversation not found, using fallback");
			if (Agent.Main != null && Agent.Main.IsActive())
			{
				return Agent.Main.Position + new Vec3(5f, 5f, 0f, -1f);
			}
			return Vec3.Zero;
		}
		catch (Exception ex)
		{
			_logger.LogError("GetEntranceSpawnPosition", ex.Message, ex);
			Agent main = Agent.Main;
			return (main != null) ? main.Position : Vec3.Zero;
		}
	}

	private int CalculateVillageDefenderCount(Settlement settlement)
	{
		try
		{
			if (settlement == null)
			{
				return 0;
			}
			int num = 0;
			MilitiaPartyComponent militiaPartyComponent = settlement.MilitiaPartyComponent;
			object obj;
			if (militiaPartyComponent == null)
			{
				obj = null;
			}
			else
			{
				MobileParty mobileParty = ((PartyComponent)militiaPartyComponent).MobileParty;
				obj = ((mobileParty != null) ? mobileParty.MemberRoster : null);
			}
			TroopRoster val = (TroopRoster)obj;
			if (val != null)
			{
				num = val.TotalRegulars;
			}
			if (num <= 0 && settlement.Militia > 0f)
			{
				num = (int)Math.Round(settlement.Militia, MidpointRounding.AwayFromZero);
			}
			num = Math.Max(0, num);
			string arg = ((settlement == null) ? null : ((object)settlement.Name)?.ToString()) ?? "Unknown";
			_logger.Log($"Calculated village defender count for {arg}: {num}");
			return num;
		}
		catch (Exception ex)
		{
			_logger.LogError("CalculateVillageDefenderCount", ex.Message, ex);
			return 0;
		}
	}

	private int CalculateCityGuardCount(Settlement settlement)
	{
		try
		{
			if (settlement == null)
			{
				return 0;
			}
			int num = 0;
			Town town = settlement.Town;
			object obj;
			if (town == null)
			{
				obj = null;
			}
			else
			{
				MobileParty garrisonParty = ((Fief)town).GarrisonParty;
				obj = ((garrisonParty != null) ? garrisonParty.MemberRoster : null);
			}
			TroopRoster val = (TroopRoster)obj;
			if (val != null)
			{
				num = val.TotalRegulars;
			}
			if (num <= 0)
			{
				MilitiaPartyComponent militiaPartyComponent = settlement.MilitiaPartyComponent;
				object obj2;
				if (militiaPartyComponent == null)
				{
					obj2 = null;
				}
				else
				{
					MobileParty mobileParty = ((PartyComponent)militiaPartyComponent).MobileParty;
					obj2 = ((mobileParty != null) ? mobileParty.MemberRoster : null);
				}
				TroopRoster val2 = (TroopRoster)obj2;
				if (val2 != null)
				{
					num = val2.TotalRegulars;
				}
			}
			if (num <= 0 && settlement.Militia > 0f)
			{
				num = (int)Math.Round(settlement.Militia, MidpointRounding.AwayFromZero);
			}
			num = Math.Max(0, num);
			string arg = ((settlement == null) ? null : ((object)settlement.Name)?.ToString()) ?? "Unknown";
			_logger.Log($"Calculated city guard count for {arg}: {num}");
			return num;
		}
		catch (Exception ex)
		{
			_logger.LogError("CalculateCityGuardCount", ex.Message, ex);
			return 0;
		}
	}

	private void EnsureCityGuardSpawnPointsCached(Mission mission)
	{
		try
		{
			if (mission == null || (NativeObject)(object)mission.Scene == (NativeObject)null || (_cachedMissionForCitySpawnPoints == mission && _cachedCityGuardSpawnPoints.Count > 0))
			{
				return;
			}
			_cachedMissionForCitySpawnPoints = mission;
			_cachedCityGuardSpawnPoints.Clear();
			string[] cITY_GUARD_SPAWN_TAGS = CITY_GUARD_SPAWN_TAGS;
			foreach (string text in cITY_GUARD_SPAWN_TAGS)
			{
				try
				{
					IEnumerable<GameEntity> enumerable = mission.Scene.FindEntitiesWithTag(text);
					if (enumerable == null)
					{
						continue;
					}
					foreach (GameEntity item in enumerable)
					{
						if (!(item == (GameEntity)null) && !item.IsGhostObject() && !_cachedCityGuardSpawnPoints.Contains(item))
						{
							_cachedCityGuardSpawnPoints.Add(item);
						}
					}
				}
				catch (Exception ex)
				{
					_logger.LogError("EnsureCityGuardSpawnPointsCached", "Error while caching tag '" + text + "': " + ex.Message, ex);
				}
			}
			_logger.Log($"City guard spawn points cached: {_cachedCityGuardSpawnPoints.Count}");
		}
		catch (Exception ex2)
		{
			_logger.LogError("EnsureCityGuardSpawnPointsCached", ex2.Message, ex2);
		}
	}

	private Vec3 GetCityGuardSpawnPosition(Mission mission, Agent targetAgent)
	{
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			EnsureCityGuardSpawnPointsCached(mission);
			if (_cachedCityGuardSpawnPoints.Count == 0)
			{
				_logger.Log("No cached city guard spawn points found, falling back to boundary spawn");
				return GetSpawnPosition(mission, targetAgent);
			}
			bool flag = Agent.Main != null && Agent.Main.IsActive();
			Vec2 val;
			if (!flag)
			{
				val = Vec2.Zero;
			}
			else
			{
				Vec3 position = Agent.Main.Position;
				val = (position).AsVec2;
			}
			Vec2 val2 = val;
			List<GameEntity> list = new List<GameEntity>();
			Vec2 val3;
			foreach (GameEntity cachedCityGuardSpawnPoint in _cachedCityGuardSpawnPoints)
			{
				if (cachedCityGuardSpawnPoint == (GameEntity)null)
				{
					continue;
				}
				Vec3 globalPosition = cachedCityGuardSpawnPoint.GlobalPosition;
				if (flag)
				{
					val3 = (globalPosition).AsVec2 - val2;
					float length = (val3).Length;
					if (length < 70f)
					{
						continue;
					}
				}
				list.Add(cachedCityGuardSpawnPoint);
			}
			if (list.Count == 0)
			{
				_logger.Log($"No city guard spawn points farther than {70f}m from player. Using full cached list as fallback.");
				list = _cachedCityGuardSpawnPoints.Where((GameEntity e) => e != (GameEntity)null).ToList();
			}
			if (list.Count == 0)
			{
				_logger.Log("City guard spawn fallback failed, using boundary spawn");
				return GetSpawnPosition(mission, targetAgent);
			}
			Vec2 val5 = default(Vec2);
			Vec3 val7 = default(Vec3);
			for (int num = 0; num < 5; num++)
			{
				GameEntity val4 = list[_random.Next(list.Count)];
				Vec3 globalPosition2 = val4.GlobalPosition;
				float num2 = (float)(_random.NextDouble() * Math.PI * 2.0);
				float num3 = (float)(_random.NextDouble() * 2.0);
				val5 = new Vec2((float)Math.Cos(num2) * num3, (float)Math.Sin(num2) * num3);
				Vec2 val6 = (globalPosition2).AsVec2 + val5;
				float z = globalPosition2.z;
				mission.Scene.GetHeightAtPoint(val6, (BodyFlags)544321929, ref z);
				val7 = new Vec3(val6.x, val6.y, z, -1f);
				if (IsSpawnPositionValid(mission, val7, checkPathAccessibility: false))
				{
					string arg = "N/A";
					if (flag)
					{
						val3 = val6 - val2;
						arg = (val3).Length.ToString("F1");
					}
					_logger.Log($"Selected city guard spawn: {val4.Name} at {val7} (distance to player: {arg}m)");
					return val7;
				}
			}
			_logger.Log("Warning: Could not find valid city guard spawn position after 5 attempts, using first available");
			GameEntity val8 = list[0];
			Vec3 globalPosition3 = val8.GlobalPosition;
			float z2 = globalPosition3.z;
			mission.Scene.GetHeightAtPoint((globalPosition3).AsVec2, (BodyFlags)544321929, ref z2);
			return new Vec3(globalPosition3.x, globalPosition3.y, z2, -1f);
		}
		catch (Exception ex)
		{
			_logger.LogError("GetCityGuardSpawnPosition", ex.Message, ex);
			return GetSpawnPosition(mission, targetAgent);
		}
	}

	private Vec3 GetSpawnPosition(Mission mission, Agent targetAgent)
	{
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Vec3 position;
			Vec2 asVec = default(Vec2);
			if (Agent.Main != null)
			{
				position = Agent.Main.Position;
				asVec = (position).AsVec2;
			}
			else if (targetAgent != null)
			{
				position = targetAgent.Position;
				asVec = (position).AsVec2;
			}
			else
			{
				asVec = new Vec2(0f, 0f);
			}
			Vec2 val = default(Vec2);
			Vec3 val6 = default(Vec3);
			for (int i = 0; i < 10; i++)
			{
				float num = (float)(_random.NextDouble() * Math.PI * 2.0);
				float num2 = 30f;
				val = new Vec2((float)Math.Cos(num) * num2, (float)Math.Sin(num) * num2);
				Vec2 val2 = asVec + val;
				Vec2 closestBoundaryPosition = mission.GetClosestBoundaryPosition(val2);
				Vec2 val3 = asVec - closestBoundaryPosition;
				Vec2 val4 = (val3).Normalized();
				float num3 = 5f + (float)(_random.NextDouble() * 5.0);
				Vec2 val5 = closestBoundaryPosition + val4 * num3;
				float num4 = 0f;
				mission.Scene.GetHeightAtPoint(val5, (BodyFlags)544321929, ref num4);
				val6 = new Vec3(val5.x, val5.y, num4, -1f);
				if (IsSpawnPositionValid(mission, val6))
				{
					return val6;
				}
			}
			_logger.Log("Warning: Could not find flat spawn position after 10 attempts");
			Vec2 val7 = default(Vec2);
			val7 = new Vec2(1f, 0f);
			Vec2 val8 = asVec + val7 * 20f;
			float num5 = 0f;
			mission.Scene.GetHeightAtPoint(val8, (BodyFlags)544321929, ref num5);
			return new Vec3(val8.x, val8.y, num5, -1f);
		}
		catch (Exception ex)
		{
			_logger.LogError("GetSpawnPosition", ex.Message, ex);
			if (Agent.Main != null)
			{
				return Agent.Main.Position + new Vec3(10f, 10f, 0f, -1f);
			}
			return new Vec3(0f, 0f, 0f, -1f);
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
			if (num2 > 3f)
			{
				return false;
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	private bool IsSpawnPositionValid(Mission mission, Vec3 position, bool checkPathAccessibility = true, bool checkSlope = true)
	{
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (mission == null || (NativeObject)(object)mission.Scene == (NativeObject)null)
			{
				return false;
			}
			if (float.IsNaN(position.x) || float.IsNaN(position.y) || float.IsNaN(position.z))
			{
				_logger.Log("Invalid spawn position: NaN values detected");
				return false;
			}
			if (float.IsInfinity(position.x) || float.IsInfinity(position.y) || float.IsInfinity(position.z))
			{
				_logger.Log("Invalid spawn position: Infinity values detected");
				return false;
			}
			float z = position.z;
			mission.Scene.GetHeightAtPoint((position).AsVec2, (BodyFlags)544321929, ref z);
			if (z < -10f || z > 1000f)
			{
				_logger.Log($"Invalid spawn position: Height out of range ({z:F2}m)");
				return false;
			}
			Vec3 val = default(Vec3);
			val = new Vec3(position.x, position.y, z, -1f);
			if (checkPathAccessibility && Agent.Main != null && Agent.Main.IsActive())
			{
				try
				{
					WorldPosition val2 = default(WorldPosition);
					val2 = new WorldPosition(mission.Scene, UIntPtr.Zero, val, false);
					WorldPosition val3 = default(WorldPosition);
					val3 = new WorldPosition(mission.Scene, UIntPtr.Zero, Agent.Main.Position, false);
					float num = default(float);
					if (!mission.Scene.GetPathDistanceBetweenPositions(ref val3, ref val2, 0f, ref num))
					{
						_logger.Log("Invalid spawn position: No path available");
						return false;
					}
					if (num > 200f || num < 0f)
					{
						_logger.Log($"Invalid spawn position: Path distance too long or invalid ({num:F2}m)");
						return false;
					}
				}
				catch
				{
				}
			}
			if (checkSlope && !IsPositionFlat(mission, val))
			{
				_logger.Log("Invalid spawn position: Too steep slope");
				return false;
			}
			try
			{
				Vec2 closestBoundaryPosition = mission.GetClosestBoundaryPosition((val).AsVec2);
				Vec2 val4 = (val).AsVec2 - closestBoundaryPosition;
				float length = (val4).Length;
				if (length < 2f)
				{
					_logger.Log($"Invalid spawn position: Too close to boundary ({length:F2}m)");
					return false;
				}
			}
			catch
			{
			}
			float z2 = val.z;
			if (!mission.Scene.GetHeightAtPoint((val).AsVec2, (BodyFlags)544321929, ref z2))
			{
				_logger.Log("Invalid spawn position: Cannot get height at point");
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			_logger.LogError("IsSpawnPositionValid", ex.Message, ex);
			return false;
		}
	}

	private void TryEquipWeapon(Agent agent)
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
			_logger.LogError("TryEquipWeapon", ex.Message, ex);
		}
	}

	public void HandleTransitionToLargeLocation(ActiveCombat combat)
	{
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (combat == null)
			{
				return;
			}
			if (combat.Analysis != null && !combat.Analysis.NeedsDefenders)
			{
				_logger.Log("HandleTransitionToLargeLocation: needs_defenders = false, skipping guard transition handling");
				return;
			}
			_currentCombat = combat;
			if (_currentCombat.LocationType != LocationType.LargeOutdoor)
			{
				return;
			}
			_logger.Log("=== LARGE LOCATION TRANSITION HANDLING ===");
			_logger.Log($"Pending guards: {_pendingGuards}, enemy reserve: {_enemySideReserve.Count}");
			_logger.Log($"Current active defenders: {CountActiveTroopsOnSide(playerSide: false)}/{GetMaxTroopsPerSide()} (max)");
			ReleaseReserveTroops(playerSide: false, "Guard (Reserve)");
			if (_pendingGuards > 0)
			{
				float num = 5f;
				if (_guardsSpawnScheduledTime.HasValue && _guardsSpawnDelay > 0f)
				{
					CampaignTime val = CampaignTime.Now - _guardsSpawnScheduledTime.Value;
					float num2 = (float)(val).ToSeconds;
					num = Math.Max(0f, _guardsSpawnDelay - num2);
					_logger.Log("=== GUARD SPAWN TIME CALCULATION ===");
					_logger.Log($"  Original delay: {_guardsSpawnDelay:F1} seconds");
					_logger.Log($"  Elapsed time: {num2:F1} seconds");
					_logger.Log($"  Remaining delay: {num:F1} seconds");
					if (num <= 0f)
					{
						num = 1f;
						_logger.Log($"  Time already elapsed, using minimum delay: {num:F1} seconds");
					}
				}
				else
				{
					_logger.Log($"No scheduled time found, using default delay: {num:F1} seconds");
				}
				_logger.Log($"Scheduling large-location guard waves. Guards remaining: {_pendingGuards}, delay: {num:F1}s");
				_guardsScheduled = true;
				ScheduleLargeGuardWave(num);
			}
			else if (_enemySideReserve.Count == 0)
			{
				_guardsScheduled = false;
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("HandleTransitionToLargeLocation", ex.Message, ex);
		}
	}

	private void ScheduleLargeGuardWave(float delaySeconds)
	{
		if (_currentCombat == null || _currentCombat.LocationType != LocationType.LargeOutdoor)
		{
			return;
		}
		ActiveCombat currentCombat = _currentCombat;
		ExecuteWhenOnMainStreet(currentCombat, delaySeconds, delegate
		{
			try
			{
				if (_currentCombat != null && _currentCombat.LocationType == LocationType.LargeOutdoor)
				{
					int maxTroopsPerSide = GetMaxTroopsPerSide();
					int num = CountActiveTroopsOnSide(playerSide: false);
					int num2 = Math.Max(0, maxTroopsPerSide - num);
					_logger.Log("=== LARGE LOCATION GUARD WAVE ===");
					_logger.Log($"  Active defenders: {num}/{maxTroopsPerSide}, reserve: {_enemySideReserve.Count}, pending: {_pendingGuards}");
					if (num2 > 0)
					{
						int num3 = ReleaseReserveTroops(playerSide: false, "Guard (Reserve)", num2);
						num2 = Math.Max(0, num2 - num3);
						if (num2 > 0 && _pendingGuards > 0)
						{
							int num4 = Math.Min(num2, _pendingGuards);
							_logger.Log($"  Spawning fresh guards: {num4}");
							SpawnGuards(_currentCombat, num4);
							_pendingGuards -= num4;
						}
					}
					else
					{
						_logger.Log("  No free slots for guard wave – skipping spawn, keeping pending counters");
					}
					if (_pendingGuards > 0 || _enemySideReserve.Count > 0)
					{
						_logger.Log("  Guards still pending/reserve present – scheduling next wave in 60s");
						ScheduleLargeGuardWave(60f);
					}
					else
					{
						_guardsScheduled = false;
						_guardsSpawnScheduledTime = null;
						_guardsSpawnDelay = 0f;
						CheckAndClearPendingCounters();
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("ScheduleLargeGuardWave", ex.Message, ex);
			}
		}, "LargeGuardWave");
	}

	private int ReleaseReserveTroops(bool playerSide, string rolePrefix, int maxToRelease = int.MaxValue)
	{
		try
		{
			if (_currentCombat == null || Mission.Current == null)
			{
				return 0;
			}
			Queue<(CharacterObject, MobileParty)> queue = (playerSide ? _playerSideReserve : _enemySideReserve);
			if (queue.Count == 0 || maxToRelease <= 0)
			{
				return 0;
			}
			int maxTroopsPerSide = GetMaxTroopsPerSide();
			int num = CountActiveTroopsOnSide(playerSide);
			int val = Math.Max(0, maxTroopsPerSide - num);
			int num2 = Math.Min(Math.Min(val, maxToRelease), queue.Count);
			if (num2 <= 0)
			{
				return 0;
			}
			int num3 = 0;
			while (queue.Count > 0 && num3 < num2)
			{
				var (character, sourceParty) = queue.Dequeue();
				SpawnDefenderAgent(character, _currentCombat, rolePrefix, playerSide, isLocal: false, sourceParty);
				num3++;
			}
			if (num3 > 0)
			{
				_logger.Log(string.Format("Released {0} {1} reserve troops (role: {2})", num3, playerSide ? "player" : "enemy", rolePrefix));
			}
			return num3;
		}
		catch (Exception ex)
		{
			_logger.LogError("ReleaseReserveTroops", ex.Message, ex);
			return 0;
		}
	}
}
