using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

[JsonSerializable]
public class CampaignEvent
{
	public string Type { get; set; }

	public string Description { get; set; }

	public CampaignTime Timestamp { get; set; }

	[JsonProperty("EventTimeDays")]
	public double EventTimeDays
	{
		get
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				double result;
				if (!(Timestamp != CampaignTime.Never))
				{
					result = 0.0;
				}
				else
				{
					CampaignTime timestamp = Timestamp;
					result = (timestamp).ToDays;
				}
				return result;
			}
			catch
			{
				return 0.0;
			}
		}
		set
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			if (value > 0.0)
			{
				CampaignTime now = CampaignTime.Now;
				double num = (now).ToDays - value;
				Timestamp = CampaignTime.DaysFromNow(0f - (float)num);
			}
			else
			{
				Timestamp = CampaignTime.Now;
			}
		}
	}

	public bool ShouldSerializeTimestamp()
	{
		return false;
	}
}
