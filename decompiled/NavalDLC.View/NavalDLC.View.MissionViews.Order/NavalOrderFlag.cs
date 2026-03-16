using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews.Order;
using TaleWorlds.MountAndBlade.View.Screens;

namespace NavalDLC.View.MissionViews.Order;

public class NavalOrderFlag : OrderFlag
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalOrderFlag(Mission mission, MissionScreen missionScreen, float flagScale = 20f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Vec3 GetFlagPosition(out bool isOnValidGround, bool checkForTargetEntity, Vec3 targetCollisionPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsPositionOnValidGround(WorldPosition worldPosition)
	{
		throw null;
	}
}
