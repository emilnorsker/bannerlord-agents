namespace AIInfluence;

[JsonSerializable]
public class TroopDetail
{
	public string Name { get; set; }

	public string StringId { get; set; }

	public int Count { get; set; }

	public int WoundedCount { get; set; }
}
