using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.GameMenus.GameMenuInitializationHandlers;

public class DefaultEncounter
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("taken_prisoner")]
	[GameMenuInitializationHandler("menu_captivity_end_no_more_enemies")]
	[GameMenuInitializationHandler("menu_captivity_end_by_ally_party_saved")]
	[GameMenuInitializationHandler("menu_captivity_end_by_party_removed")]
	[GameMenuInitializationHandler("menu_captivity_end_wilderness_escape")]
	[GameMenuInitializationHandler("menu_escape_captivity_during_battle")]
	[GameMenuInitializationHandler("menu_released_after_battle")]
	[GameMenuInitializationHandler("menu_captivity_end_propose_ransom_wilderness")]
	public static void game_menu_taken_prisoner_ui_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("defeated_and_taken_prisoner")]
	public static void game_menu_defeat_and_taken_prisoner_ui_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("menu_captivity_transfer_to_town")]
	[GameMenuInitializationHandler("menu_captivity_end_exchanged_with_prisoner")]
	[GameMenuInitializationHandler("menu_captivity_end_propose_ransom_in_prison")]
	[GameMenuInitializationHandler("menu_captivity_castle_remain")]
	[GameMenuInitializationHandler("menu_captivity_end_propose_ransom_out")]
	[GameMenuInitializationHandler("menu_captivity_end_prison_escape")]
	public static void game_menu_taken_prisoner_town_ui_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("e3_action_menu")]
	private static void E3ActionMenuOnInit(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("join_encounter")]
	private static void game_menu_join_encounter_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("encounter")]
	[GameMenuInitializationHandler("try_to_get_away")]
	[GameMenuInitializationHandler("try_to_get_away_debrief")]
	private static void game_menu_encounter_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("naval_town_outside")]
	private static void game_menu_naval_town_outside_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("join_siege_event")]
	[GameMenuInitializationHandler("join_sally_out")]
	private static void game_menu_join_siege_event_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("village_loot_complete")]
	private static void game_menu_village_loot_complete_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("town_wait")]
	[GameMenuInitializationHandler("town_guard")]
	[GameMenuInitializationHandler("menu_tournament_withdraw_verify")]
	[GameMenuInitializationHandler("menu_tournament_bet_confirm")]
	[GameMenuInitializationHandler("siege_attacker_defeated")]
	public static void game_menu_town_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("siege_attacker_left")]
	public static void game_menu_attackers_left_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("new_game_begin")]
	public static void game_menu_new_game_begin_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("kingdom", "mno_call_to_arms", GameMenuEventHandler.EventType.OnConsequence)]
	public static void game_menu_kingdom_mno_call_to_arms_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("kingdom", "encyclopedia", GameMenuEventHandler.EventType.OnConsequence)]
	[GameMenuEventHandler("reports", "encyclopedia", GameMenuEventHandler.EventType.OnConsequence)]
	public static void game_menu_encyclopedia_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("request_meeting")]
	[GameMenuInitializationHandler("request_meeting_with_besiegers")]
	public static void game_menu_town_menu_request_meeting_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultEncounter()
	{
		throw null;
	}
}
