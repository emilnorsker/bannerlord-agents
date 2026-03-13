using System;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class ActiveEconomicEffect
{
	public string TargetType { get; set; }

	public string TargetId { get; set; }

	public float ProsperityDeltaPerDay { get; set; }

	public float FoodDeltaPerDay { get; set; }

	public float SecurityDeltaPerDay { get; set; }

	public float LoyaltyDeltaPerDay { get; set; }

	public float IncomeMultiplier { get; set; } = 1f;

	public float StartDay { get; set; }

	public int DurationDays { get; set; }

	public string Reason { get; set; }

	public int GetRemainingDays()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime now = CampaignTime.Now;
		float num = (float)((CampaignTime)(ref now)).ToDays;
		int val = DurationDays - (int)(num - StartDay);
		return Math.Max(0, val);
	}
}
