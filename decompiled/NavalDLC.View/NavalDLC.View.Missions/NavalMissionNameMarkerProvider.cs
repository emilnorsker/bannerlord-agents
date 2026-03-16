using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using SandBox.ViewModelCollection.Missions.NameMarker;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.View.Missions;

public class NavalMissionNameMarkerProvider : MissionNameMarkerProvider
{
	private MissionShip _lastSteppedShip;

	private MissionShip _lastControlledShip;

	private AgentNavalComponent _mainAgentNavalComponent;

	private NavalShipsLogic _navalShipsLogic;

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
	private void OnMainAgentChanged(Agent oldAgent)
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
	public NavalMissionNameMarkerProvider()
	{
		throw null;
	}
}
