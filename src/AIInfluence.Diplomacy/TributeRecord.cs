using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class TributeRecord
{
	[JsonProperty("payer_kingdom_id")]
	public string PayerKingdomId { get; set; }

	[JsonProperty("receiver_kingdom_id")]
	public string ReceiverKingdomId { get; set; }

	[JsonProperty("daily_amount")]
	public int DailyAmount { get; set; }

	[JsonProperty("start_time")]
	public CampaignTime StartTime { get; set; }

	[JsonProperty("end_time")]
	public CampaignTime EndTime { get; set; }

	[JsonProperty("duration_days")]
	public int DurationDays { get; set; }

	[JsonProperty("total_paid")]
	public int TotalPaid { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }
}
