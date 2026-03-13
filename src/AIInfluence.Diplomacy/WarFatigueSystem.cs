using System;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class WarFatigueSystem
{
	private static WarFatigueSystem _instance;

	public static WarFatigueSystem Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new WarFatigueSystem();
			}
			return _instance;
		}
	}

	private WarFatigueSystem()
	{
	}

	public string GetWarFatigueDescription(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return "unknown";
		}
		KingdomWarStats kingdomStats = WarStatisticsTracker.Instance.GetKingdomStats(kingdom);
		if (kingdomStats == null || kingdomStats.WarFatigue < 10f)
		{
			return "fresh and ready for battle";
		}
		if (kingdomStats.WarFatigue < 30f)
		{
			return "lightly fatigued but still capable";
		}
		if (kingdomStats.WarFatigue < 50f)
		{
			return "moderately fatigued from ongoing conflicts";
		}
		if (kingdomStats.WarFatigue < 70f)
		{
			return "heavily fatigued and war-weary";
		}
		if (kingdomStats.WarFatigue < 90f)
		{
			return "severely exhausted from prolonged warfare";
		}
		return "on the brink of collapse from war exhaustion";
	}

	public float CalculatePeaceDesire(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return 0f;
		}
		KingdomWarStats kingdomStats = WarStatisticsTracker.Instance.GetKingdomStats(kingdom);
		if (kingdomStats == null)
		{
			return 0f;
		}
		float num = kingdomStats.WarFatigue / 100f;
		if (kingdomStats.InitialSettlements > 0)
		{
			int num2 = kingdomStats.InitialSettlements - kingdomStats.CurrentSettlements;
			if (num2 > 0)
			{
				float num3 = (float)num2 / (float)kingdomStats.InitialSettlements;
				num += num3 * 0.3f;
			}
		}
		if (kingdomStats.PreviousCasualties > 0 && kingdomStats.TotalCasualties > kingdomStats.PreviousCasualties)
		{
			float num4 = (float)(kingdomStats.TotalCasualties - kingdomStats.PreviousCasualties) / (float)kingdomStats.PreviousCasualties;
			if (num4 > 0.1f)
			{
				num += 0.15f;
			}
		}
		return Math.Min(num, 1f);
	}

	public string GetDetailedWarFatigueInfo(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return "Kingdom is null";
		}
		KingdomWarStats kingdomStats = WarStatisticsTracker.Instance.GetKingdomStats(kingdom);
		if (kingdomStats == null)
		{
			return $"{kingdom.Name}: No war statistics available";
		}
		int num = 0;
		if (kingdomStats.WarsAgainstKingdoms != null)
		{
			foreach (WarStatsAgainstKingdom value in kingdomStats.WarsAgainstKingdoms.Values)
			{
				if (value != null && value.IsActive)
				{
					num += value.CasualtiesAgainstThisKingdom;
				}
			}
		}
		float num2 = (float)num * GlobalSettings<ModSettings>.Instance.FatiguePerTroopLost;
		float num3 = (float)kingdomStats.TotalLordsCaptured * GlobalSettings<ModSettings>.Instance.FatiguePerLordCaptured;
		float num4 = (float)kingdomStats.TotalLordsKilled * GlobalSettings<ModSettings>.Instance.FatiguePerLordKilled;
		float num5 = (float)Math.Max(0, kingdomStats.TotalSettlementsLost) * GlobalSettings<ModSettings>.Instance.FatiguePerSettlementLost;
		float num6 = (float)kingdomStats.TotalCaravansDestroyed * GlobalSettings<ModSettings>.Instance.FatiguePerCaravanDestroyed;
		int num7 = Math.Max(0, kingdomStats.InitialSettlements - kingdomStats.CurrentSettlements);
		return $"{kingdom.Name} War Fatigue Breakdown:\n" + $"  - Total Fatigue: {kingdomStats.WarFatigue:F1}% (base from previous wars: {kingdomStats.BaseFatigue:F1}%)\n" + $"  - Casualties (active wars): {num} → {num2:F1}% fatigue\n" + $"  - Lords Captured: {kingdomStats.TotalLordsCaptured} → {num3:F1}% fatigue\n" + $"  - Lords Killed: {kingdomStats.TotalLordsKilled} → {num4:F1}% fatigue\n" + $"  - Settlements Lost: {num7} → {num5:F1}% fatigue\n" + $"  - Caravans Destroyed: {kingdomStats.TotalCaravansDestroyed} → {num6:F1}% fatigue\n" + $"  - Days at War: {kingdomStats.DaysAtWar}\n" + $"  - Current Troops: {kingdomStats.CurrentTroops}\n" + $"  - Peace Desire: {CalculatePeaceDesire(kingdom) * 100f:F1}%";
	}

	public bool IsCloseToExhaustion(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return false;
		}
		KingdomWarStats kingdomStats = WarStatisticsTracker.Instance.GetKingdomStats(kingdom);
		if (kingdomStats == null)
		{
			return false;
		}
		return kingdomStats.WarFatigue > 75f;
	}

	public int GetReadinessLevel(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return 0;
		}
		KingdomWarStats kingdomStats = WarStatisticsTracker.Instance.GetKingdomStats(kingdom);
		if (kingdomStats == null)
		{
			return 4;
		}
		if (kingdomStats.WarFatigue >= 80f)
		{
			return 0;
		}
		if (kingdomStats.WarFatigue >= 60f)
		{
			return 1;
		}
		if (kingdomStats.WarFatigue >= 40f)
		{
			return 2;
		}
		if (kingdomStats.WarFatigue >= 20f)
		{
			return 3;
		}
		return 4;
	}

	private void LogMessage(string message)
	{
		DiplomacyLogger.Instance.Log(message);
	}
}
