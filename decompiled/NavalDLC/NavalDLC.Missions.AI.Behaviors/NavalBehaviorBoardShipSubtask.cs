using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Library;

namespace NavalDLC.Missions.AI.Behaviors;

internal class NavalBehaviorBoardShipSubtask
{
	public enum ShipBoardingState
	{
		ApproachFromFarAway,
		GettingClose,
		AdjustingOrientation,
		InPosition,
		Connected,
		InactiveStuck
	}

	private const float MinimumBoardingDistance = 3f;

	private const float IdealBoardingDistance = 12f;

	private const float MaximumBoardingDistance = 30f;

	private const float DriftedAwayDistance = 50f;

	private MissionShip _selfShip;

	private MissionShip _givenTargetToBoard;

	private MissionShip _effectiveTarget;

	private bool _givenSideToBoardIsRight;

	private bool _effectiveSideToBoardIsRight;

	private float _cachedEffectiveDistance;

	public ShipBoardingState State
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
	public NavalBehaviorBoardShipSubtask(MissionShip selfShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBehaviorActivatedAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOwnerShip(MissionShip selfShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetShipAndSide(MissionShip targetShip, bool rightSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionShip GetCurrentGivenTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionShip GetCurrentEffectiveTargetShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetEffectiveDistanceToObjective()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndSwitchState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsEffectivelyRightSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsRelevantSideOfEnemyShipRight(MissionShip testedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineEffectiveTargetShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApproachFromDistance(MissionShip enemyShip, out Vec2 desiredPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GettingCloseCase(MissionShip enemyShip, out Vec2 desiredPosition, out Vec2 desiredDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CalculateShipOrders(out Vec2 desiredPosition, out Vec2 desiredDirection, out MissionShip boardingTargetShip)
	{
		throw null;
	}
}
