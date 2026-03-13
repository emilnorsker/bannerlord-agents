using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence;

public class SettlementCaptureData
{
	public Settlement Settlement { get; set; }

	public Hero NewOwner { get; set; }

	public Hero PreviousOwner { get; set; }

	public Clan NewClan { get; set; }

	public Clan PreviousClan { get; set; }

	public bool PlayerInvolved { get; set; }

	public string PlayerRoleTag { get; set; }
}
