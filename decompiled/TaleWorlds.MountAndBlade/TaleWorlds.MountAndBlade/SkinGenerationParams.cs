using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;

namespace TaleWorlds.MountAndBlade;

[EngineStruct("Skin_generation_params", false, null)]
public struct SkinGenerationParams
{
	public int _skinMeshesVisibilityMask;

	public Equipment.UnderwearTypes _underwearType;

	public int _bodyMeshType;

	public int _hairCoverType;

	public int _beardCoverType;

	public int _bodyDeformType;

	[MarshalAs(UnmanagedType.U1)]
	public bool _prepareImmediately;

	[MarshalAs(UnmanagedType.U1)]
	public bool _useTranslucency;

	[MarshalAs(UnmanagedType.U1)]
	public bool _useTesselation;

	public float _faceDirtAmount;

	public int _gender;

	public int _race;

	public int _faceCacheId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SkinGenerationParams Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SkinGenerationParams(int skinMeshesVisibilityMask, Equipment.UnderwearTypes underwearType, int bodyMeshType, int hairCoverType, int beardCoverType, int bodyDeformType, bool prepareImmediately, float faceDirtAmount, int gender, int race, bool useTranslucency, bool useTesselation, int faceCacheID)
	{
		throw null;
	}
}
