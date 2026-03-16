using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class VillageHostileActionCampaignBehavior : CampaignBehaviorBase
{
	private enum HostileActionType
	{
		Raid,
		ForceTroop,
		ForceSupply
	}

	private const int IntervalForHostileActionAsDay = 10;

	private readonly TextObject EnemyNotAttackableTooltip;

	private Dictionary<string, CampaignTime> _villageLastHostileActionTimeDictionary;

	private IFaction _raiderPartyMapFaction;

	private Village _raidedVillage;

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
	private static void BeforeGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAfterSessionLaunched(CampaignGameStarter campaignGameSystemStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus(CampaignGameStarter campaignGameSystemStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool wait_menu_end_raiding_at_army_by_leaving_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_village_hostile_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool game_menu_village_hostile_action_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_village_hostile_action_raid_village_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_village_hostile_action_raid_village_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_village_hostile_action_force_volunteers_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_village_hostile_action_force_volunteers_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_village_hostile_action_forget_it_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_village_hostile_action_take_food_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_village_hostile_action_take_food_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_village_hostile_action_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool game_menu_village_hostile_action_raid_village_warn_continue_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool game_menu_force_supplies_village_resist_warn_player_continue_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_force_supplies_village_resist_warn_player_continue_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool game_menu_force_troops_village_resist_warn_player_continue_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void village_raid_game_menu_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_force_troops_village_resist_warn_player_continue_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool wait_menu_start_raiding_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_raid_warn_player_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void wait_menu_end_raiding_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void village_player_raid_ended_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void wait_menu_end_raiding_at_army_by_leaving_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void village_raid_ended_leaded_by_someone_else_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool wait_menu_end_raiding_at_army_by_abandoning_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void wait_menu_end_raiding_at_army_by_abandoning_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool wait_menu_end_raiding_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void wait_menu_raiding_village_on_tick(MenuCallbackArgs args, CampaignTime dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void force_supply_game_menu_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void village_raid_ended_leaded_by_someone_else_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SetHostileActionWarnPlayerInitBackground(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_force_supply_warn_player_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_village_hostile_action_raid_village_warn_continue_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void village_force_supplies_ended_successfully_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void force_troop_game_menu_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_force_troop_warn_player_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void village_force_volunteers_ended_successfully_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void game_menu_village_hostile_action_warn_leave_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void village_looted_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void UpdateWaitMenuProgress(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void village_looted_leave_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void village_player_raid_ended_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TextObject GetHostileActionGenericWarnExplanation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("village_player_raid_ended")]
	private static void game_menu_village_raid_ended_menu_sound_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("village_looted")]
	[GameMenuInitializationHandler("village_raid_ended_leaded_by_someone_else")]
	[GameMenuInitializationHandler("raiding_village")]
	private static void game_menu_ui_village_hostile_raid_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[GameMenuInitializationHandler("village_hostile_action")]
	[GameMenuInitializationHandler("force_volunteers_village")]
	[GameMenuInitializationHandler("force_supplies_village")]
	[GameMenuInitializationHandler("raid_village_no_resist_warn_player")]
	[GameMenuInitializationHandler("raid_village_resisted")]
	[GameMenuInitializationHandler("village_loot_no_resist")]
	[GameMenuInitializationHandler("village_take_food_confirm")]
	[GameMenuInitializationHandler("village_press_into_service_confirm")]
	[GameMenuInitializationHandler("menu_press_into_service_success")]
	[GameMenuInitializationHandler("menu_village_take_food_success")]
	private static void game_menu_village_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool hostile_action_common_back_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool hostile_action_common_continue_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void StartHostileAction(HostileActionType hostileActionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckVillageAttackableHonorably(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnItemsLooted(MobileParty mobileParty, ItemRoster lootedItems)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckFactionAttackableHonorably(MenuCallbackArgs args, IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VillageHostileActionCampaignBehavior()
	{
		throw null;
	}
}
