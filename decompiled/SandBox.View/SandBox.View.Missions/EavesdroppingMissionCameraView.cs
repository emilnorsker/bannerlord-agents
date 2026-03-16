using System.Runtime.CompilerServices;
using SandBox.Missions;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class EavesdroppingMissionCameraView : MissionView
{
	private enum CameraSwitchState
	{
		None,
		ReadyForFadeOut,
		FadeOutAndInStarted,
		WaitingForFadeInToEnd
	}

	private CameraSwitchState _cameraSwitchState;

	private EavesdroppingMissionLogic _eavesdroppingMissionLogic;

	private MissionCameraFadeView _missionCameraFadeView;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SetPlayerMovementEnabled(bool isPlayerMovementEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EavesdroppingMissionCameraView()
	{
		throw null;
	}
}
