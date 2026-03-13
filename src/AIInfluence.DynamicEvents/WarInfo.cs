namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class WarInfo
{
	public string EnemyKingdomId { get; set; }

	public string EnemyKingdomName { get; set; }

	public int DurationDays { get; set; }
}
