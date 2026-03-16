using System.Runtime.CompilerServices;
using SandBox.View.Menu;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.TournamentLeaderboard;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Menu;

[OverrideView(typeof(MenuTournamentLeaderboardView))]
public class GauntletMenuTournamentLeaderboardView : MenuView
{
	private GauntletLayer _layerAsGauntletLayer;

	private TournamentLeaderboardVM _dataSource;

	private GauntletMovieIdentifier _movie;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationDeactivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMenuTournamentLeaderboardView()
	{
		throw null;
	}
}
