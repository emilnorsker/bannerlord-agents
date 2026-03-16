using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineClass("rglScene")]
public sealed class Scene : NativeObject
{
	public static float MaximumWindSpeed;

	public const float AutoClimbHeight = 1.5f;

	public const float NavMeshHeightLimit = 1.5f;

	public const int SunRise = 2;

	public const int SunSet = 22;

	public static readonly TWSharedMutex PhysicsAndRayCastLock;

	public int RootEntityCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasTerrainHeightmap
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool ContainsTerrain
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float TimeOfDay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public bool IsDayTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAtmosphereIndoor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 LastFinalRenderCameraPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatrixFrame LastFinalRenderCameraFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float TimeSpeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Scene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Scene(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDefaultEditorScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMultiplayerScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string TakePhotoModePicture(bool saveAmbientOcclusionPass, bool savingObjectIdPass, bool saveShadowPass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAllColorGradeNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAllFilterNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetPhotoModeRoll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPhotoModeOrbit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPhotoModeOn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPhotoModeFocus(ref float focus, ref float focusStart, ref float focusEnd, ref float exposure, ref bool vignetteOn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSceneColorGradeIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSceneFilterIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableFixedTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetLoadingStateName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLoadingFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeRoll(float roll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeOrbit(bool orbit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFallDensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeOn(bool on)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeFocus(float focusStart, float focusEnd, float focus, float exposure)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeFov(float verticalFov)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetPhotoModeFov()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasDecalRenderer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeVignette(bool vignetteOn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneColorGradeIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SetSceneFilterIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneColorGrade(string textureName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpgradeLevel(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateBurstParticle(int particleId, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float[] GetTerrainHeightData(int nodeXIndex, int nodeYIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public short[] GetTerrainPhysicsMaterialIndexData(int nodeXIndex, int nodeYIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTerrainData(out Vec2i nodeDimension, out float nodeSize, out int layerCount, out int layerVersion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTerrainNodeData(int xIndex, int yIndex, out int vertexCountAlongAxis, out float quadLength, out float minHeight, out float maxHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PhysicsMaterial GetTerrainPhysicsMaterialAtLayer(int layerIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneColorGrade(Scene scene, string textureName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterLevel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterLevelAtPosition(Vec2 position, bool useWaterRenderer, bool checkWaterBodyEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetWaterSpeedAtPosition(Vec2 position, bool doChoppinessCorrection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBulkWaterLevelAtPositions(Vec2[] waterHeightQueryArray, ref float[] waterHeightsAtVolumes, ref Vec3[] waterSurfaceNormals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetInterpolationFactorForBodyWorldTransformSmoothing(out float interpolationFactor, out float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBulkWaterLevelAtVolumes(UIntPtr waterHeightQueryArray, int waterHeightQueryArrayCount, in MatrixFrame globalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterStrength()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeRegisterShipVisual(UIntPtr visualPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr RegisterShipVisualToWaterRenderer(WeakGameEntity entity, in Vec3 waterEffectBB)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWaterStrength(float newWaterStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddWaterWakeWithSphere(Vec3 position, float radius, float wakeVisibility, float foamVisibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddWaterWakeWithCapsule(Vec3 positionA, float radiusA, Vec3 positionB, float radiusB, float wakeVisibility, float foamVisibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFaces(UIntPtr startingFace, UIntPtr endingFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, NavigationPath path, int[] excludedFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasNavmeshFaceUnsharedEdges(in PathFaceRecord faceRecord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNavmeshFaceCountBetweenTwoIds(int firstId, int secondId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNavmeshFaceRecordsBetweenTwoIds(int firstId, int secondId, PathFaceRecord[] faceRecords)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFixedTickCallbackActive(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOnCollisionFilterCallbackActive(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFaces(UIntPtr startingFace, UIntPtr endingFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, NavigationPath path, int[] excludedFaceIds, int regionSwitchCostTo0, int regionSwitchCostTo1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFaces(int startingFace, int endingFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, NavigationPath path, int[] excludedFaceIds, float extraCostMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFaces(int startingFace, int endingFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, NavigationPath path, int[] excludedFaceIds, float extraCostMultiplier, int regionSwitchCostTo0, int regionSwitchCostTo1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathDistanceBetweenAIFaces(int startingAiFace, int endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, float distanceLimit, out float distance, int[] excludedFaceIds, int regionSwitchCostTo0, int regionSwitchCostTo1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNavMeshFaceIndex(ref PathFaceRecord record, Vec2 position, bool isRegion1, bool checkIfDisabled, bool ignoreHeight = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNavMeshFaceIndex(ref PathFaceRecord record, Vec3 position, bool checkIfDisabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Scene CreateNewScene(bool initialize_physics = true, bool enable_decals = true, DecalAtlasGroup atlasGroup = DecalAtlasGroup.All, string sceneName = "mono_renderscene")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAlwaysRenderedSkeleton(Skeleton skeleton)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAlwaysRenderedSkeleton(Skeleton skeleton)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh CreatePathMesh(string baseEntityName, bool isWaterPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActiveVisibilityLevels(List<string> levelsToActivate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDoNotWaitForLoadingStatesToRender(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDynamicSnowTexture(Texture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetWindFlowMapData(float[] flowMapData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateDynamicRainTexture(int w, int h)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh CreatePathMesh(IList<GameEntity> pathNodes, bool isWaterPath = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetEntityWithGuid(string guid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEntityFrameChanged(string containsName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTerrainHeightAndNormal(Vec2 position, out float height, out Vec3 normal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFloraInstanceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFloraRendererTextureUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTerrainMemoryUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFetchCrcInfoOfScene(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetSceneXMLCRC()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetNavigationMeshCRC()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalWindStrengthVector(in Vec2 windVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetGlobalWindStrengthVector()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetGlobalWindVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalWindVelocity(in Vec2 windVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetEnginePhysicsEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearNavMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StallLoadingRenderingsUntilFurtherNotice()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNavMeshFaceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResumeLoadingRenderings()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetUpgradeLevelMask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpgradeLevelVisibility(uint mask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpgradeLevelVisibility(List<string> levels)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIdOfNavMeshFace(int faceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClothSimulationState(bool state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNavMeshCenterPosition(int faceIndex, ref Vec3 centerPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PathFaceRecord GetNavMeshPathFaceRecord(int faceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PathFaceRecord GetPathFaceRecordFromNavMeshFacePointer(UIntPtr navMeshFacePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllNavmeshFaceRecords(PathFaceRecord[] faceRecords)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetFirstEntityWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetCampaignEntityWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllEntitiesWithScriptComponent<T>(ref List<GameEntity> entities) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetFirstEntityWithScriptComponent<T>() where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetFirstEntityWithScriptComponent(string scriptName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetUpgradeLevelMaskOfLevelName(string levelName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetUpgradeLevelNameOfIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetUpgradeLevelCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWinterTimeFactor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetNavMeshFaceFirstVertexZ(int faceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWinterTimeFactor(float winterTimeFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDrynessFactor(float drynessFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFog(float fogDensity, ref Vec3 fogColor, float fogFalloff)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFogAdvanced(float fogFalloffOffset, float fogFalloffMinFog, float fogFalloffStartDist)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFogAmbientColor(ref Vec3 fogAmbientColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTemperature(float temperature)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHumidity(float humidity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDynamicShadowmapCascadesRadiusMultiplier(float multiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnvironmentMultiplier(bool useMultiplier, float multiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkyRotation(float rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkyBrightness(float brightness)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForcedSnow(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunLight(ref Vec3 color, ref Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunDirection(ref Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSun(ref Vec3 color, float altitude, float angle, float intensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunAngleAltitude(float angle, float altitude)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunSize(float size)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunShaftStrength(float strength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRainDensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRainDensity(float density)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetSnowDensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSnowDensity(float density)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddDecalInstance(Decal decal, string decalSetID, bool deletable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveDecalInstance(Decal decal, string decalSetID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShadow(bool shadowEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddPointLight(ref Vec3 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddDirectionalLight(ref Vec3 position, ref Vec3 direction, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLightPosition(int lightIndex, ref Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLightDiffuseColor(int lightIndex, ref Vec3 diffuseColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLightDirection(int lightIndex, ref Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMieScatterFocus(float strength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMieScatterStrength(float strength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBrightpassThreshold(float threshold)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensDistortion(float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHexagonVignetteAlpha(float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMinExposure(float minExposure)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaxExposure(float maxExposure)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetExposure(float targetExposure)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMiddleGray(float middleGray)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBloomStrength(float bloomStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBloomAmount(float bloomAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGrainAmount(float grainAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity AddItemEntity(ref MatrixFrame placementFrame, MetaMesh metaMesh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEntity(GameEntity entity, int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEntity(WeakGameEntity entity, int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AttachEntity(GameEntity entity, bool showWarnings = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AttachEntity(WeakGameEntity entity, bool showWarnings = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEntityWithMesh(Mesh mesh, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEntityWithMultiMesh(MetaMesh mesh, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDefaultLighting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CalculateEffectiveLighting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathDistanceBetweenPositions(ref WorldPosition point0, ref WorldPosition point1, float agentRadius, out float pathDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLineToPointClear(ref WorldPosition position, ref WorldPosition destination, float agentRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLineToPointClear(UIntPtr startingFace, Vec2 position, Vec2 destination, float agentRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLineToPointClear(int startingFace, Vec2 position, Vec2 destination, float agentRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetLastPointOnNavigationMeshFromPositionToDestination(int startingFace, Vec2 position, Vec2 destination, int[] excludedFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetLastPositionOnNavMeshFaceForPointAndDirection(PathFaceRecord record, Vec2 position, Vec2 destination)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetLastPointOnNavigationMeshFromWorldPositionToDestination(ref WorldPosition position, Vec2 destination)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoesPathExistBetweenFaces(int firstNavMeshFace, int secondNavMeshFace, bool ignoreDisabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetHeightAtPoint(Vec2 point, BodyFlags excludeBodyFlags, ref float height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetNormalAt(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetEntities(ref List<GameEntity> entities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetRootEntities(NativeObjectArray entities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SelectEntitiesInBoxWithScriptComponent<T>(ref Vec3 boundingBoxMin, ref Vec3 boundingBoxMax, WeakGameEntity[] entitiesOutput, UIntPtr[] entityIds) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SelectEntitiesCollidedWith(ref Ray ray, Intersection[] intersectionsOutput, UIntPtr[] entityIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastExcludingTwoEntities(BodyFlags flags, in Ray ray, WeakGameEntity entity1, WeakGameEntity entity2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GenerateContactsWithCapsule(ref CapsuleData capsule, BodyFlags exclude_flags, bool isFixedTick, Intersection[] intersectionsOutput, WeakGameEntity[] gameEntities, UIntPtr[] entityPointers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GenerateContactsWithCapsuleAgainstEntity(ref CapsuleData capsule, BodyFlags excludeFlags, WeakGameEntity entity, Intersection[] intersectionsOutput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvalidateTerrainPhysicsMaterials()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Read(string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Read(string sceneName, string moduleId, ref SceneInitializationData initData, string forcedAtmoName = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Read(string sceneName, ref SceneInitializationData initData, string forcedAtmoName = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame ReadAndCalculateInitialCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OptimizeScene(bool optimizeFlora = true, bool optimizeOro = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTerrainHeight(Vec2 position, bool checkHoles = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckResources(bool checkInvisibleEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceLoadResources(bool checkInvisibleEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDepthOfFieldParameters(float depthOfFieldFocusStart, float depthOfFieldFocusEnd, bool isVignetteOn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDepthOfFieldFocus(float depthOfFieldFocus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetDepthOfFieldParams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadForRendering()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetColorGradeBlend(string texture1, string texture2, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetGroundHeightAtPosition(Vec3 position, BodyFlags excludeFlags = BodyFlags.CommonCollisionExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetGroundHeightAndBodyFlagsAtPosition(Vec3 position, out BodyFlags contactPointFlags, BodyFlags excludeFlags = BodyFlags.CommonCollisionExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetGroundHeightAtPosition(Vec3 position, out Vec3 normal, BodyFlags excludeFlags = BodyFlags.CommonCollisionExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PauseSceneSounds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResumeSceneSounds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinishSceneSounds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool BoxCastOnlyForCamera(Vec3[] boxPoints, in Vec3 centerPoint, bool castSupportRay, in Vec3 supportRaycastPoint, in Vec3 dir, float distance, WeakGameEntity ignoredEntity, out float collisionDistance, out Vec3 closestPoint, out WeakGameEntity collidedEntity, BodyFlags excludedBodyFlags = BodyFlags.CameraCollisionRayCastExludeFlags | BodyFlags.DontCollideWithCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool BoxCast(Vec3 boxMin, Vec3 boxMax, bool castSupportRay, Vec3 supportRaycastPoint, Vec3 dir, float distance, out float collisionDistance, out Vec3 closestPoint, out WeakGameEntity collidedEntity, BodyFlags excludedBodyFlags = BodyFlags.CameraCollisionRayCastExludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrain(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, out Vec3 closestPoint, out WeakGameEntity collidedEntity, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrainFixedPhysics(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, out Vec3 closestPoint, out WeakGameEntity collidedEntity, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool FocusRayCastForFixedPhysics(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, out Vec3 closestPoint, out WeakGameEntity collidedEntity, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrain(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, out WeakGameEntity collidedEntity, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrainFixedPhysics(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, out WeakGameEntity collidedEntity, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForRamming(in Vec3 sourcePoint, in Vec3 targetPoint, WeakGameEntity ignoredEntity, float rayThickness, out float collisionDistance, out Vec3 intersectionPoint, out WeakGameEntity collidedEntity, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags, BodyFlags includeBodyFlags = BodyFlags.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrainIgnoreEntity(in Vec3 sourcePoint, in Vec3 targetPoint, WeakGameEntity ignoredEntity, out float collisionDistance, out GameEntity collidedEntity, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrain(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, out Vec3 closestPoint, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrainFixedPhysics(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, out Vec3 closestPoint, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrainFixedPhysics(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrain(Vec3 sourcePoint, Vec3 targetPoint, out float collisionDistance, float rayThickness = 0.01f, BodyFlags excludeBodyFlags = BodyFlags.CommonFocusRayCastExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ImportNavigationMeshPrefab(string navMeshPrefabName, int navMeshGroupShift)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ImportNavigationMeshPrefabWithFrame(string navMeshPrefabName, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveNavMeshPrefabWithFrame(string navMeshPrefabName, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNavMeshRegionMap(bool[] regionMap)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MarkFacesWithIdAsLadder(int faceGroupId, bool isLadder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SetAbilityOfFacesWithId(int faceGroupId, bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SwapFaceConnectionsWithID(int hubFaceGroupID, int toBeSeparatedFaceGroupId, int toBeMergedFaceGroupId, bool canFail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MergeFacesWithId(int faceGroupId0, int faceGroupId1, int newFaceGroupId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SeparateFacesWithId(int faceGroupId0, int faceGroupId1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAnyFaceWithId(int faceGroupId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNavigationMeshForPosition(in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNearestNavigationMeshForPosition(in Vec3 position, float heightDifferenceLimit, bool excludeDynamicNavigationMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNavigationMeshForPosition(in Vec3 position, out int faceGroupId, float heightDifferenceLimit, bool excludeDynamicNavigationMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoesPathExistBetweenPositions(WorldPosition position, WorldPosition destination)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLandscapeRainMaskData(byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnsurePostfxSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBloom(bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDofMode(bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOcclusionMode(bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetExternalInjectionTexture(Texture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunshaftMode(bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetSunDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetNorthAngle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetNorthRotation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetTerrainMinMaxHeight(out float minHeight, out float maxHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPhysicsMinMax(ref Vec3 min_max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEditorScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMotionBlurMode(bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAntialiasingMode(bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDLSSMode(bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<WeakGameEntity> FindWeakEntitiesWithTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity FindWeakEntityWithTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<GameEntity> FindEntitiesWithTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity FindEntityWithTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity FindEntityWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<WeakGameEntity> FindWeakEntitiesWithTagExpression(string expression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<GameEntity> FindEntitiesWithTagExpression(string expression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSoftBoundaryVertexCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHardBoundaryVertexCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetSoftBoundaryVertex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetHardBoundaryVertex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Path GetPathWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeletePathWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPath(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPathPoint(string name, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoundingBox(out Vec3 min, out Vec3 max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSceneLimits(out Vec3 min, out Vec3 max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetModulePath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOwnerThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Path[] GetPathsWithNamePrefix(string prefix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUseConstantTime(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckPointCanSeePoint(Vec3 source, Vec3 target, float? distanceToCheck = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlaySoundEventsAfterReadyToRender(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableStaticShadows(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mesh GetSkyboxMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAtmosphereWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillEntityWithHardBorderPhysicsBarrier(GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearDecals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoAtmosphereViaTod(float tod, bool withStorm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionOnADynamicNavMesh(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WaitWaterRendererCPUSimulation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableInclusiveAsyncPhysx()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnsureWaterWakeRenderer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteWaterWakeRenderer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SceneHadWaterWakeRenderer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWaterWakeWorldSize(float worldSize, float eraseFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWaterWakeCameraOffset(float cameraOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickWake(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDoNotAddEntitiesToTickList(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDontLoadInvisibleEntities(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsesDeleteLaterSystem(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearCurrentFrameTickEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 FindClosestExitPositionForPositionOnABoundaryFace(Vec3 position, UIntPtr boundaryFacePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Scene()
	{
		throw null;
	}
}
