using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.MountAndBlade;

[EngineStruct("Face_generation_params", false, null)]
public struct FaceGenerationParams
{
	public int Seed;

	public int CurrentBeard;

	public int CurrentHair;

	public int CurrentEyebrow;

	public int CurrentRace;

	public int CurrentGender;

	public int CurrentFaceTexture;

	public int CurrentMouthTexture;

	public int CurrentFaceTattoo;

	public int CurrentVoice;

	public int HairFilter;

	public int BeardFilter;

	public int TattooFilter;

	public int FaceTextureFilter;

	public float TattooZeroProbability;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 320)]
	public float[] KeyWeights;

	public float CurrentAge;

	public float CurrentWeight;

	public float CurrentBuild;

	public float CurrentSkinColorOffset;

	public float CurrentHairColorOffset;

	public float CurrentEyeColorOffset;

	public float FaceDirtAmount;

	public float CurrentFaceTattooColorOffset1;

	public float HeightMultiplier;

	public float VoicePitch;

	[MarshalAs(UnmanagedType.U1)]
	public bool IsHairFlipped;

	[MarshalAs(UnmanagedType.U1)]
	public bool UseCache;

	[MarshalAs(UnmanagedType.U1)]
	public bool UseGpuMorph;

	[MarshalAs(UnmanagedType.U1)]
	public bool Padding2;

	public int FaceCacheId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FaceGenerationParams Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRaceGenderAndAdjustParams(int race, int gender, int curAge)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRandomParamsExceptKeys(int race, int gender, int minAge, out float scale)
	{
		throw null;
	}
}
