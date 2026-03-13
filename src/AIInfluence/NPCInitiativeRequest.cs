using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public class NPCInitiativeRequest
{
	public Hero NPC { get; set; }

	public NPCContext Context { get; set; }

	public bool IsInParty { get; set; }

	public CampaignTime CreatedTime { get; set; }
}
