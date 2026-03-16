using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class BehaviorEliminateEnemyInsideCastle : BehaviorComponent
{
	private enum BehaviorState
	{
		UnSet,
		Gathering,
		Attacking
	}

	private BehaviorState _behaviorState;

	private MovementOrder _gatherOrder;

	private MovementOrder _attackOrder;

	private FacingOrder _gatheringFacingOrder;

	private FacingOrder _attackFacingOrder;

	private TacticalPosition _gatheringTacticalPos;

	private Formation _targetEnemyFormation;

	public override float NavmeshlessTargetPositionPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorEliminateEnemyInsideCastle(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineMostImportantInvadingEnemyFormation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConfirmGatheringSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FormationAI.BehaviorSide DetermineGatheringSide()
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
