using System.Runtime.CompilerServices;
using SandBox.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace SandBox.Missions.AgentBehaviors;

public class PatrolAgentBehavior : AgentBehavior
{
	private const float DefaultPatrollingSpeed = 1.05f;

	private PatrolPoint[] _patrolPoints;

	private int _currentPatrolIndex;

	private Timer _waitTimer;

	private bool _infiniteWaitPointReached;

	private int NextPatrolIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PatrolAgentBehavior(AgentBehaviorGroup behaviorGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDynamicPatrolArea(GameEntity parentPatrolPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetAvailability(bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveAgentToNextPatrolPoint(bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveAgentToThePoint(int pointIndex, bool correctRotation, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetDebugInfo()
	{
		throw null;
	}
}
