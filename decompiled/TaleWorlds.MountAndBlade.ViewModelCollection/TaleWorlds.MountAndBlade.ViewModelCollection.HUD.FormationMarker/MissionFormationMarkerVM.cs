using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.HUD.FormationMarker;

public class MissionFormationMarkerVM : ViewModel
{
	public class FormationMarkerDistanceComparer : IComparer<MissionFormationMarkerTargetVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(MissionFormationMarkerTargetVM x, MissionFormationMarkerTargetVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FormationMarkerDistanceComparer()
		{
			throw null;
		}
	}

	private readonly Mission _mission;

	private readonly FormationMarkerDistanceComparer _comparer;

	private bool _isEnabled;

	private bool _isFormationTargetRelevant;

	private bool _showDistanceTexts;

	private MBBindingList<MissionFormationMarkerTargetVM> _targets;

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
	public bool IsFormationTargetRelevant
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
	public MBBindingList<MissionFormationMarkerTargetVM> Targets
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
	public MissionFormationMarkerVM(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshFormationMarkers()
	{
		throw null;
	}
}
