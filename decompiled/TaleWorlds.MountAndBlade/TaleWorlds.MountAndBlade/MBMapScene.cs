using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MBMapScene
{
	public static bool ApplyRainColorGrade;

	private static UIntPtr[] _tickedMapMeshesCachedArray;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 GetNearestFaceCenterForPosition(Scene mapScene, Vec2 position, bool isRegionMap0, int[] excludedFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 GetNearestFaceCenterForPositionWithPath(Scene mapScene, PathFaceRecord pathFaceRecord, bool targetRegionMap0, float maxDist, int[] excludedFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 GetAccessiblePointNearPosition(Scene mapScene, Vec2 position, bool isRegionMap1, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveZeroCornerBodies(Scene mapScene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadAtmosphereData(Scene mapScene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TickStepSound(Scene mapScene, MBAgentVisuals visuals, int terrainType, TerrainTypeSoundSlot soundType, int partySize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TickAmbientSounds(Scene mapScene, int terrainType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetMouseVisible()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetApplyRainColorGrade()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SendMouseKeyEvent(int mouseKeyId, bool isDown)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetMousePos(int posX, int posY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TickVisuals(Scene mapScene, float tod, Mesh[] tickedMapMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ValidateTerrainSoundIds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetGlobalIlluminationOfString(Scene mapScene, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetColorGradeGridData(Scene mapScene, byte[] gridData, string textureName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetBattleSceneIndexMap(Scene mapScene, ref byte[] indexData, ref int width, ref int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetFrameForAtmosphere(Scene mapScene, float tod, float cameraElevation, bool forceLoadTextures)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTerrainDynamicParams(Scene mapScene, Vec3 dynamic_params)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetSeasonTimeFactor(Scene mapScene, float seasonTimeFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetSeasonTimeFactor(Scene mapScene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MBMapScene()
	{
		throw null;
	}
}
