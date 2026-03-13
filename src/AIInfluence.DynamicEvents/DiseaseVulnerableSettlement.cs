namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class DiseaseVulnerableSettlement
{
	public string SettlementName { get; set; }

	public string SettlementStringId { get; set; }

	public string SettlementType { get; set; }

	public string KingdomName { get; set; }

	public string KingdomStringId { get; set; }

	public string Culture { get; set; }

	public string VulnerabilityLevel { get; set; }

	public string RiskFactors { get; set; }

	public string RulerName { get; set; }

	public string RulerStringId { get; set; }
}
