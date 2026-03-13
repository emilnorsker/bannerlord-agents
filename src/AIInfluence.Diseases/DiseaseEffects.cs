using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.Diseases;

[JsonSerializable]
public class DiseaseEffects
{
	public static readonly string[] PhysicalSkills = new string[8] { "OneHanded", "TwoHanded", "Polearm", "Bow", "Crossbow", "Throwing", "Riding", "Athletics" };

	[JsonProperty("skill_modifiers")]
	public Dictionary<string, float> SkillModifiers { get; set; }

	[JsonProperty("combat_modifiers")]
	public CombatModifiers CombatModifiers { get; set; }

	[JsonProperty("map_modifiers")]
	public MapModifiers MapModifiers { get; set; }

	[JsonProperty("death_chance")]
	public float DeathChance { get; set; }

	public DiseaseEffects()
	{
		SkillModifiers = new Dictionary<string, float>();
		CombatModifiers = new CombatModifiers();
		MapModifiers = new MapModifiers();
	}

	public DiseaseEffects ScaleBy(float factor)
	{
		DiseaseEffects diseaseEffects = new DiseaseEffects
		{
			DeathChance = DeathChance * factor
		};
		foreach (KeyValuePair<string, float> skillModifier in SkillModifiers)
		{
			diseaseEffects.SkillModifiers[skillModifier.Key] = skillModifier.Value * factor;
		}
		diseaseEffects.CombatModifiers = new CombatModifiers
		{
			DamageMultiplier = 1f + (CombatModifiers.DamageMultiplier - 1f) * factor,
			DefenseMultiplier = 1f + (CombatModifiers.DefenseMultiplier - 1f) * factor,
			SpeedMultiplier = 1f + (CombatModifiers.SpeedMultiplier - 1f) * factor,
			AccuracyMultiplier = 1f + (CombatModifiers.AccuracyMultiplier - 1f) * factor
		};
		diseaseEffects.MapModifiers = new MapModifiers
		{
			MovementSpeedMultiplier = 1f + (MapModifiers.MovementSpeedMultiplier - 1f) * factor,
			MoraleModifier = MapModifiers.MoraleModifier * factor
		};
		return diseaseEffects;
	}

	public static DiseaseEffects Combine(List<DiseaseEffects> effectsList)
	{
		DiseaseEffects diseaseEffects = new DiseaseEffects();
		if (effectsList == null || effectsList.Count == 0)
		{
			return diseaseEffects;
		}
		foreach (DiseaseEffects effects in effectsList)
		{
			foreach (KeyValuePair<string, float> skillModifier in effects.SkillModifiers)
			{
				if (diseaseEffects.SkillModifiers.ContainsKey(skillModifier.Key))
				{
					diseaseEffects.SkillModifiers[skillModifier.Key] += skillModifier.Value;
				}
				else
				{
					diseaseEffects.SkillModifiers[skillModifier.Key] = skillModifier.Value;
				}
			}
		}
		List<string> list = new List<string>(diseaseEffects.SkillModifiers.Keys);
		foreach (string item in list)
		{
			if (diseaseEffects.SkillModifiers[item] < 0f)
			{
				diseaseEffects.SkillModifiers[item] = Math.Max(diseaseEffects.SkillModifiers[item], -50f);
			}
		}
		float num = 1f;
		float num2 = 1f;
		float num3 = 1f;
		float num4 = 1f;
		foreach (DiseaseEffects effects2 in effectsList)
		{
			num *= effects2.CombatModifiers.DamageMultiplier;
			num2 *= effects2.CombatModifiers.DefenseMultiplier;
			num3 *= effects2.CombatModifiers.SpeedMultiplier;
			num4 *= effects2.CombatModifiers.AccuracyMultiplier;
		}
		diseaseEffects.CombatModifiers.DamageMultiplier = Math.Max(0.5f, num);
		diseaseEffects.CombatModifiers.DefenseMultiplier = Math.Max(0.5f, num2);
		diseaseEffects.CombatModifiers.SpeedMultiplier = Math.Max(0.5f, num3);
		diseaseEffects.CombatModifiers.AccuracyMultiplier = Math.Max(0.5f, num4);
		float num5 = 1f;
		float num6 = 0f;
		foreach (DiseaseEffects effects3 in effectsList)
		{
			num5 *= effects3.MapModifiers.MovementSpeedMultiplier;
			num6 += effects3.MapModifiers.MoraleModifier;
		}
		diseaseEffects.MapModifiers.MovementSpeedMultiplier = Math.Max(0.5f, num5);
		diseaseEffects.MapModifiers.MoraleModifier = Math.Max(-50f, num6);
		foreach (DiseaseEffects effects4 in effectsList)
		{
			diseaseEffects.DeathChance += effects4.DeathChance;
		}
		diseaseEffects.DeathChance = Math.Min(1f, diseaseEffects.DeathChance);
		return diseaseEffects;
	}

	public DiseaseEffects GetPermanentModifiers()
	{
		return ScaleBy(0.5f);
	}
}
