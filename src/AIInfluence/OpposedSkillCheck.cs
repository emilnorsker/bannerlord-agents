using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace AIInfluence;

public static class OpposedSkillCheck
{
	private static readonly (string Name, CharacterAttribute Attr)[] AttributeMap = new[]
	{
		("vigor", DefaultCharacterAttributes.Vigor),
		("endurance", DefaultCharacterAttributes.Endurance),
		("control", DefaultCharacterAttributes.Control),
		("cunning", DefaultCharacterAttributes.Cunning),
		("intelligence", DefaultCharacterAttributes.Intelligence),
		("social", DefaultCharacterAttributes.Social)
	};

	/// <summary>Semantic synonyms for common LLM outputs. Checked before Levenshtein.</summary>
	private static readonly (string[] Synonyms, CharacterAttribute Attr)[] SynonymMap = new[]
	{
		(new[] { "strength", "physical", "might", "power" }, DefaultCharacterAttributes.Vigor),
		(new[] { "stamina", "health", "resilience" }, DefaultCharacterAttributes.Endurance),
		(new[] { "precision", "dexterity", "finesse" }, DefaultCharacterAttributes.Control),
		(new[] { "crafty", "clever", "deceptive", "guile" }, DefaultCharacterAttributes.Cunning),
		(new[] { "smartness", "intellect", "wisdom", "smart", "wit" }, DefaultCharacterAttributes.Intelligence),
		(new[] { "charm", "charisma", "persuasion" }, DefaultCharacterAttributes.Social)
	};

	/// <summary>Parse AI attribute name to CharacterAttribute. Synonym map + fuzzy fallback. Defaults to Vigor if invalid.</summary>
	public static CharacterAttribute ParseAttribute(string s)
	{
		if (string.IsNullOrWhiteSpace(s)) return DefaultCharacterAttributes.Vigor;
		string key = s.Trim().ToLowerInvariant();
		foreach (var (name, attr) in AttributeMap)
			if (name == key) return attr;
		foreach (var (synonyms, attr) in SynonymMap)
			foreach (string syn in synonyms)
				if (syn == key) return attr;
		int bestDist = int.MaxValue;
		CharacterAttribute best = DefaultCharacterAttributes.Vigor;
		foreach (var (name, attr) in AttributeMap)
		{
			int d = Levenshtein(key, name);
			if (d < bestDist) { bestDist = d; best = attr; }
		}
		return bestDist <= 4 ? best : DefaultCharacterAttributes.Vigor;
	}

	private static int Levenshtein(string a, string b)
	{
		int n = a.Length, m = b.Length;
		var d = new int[n + 1, m + 1];
		for (int i = 0; i <= n; i++) d[i, 0] = i;
		for (int j = 0; j <= m; j++) d[0, j] = j;
		for (int i = 1; i <= n; i++)
			for (int j = 1; j <= m; j++)
				d[i, j] = a[i - 1] == b[j - 1] ? d[i - 1, j - 1] : 1 + Math.Min(Math.Min(d[i - 1, j], d[i, j - 1]), d[i - 1, j - 1]);
		return d[n, m];
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
	public static bool PlayerWins(Hero player, Hero npc, CharacterAttribute attr, out int roll, out int dc, out int playerTotal)
	{
		int playerAbility = GetAbility(player, attr);
		int npcAbility = GetAbility(npc, attr);

		roll = MBRandom.RandomInt(1, 20);
		if (roll == 20) { dc = 0; playerTotal = 20; return true; }
		if (roll == 1) { dc = 21; playerTotal = 1; return false; }

		int npcRoll = MBRandom.RandomInt(1, 20);
		dc = (npcAbility / 20) + npcRoll;
		playerTotal = roll + (playerAbility / 20);
		return playerTotal >= dc;
	}
}
