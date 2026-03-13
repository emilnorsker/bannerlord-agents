namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class ArmyInfo
{
	public string ArmyName { get; set; }

	public int TotalTroops { get; set; }

	public string LeaderName { get; set; }

	public string LeaderStringId { get; set; }

	public string KingdomName { get; set; }

	public string KingdomStringId { get; set; }

	public string Location { get; set; }

	public string Target { get; set; }

	public int PartyCount { get; set; }

	public bool IsDisorganized { get; set; }

	public float Morale { get; set; }

	public string Objective { get; set; }
}
