using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class ReparationDemand
{
	[JsonProperty("demanding_kingdom_id")]
	public string DemandingKingdomId { get; set; }

	[JsonProperty("paying_kingdom_id")]
	public string PayingKingdomId { get; set; }

	[JsonProperty("amount")]
	public int Amount { get; set; }

	[JsonProperty("demand_time")]
	public CampaignTime DemandTime { get; set; }

	[JsonProperty("expiration_time")]
	public CampaignTime ExpirationTime { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }

	[JsonProperty("status")]
	public ReparationStatus Status { get; set; }
}
