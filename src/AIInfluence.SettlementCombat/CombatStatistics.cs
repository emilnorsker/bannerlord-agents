using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.SettlementCombat;

public class CombatStatistics
{
	private readonly AIInfluenceBehavior _behavior;

	private readonly SettlementCombatLogger _logger;

	private ActiveCombat _currentCombat;

	private bool _isTracking;

	private List<DeathRecord> _deaths = new List<DeathRecord>();

	private List<WoundRecord> _wounds = new List<WoundRecord>();

	private HashSet<string> _participants = new HashSet<string>();

	private SideCasualtySummary _defenderCasualties = new SideCasualtySummary();

	private SideCasualtySummary _attackerCasualties = new SideCasualtySummary();

	private CivilianCasualtySummary _civilianCasualties = new CivilianCasualtySummary();

	private readonly List<VipCasualtyRecord> _vipCasualties = new List<VipCasualtyRecord>();

	private bool _simpleDefendersArrived = false;

	private int _simpleDefendersSpawned = 0;

	private bool _militiaArrived = false;

	private int _militiaSpawned = 0;

	private bool _guardsArrived = false;

	private int _guardsSpawned = 0;

	private List<LordArrivalInfo> _lordsArrived = new List<LordArrivalInfo>();

	private Dictionary<int, string> _lordTroopOwnership = new Dictionary<int, string>();

	private Dictionary<string, int> _lordTroopLosses = new Dictionary<string, int>();

	private int _savedSummonedTroopsCount = 0;

	private string _savedSummonedTroopsInfo = "";

	public CombatStatistics(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
		_logger = SettlementCombatLogger.Instance;
	}

	public void StartTracking(ActiveCombat combat, CivilianBehavior civilianBehavior, SettlementCombatManager combatManager)
	{
		if (_isTracking)
		{
			_behavior.LogMessage("[COMBAT_STATS] Already tracking combat, stopping previous tracking");
			StopTracking();
		}
		_currentCombat = combat;
		_isTracking = true;
		_deaths.Clear();
		_wounds.Clear();
		_participants.Clear();
		_defenderCasualties = new SideCasualtySummary();
		_attackerCasualties = new SideCasualtySummary();
		_civilianCasualties = new CivilianCasualtySummary();
		_vipCasualties.Clear();
		_simpleDefendersArrived = false;
		_simpleDefendersSpawned = 0;
		_militiaArrived = false;
		_militiaSpawned = 0;
		_guardsArrived = false;
		_guardsSpawned = 0;
		_lordsArrived.Clear();
		_lordTroopOwnership.Clear();
		_lordTroopLosses.Clear();
		_savedSummonedTroopsCount = 0;
		_savedSummonedTroopsInfo = "";
		if (Mission.Current != null)
		{
			DisableReinforcementSystem();
			SettlementCombatMissionLogic settlementCombatMissionLogic = new SettlementCombatMissionLogic(this, _behavior, civilianBehavior, combatManager);
			Mission.Current.AddMissionBehavior((MissionBehavior)(object)settlementCombatMissionLogic);
			_logger.Log("SettlementCombatMissionLogic added to mission");
			PlayerReinforcementMissionLogic playerReinforcementMissionLogic = Mission.Current.MissionBehaviors.OfType<PlayerReinforcementMissionLogic>().FirstOrDefault();
			if (playerReinforcementMissionLogic == null)
			{
				PlayerReinforcementMissionLogic playerReinforcementMissionLogic2 = new PlayerReinforcementMissionLogic(_behavior);
				Mission.Current.AddMissionBehavior((MissionBehavior)(object)playerReinforcementMissionLogic2);
				_logger.Log("PlayerReinforcementMissionLogic added to mission");
			}
			else
			{
				_logger.Log("PlayerReinforcementMissionLogic already exists in mission, skipping");
			}
		}
		SubscribeToEvents();
		_logger.Log($"Started tracking combat in {combat.Settlement.Name}");
	}

