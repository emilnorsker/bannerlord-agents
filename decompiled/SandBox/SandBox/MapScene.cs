using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;

namespace SandBox;

public class MapScene : IMapScene
{
	private int _snowAndRainDataTextureWidth;

	private int _snowAndRainDataTextureHeight;

	public const int FlowMapTextureDimension = 512;

	private const string MapCampArea1Tag = "map_camp_area_1";

	private const string MapCampArea2Tag = "map_camp_area_2";

	private Scene _scene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	private byte[] _snowAndRainData;

	private float[] _windFlowMapData;

	private Vec2 _minimumPositionCache;

	private Vec2 _maximumPositionCache;

	private float _maximumHeightCache;

	private Dictionary<string, uint> _sceneLevels;

	private int _battleTerrainIndexMapWidth;

	private int _battleTerrainIndexMapHeight;

	private byte[] _battleTerrainIndexMap;

	private Vec2 _terrainSize;

	private ReaderWriterLockSlim _sharedLock;

	public Scene Scene
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetTerrainSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetSceneLevel(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneLevels(List<string> levels)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<AtmosphereState> GetAtmosphereStates()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ValidateAgentVisualsReseted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAtmosphereColorgrade(TerrainType terrainType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNewEntityToMapScene(string entityId, in CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMapBorders(out Vec2 minimumPosition, out Vec2 maximumPosition, out float maximumHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Load()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSnowAndRainDataWithDimension(Texture snowRainTexture, int weatherNodeGridWidthAndHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AfterLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ModuleInfo GetMainMapModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableUnwalkableNavigationMeshes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PathFaceRecord GetFaceIndex(in CampaignVec2 vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadAtmosphereData(Scene mapScene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TerrainType GetTerrainTypeAtPosition(in CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TerrainType GetFaceTerrainType(PathFaceRecord navMeshFace)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignVec2 GetNearestFaceCenterForPosition(in CampaignVec2 position, int[] excludedFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignVec2 GetNearestFaceCenterForPositionWithPath(PathFaceRecord pathFaceRecord, bool targetIsLand, float maxDist, int[] excludedFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<TerrainType> GetEnvironmentTerrainTypes(in CampaignVec2 originPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<TerrainType> GetEnvironmentTerrainTypesCount(in CampaignVec2 originPosition, out TerrainType currentPositionTerrainType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapPatchData GetMapPatchAtPosition(in CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignVec2 GetAccessiblePointNearPosition(in CampaignVec2 pos, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFaces(PathFaceRecord startingFace, PathFaceRecord endingFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, NavigationPath path, int[] excludedFaceIds, float extraCostMultiplier, int regionSwitchCostFromLandToSea, int regionSwitchCostFromSeaToLand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathDistanceBetweenAIFaces(PathFaceRecord startingAiFace, PathFaceRecord endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, float distanceLimit, out float distance, int[] excludedFaceIds, int regionSwitchCostFromLandToSea, int regionSwitchCostFromSeaToLand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLineToPointClear(PathFaceRecord startingFace, Vec2 position, Vec2 destination, float agentRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetLastPointOnNavigationMeshFromPositionToDestination(PathFaceRecord startingFace, Vec2 position, Vec2 destination, int[] excludedFaceIds = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetLastPositionOnNavMeshFaceForPointAndDirection(PathFaceRecord startingFace, Vec2 position, Vec2 destination)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetNavigationMeshCenterPosition(PathFaceRecord face)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetNavigationMeshCenterPosition(int faceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfNavigationMeshFaces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PathFaceRecord GetFaceAtIndex(int faceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetHeightAtPoint(in CampaignVec2 point, ref float height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWinterTimeFactor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFaceVertexZ(PathFaceRecord navMeshFace)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetGroundNormal(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSiegeCampFrames(Settlement settlement, out List<MatrixFrame> siegeCamp1GlobalFrames, out List<MatrixFrame> siegeCamp2GlobalFrames)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTerrainHeightAndNormal(Vec2 position, out float height, out Vec3 normal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetTerrainTypeName(TerrainType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetSceneXmlCrc()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetSceneNavigationMeshCrc()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetWindAtPosition(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetSnowAmountAtPosition(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRainAmountAtPosition(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetTextureDataIndexForPosition(Vec2 position, int dimensionX, int dimensionY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupWaterWake(float wakeWorldSize, float wakeCameraOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	PathFaceRecord IMapScene.GetFaceIndex(in CampaignVec2 vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	TerrainType IMapScene.GetTerrainTypeAtPosition(in CampaignVec2 vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	List<TerrainType> IMapScene.GetEnvironmentTerrainTypes(in CampaignVec2 vec2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	List<TerrainType> IMapScene.GetEnvironmentTerrainTypesCount(in CampaignVec2 vec2, out TerrainType currentPositionTerrainType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	MapPatchData IMapScene.GetMapPatchAtPosition(in CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	CampaignVec2 IMapScene.GetNearestFaceCenterForPosition(in CampaignVec2 vec2, int[] excludedFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	CampaignVec2 IMapScene.GetAccessiblePointNearPosition(in CampaignVec2 vec2, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMapScene.GetHeightAtPoint(in CampaignVec2 point, ref float height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMapScene.AddNewEntityToMapScene(string entityId, in CampaignVec2 position)
	{
		throw null;
	}
}
