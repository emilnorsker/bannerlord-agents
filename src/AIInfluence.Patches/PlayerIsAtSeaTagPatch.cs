using System;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace AIInfluence.Patches;

[HarmonyPatch]
public static class PlayerIsAtSeaTagPatch
{
	[HarmonyPrepare]
	public static bool Prepare()
	{
		Type type = AccessTools.TypeByName("TaleWorlds.CampaignSystem.Conversation.Tags.PlayerIsAtSeaTag");
		if (type == null)
		{
			return false;
		}
		MethodInfo methodInfo = AccessTools.Method(type, "IsApplicableTo", (Type[])null, (Type[])null);
		return methodInfo != null;
	}

	[HarmonyTargetMethod]
	public static MethodInfo TargetMethod()
	{
		return AccessTools.Method(AccessTools.TypeByName("TaleWorlds.CampaignSystem.Conversation.Tags.PlayerIsAtSeaTag"), "IsApplicableTo", (Type[])null, (Type[])null);
	}

	public static bool Prefix(ref bool __result)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		try
		{
			if (Hero.MainHero == null)
			{
				__result = false;
				return false;
			}
			Hero mainHero = Hero.MainHero;
			MobileParty val = null;
			if (mainHero.IsPrisoner)
			{
				PartyBase partyBelongedToAsPrisoner = mainHero.PartyBelongedToAsPrisoner;
				val = ((partyBelongedToAsPrisoner != null) ? partyBelongedToAsPrisoner.MobileParty : null);
			}
			else
			{
				val = mainHero.PartyBelongedTo;
			}
			if (val == null)
			{
				__result = false;
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Error in PlayerIsAtSeaTag fix: " + ex.Message));
			__result = false;
			return false;
		}
	}
}