	public void StopTracking()
	{
		if (!_isTracking)
		{
			return;
		}
		UnsubscribeFromEvents();
		try
		{
			if (Mission.Current != null)
			{
				PlayerReinforcementMissionLogic playerReinforcementMissionLogic = Mission.Current.MissionBehaviors.OfType<PlayerReinforcementMissionLogic>().FirstOrDefault();
				if (playerReinforcementMissionLogic != null)
				{
					_savedSummonedTroopsCount = playerReinforcementMissionLogic.GetSummonedTroopsCount();
					_savedSummonedTroopsInfo = playerReinforcementMissionLogic.GetSummonedTroopsInfo();
					_logger.Log($"Saved summoned troops data before cleanup: {_savedSummonedTroopsCount} ({_savedSummonedTroopsInfo})");
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("StopTracking_SaveSummonedTroops", ex.Message, ex);
		}
		try
		{
			if (Mission.Current != null)
			{
				SettlementCombatMissionLogic settlementCombatMissionLogic = Mission.Current.MissionBehaviors.OfType<SettlementCombatMissionLogic>().FirstOrDefault();
				if (settlementCombatMissionLogic != null)
				{
					Mission.Current.RemoveMissionBehavior((MissionBehavior)(object)settlementCombatMissionLogic);
					_logger.Log("SettlementCombatMissionLogic removed from mission to prevent interference with vanilla combats");
				}
				PlayerReinforcementMissionLogic playerReinforcementMissionLogic2 = Mission.Current.MissionBehaviors.OfType<PlayerReinforcementMissionLogic>().FirstOrDefault();
				if (playerReinforcementMissionLogic2 != null)
				{
					Mission.Current.RemoveMissionBehavior((MissionBehavior)(object)playerReinforcementMissionLogic2);
					_logger.Log("PlayerReinforcementMissionLogic removed from mission after settlement combat");
				}
			}
		}
		catch (Exception ex2)
		{
			_logger.LogError("StopTracking_RemoveMissionLogic", ex2.Message, ex2);
		}
		_isTracking = false;
		_behavior.LogMessage($"[COMBAT_STATS] Stopped tracking. Total deaths: {_deaths.Count}, Total wounds: {_wounds.Count}");
	}

	public CombatResult GetCombatResult()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		CombatResult combatResult = new CombatResult
		{
			Settlement = _currentCombat.Settlement,
			Duration = CampaignTime.Now - _currentCombat.StartTime,
			TotalKilled = _deaths.Count,
			TotalWounded = _wounds.Count,
			CiviliansKilled = _deaths.Count((DeathRecord d) => d.IsCivilian),
			CiviliansWounded = _wounds.Count((WoundRecord w) => w.IsCivilian),
			Deaths = _deaths.ToList(),
			Wounds = _wounds.ToList(),
			Participants = _participants.ToList(),
			SimpleDefendersArrived = _simpleDefendersArrived,
			SimpleDefendersSpawned = _simpleDefendersSpawned,
			MilitiaArrived = _militiaArrived,
			MilitiaSpawned = _militiaSpawned,
			GuardsArrived = _guardsArrived,
			GuardsSpawned = _guardsSpawned,
			LordsArrived = _lordsArrived.ToList(),
			DefenderCasualties = _defenderCasualties.Clone(),
			AttackerCasualties = _attackerCasualties.Clone(),
			CivilianCasualties = _civilianCasualties.Clone(),
			ImportantCasualties = _vipCasualties.Select((VipCasualtyRecord v) => v.Clone()).ToList(),
			PlayerSummonedTroopsCount = _savedSummonedTroopsCount,
			PlayerSummonedTroopsInfo = _savedSummonedTroopsInfo
		};
		foreach (LordArrivalInfo item in combatResult.LordsArrived)
		{
			if (_lordTroopLosses.TryGetValue(item.LordStringId, out var value))
			{
				item.TroopsLost = value;
			}
		}
		combatResult.MilitiaKilled = _deaths.Count((DeathRecord d) => d.VictimType == "militia");
		combatResult.SimpleDefendersKilled = _deaths.Count((DeathRecord d) => d.VictimType == "settlement defenders");
		combatResult.GuardsKilled = _deaths.Count((DeathRecord d) => d.VictimType == "elite guards");
		return combatResult;
	}

	public void RecordSimpleDefendersArrival(int count)
	{
		_simpleDefendersArrived = true;
		_simpleDefendersSpawned = count;
		_logger.Log($"Simple defenders arrival recorded: {count} units");
	}

	public void RecordMilitiaArrival(int count)
	{
		_militiaArrived = true;
		_militiaSpawned = count;
		_logger.Log($"Militia arrival recorded: {count} units");
	}

	public void RecordGuardsArrival(int count)
	{
		_guardsArrived = true;
		_guardsSpawned = count;
		_logger.Log($"Guards arrival recorded: {count} units");
	}

	public void RecordLordArrival(string lordId, string lordName, bool onPlayerSide, int troopsCount)
	{
		_lordsArrived.Add(new LordArrivalInfo
		{
			LordStringId = lordId,
			LordName = lordName,
			OnPlayerSide = onPlayerSide,
			TroopsSpawned = troopsCount,
			TroopsLost = 0
		});
		_logger.Log($"Lord arrival recorded: {lordName} (on player side: {onPlayerSide}, troops: {troopsCount})");
	}

	public void RegisterLordTroop(int agentIndex, string lordStringId)
	{
		_lordTroopOwnership[agentIndex] = lordStringId;
	}

	public int GetSavedSummonedTroopsCount()
	{
		return _savedSummonedTroopsCount;
	}

	public string GetSavedSummonedTroopsInfo()
	{
		return _savedSummonedTroopsInfo;
	}

	public void RecordDeath(string victimName, string victimId, string victimType, string killerName, string killerId, string killerType, bool isCivilian, CombatSide victimSide, bool isCivilianFemale, bool isCivilianChild, bool isImportant, int victimAgentIndex = -1)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (_isTracking)
		{
			DeathRecord deathRecord = new DeathRecord
			{
				VictimStringId = victimId,
				VictimName = victimName,
				VictimType = victimType,
				KillerStringId = killerId,
				KillerName = killerName,
				KillerType = killerType,
				IsCivilian = isCivilian,
				DeathTime = CampaignTime.Now,
				VictimSide = victimSide,
				IsCivilianFemale = (isCivilian && isCivilianFemale),
				IsCivilianChild = (isCivilian && isCivilianChild),
				IsImportant = isImportant
			};
			_deaths.Add(deathRecord);
			_participants.Add(victimId);
			if (killerId != "unknown")
			{
				_participants.Add(killerId);
			}
			_logger.Log("Death recorded: " + victimName + " (" + victimType + ") killed by " + killerName + " (" + killerType + ")");
			UpdateAggregatesForDeath(deathRecord);
			UpdateLordTroopLoss(victimAgentIndex);
		}
	}

