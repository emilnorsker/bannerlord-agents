using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.MapEvents;

namespace SandBox.GauntletUI.Map;

public class GauntletMapEventVisualCreator : IMapEventVisualCreator
{
	public List<IGauntletMapEventVisualHandler> Handlers;

	private readonly List<GauntletMapEventVisual> _listOfEvents;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMapEventVisual CreateMapEventVisual(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventOver(GauntletMapEventVisual overEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventInitialized(GauntletMapEventVisual initializedEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventVisibilityChanged(GauntletMapEventVisual visibilityChangedEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<GauntletMapEventVisual> GetCurrentEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapEventVisualCreator()
	{
		throw null;
	}
}
