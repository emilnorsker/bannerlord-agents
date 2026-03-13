namespace AIInfluence;

[JsonSerializable]
public class PlayerInfo
{
	public string ClaimedName { get; set; }

	public string ClaimedClan { get; set; }

	public int ClaimedAge { get; set; }

	public int ClaimedGold { get; set; }

	public string RealName { get; set; }

	public string RealClan { get; set; }

	public int RealAge { get; set; }

	public string RealCulture { get; set; }

	public string RealGender { get; set; }

	public bool SuspectedLie { get; set; }

	public string RealKingdom { get; set; }

	public string RealKingdomId { get; set; }

	public bool IsMercenary { get; set; }

	public string PlayerStringId { get; set; }
}
