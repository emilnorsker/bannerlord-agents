using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.SettlementCombat;

[JsonSerializable]
public class CombatSituationAnalysis
{
	[JsonProperty("aggressor_string_id")]
	public string AggressorStringId { get; set; }

	[JsonProperty("defender_string_id")]
	public string DefenderStringId { get; set; }

	[JsonProperty("witnesses")]
	public List<string> Witnesses { get; set; }

	[JsonProperty("needs_defenders")]
	public bool NeedsDefenders { get; set; }

	[JsonProperty("civilian_panic")]
	public bool CivilianPanic { get; set; }

	[JsonProperty("lords")]
	public List<LordIntervention> Lords { get; set; }

	[JsonProperty("player_involved")]
	public bool PlayerInvolved { get; set; }

	[JsonProperty("situation_description")]
	public string SituationDescription { get; set; }

	[JsonProperty("civilian_phrases_male_panic")]
	public List<string> CivilianPhrasesMalePanic { get; set; }

	[JsonProperty("civilian_phrases_male_fight")]
	public List<string> CivilianPhrasesMaleFight { get; set; }

	[JsonProperty("civilian_phrases_female")]
	public List<string> CivilianPhrasesFemale { get; set; }

	[JsonProperty("civilian_phrases_child")]
	public List<string> CivilianPhrasesChild { get; set; }

	[JsonProperty("notable_phrases")]
	public Dictionary<string, List<string>> NotablePhrases { get; set; }

	[JsonProperty("companion_stance")]
	public Dictionary<string, string> CompanionStance { get; set; }
}
