using System.Runtime.CompilerServices;
using NavalDLC.Storyline;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews.Storyline;

public class NavalCaptivityBattleMissionView : MissionView
{
	private const int FreeHintHotKey = 13;

	private NavalStorylineCaptivityMissionController _captivityMissionController;

	private MissionCameraFadeView _cameraFadeViewController;

	private MissionHintLogic _missionHintLogic;

	private TextObject FreeHintText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AreMarkersDirty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerStartedEscape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnOarsmenLevelChanged(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStartFadeOut(float fadeInDuration, float blackDuration, float fadeOutDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConversationSetup(Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowFreePlayerHintText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFirstHighlightCleared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnFirstHighlightClearedInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnPlayerStartedEscapeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnOarsmenLevelChangedInternal(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMarkersAreDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDirtyMarkersHandled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalCaptivityBattleMissionView()
	{
		throw null;
	}
}
