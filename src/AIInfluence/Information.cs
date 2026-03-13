using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class Information
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("usageChance")]
	public int UsageChance { get; set; }

	[JsonProperty("applicableNPCs")]
	public List<string> ApplicableNPCs { get; set; }

	[JsonProperty("category")]
	public string Category { get; set; }
}
