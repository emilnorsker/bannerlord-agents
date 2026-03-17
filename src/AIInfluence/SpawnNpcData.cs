using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class SpawnNpcEquipment
{
	[JsonProperty("weapon")]
	public string Weapon { get; set; }

	[JsonProperty("shield")]
	public string Shield { get; set; }

	[JsonProperty("head")]
	public string Head { get; set; }

	[JsonProperty("body")]
	public string Body { get; set; }

	[JsonProperty("cape")]
	public string Cape { get; set; }

	[JsonProperty("gloves")]
	public string Gloves { get; set; }

	[JsonProperty("legs")]
	public string Legs { get; set; }

	[JsonProperty("horse")]
	public string Horse { get; set; }

	[JsonProperty("tier")]
	public int? Tier { get; set; }
}

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

	[JsonProperty("equipment")]
	public SpawnNpcEquipment Equipment { get; set; }

	[JsonProperty("party_name")]
	public string PartyName { get; set; }

	[JsonProperty("party_troops")]
	public List<string> PartyTroops { get; set; }

	[JsonProperty("party_size")]
	public int? PartySize { get; set; }
}
