using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class WorldSecret
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("knowledgeChance")]
	public int KnowledgeChance { get; set; }

	[JsonProperty("applicableNPCs")]
	public List<string> ApplicableNPCs { get; set; }

	[JsonProperty("accessLevel")]
	public string AccessLevel { get; set; }

	[JsonProperty("tags")]
	public List<string> Tags { get; set; }
}
