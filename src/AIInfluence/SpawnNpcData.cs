using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class SpawnNpcData
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("culture")]
	public string Culture { get; set; }

	[JsonProperty("is_female")]
	public bool? IsFemale { get; set; }

	[JsonProperty("age")]
	public int? Age { get; set; }

	[JsonProperty("occupation")]
	public string Occupation { get; set; }

	[JsonProperty("backstory")]
	public string Backstory { get; set; }

	[JsonProperty("personality")]
	public string Personality { get; set; }

	[JsonProperty("alignment")]
	public string Alignment { get; set; }

	[JsonProperty("faction")]
	public string Faction { get; set; }

	[JsonProperty("settlement")]
	public string Settlement { get; set; }

	[JsonProperty("party_name")]
	public string PartyName { get; set; }

	[JsonProperty("party_troops")]
	public List<string> PartyTroops { get; set; }

	[JsonProperty("party_size")]
	public int? PartySize { get; set; }
}
