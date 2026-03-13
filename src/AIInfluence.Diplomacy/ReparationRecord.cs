using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class ReparationRecord
{
	[JsonProperty("paying_kingdom_id")]
	public string PayingKingdomId { get; set; }

	[JsonProperty("receiving_kingdom_id")]
	public string ReceivingKingdomId { get; set; }

	[JsonProperty("amount")]
	public int Amount { get; set; }

	[JsonProperty("payment_time")]
	public CampaignTime PaymentTime { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }
}
