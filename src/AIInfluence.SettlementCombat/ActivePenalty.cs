using System;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.SettlementCombat;

public class ActivePenalty
{
	public string SettlementId { get; set; }

	public float ProsperityPenaltyPerDay { get; set; }

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

	public bool IsActive()
	{
		return GetRemainingDays() > 0;
	}
}
