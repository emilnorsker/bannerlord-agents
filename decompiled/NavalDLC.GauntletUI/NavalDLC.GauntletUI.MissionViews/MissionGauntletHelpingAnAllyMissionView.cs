using System.Runtime.CompilerServices;
using NavalDLC.View.MissionViews.Storyline;
using TaleWorlds.MountAndBlade.View;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(HelpingAnAllyMissionView))]
public class MissionGauntletHelpingAnAllyMissionView : HelpingAnAllyMissionView
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnShipsInitializedInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletHelpingAnAllyMissionView()
	{
		throw null;
	}
}
