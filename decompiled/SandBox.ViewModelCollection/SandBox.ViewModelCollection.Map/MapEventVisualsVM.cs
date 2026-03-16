using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Map;

public class MapEventVisualsVM : ViewModel
{
	private readonly Camera _mapCamera;

	private readonly Dictionary<MapEvent, MapEventVisualItemVM> _eventToVisualMap;

	private readonly ParallelForAuxPredicate UpdateMapEventsAuxPredicate;

	private MBBindingList<MapEventVisualItemVM> _mapEvents;

	public MBBindingList<MapEventVisualItemVM> MapEvents
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
	public MapEventVisualsVM(Camera mapCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMapEventsAux(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapEventVisibilityChanged(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapEventStarted(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMapEventSettlementRelated(MapEvent mapEvent)
	{
		throw null;
	}
}
