using System;
using System.Collections.Generic;
using AIInfluence.SettlementCombat;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.AgentOrigins;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(MissionBoundaryCrossingHandler))]
[HarmonyPatch("HandleAgentStateChange")]
public class SettlementCombatBoundaryPatch
{
	private static bool Prefix(Agent agent, bool isAgentOutside, bool isTimerActiveForAgent, MissionTimer timerInstance)
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Invalid comparison between Unknown and I4
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (agent != Agent.Main)
			{
				return true;
			}
			if (!isAgentOutside || !isTimerActiveForAgent || timerInstance == null)
			{
				return true;
			}
			if (!timerInstance.Check(false))
			{
				return true;
			}
			Campaign current = Campaign.Current;
			AIInfluenceBehavior aIInfluenceBehavior = ((current != null) ? current.GetCampaignBehavior<AIInfluenceBehavior>() : null);
			if (aIInfluenceBehavior == null)
			{
				return true;
			}
			SettlementCombatManager settlementCombatManager = aIInfluenceBehavior.GetSettlementCombatManager();
			if (settlementCombatManager == null || !settlementCombatManager.IsActiveCombat())
			{
				return true;
			}
			if (Mission.Current != null && Mission.Current.IsPlayerCloseToAnEnemy(90f))
			{
				TextObject val = new TextObject("{=AIInfluence_CannotRetreatEnemyNear}You cannot retreat while enemies are nearby!", (Dictionary<string, object>)null);
				MBInformationManager.AddQuickInformation(val, 0, (BasicCharacterObject)null, (Equipment)null, "");
				SettlementCombatLogger instance = SettlementCombatLogger.Instance;
				return false;
			}
			try
			{
				if (Mission.Current != null)
				{
					int num = ((Agent.Main != null) ? 1 : 0);
					int num2 = ((Agent.Main != null) ? 1 : 0);
					Agent main = Agent.Main;
					Vec3 val2 = ((main != null) ? main.Position : Vec3.Zero);
					Team playerTeam = Mission.Current.PlayerTeam;
					foreach (Agent item in (List<Agent>)(((object)((playerTeam != null) ? playerTeam.ActiveAgents : null)) ?? ((object)new MBList<Agent>())))
					{
						if (item == null || item == Agent.Main || !item.IsHuman || !item.IsActive())
						{
							continue;
						}
						IAgentOriginBase origin = item.Origin;
						PartyBase val3 = null;
						PartyAgentOrigin val4 = (PartyAgentOrigin)(object)((origin is PartyAgentOrigin) ? origin : null);
						if (val4 != null)
						{
							val3 = val4.Party;
						}
						else
						{
							PartyGroupAgentOrigin val5 = (PartyGroupAgentOrigin)(object)((origin is PartyGroupAgentOrigin) ? origin : null);
							if (val5 != null)
							{
								val3 = val5.Party;
							}
						}
						if (val3 == PartyBase.MainParty && (int)item.State == 1 && !(item.Health <= 0f))
						{
							num++;
							Vec3 val6 = item.Position - val2;
							if (((Vec3)(ref val6)).LengthSquared <= 15f)
							{
								num2++;
							}
						}
					}
					settlementCombatManager.RegisterPlayerEscapeAttempt(num, num2);
				}
			}
			catch (Exception ex)
			{
				SettlementCombatLogger.Instance?.LogError("SettlementCombatBoundaryPatch.RegisterEscape", ex.Message, ex);
			}
			return true;
		}
		catch (Exception ex2)
		{
			SettlementCombatLogger.Instance?.LogError("SettlementCombatBoundaryPatch.Prefix", ex2.Message, ex2);
			return true;
		}
	}
}
