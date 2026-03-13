using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class ExpulsionRecord
{
	[JsonProperty("clan_id")]
	public string ClanId { get; set; }

	[JsonProperty("kingdom_id")]
	public string KingdomId { get; set; }

	[JsonProperty("expulsion_date")]
	public CampaignTime ExpulsionDate { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }
}
