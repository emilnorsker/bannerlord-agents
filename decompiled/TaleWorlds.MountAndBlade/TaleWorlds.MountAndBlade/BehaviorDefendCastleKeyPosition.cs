using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class BehaviorDefendCastleKeyPosition : BehaviorComponent
{
	private enum BehaviorState
	{
		UnSet,
		Waiting,
		Ready
	}

	private TeamAISiegeComponent _teamAISiegeDefender;

	private CastleGate _innerGate;

	private CastleGate _outerGate;

	private List<SiegeLadder> _laddersOnThisSide;

	private BehaviorState _behaviorState;

	private MovementOrder _waitOrder;

	private MovementOrder _readyOrder;

	private FacingOrder _waitFacingOrder;

	private FacingOrder _readyFacingOrder;

	private TacticalPosition _tacticalMiddlePos;

	private TacticalPosition _tacticalWaitPos;

	private bool _hasFormedShieldWall;

	private WorldPosition _readyOrderPosition;

	public override float NavmeshlessTargetPositionPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorDefendCastleKeyPosition(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetBehaviorString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetOrderPositions()
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
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ResetBehavior()
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
