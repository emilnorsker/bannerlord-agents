namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class CurrentWarInfo
{
	public int DurationDays { get; set; }

	public int DestroyedKingdomCasualties { get; set; }

	public int DestroyerKingdomCasualties { get; set; }
}
