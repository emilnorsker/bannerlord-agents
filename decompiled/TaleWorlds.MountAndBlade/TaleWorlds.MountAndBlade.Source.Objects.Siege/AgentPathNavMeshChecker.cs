using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Source.Objects.Siege;

public class AgentPathNavMeshChecker
{
	public enum Direction
	{
		ForwardOnly,
		BackwardOnly,
		BothDirections
	}

	private BattleSideEnum _teamToCollect;

	private Direction _directionToCollect;

	private MatrixFrame _pathFrameToCheck;

	private float _radiusToCheck;

	private Mission _mission;

	private int _navMeshId;

	private Timer _tickOccasionallyTimer;

	private MBList<Agent> _nearbyAgents;

	private bool _isBeingUsed;

	private Timer _setBeingUsedToFalseTimer;

	private float _maxDistanceCheck;

	private float _agentMoveTime;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentPathNavMeshChecker(Mission mission, MatrixFrame pathFrameToCheck, float radiusToCheck, int navMeshId, BattleSideEnum teamToCollect, Direction directionToCollect, float maxDistanceCheck, float agentMoveTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickOccasionally(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAgentsUsingPath()
	{
		throw null;
	}
}
