using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class CompanionRolesCampaignBehavior : CampaignBehaviorBase
{
	private const int CompanionRelationLimit = -10;

	private const int NeededGoldToGrantFief = 20000;

	private const int NeededInfluenceToGrantFief = 500;

	private const int RelationGainWhenCompanionToLordAction = 50;

	private const int NewCreatedHeroForCompanionClanMaxAge = 50;

	private const int NewHeroSkillUpperLimit = 175;

	private const int NewHeroSkillLowerLimit = 125;

	private Settlement _selectedFief;

	private bool _playerConfirmedTheAction;

	private List<int> _alreadyUsedIconIdsForNewClans;

	private bool _partyCreatedAfterRescueForCompanion;

	private static CompanionRolesCampaignBehavior CurrentBehavior
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroRelationChanged(Hero effectiveHero, Hero effectiveHeroGainedRelationWith, int relationChange, bool showNotification, ChangeRelationAction.ChangeRelationDetail detail, Hero originalHero, Hero originalGainedRelationWith)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddDialogs(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_fire_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool turn_companion_to_lord_no_fief_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool turn_companion_to_lord_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_is_leading_caravan_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void fief_grant_answer_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool list_player_fief_clickable_condition(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool list_player_fief_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void list_player_fief_selected_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void turn_companion_to_lord_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ConfirmTurningCompanionToLordConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void RejectTurningCompanionToLordConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ClanNameSelectionIsDone(string clanName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AdjustCompanionsEquipment(Hero companionHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetRandomBannerIdForNewClan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SpawnNewHeroesForNewCompanionClan(Hero companionHero, Clan clan, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Hero CreateNewHeroForNewCompanionClan(CharacterObject templateCharacter, Settlement settlement, Dictionary<SkillObject, int> startingSkills)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Equipment GetNewEquipmentForCompanion(Hero companionHero, bool isCivilian)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void list_player_fief_cancel_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool fief_selected_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_thanks_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool fief_selected_confirm_clickable_on_condition(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void companion_talk_done_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void companion_fire_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool companion_rejoin_after_emprisonment_role_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void companion_rejoin_after_emprisonment_role_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCompanionRemoved(Hero companion, RemoveCompanionAction.RemoveCompanionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool companion_agrees_to_leave_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_has_role_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_role_discuss_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_assign_role_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_becomes_engineer_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void companion_becomes_engineer_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_becomes_surgeon_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void companion_becomes_surgeon_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_becomes_quartermaster_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void companion_becomes_quartermaster_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_becomes_scout_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void companion_becomes_scout_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void companion_delete_party_role_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_fire_engineer_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_fire_surgeon_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_fire_quartermaster_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool companion_fire_scout_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool companion_rescue_start_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void companion_rescue_answer_options_join_party_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool lead_a_party_clickable_condition(out TextObject reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void companion_rescue_answer_options_lead_party_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenPartyScreenForRescue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PartyScreenClosed(PartyBase leftOwnerParty, TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, PartyBase rightOwnerParty, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TroopTransferableDelegate(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase LeftOwnerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool party_screen_continue_conversation_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool party_screen_opened_but_party_is_not_created_after_rescue_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool party_screen_opened_and_party_is_created_after_rescue_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void end_rescue_companion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CompanionRolesCampaignBehavior()
	{
		throw null;
	}
}
