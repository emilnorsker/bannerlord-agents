using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

[JsonSerializable]
public class SimpleCampaignTime
{
	[JsonProperty("Year")]
	public int Year { get; set; }

	[JsonProperty("DayOfYear")]
	public int DayOfYear { get; set; }

	[JsonProperty("Hour")]
	public int Hour { get; set; }

	[JsonProperty("TotalDays")]
	public double TotalDays { get; set; }

	public SimpleCampaignTime()
	{
	}

	public SimpleCampaignTime(CampaignTime campaignTime)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (campaignTime != CampaignTime.Never)
			{
				Year = ((CampaignTime)(ref campaignTime)).GetYear;
				DayOfYear = ((CampaignTime)(ref campaignTime)).GetDayOfYear;
				Hour = ((CampaignTime)(ref campaignTime)).GetHourOfDay;
				TotalDays = ((CampaignTime)(ref campaignTime)).ToDays;
			}
		}
		catch
		{
		}
	}

	public double GetDaysFromNow()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime now = CampaignTime.Now;
		return ((CampaignTime)(ref now)).ToDays - TotalDays;
	}
}
