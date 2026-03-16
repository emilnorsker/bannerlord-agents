using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews;

public class NavalMissionShipHighlightView : MissionView
{
	private NavalShipsLogic _navalShipsLogic;

	private Dictionary<MissionShip, (bool, uint)> _contourCache;

	private MissionShip _focusedShip;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipFocused(MissionShip focusedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSelectedShipContours()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionShipHighlightView()
	{
		throw null;
	}
}
