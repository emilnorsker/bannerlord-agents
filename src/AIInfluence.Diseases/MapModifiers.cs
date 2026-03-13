using Newtonsoft.Json;

namespace AIInfluence.Diseases;

[JsonSerializable]
public class MapModifiers
{
	[JsonProperty("movement_speed_multiplier")]
	public float MovementSpeedMultiplier { get; set; } = 1f;

	[JsonProperty("morale_modifier")]
	public float MoraleModifier { get; set; } = 0f;
}
