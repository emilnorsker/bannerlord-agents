using System.Runtime.CompilerServices;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement;
using TaleWorlds.MountAndBlade.View.Screens;

namespace NavalDLC.GauntletUI.KingdomManagement;

[GameStateScreen(typeof(KingdomState))]
public class NavalGauntletKingdomScreen : GauntletKingdomScreen
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalGauntletKingdomScreen(KingdomState kingdomState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override KingdomManagementVM CreateDataSource()
	{
		throw null;
	}
}
