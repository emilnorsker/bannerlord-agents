using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public class NPCEraseInfo
{
	public string StringId { get; set; }

	public string Name { get; set; }

	public string FilePath { get; set; }

	public Hero Hero { get; set; }

	public NPCContext Context { get; set; }

	public int InteractionCount { get; set; }

	public bool HasConversationHistory { get; set; }

	public bool HasKnownSecrets { get; set; }

	public bool HasKnownInfo { get; set; }

	public bool HasEvents { get; set; }
}
