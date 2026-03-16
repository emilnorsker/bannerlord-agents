using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBFaceGen : IMBFaceGen
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool EnforceConstraintsDelegate(ref FaceGenerationParams faceGenerationParams);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FlushFaceCacheDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetDeformKeyDataDelegate(int keyNo, ref DeformKeyData deformKeyData, int race, int gender, float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetFaceGenInstancesLengthDelegate(int race, int gender, float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetFacialIndicesByTagDelegate(int race, int curGender, float age, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetHairColorCountDelegate(int race, int curGender, float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetHairColorGradientPointsDelegate(int race, int curGender, float age, IntPtr colors);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetHairIndicesByTagDelegate(int race, int curGender, float age, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetMaturityTypeDelegate(float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNumEditableDeformKeysDelegate(int race, [MarshalAs(UnmanagedType.U1)] bool initialGender, float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetParamsFromKeyDelegate(ref FaceGenerationParams faceGenerationParams, ref BodyProperties bodyProperties, [MarshalAs(UnmanagedType.U1)] bool earsAreHidden, [MarshalAs(UnmanagedType.U1)] bool mouthHidden);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetParamsMaxDelegate(int race, int curGender, float curAge, ref int hairNum, ref int beardNum, ref int faceTextureNum, ref int mouthTextureNum, ref int faceTattooNum, ref int soundNum, ref int eyebrowNum, ref float scale);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetRaceIdsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetRandomBodyPropertiesDelegate(int race, int gender, ref BodyProperties bodyPropertiesMin, ref BodyProperties bodyPropertiesMax, int hairCoverType, int seed, byte[] hairTags, byte[] beardTags, byte[] tatooTags, float variationAmount, ref BodyProperties outBodyProperties);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetScaleFromKeyDelegate(int race, int gender, ref BodyProperties initialBodyProperties);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetSkinColorCountDelegate(int race, int curGender, float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetSkinColorGradientPointsDelegate(int race, int curGender, float age, IntPtr colors);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetTatooColorCountDelegate(int race, int curGender, float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetTatooColorGradientPointsDelegate(int race, int curGender, float age, IntPtr colors);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetTattooIndicesByTagDelegate(int race, int curGender, float age, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetVoiceRecordsCountDelegate(int race, int curGender, float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetVoiceTypeUsableForPlayerDataDelegate(int race, int curGender, float age, IntPtr aiArray);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetZeroProbabilitiesDelegate(int race, int curGender, float curAge, ref float tattooZeroProbability);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ProduceNumericKeyWithDefaultValuesDelegate(ref BodyProperties initialBodyProperties, [MarshalAs(UnmanagedType.U1)] bool earsAreHidden, [MarshalAs(UnmanagedType.U1)] bool mouthIsHidden, int race, int gender, float age);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ProduceNumericKeyWithParamsDelegate(ref FaceGenerationParams faceGenerationParams, [MarshalAs(UnmanagedType.U1)] bool earsAreHidden, [MarshalAs(UnmanagedType.U1)] bool mouthIsHidden, ref BodyProperties bodyProperties);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TransformFaceKeysToDefaultFaceDelegate(ref FaceGenerationParams faceGenerationParams);

	private static readonly Encoding _utf8;

	public static EnforceConstraintsDelegate call_EnforceConstraintsDelegate;

	public static FlushFaceCacheDelegate call_FlushFaceCacheDelegate;

	public static GetDeformKeyDataDelegate call_GetDeformKeyDataDelegate;

	public static GetFaceGenInstancesLengthDelegate call_GetFaceGenInstancesLengthDelegate;

	public static GetFacialIndicesByTagDelegate call_GetFacialIndicesByTagDelegate;

	public static GetHairColorCountDelegate call_GetHairColorCountDelegate;

	public static GetHairColorGradientPointsDelegate call_GetHairColorGradientPointsDelegate;

	public static GetHairIndicesByTagDelegate call_GetHairIndicesByTagDelegate;

	public static GetMaturityTypeDelegate call_GetMaturityTypeDelegate;

	public static GetNumEditableDeformKeysDelegate call_GetNumEditableDeformKeysDelegate;

	public static GetParamsFromKeyDelegate call_GetParamsFromKeyDelegate;

	public static GetParamsMaxDelegate call_GetParamsMaxDelegate;

	public static GetRaceIdsDelegate call_GetRaceIdsDelegate;

	public static GetRandomBodyPropertiesDelegate call_GetRandomBodyPropertiesDelegate;

	public static GetScaleFromKeyDelegate call_GetScaleFromKeyDelegate;

	public static GetSkinColorCountDelegate call_GetSkinColorCountDelegate;

	public static GetSkinColorGradientPointsDelegate call_GetSkinColorGradientPointsDelegate;

	public static GetTatooColorCountDelegate call_GetTatooColorCountDelegate;

	public static GetTatooColorGradientPointsDelegate call_GetTatooColorGradientPointsDelegate;

	public static GetTattooIndicesByTagDelegate call_GetTattooIndicesByTagDelegate;

	public static GetVoiceRecordsCountDelegate call_GetVoiceRecordsCountDelegate;

	public static GetVoiceTypeUsableForPlayerDataDelegate call_GetVoiceTypeUsableForPlayerDataDelegate;

	public static GetZeroProbabilitiesDelegate call_GetZeroProbabilitiesDelegate;

	public static ProduceNumericKeyWithDefaultValuesDelegate call_ProduceNumericKeyWithDefaultValuesDelegate;

	public static ProduceNumericKeyWithParamsDelegate call_ProduceNumericKeyWithParamsDelegate;

	public static TransformFaceKeysToDefaultFaceDelegate call_TransformFaceKeysToDefaultFaceDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool EnforceConstraints(ref FaceGenerationParams faceGenerationParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlushFaceCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetDeformKeyData(int keyNo, ref DeformKeyData deformKeyData, int race, int gender, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFaceGenInstancesLength(int race, int gender, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFacialIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHairColorCount(int race, int curGender, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetHairColorGradientPoints(int race, int curGender, float age, Vec3[] colors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetHairIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMaturityType(float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumEditableDeformKeys(int race, bool initialGender, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetParamsFromKey(ref FaceGenerationParams faceGenerationParams, ref BodyProperties bodyProperties, bool earsAreHidden, bool mouthHidden)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetParamsMax(int race, int curGender, float curAge, ref int hairNum, ref int beardNum, ref int faceTextureNum, ref int mouthTextureNum, ref int faceTattooNum, ref int soundNum, ref int eyebrowNum, ref float scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetRaceIds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetRandomBodyProperties(int race, int gender, ref BodyProperties bodyPropertiesMin, ref BodyProperties bodyPropertiesMax, int hairCoverType, int seed, string hairTags, string beardTags, string tatooTags, float variationAmount, ref BodyProperties outBodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetScaleFromKey(int race, int gender, ref BodyProperties initialBodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSkinColorCount(int race, int curGender, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSkinColorGradientPoints(int race, int curGender, float age, Vec3[] colors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTatooColorCount(int race, int curGender, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTatooColorGradientPoints(int race, int curGender, float age, Vec3[] colors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetTattooIndicesByTag(int race, int curGender, float age, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetVoiceRecordsCount(int race, int curGender, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetVoiceTypeUsableForPlayerData(int race, int curGender, float age, bool[] aiArray)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetZeroProbabilities(int race, int curGender, float curAge, ref float tattooZeroProbability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProduceNumericKeyWithDefaultValues(ref BodyProperties initialBodyProperties, bool earsAreHidden, bool mouthIsHidden, int race, int gender, float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProduceNumericKeyWithParams(ref FaceGenerationParams faceGenerationParams, bool earsAreHidden, bool mouthIsHidden, ref BodyProperties bodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransformFaceKeysToDefaultFace(ref FaceGenerationParams faceGenerationParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBFaceGen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBFaceGen()
	{
		throw null;
	}
}
