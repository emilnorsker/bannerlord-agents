using Newtonsoft.Json;

namespace AIInfluence.Diseases;

[JsonSerializable]
public class CombatModifiers
{
	[JsonProperty("damage_multiplier")]
	public float DamageMultiplier { get; set; } = 1f;

	[JsonProperty("defense_multiplier")]
	public float DefenseMultiplier { get; set; } = 1f;

	[JsonProperty("speed_multiplier")]
	public float SpeedMultiplier { get; set; } = 1f;

	[JsonProperty("accuracy_multiplier")]
	public float AccuracyMultiplier { get; set; } = 1f;
}
