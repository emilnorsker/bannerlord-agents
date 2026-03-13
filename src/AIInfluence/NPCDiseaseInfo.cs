using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class NPCDiseaseInfo
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("severity")]
	public int Severity { get; set; }

	[JsonProperty("progress")]
	public float Progress { get; set; }

	[JsonProperty("is_treated")]
	public bool IsTreated { get; set; }

	[JsonProperty("days_infected")]
	public int DaysInfected { get; set; }

	[JsonProperty("severity_description")]
	public string SeverityDescription => Severity switch
	{
		1 => "mild", 
		2 => "moderate", 
		3 => "serious", 
		4 => "severe", 
		5 => "critical", 
		_ => "unknown", 
	};
}
