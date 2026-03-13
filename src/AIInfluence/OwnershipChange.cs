using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public class OwnershipChange
{
	[JsonProperty("FromKingdomId")]
	public string FromKingdomId { get; set; }

	[JsonProperty("FromKingdomName")]
	public string FromKingdomName { get; set; }

	[JsonProperty("ToKingdomId")]
	public string ToKingdomId { get; set; }

	[JsonProperty("ToKingdomName")]
	public string ToKingdomName { get; set; }

	[JsonProperty("ChangeDate")]
	public CampaignTime ChangeDate { get; set; }

	[JsonProperty("ChangeReason")]
	public string ChangeReason { get; set; }

	[JsonProperty("CapturerHeroId")]
	public string CapturerHeroId { get; set; }

	[JsonProperty("CapturerHeroName")]
	public string CapturerHeroName { get; set; }

	[JsonProperty("CapturerClanId")]
	public string CapturerClanId { get; set; }

	[JsonProperty("CapturerClanName")]
	public string CapturerClanName { get; set; }
}
