using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class SettlementCaptureInfo
{
	public string SettlementId { get; set; }

	public string SettlementName { get; set; }

	public string CapturerKingdomId { get; set; }

	public string CapturerKingdomName { get; set; }

	public CampaignTime CaptureTime { get; set; }
}
