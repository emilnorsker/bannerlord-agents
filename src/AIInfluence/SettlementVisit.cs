using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

[JsonSerializable]
public class SettlementVisit
{
	[JsonProperty("SettlementId")]
	public string SettlementId { get; set; }

	[JsonProperty("SettlementName")]
	public string SettlementName { get; set; }

	[JsonProperty("VisitTimeDays")]
	public double VisitTimeDays { get; set; }

	[JsonIgnore]
	public CampaignTime VisitTime
	{
		get
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			return (VisitTimeDays <= 0.0) ? CampaignTime.Never : CampaignTime.Days((float)VisitTimeDays);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			VisitTimeDays = ((value == CampaignTime.Never) ? 0.0 : (value).ToDays);
		}
	}

	public SettlementVisit()
	{
	}

	public SettlementVisit(string settlementId, string settlementName, CampaignTime visitTime)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		SettlementId = settlementId;
		SettlementName = settlementName;
		VisitTime = visitTime;
	}

	public int GetDaysAgo()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (VisitTime == CampaignTime.Never)
		{
			return -1;
		}
		CampaignTime val = CampaignTime.Now;
		double toDays = (val).ToDays;
		val = VisitTime;
		return (int)(toDays - (val).ToDays);
	}
}
