using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class BehaviorAssaultWalls : BehaviorComponent
{
	private enum BehaviorState
	{
		Deciding,
		ClimbWall,
		AttackEntity,
		TakeControl,
		MoveToGate,
		Charging,
		Stop
	}

	private BehaviorState _behaviorState;

	private List<IPrimarySiegeWeapon> _primarySiegeWeapons;

	private WallSegment _wallSegment;

	private CastleGate _innerGate;

	private TeamAISiegeComponent _teamAISiegeComponent;

	private MovementOrder _attackEntityOrderInnerGate;

	private MovementOrder _attackEntityOrderOuterGate;

	private MovementOrder _chargeOrder;

	private MovementOrder _stopOrder;

	private MovementOrder _castleGateMoveOrder;

	private MovementOrder _wallSegmentMoveOrder;

	private FacingOrder _facingOrder;

	protected ArrangementOrder CurrentArrangementOrder;

	private bool _isGateLane;

	public override float NavmeshlessTargetPositionPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetOrderPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorAssaultWalls(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetBehaviorString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BehaviorState CheckAndChangeState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnValidBehaviorSideChanged()
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
