using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence;

public class PrisonerEventData
{
	public Hero Prisoner { get; set; }

	public Hero Participant { get; set; }

	public Settlement Location { get; set; }

	public bool IsPlayerInvolved { get; set; }

	public string Description { get; set; }

	public string Type { get; set; }
}
