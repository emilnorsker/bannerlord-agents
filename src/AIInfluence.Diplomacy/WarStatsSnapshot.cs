using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

[JsonSerializable]
public class WarStatsSnapshot
{
	[JsonProperty("timestamp_days")]
	public float TimestampDays { get; set; }

	[JsonIgnore]
	public CampaignTime Timestamp
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
			if (TimestampDays > 0f)
			{
				_ = CampaignTime.Now;
				if (true)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)((CampaignTime)(ref now)).ToDays;
					float num2 = num - TimestampDays;
					return CampaignTime.DaysFromNow(0f - num2);
				}
			}
			return CampaignTime.Now;
		}
		set
		{
			bool flag = true;
			TimestampDays = (float)((CampaignTime)(ref value)).ToDays;
		}
	}

	[JsonProperty("troops")]
	public int Troops { get; set; }

	[JsonProperty("casualties")]
	public int Casualties { get; set; }

	[JsonProperty("lords_captured")]
	public int LordsCaptured { get; set; }

	[JsonProperty("lords_killed")]
	public int LordsKilled { get; set; }

	[JsonProperty("settlements_lost")]
	public int SettlementsLost { get; set; }

	[JsonProperty("caravans_destroyed")]
	public int CaravansDestroyed { get; set; }

	public WarStatsSnapshot()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		Timestamp = CampaignTime.Now;
	}
}
