using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews;

public class NavalFinalConversationMissionView : MissionView
{
	private const float FadeDuration = 0.5f;

	private MissionCameraFadeView _cameraFadeView;

	private CharacterObject _currentConversationCharacter;

	private float _remainingSisterSpawnTime;

	private bool _shouldSpawnSister;

	private bool _shouldStartSisterConversation;

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
	public override void OnConversationEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TransitionToSister()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalFinalConversationMissionView()
	{
		throw null;
	}
}
