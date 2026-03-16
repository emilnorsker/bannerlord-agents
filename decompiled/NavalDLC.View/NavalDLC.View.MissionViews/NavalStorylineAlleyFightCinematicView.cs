using System.Runtime.CompilerServices;
using NavalDLC.Storyline;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews;

public class NavalStorylineAlleyFightCinematicView : MissionView
{
	private bool _isInitialized;

	private bool _isCinematicPartActive;

	private NavalStorylineAlleyFightCinematicController _cinematicLogicController;

	private MissionCameraFadeView _cameraFadeViewController;

	private Camera _camera;

	private MatrixFrame _cameraFrame;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsPhotoModeAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetCameraFrame(Vec3 position, Vec3 direction, out MatrixFrame cameraFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCamera(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReleaseCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCinematicStateChanged(NavalStorylineAlleyFightCinematicController.NavalAlleyFightCinematicState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFightEnded(float fadeInDuration, float blackDuration, float fadeOutDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConversationSetup(Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylineAlleyFightCinematicView()
	{
		throw null;
	}
}
