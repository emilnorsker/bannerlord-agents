using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.ViewModelCollection.HUD.ShipMarker;

public class NavalShipMarkersVM : ViewModel
{
	public class ShipMarkerDistanceComparer : IComparer<NavalShipMarkerItemVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(NavalShipMarkerItemVM x, NavalShipMarkerItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipMarkerDistanceComparer()
		{
			throw null;
		}
	}

	private readonly Mission _mission;

	private NavalShipsLogic _navalShipsLogic;

	private readonly ShipMarkerDistanceComparer _comparer;

	private bool _isEnabled;

	private bool _isShipTargetingRelevant;

	private bool _showDistanceTexts;

	private MBBindingList<NavalShipMarkerItemVM> _shipMarkers;

	[DataSourceProperty]
	public bool IsEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsShipTargetingRelevant
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool ShowDistanceTexts
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<NavalShipMarkerItemVM> ShipMarkers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalShipMarkersVM(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshShipMarkers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetShipChanges(List<Formation> allFormations, MBBindingList<NavalShipMarkerItemVM> activeMarkers, out MBList<NavalShipMarkerItemVM> markersToRemove, out MBList<NavalShipMarkerItemVM> markersToAdd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateCrewCounts()
	{
		throw null;
	}
}
