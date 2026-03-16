using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.ViewModelCollection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.MountAndBlade.View.Screens;

namespace NavalDLC.View.Map;

[GameStateScreen(typeof(MapState))]
public class NavalMapScreen : MapScreen
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMapScreen(MapState mapState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool TickNavigationInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenManageFleet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override SPScoreboardVM CreateSimulationScoreboardDatasource(BattleSimulation battleSimulation)
	{
		throw null;
	}
}
