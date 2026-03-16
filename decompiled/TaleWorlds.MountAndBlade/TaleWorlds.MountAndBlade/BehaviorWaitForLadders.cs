using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class BehaviorWaitForLadders : BehaviorComponent
{
	private enum BehaviorState
	{
		Unset,
		Stop,
		Follow
	}

	private const string WallWaitPositionTag = "attacker_wait_pos";

	private List<SiegeLadder> _ladders;

	private WallSegment _breachedWallSegment;

	private TeamAISiegeComponent _teamAISiegeComponent;

	private MovementOrder _stopOrder;

	private MovementOrder _followOrder;

	private BehaviorState _behaviorState;

	private GameEntity _followedEntity;

	private TacticalPosition _followTacticalPosition;

	public override float NavmeshlessTargetPositionPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorWaitForLadders(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetFollowOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnValidBehaviorSideChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBehaviorActivatedAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetAiWeight()
	{
		throw null;
	}
}
