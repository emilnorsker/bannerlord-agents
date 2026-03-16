using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class FaceGen : IFaceGen
{
	private readonly Dictionary<string, int> _raceNamesDictionary;

	private readonly string[] _raceNamesArray;

	private readonly Dictionary<string, Monster> _monstersDictionary;

	private readonly Monster[] _monstersArray;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FaceGen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CreateInstance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Monster GetMonster(string monsterID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Monster GetMonsterWithSuffix(int race, string suffix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Monster GetBaseMonsterFromRace(int race)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BodyProperties GetRandomBodyProperties(int race, bool isFemale, BodyProperties bodyPropertiesMin, BodyProperties bodyPropertiesMax, int hairCoverType, int seed, string hairTags, string beardTags, string tattooTags, float variationAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGen.GenerateParentBody(BodyProperties childBodyProperties, int race, ref BodyProperties motherBodyProperties, ref BodyProperties fatherBodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGen.SetHair(ref BodyProperties bodyProperties, int hair, int beard, int tattoo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGen.SetBody(ref BodyProperties bodyProperties, int build, int weight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGen.SetPigmentation(ref BodyProperties bodyProperties, int skinColor, int hairColor, int eyeColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BodyProperties GetBodyPropertiesWithAge(ref BodyProperties bodyProperties, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetParamsFromBody(ref FaceGenerationParams faceGenerationParams, BodyProperties bodyProperties, bool earsAreHidden, bool mouthIsHidden)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BodyMeshMaturityType GetMaturityTypeWithAge(float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FlushFaceCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRaceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRaceOrDefault(string raceId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetBaseMonsterNameFromRace(int race)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string[] GetRaceNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int[] GetHairIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int[] GetFacialIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int[] GetTattooIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTattooZeroProbability(int race, int curGender, float age)
	{
		throw null;
	}
}
