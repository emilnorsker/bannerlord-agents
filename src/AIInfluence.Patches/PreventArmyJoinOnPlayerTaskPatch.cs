using System;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(Army), "AddPartyToMergedParties")]
public static class PreventArmyJoinOnPlayerTaskPatch
{
	[HarmonyPrefix]
	public static bool Prefix(Army __instance, MobileParty mobileParty)
	{
		try
		{
			if (mobileParty == null || mobileParty.IsMainParty)
			{
				return true;
			}
			Hero leaderHero = mobileParty.LeaderHero;
			if (leaderHero == null)
			{
				return true;
			}
			bool flag = __instance != null && __instance.LeaderParty != null && __instance.LeaderParty.IsMainParty;
			TaskManager instance = TaskManager.Instance;
			if (instance == null)
			{
				return true;
			}
			HeroTask activeTask = instance.GetActiveTask(leaderHero);
			if (activeTask != null && activeTask.IsActive())
			{
				if (flag)
				{
					instance.CancelTask(leaderHero);
					AIActionManager.Instance?.StopAllActions(leaderHero);
					AIInfluenceBehavior.Instance?.LogMessage($"[ARMY_JOIN_PLAYER] {leaderHero.Name} joining player's army. Cancelled all active tasks and actions to allow army join.");
					return true;
				}
				AIInfluenceBehavior instance2 = AIInfluenceBehavior.Instance;
				if (instance2 != null)
				{
					TextObject name = leaderHero.Name;
					object obj;
					if (__instance == null)
					{
						obj = null;
					}
					else
					{
						MobileParty leaderParty = __instance.LeaderParty;
						if (leaderParty == null)
						{
							obj = null;
						}
						else
						{
							Hero leaderHero2 = leaderParty.LeaderHero;
							obj = ((leaderHero2 == null) ? null : ((object)leaderHero2.Name)?.ToString());
						}
					}
					if (obj == null)
					{
						obj = "unknown";
					}
					instance2.LogMessage(string.Format("[ARMY_JOIN_BLOCK] Prevented {0} from joining army (leader: {1}) because they have an active player task: {2}", name, obj, activeTask.Description ?? "No description"));
				}
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ARMY_JOIN_BLOCK] Error in PreventArmyJoinOnPlayerTaskPatch: " + ex.Message);
			return true;
		}
	}
}
