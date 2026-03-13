using System.Collections.Generic;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class KingdomDestructionInfo
{
	public string DestroyedKingdomId { get; set; }

	public string DestroyedKingdomName { get; set; }

	public string DestroyerKingdomId { get; set; }

	public string DestroyerKingdomName { get; set; }

	public string LastCapturedSettlementId { get; set; }

	public string LastCapturedSettlementName { get; set; }

	public string Method { get; set; }

	public CampaignTime DestructionTime { get; set; }

	public List<WarInfo> WarsInvolved { get; set; } = new List<WarInfo>();

	public CurrentWarInfo CurrentWar { get; set; }

	public List<string> DestroyedKingdomAllies { get; set; } = new List<string>();

	public List<string> DestroyerKingdomAllies { get; set; } = new List<string>();

	public WarLossesInfo WarLosses { get; set; }

	public bool PlayerInvolved { get; set; } = false;
}
