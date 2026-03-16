using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Storyline;
using NavalDLC.View.MissionViews.Storyline;
using SandBox.ViewModelCollection.Missions.NameMarker;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.View.Missions;

public class NavalStorylineCaptivityMissionNameMarkerProvider : MissionNameMarkerProvider
{
	private NavalStorylineCaptivityMissionController _captivityMissionController;

	private NavalCaptivityBattleMissionView _captivityMissionView;

	private bool _hasSetTargets;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CreateMarkers(List<MissionNameMarkerTargetBaseVM> markers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylineCaptivityMissionNameMarkerProvider()
	{
		throw null;
	}
}
