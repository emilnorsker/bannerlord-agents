using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diseases;

public static class KillCharacterAction
{
	public static void ApplyByOldAge(Hero hero, bool showNotification = true)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null || !hero.IsAlive)
		{
			return;
		}
		try
		{
			KillCharacterAction.ApplyByOldAge(hero, showNotification);
		}
		catch (Exception ex)
		{
			DiseaseLogger.Instance?.Log($"[DISEASE_MANAGER] Error killing hero {hero.Name} (StringId: {((MBObjectBase)hero).StringId}, IsLord: {hero.IsLord}, IsNotable: {hero.IsNotable}, Occupation: {hero.Occupation}): {ex.Message}");
		}
	}
}
