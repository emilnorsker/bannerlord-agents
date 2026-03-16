using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews.Order;

namespace NavalDLC.View.MissionViews.Order;

public class NavalOrderTroopPlacer : OrderTroopPlacer
{
	private NavalShipsLogic _navalShipsLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalOrderTroopPlacer(OrderController orderController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CanUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override OrderFlag CreateOrderFlag()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override CursorState GetCursorState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool TryGetScreenMiddleToWorldPosition(out WorldPosition worldPosition, out float collisionDistance, out WeakGameEntity collidedEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Vec3 GetGroundedVec3(WorldPosition worldPosition)
	{
		throw null;
	}
}
