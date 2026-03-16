using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Settlements;

namespace SandBox.CampaignBehaviors;

public class RetirementCampaignBehavior : CampaignBehaviorBase
{
	private Hero _selectedHeir;

	private bool _hasTalkedWithHermitBefore;

	private bool _playerEndedGame;

	private Settlement _retirementSettlement;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupGameMenus(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupConversationDialogues(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool hermit_start_talk_first_time_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hermit_player_retire_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DecideRetirementPositively()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DecideRetirementNegatively()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hermit_player_select_heir_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hermit_select_heir_multiple_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool hermit_select_heir_multiple_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool hermit_start_talk_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowGameStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void retirement_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool enter_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool leave_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void retirement_menu_on_enter(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void retirement_menu_on_leave(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckRetirementSettlementVisibility()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RetirementCampaignBehavior()
	{
		throw null;
	}
}
