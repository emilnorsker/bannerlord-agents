using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using SandBox.ViewModelCollection.Missions.NameMarker;
using TaleWorlds.MountAndBlade;

namespace SandBox.View.Missions.NameMarkers;

public class StealthNameMarkerProvider : MissionNameMarkerProvider
{
	private StealthAreaMissionLogic _stealthAreaMissionLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDestroy(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CreateMarkers(List<MissionNameMarkerTargetBaseVM> markers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateStealthAreaMarkers(List<MissionNameMarkerTargetBaseVM> markers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StealthNameMarkerProvider()
	{
		throw null;
	}
}
