using TaleWorlds.CampaignSystem;

namespace AIInfluence.SettlementCombat;

public class WoundRecord
{
	public string VictimStringId { get; set; }

	public string VictimName { get; set; }

	public string VictimType { get; set; }

	public string AttackerStringId { get; set; }

	public string AttackerName { get; set; }

	public string AttackerType { get; set; }

	public bool IsCivilian { get; set; }

	public CampaignTime WoundTime { get; set; }

	public CombatSide VictimSide { get; set; }

	public bool IsCivilianFemale { get; set; }

	public bool IsCivilianChild { get; set; }

	public bool IsImportant { get; set; }
}
