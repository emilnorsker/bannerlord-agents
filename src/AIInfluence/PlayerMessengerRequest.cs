using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public class PlayerMessengerRequest
{
	public Hero TargetNPC { get; set; }

	public NPCContext Context { get; set; }

	public int Cost { get; set; }

	public float Distance { get; set; }

	public string PlayerMessage { get; set; }

	public CampaignTime SentTime { get; set; }
}
