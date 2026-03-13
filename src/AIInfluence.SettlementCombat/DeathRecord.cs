using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace AIInfluence.SettlementCombat;

public class DeathRecord
{
	public string VictimStringId { get; set; }

	public string VictimName { get; set; }

	public string VictimType { get; set; }

	public string KillerStringId { get; set; }

	public string KillerName { get; set; }

	public string KillerType { get; set; }

	public bool IsCivilian { get; set; }

	public CampaignTime DeathTime { get; set; }

	public KillCharacterActionDetail DeathDetail { get; set; }

	public CombatSide VictimSide { get; set; }

	public bool IsCivilianFemale { get; set; }

	public bool IsCivilianChild { get; set; }

	public bool IsImportant { get; set; }
}
