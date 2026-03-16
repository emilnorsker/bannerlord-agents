using System.Runtime.CompilerServices;
using NavalDLC.Storyline;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews;

public class NavalStorylinePirateBattleMissionView : MissionView
{
	private bool _isInitialized;

	private PirateBattleMissionController _controller;

	private MissionCameraFadeView _cameraFadeViewController;

	private MatrixFrame _cameraFrame;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeginScreenFade(float fadeDuration, float blackScreenDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCameraBearingNeedsUpdate(float direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipsInitialized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnShipsInitializedInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylinePirateBattleMissionView()
	{
		throw null;
	}
}
