namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class DeathInfo
{
	public string HeroName { get; set; }

	public string HeroStringId { get; set; }

	public string Title { get; set; }

	public string DeathCause { get; set; }

	public string KillerName { get; set; }

	public string KillerStringId { get; set; }

	public string KingdomName { get; set; }

	public string KingdomStringId { get; set; }

	public int DaysAgo { get; set; }
}
