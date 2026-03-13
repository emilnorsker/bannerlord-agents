using System.Collections.Generic;
using AIInfluence.Diseases;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SceneInformationPopupTypes;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch(typeof(DeathOldAgeSceneNotificationItem), "get_TitleText")]
public static class PlayerDiseaseDeathNotificationPatch
{
	[HarmonyPostfix]
	public static void Postfix(ref TextObject __result)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		try
		{
			string pendingPlayerDiseaseDeathName = DiseaseManager.PendingPlayerDiseaseDeathName;
			if (pendingPlayerDiseaseDeathName != null)
			{
				GameTexts.SetVariable("DISEASE_NAME", pendingPlayerDiseaseDeathName);
				__result = new TextObject("{=AIInfluence_str_died_of_disease}In {DAY_OF_YEAR}, {YEAR}, {NAME} died from {DISEASE_NAME}.", (Dictionary<string, object>)null);
			}
		}
		catch
		{
		}
	}
}
