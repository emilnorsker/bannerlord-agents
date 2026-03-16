using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public static class FaceGen
{
	public const string MonsterSuffixSettlement = "_settlement";

	public const string MonsterSuffixSettlementSlow = "_settlement_slow";

	public const string MonsterSuffixSettlementFast = "_settlement_fast";

	public const string MonsterSuffixChild = "_child";

	public static bool ShowDebugValues;

	public static bool UpdateDeformKeys;

	private static IFaceGen _instance;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetInstance(IFaceGen faceGen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BodyProperties GetRandomBodyProperties(int race, bool isFemale, BodyProperties bodyPropertiesMin, BodyProperties bodyPropertiesMax, int hairCoverType, int seed, string hairTags, string beardTags, string tatooTags, float variationAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRaceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRaceOrDefault(string raceId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetBaseMonsterNameFromRace(int race)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetRaceNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Monster GetMonster(string monsterID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Monster GetMonsterWithSuffix(int race, string suffix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Monster GetBaseMonsterFromRace(int race)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GenerateParentKey(BodyProperties childBodyProperties, int race, ref BodyProperties motherBodyProperties, ref BodyProperties fatherBodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetHair(ref BodyProperties bodyProperties, int hair, int beard, int tattoo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetBody(ref BodyProperties bodyProperties, int build, int weight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetPigmentation(ref BodyProperties bodyProperties, int skinColor, int hairColor, int eyeColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BodyProperties GetBodyPropertiesWithAge(ref BodyProperties originalBodyProperties, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BodyMeshMaturityType GetMaturityTypeWithAge(float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int[] GetHairIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int[] GetFacialIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int[] GetTattooIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetTattooZeroProbability(int race, int curGender, float age)
	{
		throw null;
	}
}
