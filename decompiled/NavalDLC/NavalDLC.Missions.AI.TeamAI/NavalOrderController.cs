using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.TeamAI;

internal class NavalOrderController : OrderController
{
	private readonly NavalShipsLogic _navalShipsLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalOrderController(Mission mission, Team team, Agent owner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SelectAllFormations(Agent selectorAgent, bool uiFeedback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SelectFormation(Formation formation, Agent selectorAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetOrderWithTwoPositions(OrderType orderType, WorldPosition position1, WorldPosition position2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetOrderWithPosition(OrderType orderType, WorldPosition position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetOrder(OrderType orderType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetOrderWithAgent(OrderType orderType, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSkirmishState(bool isSkirmishing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDefensiveState(bool isDefensive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetOrderWithFormation(OrderType orderType, Formation orderFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetOrderWithOrderableObject(IOrderable target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavalFollowOrder(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavalFollowMeOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavalEngageWithTargetFormation(Formation targetFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavalSkirmishWithTargetFormation(Formation targetFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavalStop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavalRetreat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavalTroopsAggressive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MovementOrder GetNavalDefensiveMovementOrder(MissionShip missionShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavalTroopsDefensive()
	{
		throw null;
	}
}
