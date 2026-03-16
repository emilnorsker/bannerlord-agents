using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

[DefaultView]
public class MissionCrosshair : MissionView
{
	private GameEntity[] _crosshairEntities;

	private GameEntity[] _arrowEntities;

	private float[] _gadgetOpacities;

	private const int GadgetCount = 7;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionCrosshair()
	{
		throw null;
	}
}
