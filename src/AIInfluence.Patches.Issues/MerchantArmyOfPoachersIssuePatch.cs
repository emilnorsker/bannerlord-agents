using System;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.Patches.Issues;

[HarmonyPatch]
public static class MerchantArmyOfPoachersIssuePatch
{
	private static Type GetIssueType()
	{
		Type type = typeof(IssueBase).Assembly.GetType("TaleWorlds.CampaignSystem.Issues.MerchantArmyOfPoachersIssueBehavior");
		if (type != null)
		{
			Type[] nestedTypes = type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);
			Type[] array = nestedTypes;
			foreach (Type type2 in array)
			{
				if (type2.Name == "MerchantArmyOfPoachersIssue" && typeof(IssueBase).IsAssignableFrom(type2))
				{
					return type2;
				}
			}
		}
		return null;
	}

	private static MethodBase TargetMethod()
	{
		Type issueType = GetIssueType();
		if (issueType != null)
		{
			MethodInfo methodInfo = AccessTools.Method(issueType, "IssueStayAliveConditions", (Type[])null, (Type[])null);
			if (methodInfo != null)
			{
				LogMessage("[MerchantArmyOfPoachersIssuePatch] Patch successfully found and will be applied");
			}
			else
			{
				LogMessage("[MerchantArmyOfPoachersIssuePatch] WARNING: Type found, but method IssueStayAliveConditions not found");
			}
			return methodInfo;
		}
		LogMessage("[MerchantArmyOfPoachersIssuePatch] INFO: Type MerchantArmyOfPoachersIssue not found (possibly different game version)");
		return null;
	}

	private static bool Prefix(IssueBase __instance, ref bool __result)
	{
		try
		{
			Hero val = ((__instance != null) ? __instance.IssueOwner : null);
			if (val == null)
			{
				__result = false;
				return false;
			}
			Settlement currentSettlement = val.CurrentSettlement;
			if (currentSettlement == null)
			{
				__result = false;
				return false;
			}
			Town town = currentSettlement.Town;
			if (town == null)
			{
				__result = false;
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			LogMessage("[MerchantArmyOfPoachersIssuePatch] Error in Prefix: " + ex.Message);
			__result = false;
			return false;
		}
	}

	private static void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
