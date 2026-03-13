using System.Collections.Generic;
using AIInfluence.Diseases;
using HarmonyLib;
using Helpers;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch(typeof(CharacterKilledLogEntry), "GetNotificationText")]
public static class DiseaseDeathNotificationTextPatch
{
	[HarmonyPostfix]
	public static void Postfix(CharacterKilledLogEntry __instance, ref TextObject __result)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		try
		{
			if (__instance.Victim != null && DiseaseManager.PendingDiseaseDeathNames.TryGetValue(((MBObjectBase)__instance.Victim).StringId, out var value))
			{
				TextObject val = new TextObject("{=AIInfluence_HeroDiedFromDisease}{VICTIM.NAME} died from {DISEASE_NAME}. {?VICTIM.GENDER}Her{?}His{\\?} family and friends will remember {?VICTIM.GENDER}her{?}him{\\?}.", (Dictionary<string, object>)null);
				StringHelpers.SetCharacterProperties("VICTIM", __instance.Victim.CharacterObject, val, false);
				val.SetTextVariable("DISEASE_NAME", value);
				__result = val;
			}
		}
		catch
		{
		}
	}
}
