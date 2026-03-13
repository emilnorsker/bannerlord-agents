using System.Collections.Generic;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

[JsonSerializable]
public class SettlementCombatInfo
{
	public string SettlementName { get; set; }

	public SettlementCombatHandler.SettlementCombatType CombatType { get; set; }

	public CampaignTime StartTime { get; set; }

	public List<string> Events { get; set; } = new List<string>();
}
