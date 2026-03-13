using System;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace AIInfluence.Patches;

[HarmonyPatch]
public static class PreventCompanionKillOnBadRelationPatch
{
	[HarmonyPrepare]
	public static bool Prepare()
	{
		Type type = AccessTools.TypeByName("TaleWorlds.CampaignSystem.CampaignBehaviors.CompanionRolesCampaignBehavior");
		if (type == null)
		{
			return false;
		}
		MethodInfo methodInfo = AccessTools.Method(type, "OnHeroRelationChanged", (Type[])null, (Type[])null);
		return methodInfo != null;
	}

	[HarmonyTargetMethod]
	public static MethodInfo TargetMethod()
	{
		return AccessTools.Method(AccessTools.TypeByName("TaleWorlds.CampaignSystem.CampaignBehaviors.CompanionRolesCampaignBehavior"), "OnHeroRelationChanged", (Type[])null, (Type[])null);
	}

	[HarmonyPrefix]
	public static bool Prefix(Hero effectiveHero, Hero effectiveHeroGainedRelationWith, int relationChange, bool showNotification, ChangeRelationDetail detail, Hero originalHero, Hero originalGainedRelationWith)
	{
		try
		{
			if ((effectiveHero != Hero.MainHero || !effectiveHeroGainedRelationWith.IsPlayerCompanion) && (!effectiveHero.IsPlayerCompanion || effectiveHeroGainedRelationWith != Hero.MainHero))
			{
				return true;
			}
			if (relationChange < 0 && effectiveHero.GetRelation(effectiveHeroGainedRelationWith) < -10)
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}
}
