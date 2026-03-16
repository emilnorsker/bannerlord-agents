using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.GameMenus.GameMenuInitializationHandlers;

public class PlayerTownVisit
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("town")]
	[GameMenuInitializationHandler("castle")]
	private static void game_menu_town_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("town_wait")]
	[GameMenuInitializationHandler("town_guard")]
	[GameMenuInitializationHandler("menu_tournament_withdraw_verify")]
	[GameMenuInitializationHandler("menu_tournament_bet_confirm")]
	public static void game_menu_town_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("town", "manage_production", GameMenuEventHandler.EventType.OnConsequence)]
	[GameMenuEventHandler("town", "manage_production_cheat", GameMenuEventHandler.EventType.OnConsequence)]
	public static void game_menu_town_manage_town_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("town_keep", "manage_production", GameMenuEventHandler.EventType.OnConsequence)]
	public static void game_menu_town_castle_manage_town_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("castle", "manage_production", GameMenuEventHandler.EventType.OnConsequence)]
	public static void game_menu_castle_manage_castle_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("tutorial", "mno_go_back_dot", GameMenuEventHandler.EventType.OnConsequence)]
	private static void mno_go_back_dot(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("village", "buy_goods", GameMenuEventHandler.EventType.OnConsequence)]
	private static void game_menu_village_buy_good_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("village", "manage_production", GameMenuEventHandler.EventType.OnConsequence)]
	private static void game_menu_village_manage_village_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuEventHandler("village", "recruit_volunteers", GameMenuEventHandler.EventType.OnConsequence)]
	[GameMenuEventHandler("town_backstreet", "recruit_volunteers", GameMenuEventHandler.EventType.OnConsequence)]
	[GameMenuEventHandler("town", "recruit_volunteers", GameMenuEventHandler.EventType.OnConsequence)]
	private static void game_menu_recruit_volunteers_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerTownVisit()
	{
		throw null;
	}
}
