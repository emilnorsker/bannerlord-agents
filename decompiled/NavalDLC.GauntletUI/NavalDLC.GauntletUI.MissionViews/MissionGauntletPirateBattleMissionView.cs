using System.Runtime.CompilerServices;
using NavalDLC.View.MissionViews;
using TaleWorlds.MountAndBlade.View;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(NavalStorylinePirateBattleMissionView))]
internal class MissionGauntletPirateBattleMissionView : NavalStorylinePirateBattleMissionView
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnShipsInitializedInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletPirateBattleMissionView()
	{
		throw null;
	}
}
