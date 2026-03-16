using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map.Tracker;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Map.Tracker;

public class MapTrackerCollectionVM : ViewModel
{
	private readonly MapTrackerProvider _mapTrackerProvider;

	private MBBindingList<MapTrackerItemVM> _trackers;

	public MBBindingList<MapTrackerItemVM> Trackers
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
	public MapTrackerCollectionVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTrackerAddedOrRemoved(MapTrackerItemVM item, bool added)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateProperties()
	{
		throw null;
	}
}
