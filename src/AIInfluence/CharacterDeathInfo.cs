using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class CharacterDeathInfo
{
	[JsonProperty("should_die")]
	public bool ShouldDie { get; set; }

	[JsonProperty("death_reason")]
	public string DeathReason { get; set; }

	[JsonProperty("killer_string_id")]
	public string KillerStringId { get; set; }

	/// <summary>Single attribute for opposed check when player is killer. AI chooses: vigor, endurance, control, cunning, intelligence, social.</summary>
	[JsonProperty("opposed_attribute")]
	public string OpposedAttribute { get; set; }
}
