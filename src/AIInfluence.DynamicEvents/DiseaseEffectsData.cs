using Newtonsoft.Json;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class DiseaseEffectsData
{
	[JsonProperty("physical_skill_penalty")]
	public float PhysicalSkillPenalty { get; set; } = 0f;

	[JsonProperty("combat_damage_modifier")]
	public float CombatDamageModifier { get; set; } = 1f;

	[JsonProperty("combat_defense_modifier")]
	public float CombatDefenseModifier { get; set; } = 1f;

	[JsonProperty("combat_speed_modifier")]
	public float CombatSpeedModifier { get; set; } = 1f;

	[JsonProperty("map_speed_modifier")]
	public float MapSpeedModifier { get; set; } = 1f;

	[JsonProperty("morale_modifier")]
	public float MoraleModifier { get; set; } = 0f;

	[JsonProperty("death_chance")]
	public float DeathChance { get; set; } = 0f;
}
