using System.Collections.Generic;

namespace AIInfluence.Diplomacy;

internal class KingdomDiplomaticData
{
	public string KingdomName { get; set; }

	public string KingdomId { get; set; }

	public string LeaderName { get; set; }

	public int CurrentTroops { get; set; }

	public int TotalCasualties { get; set; }

	public int PreviousCasualties { get; set; }

	public float WarFatigue { get; set; }

	public string WarFatigueDescription { get; set; }

	public float PeaceDesire { get; set; }

	public int ReadinessLevel { get; set; }

	public int DaysAtWar { get; set; }

	public int CurrentSettlements { get; set; }

	public int InitialSettlements { get; set; }

	public List<string> Allies { get; set; } = new List<string>();

	public string AllianceInfo { get; set; }

	public List<string> CurrentWars { get; set; } = new List<string>();

	public Dictionary<string, int> Relations { get; set; } = new Dictionary<string, int>();

	public List<string> PreviousStatements { get; set; } = new List<string>();

	public List<string> RecentDynamicEvents { get; set; } = new List<string>();
}
