using System.Runtime.CompilerServices;
using NavalDLC.View.MissionViews.Storyline;
using TaleWorlds.MountAndBlade.View;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(NavalCaptivityBattleMissionView))]
public class MissionGauntletCaptivityMissionView : NavalCaptivityBattleMissionView
{
	private bool _hasHandledOarsmenLevel;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFirstHighlightClearedInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPlayerStartedEscapeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnOarsmenLevelChangedInternal(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletCaptivityMissionView()
	{
		throw null;
	}
}
