using System.Runtime.CompilerServices;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.MountAndBlade.View.Screens;

namespace NavalDLC.GauntletUI.Clan;

[GameStateScreen(typeof(ClanState))]
public class NavalGauntletClanScreen : GauntletClanScreen
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalGauntletClanScreen(ClanState clanState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override ClanManagementVM CreateDataSource()
	{
		throw null;
	}
}
