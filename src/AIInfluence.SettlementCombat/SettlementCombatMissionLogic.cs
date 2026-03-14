using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.SettlementCombat;

public class SettlementCombatMissionLogic : MissionLogic
{
	private readonly CombatStatistics _statistics;

	private readonly SettlementCombatLogger _logger;

	private readonly AIInfluenceBehavior _behavior;

	private readonly CivilianBehavior _civilianBehavior;

	private readonly SettlementCombatManager _combatManager;

	private readonly DefenderSpawner _defenderSpawner;

	private float _combatCheckTimer = 0f;

	private const float COMBAT_CHECK_INTERVAL = 2f;

	private bool _eventSubscribed = false;

	public SettlementCombatMissionLogic(CombatStatistics statistics, AIInfluenceBehavior behavior, CivilianBehavior civilianBehavior, SettlementCombatManager combatManager)
	{
		_statistics = statistics;
		_behavior = behavior;
		_civilianBehavior = civilianBehavior;
		_combatManager = combatManager;
		_defenderSpawner = combatManager?.GetDefenderSpawner();
		_logger = SettlementCombatLogger.Instance;
		if (Mission.Current != null)
		{
			Mission.Current.GetOverriddenFleePositionForAgent += GetOverriddenFleePositionForAgent;
			_eventSubscribed = true;
		}
	}

	public override void AfterStart()
	{
		base.AfterStart();
		if (!_eventSubscribed && Mission.Current != null)
		{
			Mission.Current.GetOverriddenFleePositionForAgent += GetOverriddenFleePositionForAgent;
			_eventSubscribed = true;
		}
	}

	private WorldPosition? GetOverriddenFleePositionForAgent(Agent agent)
	{
		if (_combatManager == null || !_combatManager.IsActiveCombat())
		{
			return null;
		}
		try
		{
			if (_civilianBehavior != null && _civilianBehavior.IsAgentPanicking(agent))
			{
				return null;
			}
			return null;
		}
		catch (Exception ex)
		{
			_logger.LogError("GetOverriddenFleePositionForAgent", ex.Message, ex);
			return null;
		}
	}

