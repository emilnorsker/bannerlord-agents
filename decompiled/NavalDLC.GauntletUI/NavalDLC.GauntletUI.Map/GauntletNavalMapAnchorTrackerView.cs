using System.Runtime.CompilerServices;
using NavalDLC.View.Map;
using NavalDLC.ViewModelCollection.Map;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace NavalDLC.GauntletUI.Map;

[OverrideView(typeof(NavalMapAnchorTrackerView))]
public class GauntletNavalMapAnchorTrackerView : MapView
{
	private GauntletLayer _gauntletLayer;

	private MapAnchorTrackerVM _dataSource;

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
	protected override void CreateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMoveCameraToAnchor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapScreenUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAnchorScreenPosition(AnchorPoint anchor, out float screenX, out float screenY, out float screenW)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletNavalMapAnchorTrackerView()
	{
		throw null;
	}
}
