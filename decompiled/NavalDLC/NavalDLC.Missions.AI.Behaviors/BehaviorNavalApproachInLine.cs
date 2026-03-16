using System.Runtime.CompilerServices;
using NavalDLC.Missions.AI.TeamAI;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.Objects.UsableMachines;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.Behaviors;

public sealed class BehaviorNavalApproachInLine : NavalBehaviorComponent
{
	private enum ShipDefenseState
	{
		StandInLine,
		BeingBoarded,
		GoingToHelp,
		HelpingFriend,
		HelpingFinishedStuckBoarded
	}

	private const float DistanceToKeepWithAllyShip = 30f;

	private NavalShipsLogic _navalShipsLogic;

	private MissionShip _formationMainShip;

	private MBReadOnlyList<ShipAttachmentMachine> _formationShipAttachmentMachines;

	private MBReadOnlyList<ShipAttachmentPointMachine> _formationShipAttachmentPointMachines;

	private TeamAINavalComponent _navalTeamAI;

	private ShipDefenseState _currentState;

	private MissionShip _leftAllyShip;

	private MissionShip _rightAllyShip;

	private MissionShip _helpedAllyShip;

	private int _navalLineOrder;

	private bool _actualRightSide;

	private MissionShip _allyShip;

	private bool _tacticallyOnRightSide;

	private bool _isAnchor;

	private bool _hasPulledAhead;

	private NavalBehaviorBoardShipSubtask _boardShipSubtask;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorNavalApproachInLine(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshShipReferences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetShipSideAndOrder(bool rightSide, int navalLineOrder, bool isAnchor)
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
