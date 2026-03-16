using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public static class MBBodyProperties
{
	public enum GenerationType
	{
		FromMother,
		FromFather,
		Count
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumEditableDeformKeys(int race, bool initialGender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetParamsFromKey(ref FaceGenerationParams faceGenerationParams, BodyProperties bodyProperties, bool earsAreHidden, bool mouthHidden)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetParamsMax(int race, int curGender, int curAge, ref int hairNum, ref int beardNum, ref int faceTextureNum, ref int mouthTextureNum, ref int faceTattooNum, ref int soundNum, ref int eyebrowNum, ref float scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetZeroProbabilities(int race, int curGender, float curAge, ref float tattooZeroProbability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ProduceNumericKeyWithParams(FaceGenerationParams faceGenerationParams, bool earsAreHidden, bool mouthIsHidden, ref BodyProperties bodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TransformFaceKeysToDefaultFace(ref FaceGenerationParams faceGenerationParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ProduceNumericKeyWithDefaultValues(ref BodyProperties initialBodyProperties, bool earsAreHidden, bool mouthIsHidden, int race, int gender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BodyProperties GetRandomBodyProperties(int race, bool isFemale, BodyProperties bodyPropertiesMin, BodyProperties bodyPropertiesMax, int hairCoverType, int seed, string hairTags, string beardTags, string tatooTags, float variationAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static DeformKeyData GetDeformKeyData(int keyNo, int race, int gender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetFaceGenInstancesLength(int race, int gender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool EnforceConstraints(ref FaceGenerationParams faceGenerationParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetScaleFromKey(int race, int gender, BodyProperties bodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetHairColorCount(int race, int curGender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<uint> GetHairColorGradientPoints(int race, int curGender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetTatooColorCount(int race, int curGender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<uint> GetTatooColorGradientPoints(int race, int curGender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetSkinColorCount(int race, int curGender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BodyMeshMaturityType GetMaturityType(float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FlushFaceCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetRaceIds()
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
	public static List<uint> GetSkinColorGradientPoints(int race, int curGender, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<bool> GetVoiceTypeUsableForPlayerData(int race, int curGender, float age, int voiceTypeCount)
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
	public static void GenerateParentKey(BodyProperties childBodyProperties, int race, ref BodyProperties motherBodyProperties, ref BodyProperties fatherBodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BodyProperties GetBodyPropertiesWithAge(ref BodyProperties bodyProperties, float age)
	{
		throw null;
	}
}
