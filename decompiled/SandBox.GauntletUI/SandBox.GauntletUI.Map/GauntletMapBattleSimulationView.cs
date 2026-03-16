using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.ViewModelCollection;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(BattleSimulationMapView))]
public class GauntletMapBattleSimulationView : MapView
{
	private GauntletLayer _layerAsGauntletLayer;

	private readonly SPScoreboardVM _dataSource;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapBattleSimulationView(SPScoreboardVM dataSource)
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
	protected override void CreateLayout()
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
}
