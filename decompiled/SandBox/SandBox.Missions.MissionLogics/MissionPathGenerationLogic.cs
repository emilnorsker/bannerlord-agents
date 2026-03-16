using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Missions.AgentBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class MissionPathGenerationLogic : MissionLogic
{
	public enum PointOfInterests
	{
		VisitPoint,
		CrossRoadPoint,
		GuardSpawnPoint,
		LookBackPoint
	}

	public class UsableMachineData
	{
		public SynchedMissionObject MissionObject;

		public Vec2 ClosestPointToPath;

		public float PathDistanceRatio;

		public bool IsAlreadyAddedToPath;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public UsableMachineData(SynchedMissionObject missionObject, Vec2 closestPointToPath, float pathDistanceRatio)
		{
			throw null;
		}
	}

	public class NavigationPathData
	{
		public GameEntity StartingGameEntity;

		public GameEntity EndingGameEntity;

		public NavigationPath Path;

		public Dictionary<Vec2, float> PathNodeAndDistances;

		public List<UsableMachineData> ValidUsableMachinesData;

		public float TotalDistance;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NavigationPathData(List<UsableMachine> allUsablePoints, GameEntity startingEntity, GameEntity endingEntity, int disabledFaceId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private NavigationPathData(NavigationPathData navigationPathData)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NavigationPathData ReverseClone()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool GetPositionData(Vec2 position, out Vec2 closestPointToPath, out float pathDistanceRatio)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InitializeUsablePoints(List<UsableMachine> allUsableMachines)
		{
			throw null;
		}
	}

	public abstract class PointOfInterestBaseData
	{
		public float Score;

		public abstract PointOfInterests GetPointOfInterestType();

		public abstract List<(Vec2, float)> GetPositionAndRadiusPairs();

		public abstract bool IsInRadius(PointOfInterestBaseData otherPointOfInterest);

		public abstract float GetLocationRatio();

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected PointOfInterestBaseData()
		{
			throw null;
		}
	}

	public class LookBackPointData : PointOfInterestBaseData
	{
		public WorldPosition WorldPosition;

		public WorldPosition DirectionWorldPosition;

		public float PathDistanceRatio;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public LookBackPointData(WorldPosition position, WorldPosition direction, float pathDistanceRatio)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PointOfInterests GetPointOfInterestType()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override List<(Vec2, float)> GetPositionAndRadiusPairs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsInRadius(PointOfInterestBaseData otherPointOfInterest)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override float GetLocationRatio()
		{
			throw null;
		}
	}

	public class VisitPointNodeScoreData : PointOfInterestBaseData
	{
		public UsableMachineData VisitPointData;

		public bool UsingAsInteractablePoint;

		public WorldPosition PossibleBlendPointPosition;

		public List<(Vec2, float)> PositionAndRadiusPairs;

		public WorldPosition VisitPointPathStartPoint;

		public float VisitPointPathStartPointPathRatio;

		public WorldPosition ClosestPointToBlendPoint;

		public WorldPosition FWP;

		public WorldPosition SWP;

		public float StartingAngle;

		public Vec2 PathToVisitPoint;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public VisitPointNodeScoreData(UsableMachineData visitPointData, WorldPosition possibleBlendPointPosition, WorldPosition visitPointPathStartPoint, float visitPointPathStartPointPathRatio, float score, float startingAngle, WorldPosition fWP, WorldPosition sWP, Vec2 pathToVisitPoint, WorldPosition closestPointToBlendPoint)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PointOfInterests GetPointOfInterestType()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override List<(Vec2, float)> GetPositionAndRadiusPairs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsInRadius(PointOfInterestBaseData otherPointOfInterest)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override float GetLocationRatio()
		{
			throw null;
		}
	}

	public class CrossRoadScoreData : PointOfInterestBaseData
	{
		public UsableMachineData LeftNode;

		public UsableMachineData RightNode;

		public List<(Vec2, float)> PositionAndRadiusPairs;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CrossRoadScoreData(UsableMachineData leftNode, UsableMachineData rightNode, float score)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PointOfInterests GetPointOfInterestType()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override List<(Vec2, float)> GetPositionAndRadiusPairs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsInRadius(PointOfInterestBaseData otherPointOfInterest)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override float GetLocationRatio()
		{
			throw null;
		}
	}

	public class StandingGuardSpawnData : PointOfInterestBaseData
	{
		public UsableMachineData GuardPointData;

		public Vec2 SpawnDirection;

		public List<(Vec2, float)> PositionAndRadiusPairs;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StandingGuardSpawnData(UsableMachineData guardPointData, Vec2 spawnDirection, float score)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PointOfInterests GetPointOfInterestType()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override List<(Vec2, float)> GetPositionAndRadiusPairs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsInRadius(PointOfInterestBaseData otherPointOfInterest)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override float GetLocationRatio()
		{
			throw null;
		}
	}

	public class PointOfInterestScorePair
	{
		public NavigationPathData PathData;

		private List<PointOfInterestBaseData> _data;

		public Dictionary<PointOfInterests, int> PointOfInterestCount;

		public float Score;

		public List<PointOfInterestBaseData> Data
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PointOfInterestScorePair(NavigationPathData pathData, List<PointOfInterestBaseData> data, float score)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PointOfInterestScorePair(PointOfInterestScorePair otherPair)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PointOfInterestScorePair Clone()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddToData(PointOfInterestBaseData pointOfInterestToAdd)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsDataEqualTo(PointOfInterestScorePair other, PointOfInterestBaseData newDataToAdd)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsBetterThan(PointOfInterestScorePair other)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsSufficient()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ReOrderDataAccordingToPathRatios()
		{
			throw null;
		}
	}

	private const float MaximumPathNodeDistanceSquaredToCheckForCrossRoads = 100f;

	private const float MinimumPathNodeDistanceSquaredToCheckForCrossRoads = 25f;

	private const float StandingGuardCountPerXMeter = 10f;

	private const float HumanMonsterCapsuleRadius = 0.37f;

	private const float MinimumStandingGuardSpawnDistance = 3f;

	private const float OptimumStandingGuardSpawnDistance = 5f;

	private const float MaximumStandingGuardSpawnDistance = 30f;

	private const float DoNotSpawnVisitPointPathRatioMin = 0.2f;

	private const float DoNotSpawnVisitPointPathRatioMax = 0.9f;

	private const float OptimumPathIndexRatioForVisitPoint = 0.75f;

	private const float FilterPadding = 20f;

	private const string VisitBarrelPrefabName = "disguise_mission_interactable_barrel";

	private const bool PlayerCompromised = false;

	private readonly CharacterObject _defaultDisguiseCharacter;

	private int _disabledFaceId;

	public static int MinimumPathDistance;

	public static int MaximumPathDistance;

	public float MinimumDistanceToBlendPointToVisitPoint;

	private PointOfInterestScorePair _selectedPath;

	public static int MinimumVisitPointCountInPath;

	public static int MaximumVisitPointCountInPath;

	public static int MinimumCrossRoadCountInPath;

	public static int MaximumCrossRoadCountInPath;

	public static int MinimumStandingGuardCountInPath;

	public static int MaximumStandingGuardCountInPath;

	public static float MinimumGuardSpawnPathRatio;

	public static int MaximumLookBackPointCountInPath;

	public static int ScoreToAchieve;

	private Dictionary<Agent, bool> _crossRoadAgentData;

	private DisguiseMissionLogic _disguiseMissionLogic;

	private readonly List<GameEntity> _visitBarrelEntities;

	public List<GameEntity> _startAndFinishPointPool;

	private GameEntity _currentStarting;

	private GameEntity _currentEnding;

	public int CrossRoadMaximumDistance;

	public int CrossRoadMinimumDistance;

	public int MinimumVisitPointDistance;

	public int MaximumVisitPointDistance;

	private List<UsableMachineData> _nearbyLeftSideUsableMachinesCache;

	private List<UsableMachineData> _nearbyRightSideUsableMachinesCache;

	private List<PointOfInterestBaseData> _allTargetAgentPointOfInterest;

	private WorldPosition _tempWorldPosition;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionPathGenerationLogic(CharacterObject defaultDisguiseCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnDisguiseAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnVisitPointGuardsAndBlendPoints(VisitPointNodeScoreData visitPointData, bool useAsBarrelPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnStandingGuards(StandingGuardSpawnData standingGuardSpawnPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnCrossRoadAgents(CrossRoadScoreData selectedCrossRoad)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CrossRoadAgentWaitDelegate(Agent agent, ref float waitTimeInSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CrossRoadAgentOnTargetReachDelegate(Agent agent1, ref Agent targetAgent, ref UsableMachine machine, ref WorldFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ScriptBehavior.SelectTargetDelegate CrossRoadAgentSelectTargetDelegate(CrossRoadScoreData selectedCrossRoad)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateCrossRoadScoreForUsableMachines(UsableMachineData leftSideUsableMachineData, UsableMachineData rightSideUsableMachineData, NavigationPath originalPath, WorldPosition pathNodeStartPosition, WorldPosition pathNodeEndPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateVisitPointScore(UsableMachineData usableMachineData, NavigationPath originalPath, WorldPosition pathNodeStart, WorldPosition pathNodeEnd, out Vec3 possibleBlendPointPosition, out float startingAngle, out Vec2 pathToVisitPointZero, out Vec2 closestPointToPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateSpawnGuardScore(UsableMachineData guardSpawnPointData, out Vec2 spawnRotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FadeOutUserAgentsInUsableMachine(UsableMachine usableMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PointOfInterestScorePair CreatePathScorePair(NavigationPathData pathData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PointOfInterestScorePair CreatePathDataWith(Stack<(PointOfInterestScorePair, int)> stack, List<PointOfInterestBaseData> pointOfInterestData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PointOfInterestScorePair GetRandomPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddLookBackPointsToThePath(PointOfInterestScorePair path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddStandingGuardsToThePath(PointOfInterestScorePair path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PointOfInterestScorePair> GetAllPossiblePaths()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOnLeftSide(Vec2 lineA, Vec2 lineB, Vec2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PointOfInterestScorePair GetPathInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<StandingGuardSpawnData> GetGuardSpawnPoints(NavigationPathData pathData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<VisitPointNodeScoreData> GetVisitPoints(NavigationPathData pathData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<CrossRoadScoreData> GetCrossRoadPoints(NavigationPathData pathData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowMissionFailedPopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionPathGenerationLogic()
	{
		throw null;
	}
}
