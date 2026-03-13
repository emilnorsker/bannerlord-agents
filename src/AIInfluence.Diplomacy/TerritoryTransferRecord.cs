using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class TerritoryTransferRecord
{
	[JsonProperty("settlement_id")]
	public string SettlementId { get; set; }

	[JsonProperty("settlement_name")]
	public string SettlementName { get; set; }

	[JsonProperty("from_kingdom_id")]
	public string FromKingdomId { get; set; }

	[JsonProperty("to_kingdom_id")]
	public string ToKingdomId { get; set; }

	[JsonProperty("transfer_time")]
	public CampaignTime TransferTime { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }
}
