using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.ViewModelCollection.Map.Tracker;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(MapTrackersView))]
public class GauntletMapTrackersView : MapTrackersView
{
	private GauntletLayer _layerAsGauntletLayer;

	private GauntletMovieIdentifier _movie;

	private MapTrackerCollectionVM _dataSource;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapTrackersView()
	{
		throw null;
	}

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
	private void UpdateTrackerPropertiesAux(int startInclusive, int endExclusive)
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
	private void GetScreenPosition(ITrackableCampaignObject trackable, out float screenX, out float screenY, out float screenW)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FastMoveCameraToPosition(CampaignVec2 target)
	{
		throw null;
	}
}
