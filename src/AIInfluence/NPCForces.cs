using System.Collections.Generic;

namespace AIInfluence;

[JsonSerializable]
public class NPCForces
{
	public int PartySize { get; set; }

	public float WoundedPercentage { get; set; }

	public bool HasArmy { get; set; }

	public string ArmyDetails { get; set; }

	public List<TroopDetail> TroopDetails { get; set; } = new List<TroopDetail>();
}
