using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace AIInfluence;

public static class OpposedSkillCheck
{
	/// <summary>Parse AI attribute name to CharacterAttribute. Defaults to Vigor if invalid.</summary>
	public static CharacterAttribute ParseAttribute(string s)
	{
		if (string.IsNullOrWhiteSpace(s)) return DefaultCharacterAttributes.Vigor;
		return s.Trim().ToLowerInvariant() switch
		{
			"endurance" => DefaultCharacterAttributes.Endurance,
			"control" => DefaultCharacterAttributes.Control,
			"cunning" => DefaultCharacterAttributes.Cunning,
			"intelligence" => DefaultCharacterAttributes.Intelligence,
			"social" => DefaultCharacterAttributes.Social,
			_ => DefaultCharacterAttributes.Vigor
		};
	}

	/// <summary>Ability score from single attribute. Scaled to 0–200 range.</summary>
	public static int GetAbility(Hero hero, CharacterAttribute attr)
	{
		if (hero == null || attr == null) return 0;
		return hero.GetAttributeValue(attr) * 20;
	}

	/// <summary>
	/// Opposed ability check with crit modifiers.
	/// Nat 20 = success (5% chance when outmatched).
	/// Nat 1 = fail (5% chance when dominant).
	/// </summary>
	public static bool PlayerWins(Hero player, Hero npc, CharacterAttribute attr)
	{
		int playerAbility = GetAbility(player, attr);
		int npcAbility = GetAbility(npc, attr);

		int roll = MBRandom.RandomInt(1, 20);
		if (roll == 20) return true;
		if (roll == 1) return false;

		int dc = (npcAbility / 20) + MBRandom.RandomInt(1, 20);
		int playerTotal = roll + (playerAbility / 20);
		return playerTotal >= dc;
	}
}