	public override void OnMissionTick(float dt)
	{
		if (_combatManager == null || !_combatManager.IsActiveCombat())
		{
			return;
		}
		base.OnMissionTick(dt);
		try
		{
			_civilianBehavior?.OnTick(dt);
			_defenderSpawner?.OnTick(dt);
			_combatCheckTimer += dt;
			if (_combatCheckTimer >= 2f)
			{
				_combatCheckTimer = 0f;
				CheckCombatEnd();
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("OnMissionTick", ex.Message, ex);
		}
	}

	private void CheckCombatEnd()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || Mission.Current.PlayerTeam == null || Mission.Current.DefenderTeam == null || (int)Mission.Current.Mode != 2)
			{
				return;
			}
			int num = 0;
			foreach (Agent item in (List<Agent>)(object)Mission.Current.DefenderTeam.ActiveAgents)
			{
				if (item != null && item.IsActive() && item.IsHuman && Extensions.HasAnyFlag<AgentFlag>(item.GetAgentFlags(), (AgentFlag)8))
				{
					num++;
				}
			}
			DefenderSpawner defenderSpawner = _combatManager.GetDefenderSpawner();
			bool flag = defenderSpawner?.HasPendingSpawns() ?? false;
			if (num == 0)
			{
				if (flag)
				{
					_logger.Log("All current enemies eliminated, but waiting for reinforcements: " + defenderSpawner.GetPendingSpawnsInfo());
					return;
				}
				_logger.Log("All fighting enemies eliminated! Returning to peace mode...");
				_combatManager.OnAllEnemiesEliminated();
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CheckCombatEnd", ex.Message, ex);
		}
	}

	public override void OnAgentCreated(Agent agent)
	{
		if (_combatManager == null || !_combatManager.IsActiveCombat())
		{
			return;
		}
		base.OnAgentCreated(agent);
		try
		{
			if (agent != null && agent.IsHuman)
			{
				BasicCharacterObject character = agent.Character;
				CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
				if (val != null && !string.IsNullOrEmpty(((MBObjectBase)val).StringId) && _combatManager.TryGetCompanionDecision(((MBObjectBase)val).StringId, out var _))
				{
					_combatManager.ApplyCompanionDecisionToAgent(agent);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("OnAgentCreated", ex.Message, ex);
		}
	}

	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		bool flag = (int)agentState == 3;
		bool flag2 = flag && affectedAgent == Agent.Main;
		if (!flag2 && (_combatManager == null || !_combatManager.IsActiveCombat()))
		{
			return;
		}
		try
		{
			if (affectedAgent == null || !affectedAgent.IsHuman)
			{
				return;
			}
			bool flag3 = (int)agentState == 4;
			if (!flag3 && !flag)
			{
				return;
			}
			if (flag2 && _combatManager != null)
			{
				try
				{
					float num = 0f;
					float num2 = 0f;
					Mission current = Mission.Current;
					if (((current != null) ? current.PlayerTeam : null) != null)
					{
						foreach (Agent item in (List<Agent>)(object)Mission.Current.PlayerTeam.ActiveAgents)
						{
							if (item != null && item.IsHuman && item.Health > 0f)
							{
								num += item.CharacterPowerCached;
							}
						}
					}
					Mission current3 = Mission.Current;
					if (((current3 != null) ? current3.DefenderTeam : null) != null)
					{
						foreach (Agent item2 in (List<Agent>)(object)Mission.Current.DefenderTeam.ActiveAgents)
						{
							if (item2 != null && item2.IsHuman && item2.Health > 0f)
							{
								num2 += item2.CharacterPowerCached;
							}
						}
					}
					_combatManager.OnPlayerKnockedOut(num, num2);
				}
				catch (Exception ex)
				{
					_logger.LogError("OnAgentRemoved_PlayerKnockout", ex.Message, ex);
				}
			}
			string victimName = affectedAgent.Name ?? "Unknown";
			BasicCharacterObject character = affectedAgent.Character;
			string victimId = ((character != null) ? ((MBObjectBase)character).StringId : null) ?? "unknown_agent";
			bool flag4 = IsCivilian(affectedAgent.Character);
			BasicCharacterObject character2 = affectedAgent.Character;
			CharacterObject val = (CharacterObject)(object)((character2 is CharacterObject) ? character2 : null);
			bool isCivilianFemale = flag4 && val != null && ((BasicCharacterObject)val).IsFemale;
			Campaign current5 = Campaign.Current;
			object obj;
			if (current5 == null)
			{
				obj = null;
			}
			else
			{
				GameModels models = current5.Models;
				obj = ((models != null) ? models.AgeModel : null);
			}
			AgeModel val2 = (AgeModel)obj;
			bool flag5 = val2 != null && affectedAgent.Age < (float)val2.BecomeTeenagerAge;
			bool isCivilianChild = flag4 && flag5;
			bool isImportant = IsImportantCharacter(val);
			CombatSide agentSide = GetAgentSide(affectedAgent);
			Mission current6 = Mission.Current;
			PlayerReinforcementMissionLogic playerReinforcementMissionLogic = ((current6 != null) ? current6.GetMissionBehavior<PlayerReinforcementMissionLogic>() : null);
			bool isPlayerTroop = playerReinforcementMissionLogic?.IsSummonedTroop(affectedAgent) ?? false;
			string text = "Unknown";
			string text2 = "unknown";
			bool isPlayerTroop2 = false;
			if (affectorAgent != null)
			{
				text = affectorAgent.Name ?? "Unknown";
				BasicCharacterObject character3 = affectorAgent.Character;
				text2 = ((character3 != null) ? ((MBObjectBase)character3).StringId : null) ?? "unknown_agent";
				isPlayerTroop2 = playerReinforcementMissionLogic?.IsSummonedTroop(affectorAgent) ?? false;
			}
			else if (blow.OwnerId >= 0 && blow.OwnerId < ((List<Agent>)(object)((MissionBehavior)this).Mission.Agents).Count)
			{
				Agent val3 = ((List<Agent>)(object)((MissionBehavior)this).Mission.Agents).Find((Predicate<Agent>)((Agent a) => a != null && a.Index == blow.OwnerId));
				if (val3 != null)
				{
					text = val3.Name ?? "Unknown";
					BasicCharacterObject character4 = val3.Character;
					text2 = ((character4 != null) ? ((MBObjectBase)character4).StringId : null) ?? "unknown_agent";
					isPlayerTroop2 = playerReinforcementMissionLogic?.IsSummonedTroop(val3) ?? false;
				}
			}
			string victimType = DetermineAgentType(affectedAgent, isPlayerTroop, flag4);
			string text3 = ((affectorAgent != null) ? DetermineAgentType(affectorAgent, isPlayerTroop2, isCivilian: false) : "unknown");
			if (_combatManager != null && _combatManager.IsActiveCombat())
			{
				int index = affectedAgent.Index;
				if (flag3)
				{
					_statistics.RecordDeath(victimName, victimId, victimType, text, text2, text3, flag4, agentSide, isCivilianFemale, isCivilianChild, isImportant, index);
				}
				else if (flag)
				{
					_statistics.RecordWound(victimName, victimId, victimType, text, text2, text3, flag4, agentSide, isCivilianFemale, isCivilianChild, isImportant, index);
				}
			}
		}
		catch (Exception ex2)
		{
			_logger.LogError("OnAgentRemoved", ex2.Message, ex2);
		}
	}

	public override void OnRemoveBehavior()
	{
		try
		{
			if (_eventSubscribed && Mission.Current != null)
			{
				Mission.Current.GetOverriddenFleePositionForAgent -= GetOverriddenFleePositionForAgent;
				_eventSubscribed = false;
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("OnRemoveBehavior", ex.Message, ex);
		}
		base.OnRemoveBehavior();
	}

	public override InquiryData OnEndMissionRequest(out bool canPlayerLeave)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		try
		{
			SettlementCombatManager combatManager = _combatManager;
			if (combatManager != null && combatManager.ShouldBlockMissionExit())
			{
				canPlayerLeave = false;
				TextObject val = new TextObject("{=AIInfluence_CannotLeaveDuringCombat}You cannot leave the settlement during combat! Run to the map boundary.", (Dictionary<string, object>)null);
				MBInformationManager.AddQuickInformation(val, 0, (BasicCharacterObject)null, (Equipment)null, "");
				return null;
			}
			canPlayerLeave = true;
			return null;
		}
		catch (Exception ex)
		{
			_logger.LogError("OnEndMissionRequest", ex.Message, ex);
			canPlayerLeave = true;
			return null;
		}
	}

	private string DetermineAgentType(Agent agent, bool isPlayerTroop, bool isCivilian)
	{
		if (agent == null)
		{
			return "unknown";
		}
		if (isPlayerTroop)
		{
			return "player's summoned troops";
		}
		if (isCivilian)
		{
			return "civilian";
		}
		BasicCharacterObject character = agent.Character;
		CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
		if (val != null && ((BasicCharacterObject)val).IsHero)
		{
			if (val.HeroObject == Hero.MainHero)
			{
				return "player";
			}
			if (val.HeroObject.IsLord)
			{
				return $"lord's troops ({val.HeroObject.Name})";
			}
			if (val.HeroObject.IsPlayerCompanion)
			{
				return "player's companion";
			}
		}
		if (agent.Team == ((MissionBehavior)this).Mission.DefenderTeam)
		{
			if (val != null)
			{
				if (val.Tier <= 2)
				{
					return "settlement defenders";
				}
				if (val.Tier <= 3 && agent.HasMount)
				{
					return "militia";
				}
				if (val.Tier >= 4)
				{
					return "elite guards";
				}
			}
			return "settlement forces";
		}
		return "soldier";
	}

	private bool IsCivilian(BasicCharacterObject character)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		if (character == null)
		{
			return false;
		}
		CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
		if (val == null)
		{
			return false;
		}
		if (((BasicCharacterObject)val).IsHero)
		{
			Hero heroObject = val.HeroObject;
			if (heroObject != null && heroObject.IsLord)
			{
				return false;
			}
		}
		return (int)val.Occupation != 7 && (int)val.Occupation != 15 && (int)val.Occupation != 2;
	}

	private CombatSide GetAgentSide(Agent agent)
	{
		if (((agent != null) ? agent.Team : null) == null)
		{
			return CombatSide.Unknown;
		}
		Mission current = Mission.Current;
		if (((current != null) ? current.PlayerTeam : null) != null)
		{
			if (agent.Team == Mission.Current.PlayerTeam)
			{
				return CombatSide.Attackers;
			}
			return CombatSide.Defenders;
		}
		Team team = agent.Team;
		Mission current2 = Mission.Current;
		if (team == ((current2 != null) ? current2.AttackerTeam : null))
		{
			return CombatSide.Attackers;
		}
		return CombatSide.Defenders;
	}

	private bool IsImportantCharacter(CharacterObject character)
	{
		if (character == null)
		{
			return false;
		}
		if (((BasicCharacterObject)character).IsHero)
		{
			Hero heroObject = character.HeroObject;
			if (heroObject != null && (heroObject.IsLord || heroObject == Hero.MainHero))
			{
				return true;
			}
		}
		return false;
	}
}
