using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class RomanceCampaignBehavior : CampaignBehaviorBase
{
	public enum RomanticPreference
	{
		Conventional,
		Moralist,
		AttractedToBravery,
		Macchiavellian,
		Romantic,
		Companionship,
		MadAndBad,
		Security,
		PreferencesEnd
	}

	private enum RomanceReservationType
	{
		TravelChat,
		TravelLesson,
		Aspirations,
		Compatibility,
		Attraction,
		Family,
		MaterialWealth,
		NoObjection
	}

	private enum RomanceReservationDescription
	{
		CompatibilityINeedSomeoneUpright,
		CompatibilityNeedSomethingInCommon,
		CompatibiliyINeedSomeoneDangerous,
		CompatibilityStrongPoliticalBeliefs,
		AttractionYoureNotMyType,
		AttractionYoureGoodEnough,
		AttractionIAmDrawnToYou,
		PropertyYouSeemRichEnough,
		PropertyWeNeedToBeComfortable,
		PropertyIWantRealWealth,
		PropertyHowCanIMarryAnAdventuress,
		FamilyApprovalIAmGladYouAreFriendsWithOurFamily,
		FamilyApprovalYouNeedToBeFriendsWithOurFamily,
		FamilyApprovalHowCanYouBeEnemiesWithOurFamily,
		FamilyApprovalItWouldBeBestToBefriendOurFamily
	}

	private const PersuasionDifficulty _difficulty = PersuasionDifficulty.Medium;

	private List<PersuasionTask> _allReservations;

	[SaveableField(1)]
	private List<PersuasionAttempt> _previousRomancePersuasionAttempts;

	private Hero _playerProposalHero;

	private Hero _proposedSpouseForPlayerRelative;

	private float _maximumScoreCap;

	private const float _successValue = 1f;

	private const float _criticalSuccessValue = 2f;

	private const float _criticalFailValue = 2f;

	private const float _failValue = 0f;

	private CampaignTime RomanceCourtshipAttemptCooldown
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RomanceCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckNpcMarriages(Clan consideringClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsClanSuitableForNpcMarriage(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionTask GetCurrentPersuasionTask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveUnneededPersuasionAttempts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddDialogs(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool courtship_hero_not_clan_leader_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void courtship_conversation_leave_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_finalize_marriage_barter_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IEnumerable<RomanceReservationDescription> GetRomanceReservations(Hero wooed, Hero wooer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PersuasionTask> GetPersuasionTasksForCourtshipStage1(Hero wooed, Hero wooer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Tuple<TraitObject, int>[] GetTraitCorrelations(int valor = 0, int mercy = 0, int honor = 0, int generosity = 0, int calculating = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PersuasionTask> GetPersuasionTasksForCourtshipStage2(Hero wooed, Hero wooer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_initial_reaction_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_decline_reaction_to_player_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_reaction_to_player_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_fail_courtship_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_start_courtship_persuasion_pt1_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_courtship_stage_1_success_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_courtship_stage_2_success_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_continue_courtship_stage_2_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_check_if_unmet_reservation_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_player_has_failed_in_courtship_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_persuasion_option_1_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_persuasion_option_2_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_persuasion_option_3_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_persuasion_option_4_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_romance_1_persuade_option_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_romance_2_persuade_option_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_romance_3_persuade_option_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_romance_4_persuade_option_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RomancePersuasionOption1ClickableOnCondition1(out TextObject hintText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RomancePersuasionOption2ClickableOnCondition2(out TextObject hintText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RomancePersuasionOption3ClickableOnCondition3(out TextObject hintText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RomancePersuasionOption4ClickableOnCondition4(out TextObject hintText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionArgs SetupCourtshipPersuasionOption1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionArgs SetupCourtshipPersuasionOption2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionArgs SetupCourtshipPersuasionOption3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionArgs SetupCourtshipPersuasionOption4()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_eligible_for_marriage_with_conversation_hero_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_eligible_for_marriage_with_hero_rltv_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_find_player_relatives_eligible_for_marriage_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_player_nominates_self_for_marriage_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_player_nominates_marriage_relative_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_relative_eligible_for_marriage_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_propose_clan_leader_for_player_nomination_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_propose_spouse_for_player_nomination_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_rltv_agrees_on_courtship_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_player_agrees_on_courtship_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_lord_propose_marriage_to_clan_leader_confirm_consequences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_romance_blocked_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_romance_at_stage_1_discussions_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_romance_at_stage_2_discussions_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_finalize_courtship_for_hero_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_finalize_courtship_for_other_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_discuss_marriage_alliance_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_can_open_courtship_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_opens_courtship_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_player_opens_courtship_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_try_later_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_reaction_stage_1_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_marriage_barter_successful_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_marriage_barter_successful_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_courtship_reaction_stage_2_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_lord_persuade_option_reaction_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionTask FindTaskOfOption(PersuasionOptionArgs optionChosenWithLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<CharacterObject> FindPlayerRelativesEligibleForMarriage(Clan withClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject ShowSuccess(PersuasionOptionArgs optionArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MarriageCourtshipPossibility(Hero person1, Hero person2)
	{
		throw null;
	}
}
