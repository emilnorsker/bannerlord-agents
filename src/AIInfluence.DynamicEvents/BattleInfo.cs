using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class BattleInfo
{
	public string AttackerKingdom { get; set; }

	public string DefenderKingdom { get; set; }

	public string BattleType { get; set; }

	public string Winner { get; set; }

	public string AttackerLeader { get; set; }

	public string DefenderLeader { get; set; }

	public string Location { get; set; }

	public int DaysAgo { get; set; }

	public int AttackerTroops { get; set; }

	public int DefenderTroops { get; set; }

	public int AttackerLosses { get; set; }

	public int DefenderLosses { get; set; }

	public CampaignTime BattleTime { get; set; }
}
