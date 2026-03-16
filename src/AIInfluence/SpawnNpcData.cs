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

	[JsonProperty("clan_id")]
	public string ClanId { get; set; }

	[JsonProperty("spawn_near_settlement_id")]
	public string SpawnNearSettlementId { get; set; }

	[JsonProperty("party_name")]
	public string PartyName { get; set; }

	[JsonProperty("party_troop_names")]
	public List<string> PartyTroopNames { get; set; }

	[JsonProperty("party_size")]
	public int? PartySize { get; set; }
}
