namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class WarLossesInfo
{
	public int DestroyedKingdomTroopsLost { get; set; }

	public int DestroyedKingdomCasualtiesInThisWar { get; set; }

	public int DestroyedKingdomLordsCaptured { get; set; }

	public int DestroyedKingdomLordsKilled { get; set; }

	public int DestroyedKingdomSettlementsLost { get; set; }

	public int DestroyedKingdomCaravansDestroyed { get; set; }

	public float DestroyedKingdomWarFatigue { get; set; }

	public int DestroyerKingdomTroopsLost { get; set; }

	public int DestroyerKingdomCasualtiesInThisWar { get; set; }

	public int DestroyerKingdomLordsCaptured { get; set; }

	public int DestroyerKingdomLordsKilled { get; set; }

	public int DestroyerKingdomSettlementsLost { get; set; }

	public int DestroyerKingdomCaravansDestroyed { get; set; }

	public float DestroyerKingdomWarFatigue { get; set; }
}
