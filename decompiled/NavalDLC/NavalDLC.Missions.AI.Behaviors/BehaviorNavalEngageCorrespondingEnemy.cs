using System.Runtime.CompilerServices;
using NavalDLC.Missions.AI.TeamAI;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.Objects.UsableMachines;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.Behaviors;

public sealed class BehaviorNavalEngageCorrespondingEnemy : NavalBehaviorComponent
{
	private enum ShipBoardingState
	{
		ApproachFromFarAway,
		GettingClose,
		AdjustingOrientation,
		InPosition,
		Connected
	}

	private const float IdealBoardingDistance = 12f;

	private const float MaximumBoardingDistance = 30f;

	private const float DriftedAwayDistance = 50f;

	private NavalShipsLogic _navalShipsLogic;

	private MissionShip _formationMainShip;

	private MBReadOnlyList<ShipAttachmentMachine> _formationShipAttachmentMachines;

	private MBReadOnlyList<ShipAttachmentPointMachine> _formationShipAttachmentPointMachines;

	private TeamAINavalComponent _navalTeamAI;

	private ShipBoardingState _currentState;

	private bool _tacticallyOnRightSide;

	private MissionShip _targetShip;

	private int _navalLineOrder;

	private bool _perfectMatch;

	private bool _actualRightSide;

	private NavalBehaviorBoardShipSubtask _boardShipSubtask;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorNavalEngageCorrespondingEnemy(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshShipReferences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetShipSideAndOrder(bool rightSide, int navalLineOrder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip FindCorrespondingEnemyShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshTargetShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateAndSetShipOrders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndRefreshTargetIfNecessary()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndSwitchState()
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
	private void CancelPreferredTargetShipForAttachmentMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnLostAIControl()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorCanceled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetAiWeight()
	{
		throw null;
	}
}
