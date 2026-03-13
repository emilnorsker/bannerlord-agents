using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace AIInfluence;

public class HeroKilledData
{
	public Hero Victim { get; set; }

	public Hero Killer { get; set; }

	public KillCharacterActionDetail Detail { get; set; }

	public string BaseText { get; set; }

	public bool PlayerInvolved { get; set; }

	public string PlayerRoleTag { get; set; }
}
