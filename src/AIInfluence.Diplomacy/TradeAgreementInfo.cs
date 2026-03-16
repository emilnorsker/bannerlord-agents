using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class TradeAgreementInfo
{
	[JsonProperty("kingdom1_id")]
	public string Kingdom1Id { get; set; }

	[JsonProperty("kingdom2_id")]
	public string Kingdom2Id { get; set; }

	[JsonProperty("start_time_days")]
	public float StartTimeDays { get; set; }

	[JsonProperty("end_time_days")]
	public float EndTimeDays { get; set; }

	[JsonProperty("duration_years")]
	public float DurationYears { get; set; }

	[JsonIgnore]
	public CampaignTime StartTime
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			if (StartTimeDays > 0f)
			{
				_ = CampaignTime.Now;
				if (true)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)(now).ToDays;
					float num2 = num - StartTimeDays;
					return CampaignTime.DaysFromNow(0f - num2);
				}
			}
			return CampaignTime.Now;
		}
		set
		{
			StartTimeDays = (float)(value).ToDays;
		}
	}

	[JsonIgnore]
	public CampaignTime EndTime
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			if (EndTimeDays > 0f)
			{
				_ = CampaignTime.Now;
				if (true)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)(now).ToDays;
					float num2 = num - EndTimeDays;
					return CampaignTime.DaysFromNow(0f - num2);
				}
			}
			return CampaignTime.Now;
		}
		set
		{
			EndTimeDays = (float)(value).ToDays;
		}
	}
}
