using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.ViewModelCollection.Map;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(MapEventVisualsView))]
public class GauntletMapEventVisualsView : MapView, IGauntletMapEventVisualHandler
{
	private GauntletLayer _layerAsGauntletLayer;

	private GauntletMovieIdentifier _movie;

	private MapEventVisualsVM _dataSource;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapScreenUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGauntletMapEventVisualHandler.OnNewEventStarted(GauntletMapEventVisual newEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGauntletMapEventVisualHandler.OnInitialized(GauntletMapEventVisual newEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGauntletMapEventVisualHandler.OnEventEnded(GauntletMapEventVisual newEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGauntletMapEventVisualHandler.OnEventVisibilityChanged(GauntletMapEventVisual visibilityChangedEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapEventVisualsView()
	{
		throw null;
	}
}
