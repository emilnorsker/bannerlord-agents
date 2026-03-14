using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

[JsonSerializable]
public class WarStatsAgainstKingdom
{
	[JsonProperty("enemy_kingdom_id")]
	public string EnemyKingdomId { get; set; }

	[JsonProperty("casualties_against_this_kingdom")]
	public int CasualtiesAgainstThisKingdom { get; set; }

	[JsonProperty("previous_casualties_against_this_kingdom")]
	public int PreviousCasualtiesAgainstThisKingdom { get; set; }

	[JsonProperty("war_start_time_days")]
	public float WarStartTimeDays { get; set; }

	[JsonProperty("is_active")]
	public bool IsActive { get; set; } = true;

	[JsonIgnore]
	public CampaignTime WarStartTime
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
			if (WarStartTimeDays > 0f)
			{
				_ = CampaignTime.Now;
				if (true)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)(now).ToDays;
					float num2 = num - WarStartTimeDays;
					return CampaignTime.DaysFromNow(0f - num2);
				}
			}
			return CampaignTime.Now;
		}
		set
		{
			bool flag = true;
			WarStartTimeDays = (float)(value).ToDays;
		}
	}
}
