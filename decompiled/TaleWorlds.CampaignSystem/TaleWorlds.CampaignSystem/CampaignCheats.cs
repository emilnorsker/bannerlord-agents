using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.CampaignSystem;

public static class CampaignCheats
{
	[Flags]
	private enum CheatTextControl
	{
		None = 0,
		IgnoreCase = 1,
		ContainId = 2,
		RemoveEmptySpace = 4,
		All = 7
	}

	public const string Help = "help";

	public const string EnterNumber = "Please enter a number";

	public const string EnterPositiveNumber = "Please enter a positive number";

	public const string CampaignNotStarted = "Campaign was not started.";

	public const string CheatModeDisabled = "Cheat mode is disabled!";

	private const string AmbiguityFoundErrorMessage = "There is ambiguity with requested id, check parameters";

	private const string NotFoundErrorMessage = "Requested object could not found, check parameters";

	private const string EmptyIdRequestedMessage = "Requested Id can't be empty";

	public const int MaxSkillValue = 300;

	public const string OK = "Success";

	public const string CheatNameSeparator = "|";

	public static string ErrorType;

	private const float _maxAmountPlayerCanGive = 10000f;

	private const string _maxAmountWarning = "The value is too much";

	public static Settlement GetDefaultSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckCheatUsage(ref string ErrorType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckParameters(List<string> strings, int ParameterCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckHelp(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsValueAcceptable(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<string> GetSeparatedNames(List<string> strings, bool removeEmptySpaces = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ConcatenateString(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("export_hero", "campaign")]
	private static string ExportHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("import_main_hero", "campaign")]
	public static string ImportMainHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("export_main_hero", "campaign")]
	public static string ExportMainHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_hero_crafting_stamina", "campaign")]
	public static string SetCraftingStamina(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_hero_culture", "campaign")]
	public static string SetHeroCulture(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_clan_culture", "campaign")]
	public static string SetClanCulture(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_skill_xp_to_hero", "campaign")]
	public static string AddSkillXpToHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_player_traits", "campaign")]
	public static string PrintPlayerTrait(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("show_settlements", "campaign")]
	public static string ShowSettlements(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_skills_of_hero", "campaign")]
	public static string SetSkillsOfGivenHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("hide_settlements", "campaign")]
	public static string HideSettlements(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_skill_player", "campaign")]
	public static string SetSkillMainHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_skill_of_all_companions", "campaign")]
	public static string SetSkillCompanion(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_all_companion_skills", "campaign")]
	public static string SetAllSkillsOfAllCompanions(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_all_heroes_skills", "campaign")]
	public static string SetAllHeroSkills(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_loyalty_of_settlement", "campaign")]
	public static string SetLoyaltyOfSettlement(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_prosperity_of_settlement", "campaign")]
	public static string SetProsperityOfSettlement(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_militia_of_settlement", "campaign")]
	public static string SetMilitiaOfSettlement(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_security_of_settlement", "campaign")]
	public static string SetSecurityOfSettlement(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_food_of_settlement", "campaign")]
	public static string SetFoodOfSettlement(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_hearth_of_settlement", "campaign")]
	public static string SetHearthOfSettlement(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("show_relation", "campaign")]
	public static string ShowHeroRelation(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_hero_relation", "campaign")]
	public static string AddHeroRelation(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_player_party_position", "campaign")]
	public static string PrintMainPartyPosition(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_crafting_materials", "campaign")]
	public static string AddCraftingMaterials(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("heal_player_party", "campaign")]
	public static string HealMainParty(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("declare_war", "campaign")]
	public static string DeclareWar(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_item_to_player_party", "campaign")]
	public static string AddItemToPlayerParty(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("declare_peace", "campaign")]
	public static string DeclarePeace(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_influence", "campaign")]
	public static string AddInfluence(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_renown_to_clan", "campaign")]
	public static string AddRenown(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_gold_to_hero", "campaign")]
	public static string AddGoldToHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_building_level", "campaign")]
	public static string AddDevelopment(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("activate_all_policies_for_player_kingdom", "campaign")]
	public static string ActivateAllPolicies(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_player_trait", "campaign")]
	public static string SetPlayerReputationTrait(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("give_settlement_to_player", "campaign")]
	public static string GiveSettlementToPlayer(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("give_settlement_to_kingdom", "campaign")]
	public static string GiveSettlementToKingdom(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_power_to_notable", "campaign")]
	public static string AddPowerToNotable(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("rule_your_faction", "campaign")]
	public static string LeadYourFaction(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_heroes_suitable_for_marriage", "campaign")]
	public static string PrintHeroesSuitableForMarriage(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("marry_player_with_hero", "campaign")]
	public static string MarryPlayerWithHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("marry_hero_to_hero", "campaign")]
	public static string MarryHeroWithHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("is_hero_suitable_for_marriage_with_player", "campaign")]
	public static string IsHeroSuitableForMarriageWithPlayer(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("create_player_kingdom", "campaign")]
	public static string CreatePlayerKingdom(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("create_clan", "campaign")]
	public static string CreateRandomClan(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("lead_kingdom", "campaign")]
	public static string LeadKingdom(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("join_kingdom", "campaign")]
	public static string JoinKingdom(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("join_kingdom_as_mercenary", "campaign")]
	public static string JoinKingdomAsMercenary(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("make_trade_agreement", "campaign")]
	public static string MakeTradeAgreement(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_criminal_ratings", "campaign")]
	public static string PrintCriminalRatings(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_player_age", "campaign")]
	public static string SetMainHeroAge(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_main_party_attackable", "campaign")]
	public static string SetMainPartyAttackable(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_morale_to_party", "campaign")]
	public static string AddMoraleToParty(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("boost_cohesion_of_army", "campaign")]
	public static string BoostCohesionOfArmy(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_focus_points_to_hero", "campaign")]
	public static string AddFocusPointCheat(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_attribute_points_to_hero", "campaign")]
	public static string AddAttributePointsCheat(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_tournaments", "campaign")]
	public static string PrintSettlementsWithTournament(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ConvertListToMultiLine(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_all_issues", "campaign")]
	public static string PrintAllIssues(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("give_workshop_to_player", "campaign")]
	public static string GiveWorkshopToPlayer(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("conceive_child", "campaign")]
	public static string MakePregnant(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hero GenerateChild(Hero hero, bool isFemale, CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_prisoner_to_party", "campaign")]
	public static string AddPrisonerToParty(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("clear_settlement_defense", "campaign")]
	public static string ClearSettlementDefense(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_xp_to_player_party_prisoners", "campaign")]
	public static string AddPrisonersXp(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_hero_trait", "campaign")]
	public static string SetHeroTrait(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("remove_militias_from_settlement", "campaign")]
	public static string RemoveMilitiasFromSettlement(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("cancel_quest", "campaign")]
	public static string CancelQuestCheat(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("kick_companion", "campaign")]
	public static string KickCompanionFromParty(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_xp_to_player_party_troops", "campaign")]
	public static string AddTroopsXp(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_gameplay_statistics", "campaign")]
	public static string PrintGameplayStatistics(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_parties_visible", "campaign")]
	public static string SetAllArmiesAndPartiesVisible(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_strength_of_lord_parties", "campaign")]
	public static string PrintStrengthOfLordParties(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("toggle_information_restrictions", "campaign")]
	public static string ToggleInformationRestrictions(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("print_strength_of_factions", "campaign")]
	public static string PrintStrengthOfFactions(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_supporters_for_main_hero", "campaign")]
	public static string AddSupportersForMainHero(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_campaign_speed_multiplier", "campaign")]
	public static string SetCampaignSpeed(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("show_hideouts", "campaign")]
	public static string ShowHideouts(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("hide_hideouts", "campaign")]
	public static string HideHideouts(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("unlock_all_crafting_pieces", "campaign")]
	public static string UnlockCraftingPieces(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("rebellion_enabled", "campaign")]
	public static string SetRebellionEnabled(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("add_troops", "campaign")]
	public static string AddTroopsToParty(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetObject<T>(string requestedId, out T obj, out string errorMessage, Func<T, bool> predicate = null) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Hero GetClanLeader(string clanName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ItemModifier GetItemModifier(string itemModifierName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsPartySuitableToUseCheat(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CampaignCheats()
	{
		throw null;
	}
}
