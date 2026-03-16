using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.ViewModelCollection.Nameplate;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(MapSettlementNameplateView))]
public class GauntletMapSettlementNameplateView : MapView, IGauntletMapEventVisualHandler
{
	private GauntletLayer _layerAsGauntletLayer;

	private GauntletMovieIdentifier _movie;

	private SettlementNameplatesVM _dataSource;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResume()
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
	private void OnHideoutSpotted(PartyBase party, PartyBase hideoutParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SettlementNameplateVM GetNameplateOfMapEvent(GauntletMapEventVisual mapEvent)
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
	public GauntletMapSettlementNameplateView()
	{
		throw null;
	}
}
