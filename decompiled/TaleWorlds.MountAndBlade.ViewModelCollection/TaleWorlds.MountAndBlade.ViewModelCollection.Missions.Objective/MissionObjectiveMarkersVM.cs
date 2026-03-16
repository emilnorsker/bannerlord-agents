using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Missions.Objective;

public class MissionObjectiveMarkersVM : ViewModel
{
	private class MarkerDistanceComparer : IComparer<MissionObjectiveMarkerVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(MissionObjectiveMarkerVM x, MissionObjectiveMarkerVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MarkerDistanceComparer()
		{
			throw null;
		}
	}

	private readonly Camera _missionCamera;

	private readonly MarkerDistanceComparer _distanceComparer;

	private readonly MissionObjectiveLogic _objectiveLogic;

	private MissionObjective _latestObjective;

	private MBBindingList<MissionObjectiveMarkerVM> _targets;

	private bool _isEnabled;

	[DataSourceProperty]
	public MBBindingList<MissionObjectiveMarkerVM> Targets
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionObjectiveMarkersVM(MissionObjectiveLogic objectiveLogic, Camera missionCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateObjective(MissionObjective objective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTargets()
	{
		throw null;
	}
}
