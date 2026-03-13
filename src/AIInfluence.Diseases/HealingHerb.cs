using System.Collections.Generic;
using Newtonsoft.Json;
using TaleWorlds.Localization;

namespace AIInfluence.Diseases;

[JsonSerializable]
public class HealingHerb
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("strength")]
	public int Strength { get; set; }

	[JsonProperty("cost")]
	public int Cost { get; set; }

	[JsonProperty("duration_days")]
	public int DurationDays { get; set; }

	[JsonProperty("immunity_bonus")]
	public float ImmunityBonus { get; set; }

	public HealingHerb()
	{
	}

	public HealingHerb(string id, string name, string description, int strength, int cost, int durationDays, float immunityBonus)
	{
		Id = id;
		Name = name;
		Description = description;
		Strength = strength;
		Cost = cost;
		DurationDays = durationDays;
		ImmunityBonus = immunityBonus;
	}

	public static HealingHerb[] GetPredefinedHerbs()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		return new HealingHerb[5]
		{
			new HealingHerb("herb_common", ((object)new TextObject("{=AIInfluence_Herb_Common}Common herbs", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Herb_CommonDesc}Simple healing herbs found in any area. Provide slight protection from diseases.", (Dictionary<string, object>)null)).ToString(), 1, 100, 7, 0.05f),
			new HealingHerb("herb_rare", ((object)new TextObject("{=AIInfluence_Herb_Rare}Rare herbs", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Herb_RareDesc}Herbs that are not often found. Strengthen the body and help resist disease.", (Dictionary<string, object>)null)).ToString(), 2, 300, 10, 0.1f),
			new HealingHerb("herb_valuable", ((object)new TextObject("{=AIInfluence_Herb_Valuable}Valuable herbs", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Herb_ValuableDesc}Gathered by experienced herbalists, these plants have strong healing properties.", (Dictionary<string, object>)null)).ToString(), 3, 700, 12, 0.15f),
			new HealingHerb("herb_exceptional", ((object)new TextObject("{=AIInfluence_Herb_Exceptional}Exceptional herbs", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Herb_ExceptionalDesc}Extremely rare plants with unique properties. Significantly strengthen immunity.", (Dictionary<string, object>)null)).ToString(), 4, 1500, 14, 0.2f),
			new HealingHerb("herb_legendary", ((object)new TextObject("{=AIInfluence_Herb_Legendary}Legendary herbs", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Herb_LegendaryDesc}Rarest plants from distant lands. Said to protect even from the most terrible diseases.", (Dictionary<string, object>)null)).ToString(), 5, 3000, 14, 0.25f)
		};
	}

	public float GetTreatmentRecoveryBonus()
	{
		return Strength switch
		{
			1 => 1f, 
			2 => 1.3f, 
			3 => 1.6f, 
			4 => 2f, 
			5 => 2.5f, 
			_ => 1f, 
		};
	}

	public int GetMinProsperityRequired()
	{
		switch (Strength)
		{
		case 1:
		case 2:
			return 0;
		case 3:
			return 2000;
		case 4:
			return 3000;
		case 5:
			return int.MaxValue;
		default:
			return 0;
		}
	}

	public bool RequiresCapital()
	{
		return Strength >= 5;
	}
}
