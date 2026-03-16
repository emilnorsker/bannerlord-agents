using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics.Hideout;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

internal class MissionHideoutAmbushBossFightCinematicView : MissionView
{
	private bool _isInitialized;

	private HideoutAmbushBossFightCinematicController _cinematicLogicController;

	private MissionCameraFadeView _cameraFadeViewController;

	private HideoutAmbushBossFightCinematicController.HideoutCinematicState _currentState;

	private HideoutAmbushBossFightCinematicController.HideoutCinematicState _nextState;

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
	private void OnCinematicStateChanged(HideoutAmbushBossFightCinematicController.HideoutCinematicState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCinematicTransition(HideoutAmbushBossFightCinematicController.HideoutCinematicState nextState, float duration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionHideoutAmbushBossFightCinematicView()
	{
		throw null;
	}
}
