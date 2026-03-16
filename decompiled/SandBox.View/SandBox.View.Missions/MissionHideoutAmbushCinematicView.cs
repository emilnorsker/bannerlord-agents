using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics.Hideout;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class MissionHideoutAmbushCinematicView : MissionView
{
	private enum HideoutAmbushCinematicState
	{
		None,
		FirstFadeOut,
		ChangeToCustomCamera,
		FirstFadeIn,
		SendArrow,
		Wait,
		SecondFadeOut,
		ChangeBackToDefaultCamera,
		SecondFadeIn,
		Ending,
		Ended
	}

	private const string CameraTag = "hideout_ambush_cutscene_camera";

	private const string ArrowBarrelTag = "hideout_ambush_cutscene_arrow_barrel";

	private const string ArrowPathTag = "hideout_ambush_cutscene_arrow_path";

	private Camera _camera;

	private GameEntity _cameraEntity;

	private GameEntity _arrowPath;

	private HideoutAmbushMissionController _hideoutAmbushMissionController;

	private MissionCameraFadeView _missionCameraFadeView;

	private HideoutAmbushCinematicState _currentHideoutAmbushCinematicState;

	private Timer _timer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SetPlayerMovementEnabled(bool isPlayerMovementEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionHideoutAmbushCinematicView()
	{
		throw null;
	}
}
