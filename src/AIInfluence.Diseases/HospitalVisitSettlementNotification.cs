using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.Diseases;

public static class HospitalVisitSettlementNotification
{
	public static event Action<Hero, Settlement> OnHeroVisitedHospital;

	public static event Action<Settlement, string, Hero, string> OnSettlementForceTreated;

	public static void NotifyHeroVisitedHospital(Hero hero, Settlement settlement)
	{
		if (hero != null && settlement != null)
		{
			HospitalVisitSettlementNotification.OnHeroVisitedHospital?.Invoke(hero, settlement);
		}
	}

	public static void NotifySettlementForceTreated(Settlement settlement, string targetType, Hero lordHero = null, string ownerDisplayName = null)
	{
		if (settlement != null && !string.IsNullOrEmpty(targetType))
		{
			HospitalVisitSettlementNotification.OnSettlementForceTreated?.Invoke(settlement, targetType, lordHero, ownerDisplayName);
		}
	}
}
