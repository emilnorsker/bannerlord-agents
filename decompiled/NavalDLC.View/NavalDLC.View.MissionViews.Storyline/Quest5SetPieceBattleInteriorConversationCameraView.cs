using System.Runtime.CompilerServices;
using NavalDLC.Storyline.MissionControllers;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews.Storyline;

public class Quest5SetPieceBattleInteriorConversationCameraView : MissionView
{
	private enum CameraChangeState
	{
		None,
		FadeOutBeforeConversation,
		ConversationInProgress,
		FadeOutAfterConversation,
		ChangeCameraBack,
		End
	}

	private Quest5SetPieceBattleMissionController _quest5SetPieceBattleMissionController;

	private MissionCameraFadeView _missionCameraFadeView;

	private float _fadeInDuration;

	private Camera _interiorConversationCamera;

	private CameraChangeState _state;

	private bool _sisterConversationStarted;

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
	public Quest5SetPieceBattleInteriorConversationCameraView()
	{
		throw null;
	}
}
