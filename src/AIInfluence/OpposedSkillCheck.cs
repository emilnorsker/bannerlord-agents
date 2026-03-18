using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace AIInfluence;

public enum OpposedActionType
{
	Combat,
	ArmWrestle,
	Poisoning
}

public static class OpposedSkillCheck
{
	private static readonly CharacterAttribute[] CombatAttributes = new[]
	{
		DefaultCharacterAttributes.Vigor,
		DefaultCharacterAttributes.Endurance,
		DefaultCharacterAttributes.Control
	};

	private static readonly CharacterAttribute[] ArmWrestleAttributes = new[]
	{
		DefaultCharacterAttributes.Vigor,
		DefaultCharacterAttributes.Endurance
	};

	private static readonly CharacterAttribute[] PoisoningAttributes = new[]
	{
		DefaultCharacterAttributes.Cunning,
		DefaultCharacterAttributes.Control,
		DefaultCharacterAttributes.Intelligence
	};

	private static CharacterAttribute[] GetAttributesForAction(OpposedActionType actionType)
	{
		return actionType switch
		{
			OpposedActionType.Combat => CombatAttributes,
			OpposedActionType.ArmWrestle => ArmWrestleAttributes,
			OpposedActionType.Poisoning => PoisoningAttributes,
			_ => CombatAttributes
		};
	}

	/// <summary>
	/// Ability score for the given action type. Scaled to 0–400 range.
	/// </summary>
	public static int GetAbility(Hero hero, OpposedActionType actionType)
	{
		if (hero == null) return 0;
		int sum = 0;
		foreach (CharacterAttribute attr in GetAttributesForAction(actionType))
		{
			sum += hero.GetAttributeValue(attr);
		}
		return sum * 20;
	}

	/// <summary>
	/// Opposed ability check with crit modifiers.
	/// Nat 20 = success (5% chance when outmatched).
	/// Nat 1 = fail (5% chance when dominant).
	/// </summary>
	public static bool PlayerWins(Hero player, Hero npc, OpposedActionType actionType)
	{
		int playerAbility = GetAbility(player, actionType);
		int npcAbility = GetAbility(npc, actionType);

		int roll = MBRandom.RandomInt(1, 20);
		if (roll == 20) return true;
		if (roll == 1) return false;

		int dc = (npcAbility / 20) + MBRandom.RandomInt(1, 20);
		int playerTotal = roll + (playerAbility / 20);
		return playerTotal >= dc;
	}

	/// <summary>
	/// Opposed combat check (convenience for lethal strike).
	/// </summary>
	public static bool PlayerWinsLethalStrike(Hero player, Hero npc)
	{
		return PlayerWins(player, npc, OpposedActionType.Combat);
	}

	/// <summary>Parse AI string to OpposedActionType. Defaults to Combat if invalid.</summary>
	public static OpposedActionType ParseActionType(string s)
	{
		if (string.IsNullOrWhiteSpace(s)) return OpposedActionType.Combat;
		return s.Trim().ToLowerInvariant() switch
		{
			"poisoning" => OpposedActionType.Poisoning,
			"arm_wrestle" => OpposedActionType.ArmWrestle,
			_ => OpposedActionType.Combat
		};
	}
}
