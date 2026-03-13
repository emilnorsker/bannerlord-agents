namespace AIInfluence.Diplomacy;

[JsonSerializable]
public class WarStatistics
{
	public string Kingdom1Id { get; set; }

	public string Kingdom2Id { get; set; }

	public int Kingdom1Casualties { get; set; }

	public int Kingdom2Casualties { get; set; }

	public int Kingdom1Troops { get; set; }

	public int Kingdom2Troops { get; set; }

	public float Kingdom1WarFatigue { get; set; }

	public float Kingdom2WarFatigue { get; set; }

	public int DaysAtWar { get; set; }
}
