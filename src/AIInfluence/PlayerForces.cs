using System.Collections.Generic;

namespace AIInfluence;

[JsonSerializable]
public class PlayerForces
{
	public int PartySize { get; set; }

	public float WoundedPercentage { get; set; }

	public bool HasArmy { get; set; }

	public List<TroopDetail> TroopDetails { get; set; } = new List<TroopDetail>();
}