	public void RecordWound(string victimName, string victimId, string victimType, string attackerName, string attackerId, string attackerType, bool isCivilian, CombatSide victimSide, bool isCivilianFemale, bool isCivilianChild, bool isImportant, int victimAgentIndex = -1)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (_isTracking)
		{
			WoundRecord woundRecord = new WoundRecord
			{
				VictimStringId = victimId,
				VictimName = victimName,
				VictimType = victimType,
				AttackerStringId = attackerId,
				AttackerName = attackerName,
				AttackerType = attackerType,
				IsCivilian = isCivilian,
				WoundTime = CampaignTime.Now,
				VictimSide = victimSide,
				IsCivilianFemale = (isCivilian && isCivilianFemale),
				IsCivilianChild = (isCivilian && isCivilianChild),
				IsImportant = isImportant
			};
			_wounds.Add(woundRecord);
			_participants.Add(victimId);
			if (attackerId != "unknown")
			{
				_participants.Add(attackerId);
			}
			_logger.Log("Wound recorded: " + victimName + " (" + victimType + ") wounded by " + attackerName + " (" + attackerType + ")");
			UpdateAggregatesForWound(woundRecord);
			UpdateLordTroopLoss(victimAgentIndex);
		}
	}

	private void UpdateLordTroopLoss(int agentIndex)
	{
		if (agentIndex >= 0 && _lordTroopOwnership.TryGetValue(agentIndex, out var value))
		{
			if (_lordTroopLosses.ContainsKey(value))
			{
				_lordTroopLosses[value]++;
			}
			else
			{
				_lordTroopLosses[value] = 1;
			}
		}
	}

	private void SubscribeToEvents()
	{
		CampaignEvents.HeroKilledEvent.AddNonSerializedListener((object)this, (Action<Hero, Hero, KillCharacterActionDetail, bool>)OnHeroKilled);
	}

	private void UnsubscribeFromEvents()
	{
		((IMbEventBase)CampaignEvents.HeroKilledEvent).ClearListeners((object)this);
	}

	private void DisableReinforcementSystem()
	{
		try
		{
			if (Mission.Current == null)
			{
				return;
			}
			if (Settlement.CurrentSettlement == null || (PlayerEncounter.Current != null && PlayerEncounter.EncounteredBattle != null))
			{
				_logger.Log("DisableReinforcementSystem: Not a settlement combat, skipping (ReinforcementSystem will work normally)");
				return;
			}
			MissionBehavior val = ((IEnumerable<MissionBehavior>)Mission.Current.MissionBehaviors).FirstOrDefault((Func<MissionBehavior, bool>)((MissionBehavior mb) => ((object)mb).GetType().Name == "RS_Core_Field"));
			MissionBehavior val2 = ((IEnumerable<MissionBehavior>)Mission.Current.MissionBehaviors).FirstOrDefault((Func<MissionBehavior, bool>)((MissionBehavior mb) => ((object)mb).GetType().Name == "RS_Core_Siege"));
			if (val != null)
			{
				Type type = ((object)val).GetType();
				FieldInfo field = type.GetField("reinforceswitch", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field2 = type.GetField("spawnswitch", BindingFlags.Instance | BindingFlags.NonPublic);
				if (field != null)
				{
					field.SetValue(val, false);
				}
				if (field2 != null)
				{
					field2.SetValue(val, false);
				}
				_logger.Log("ReinforcementSystem RS_Core_Field: reinforcement search and spawn disabled for settlement combat (mod remains active for this mission only)");
			}
			if (val2 != null)
			{
				Type type2 = ((object)val2).GetType();
				FieldInfo field3 = type2.GetField("reinforceswitch", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field4 = type2.GetField("spawnswitch", BindingFlags.Instance | BindingFlags.NonPublic);
				if (field3 != null)
				{
					field3.SetValue(val2, false);
				}
				if (field4 != null)
				{
					field4.SetValue(val2, false);
				}
				_logger.Log("ReinforcementSystem RS_Core_Siege: reinforcement search and spawn disabled for settlement combat (mod remains active for this mission only)");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("DisableReinforcementSystem", ex.Message, ex);
		}
	}

	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification)
	{
		if (!_isTracking)
		{
			return;
		}
		try
		{
			if (!_deaths.Any((DeathRecord d) => d.VictimStringId == ((MBObjectBase)victim).StringId))
			{
				bool flag = !victim.IsLord && !victim.IsWanderer;
				bool isCivilianChild = flag && IsChild(victim.Age, victim.IsChild);
				bool isCivilianFemale = flag && victim.IsFemale;
				bool isImportant = victim.IsLord || victim == Hero.MainHero;
				CombatSide victimSide = DetermineHeroSide(victim);
				RecordDeath(((object)victim.Name)?.ToString(), ((MBObjectBase)victim).StringId, victim.IsLord ? "lord" : "hero", ((killer == null) ? null : ((object)killer.Name)?.ToString()) ?? "Unknown", ((killer != null) ? ((MBObjectBase)killer).StringId : null) ?? "unknown", (killer != null) ? "hero" : "unknown", flag, victimSide, isCivilianFemale, isCivilianChild, isImportant);
			}
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[COMBAT_STATS] ERROR recording death: " + ex.Message);
		}
	}

	public void RecordWound(Agent victimAgent, Agent attackerAgent)
	{
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		if (!_isTracking)
		{
			return;
		}
		try
		{
			BasicCharacterObject character = victimAgent.Character;
			BasicCharacterObject obj = ((character is CharacterObject) ? character : null);
			Hero val = ((obj != null) ? ((CharacterObject)obj).HeroObject : null);
			BasicCharacterObject obj2 = ((attackerAgent != null) ? attackerAgent.Character : null);
			BasicCharacterObject obj3 = ((obj2 is CharacterObject) ? obj2 : null);
			Hero val2 = ((obj3 != null) ? ((CharacterObject)obj3).HeroObject : null);
			if (val != null)
			{
				bool flag = !val.IsLord && !val.IsWanderer;
				bool isCivilianChild = flag && IsChild(val.Age, val.IsChild);
				bool isCivilianFemale = flag && val.IsFemale;
				bool isImportant = val.IsLord || val == Hero.MainHero;
				CombatSide victimSide = DetermineHeroSide(val);
				WoundRecord woundRecord = new WoundRecord
				{
					VictimStringId = ((MBObjectBase)val).StringId,
					VictimName = ((object)val.Name)?.ToString(),
					AttackerStringId = ((val2 != null) ? ((MBObjectBase)val2).StringId : null),
					AttackerName = (((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? "Unknown"),
					IsCivilian = flag,
					WoundTime = CampaignTime.Now,
					VictimSide = victimSide,
					IsCivilianFemale = isCivilianFemale,
					IsCivilianChild = isCivilianChild,
					IsImportant = isImportant
				};
				_wounds.Add(woundRecord);
				_participants.Add(((MBObjectBase)val).StringId);
				if (val2 != null)
				{
					_participants.Add(((MBObjectBase)val2).StringId);
				}
				_behavior.LogMessage(string.Format("[COMBAT_STATS] Wound recorded: {0} wounded by {1} (Civilian: {2})", val.Name, ((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? "Unknown", flag));
				UpdateAggregatesForWound(woundRecord);
			}
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[COMBAT_STATS] ERROR recording wound: " + ex.Message);
		}
	}

	private void UpdateAggregatesForDeath(DeathRecord death)
	{
		switch (death.VictimSide)
		{
		case CombatSide.Defenders:
			_defenderCasualties.Killed++;
			break;
		case CombatSide.Attackers:
			_attackerCasualties.Killed++;
			break;
		}
		if (death.IsCivilian)
		{
			if (death.IsCivilianChild)
			{
				_civilianCasualties.ChildrenKilled++;
			}
			else if (death.IsCivilianFemale)
			{
				_civilianCasualties.WomenKilled++;
			}
			else
			{
				_civilianCasualties.MenKilled++;
			}
		}
		if (death.IsImportant)
		{
			_vipCasualties.Add(new VipCasualtyRecord
			{
				VictimName = death.VictimName,
				VictimStringId = death.VictimStringId,
				Side = death.VictimSide,
				IsKilled = true,
				KillerName = death.KillerName,
				KillerStringId = death.KillerStringId,
				KillerType = death.KillerType
			});
		}
	}

	private void UpdateAggregatesForWound(WoundRecord wound)
	{
		switch (wound.VictimSide)
		{
		case CombatSide.Defenders:
			_defenderCasualties.Wounded++;
			break;
		case CombatSide.Attackers:
			_attackerCasualties.Wounded++;
			break;
		}
		if (wound.IsCivilian)
		{
			if (wound.IsCivilianChild)
			{
				_civilianCasualties.ChildrenWounded++;
			}
			else if (wound.IsCivilianFemale)
			{
				_civilianCasualties.WomenWounded++;
			}
			else
			{
				_civilianCasualties.MenWounded++;
			}
		}
		if (wound.IsImportant)
		{
			_vipCasualties.Add(new VipCasualtyRecord
			{
				VictimName = wound.VictimName,
				VictimStringId = wound.VictimStringId,
				Side = wound.VictimSide,
				IsKilled = false,
				KillerName = wound.AttackerName,
				KillerStringId = wound.AttackerStringId,
				KillerType = wound.AttackerType
			});
		}
	}

	private CombatSide DetermineHeroSide(Hero hero)
	{
		if (hero == null)
		{
			return CombatSide.Unknown;
		}
		if (_currentCombat != null && hero.MapFaction == _currentCombat.Settlement.MapFaction)
		{
			return CombatSide.Defenders;
		}
		return CombatSide.Attackers;
	}

	private bool IsChild(float age, bool isChildOccupation)
	{
		if (isChildOccupation)
		{
			return true;
		}
		Campaign current = Campaign.Current;
		object obj;
		if (current == null)
		{
			obj = null;
		}
		else
		{
			GameModels models = current.Models;
			obj = ((models != null) ? models.AgeModel : null);
		}
		AgeModel val = (AgeModel)obj;
		if (val != null)
		{
			return age < (float)val.HeroComesOfAge;
		}
		return age < 18f;
	}
}
