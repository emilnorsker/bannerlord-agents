using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public class PendingPlayerLetter
{
	public string TargetNPCStringId { get; set; }

	public string PlayerMessage { get; set; }

	public CampaignTime SentTime { get; set; }

	public CampaignTime ExpectedArrivalTime { get; set; }

	public float Distance { get; set; }
}
