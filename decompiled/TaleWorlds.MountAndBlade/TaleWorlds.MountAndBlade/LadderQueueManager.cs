using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class LadderQueueManager : MissionObject
{
	public int ManagedNavigationFaceId;

	public int ManagedNavigationFaceAlternateID1;

	public int ManagedNavigationFaceAlternateID2;

	public float CostAddition;

	private readonly List<Agent> _userAgents;

	private readonly List<Agent> _queuedAgents;

	private MatrixFrame _managedEntitialFrame;

	private Vec2 _managedEntitialDirection;

	private Vec3 _lastCachedGameEntityGlobalPosition;

	private MatrixFrame _managedGlobalFrame;

	private WorldPosition _managedGlobalWorldPosition;

	private Vec2 _managedGlobalDirection;

	private BattleSideEnum _managedSide;

	private bool _blockUsage;

	private int _maxUserCount;

	private int _queuedAgentCount;

	private float _arcAngle;

	private float _queueBeginDistance;

	private float _queueRowSize;

	private float _agentSpacing;

	private float _timeSinceLastUpdate;

	private float _updatePeriod;

	private float _usingAgentResetTime;

	private float _costPerRow;

	private float _baseCost;

	private float _zDifferenceToStopUsing;

	private float _distanceToStopUsing2d;

	private bool _doesManageMultipleIDs;

	private int _maxClimberCount;

	private int _maxRunnerCount;

	private Timer _deactivateTimer;

	private bool _deactivationDelayTimerElapsed;

	private LadderQueueManager _neighborLadderQueueManager;

	private (float, bool)[] _lastUserCostPenaltyPerLadder;

	public bool IsDeactivated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateImmediate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Activate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(int managedNavigationFaceId, MatrixFrame managedFrame, Vec3 managedDirection, BattleSideEnum managedSide, int maxUserCount, float arcAngle, float queueBeginDistance, float queueRowSize, float costPerRow, float baseCost, bool blockUsage, float agentSpacing, float zDifferenceToStopUsing, float distanceToStopUsing2d, bool doesManageMultipleIDs, int managedNavigationFaceAlternateID1, int managedNavigationFaceAlternateID2, int maxClimberCount, int maxRunnerCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateGlobalFrameCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTickParallelAux(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConditionsAreMet(Agent agent, Agent.AIScriptedFrameFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMissionReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetParentIndicesForQueueIndex(int queueIndex, out int parentIndex1, out int parentIndex2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetScoreForAddingAgentToQueueIndex(Vec3 agentPosition, int queueIndex, out int scoreOfQueueIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAgentToQueue(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveAgentFromQueueAtIndex(int queueIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetNavigationFaceCost(int rowIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetNavigationFaceCostPerClimber(float costPenalty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveAgentFromQueueIndexToQueueIndex(int fromQueueIndex, int toQueueIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetRowSize(int rowIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetQueueIndexForCoordinates(Vec2i coordinates)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2i GetCoordinatesForQueueIndex(int queueIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorldPosition GetQueuePositionForCoordinates(Vec2i coordinates, int randomSeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorldPosition GetQueuePositionForIndex(int queueIndex, int randomSeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlushQueueManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AssignNeighborQueueManager(LadderQueueManager neighborLadderQueueManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsFormationPositionOtherSideOfTheCastle(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldAgentUseTheLadder(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationFrameChanged(Agent agent, bool hasFrame, WorldPosition frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LadderQueueManager()
	{
		throw null;
	}
}
