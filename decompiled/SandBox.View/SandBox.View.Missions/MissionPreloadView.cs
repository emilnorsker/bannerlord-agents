using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class MissionPreloadView : MissionView
{
	private readonly PreloadHelper _helperInstance;

	private bool _preloadDone;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSceneRenderingStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateDeactivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionPreloadView()
	{
		throw null;
	}
}
