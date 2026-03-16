using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Missions.NameMarker;

public class MissionNameMarkerVM : ViewModel
{
	private class MarkerDistanceComparer : IComparer<MissionNameMarkerTargetBaseVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(MissionNameMarkerTargetBaseVM x, MissionNameMarkerTargetBaseVM y)
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

	private bool _prevEnabledState;

	private bool _fadeOutTimerStarted;

	private float _fadeOutTimer;

	private readonly MarkerDistanceComparer _distanceComparer;

	private readonly List<MissionNameMarkerProvider> _providers;

	private MBBindingList<MissionNameMarkerTargetBaseVM> _targets;

	private bool _isEnabled;

	public bool IsTargetsAdded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<MissionNameMarkerTargetBaseVM> Targets
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
	public MissionNameMarkerVM(List<MissionNameMarkerProvider> providers, Camera missionCamera)
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
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetTargetDifferences(IList<MissionNameMarkerTargetBaseVM> currentTargets, IList<MissionNameMarkerTargetBaseVM> newTargets, out MBReadOnlyList<MissionNameMarkerTargetBaseVM> removedTargets, out MBReadOnlyList<MissionNameMarkerTargetBaseVM> addedTargets)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetsDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTargetScreenPositions(bool forceUpdate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTargetStates(bool state)
	{
		throw null;
	}
}
