using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(MobileParty), "get_SpeedExplained")]
public static class PartySpeedExplainedBugFixPatch
{
	private static readonly FieldRef<MobileParty, float> LastCalculatedSpeedRef = AccessTools.FieldRefAccess<MobileParty, float>("_lastCalculatedSpeed");

	[HarmonyPrefix]
	public static bool Prefix(MobileParty __instance, ref ExplainedNumber __result)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ExplainedNumber val = Campaign.Current.Models.PartySpeedCalculatingModel.CalculateBaseSpeed(__instance, true, 0, 0);
			val = Campaign.Current.Models.PartySpeedCalculatingModel.CalculateFinalSpeed(__instance, val);
			LastCalculatedSpeedRef.Invoke(__instance) = ((ExplainedNumber)(ref val)).ResultNumber;
			__result = val;
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}
}
