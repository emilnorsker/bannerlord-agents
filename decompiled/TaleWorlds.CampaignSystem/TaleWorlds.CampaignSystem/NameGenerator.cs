using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem;

public class NameGenerator
{
	private readonly Dictionary<int, int> _nameCodeAndCount;

	private MBList<TextObject> _imperialNamesMale;

	private MBList<TextObject> _imperialNamesFemale;

	private MBList<TextObject> _preacherNames;

	private MBList<TextObject> _merchantNames;

	private MBList<TextObject> _artisanNames;

	private MBList<TextObject> _gangLeaderNames;

	public static NameGenerator Current
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NameGenerator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeNameCodeAndCountDictionary()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GenerateHeroNameAndHeroFullName(Hero hero, out TextObject firstName, out TextObject fullName, bool useDeterministicValues = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GenerateHeroFullName(Hero hero, TextObject heroFirstName, bool useDeterministicValues = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GenerateHeroFirstName(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GenerateFirstNameForPlayer(CultureObject culture, bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GenerateClanName(CultureObject culture, Settlement clanOriginSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePersonNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<TextObject> GetNameListForCulture(CultureObject npcCulture, bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject[] GetClanNameListForCulture(CultureObject clanCulture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddName(TextObject name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CreateNameCode(TextObject name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateNameScore(Hero hero, TextObject name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int SelectNameIndex(Hero hero, MBReadOnlyList<TextObject> nameList, uint deterministicIndex, bool useDeterministicValues)
	{
		throw null;
	}
}
