namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class MarriageInfo
{
	public string HusbandName { get; set; }

	public string HusbandStringId { get; set; }

	public string HusbandCulture { get; set; }

	public string HusbandKingdomName { get; set; }

	public string HusbandKingdomStringId { get; set; }

	public string WifeName { get; set; }

	public string WifeStringId { get; set; }

	public string WifeCulture { get; set; }

	public string WifeKingdomName { get; set; }

	public string WifeKingdomStringId { get; set; }

	public string PoliticalSignificance { get; set; }

	public int DaysAgo { get; set; }
}
