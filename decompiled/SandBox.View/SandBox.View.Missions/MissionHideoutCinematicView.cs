using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics.Hideout;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class MissionHideoutCinematicView : MissionView
{
	private bool _isInitialized;

	private HideoutCinematicController _cinematicLogicController;

	private MissionCameraFadeView _cameraFadeViewController;

	private HideoutCinematicController.HideoutCinematicState _currentState;

	private HideoutCinematicController.HideoutCinematicState _nextState;

	private Camera _camera;

	private MatrixFrame _cameraFrame;

	private readonly Vec3 _cameraOffset;

	private Vec3 _cameraMoveDir;

	private float _cameraSpeed;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCameraFrame(Vec3 position, Vec3 direction, out MatrixFrame cameraFrame)
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
	private void OnCinematicStateChanged(HideoutCinematicController.HideoutCinematicState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCinematicTransition(HideoutCinematicController.HideoutCinematicState nextState, float duration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionHideoutCinematicView()
	{
		throw null;
	}
}
