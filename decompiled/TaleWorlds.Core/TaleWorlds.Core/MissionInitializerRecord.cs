using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core;

public struct MissionInitializerRecord : ISerializableObject
{
	public int TerrainType;

	public float DamageToFriendsMultiplier;

	public float DamageFromPlayerToFriendsMultiplier;

	[MarshalAs(UnmanagedType.U1)]
	public bool NeedsRandomTerrain;

	public int RandomTerrainSeed;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string SceneName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string SceneLevels;

	[MarshalAs(UnmanagedType.U1)]
	public bool PlayingInCampaignMode;

	[MarshalAs(UnmanagedType.U1)]
	public bool EnableSceneRecording;

	public int SceneUpgradeLevel;

	[MarshalAs(UnmanagedType.U1)]
	public bool SceneHasMapPatch;

	public Vec2 PatchCoordinates;

	public Vec2 PatchEncounterDir;

	[MarshalAs(UnmanagedType.U1)]
	public bool DoNotUseLoadingScreen;

	[MarshalAs(UnmanagedType.U1)]
	public bool DisableDynamicPointlightShadows;

	[MarshalAs(UnmanagedType.I1)]
	public bool DisableCorpseFadeOut;

	public int DecalAtlasGroup;

	public AtmosphereInfo AtmosphereOnCampaign;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionInitializerRecord(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ISerializableObject.DeserializeFrom(IReader reader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ISerializableObject.SerializeTo(IWriter writer)
	{
		throw null;
	}
}
