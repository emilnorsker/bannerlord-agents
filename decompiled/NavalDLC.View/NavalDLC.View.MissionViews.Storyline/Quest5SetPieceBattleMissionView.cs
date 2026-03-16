using System.Runtime.CompilerServices;
using NavalDLC.Storyline.MissionControllers;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews.Storyline;

public class Quest5SetPieceBattleMissionView : MissionView
{
	public enum Quest5SetPieceBattleMissionViewState
	{
		None,
		FadeOut,
		Initialize,
		FadeIn,
		End
	}

	private enum ApproachPlayerShipLocationCheckState
	{
		None,
		CheckDistance,
		FadeOut,
		TeleportPlayerShip,
		End
	}

	private enum AllowedSwimRadiusCheckState
	{
		None,
		CheckDistance,
		FadeOut,
		TeleportPlayer,
		End
	}

	private enum EscapeShipStuckCheckState
	{
		None,
		CheckForStuck,
		FadeOut,
		TeleportEscapeShip,
		End
	}

	private enum PurigCutsceneCameraChangeState
	{
		None,
		WaitingForCountDown,
		FadeOut,
		ChangeBackToDefaultCamera,
		End
	}

	private const string PurigShipCutsceneCamTag = "purig_ship_cutscene_cam_tag";

	private TextObject _restrictionNotificationText;

	private Quest5SetPieceBattleMissionViewState _state;

	private MissionCameraFadeView _missionCameraFadeView;

	private Quest5SetPieceBattleMissionController _quest5SetPieceBattleMissionController;

	private ApproachPlayerShipLocationCheckState _approachPlayerShipLocationCheckState;

	private AllowedSwimRadiusCheckState _allowedSwimRadiusCheckState;

	private EscapeShipStuckCheckState _escapeShipStuckCheckState;

	private PurigCutsceneCameraChangeState _purigCutsceneCameraChangeState;

	private MissionTimer _purigCutsceneCameraChangeTimer;

	private MissionTimer _missionEndTimer;

	private bool _isPlayerShipRotationCorrectedAtTheStartOfTheMission;

	private bool _isMainAgentRotatedBeforeBossFight;

	public Camera PurigShipCutsceneCamera;

	public Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState LastHitCheckpoint;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quest5SetPieceBattleMissionView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void PassMissionStateOnTick(Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState currentState)
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
	private void HandleAllowedSwimRadiusCheck()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleApproachPlayerShipLocationCheck()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePurigCutsceneCameraChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePurigShipCutsceneCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetCameraFrame(out MatrixFrame cameraFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeMainAgentRotation(Vec3 mainAgentDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleEscapeShipStuckCheck()
	{
		throw null;
	}
}
