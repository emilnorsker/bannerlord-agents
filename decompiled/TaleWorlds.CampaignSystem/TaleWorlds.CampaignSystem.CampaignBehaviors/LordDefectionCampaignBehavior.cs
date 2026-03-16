using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class LordDefectionCampaignBehavior : CampaignBehaviorBase
{
	public class LordDefectionCampaignBehaviorTypeDefiner : SaveableTypeDefiner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public LordDefectionCampaignBehaviorTypeDefiner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineEnumTypes()
		{
			throw null;
		}
	}

	private enum DefectionReservationType
	{
		LordDefectionPlayerTrust,
		LordDefectionOathToLiege,
		LordDefectionLoyalty,
		LordDefectionPolicy,
		LordDefectionSelfinterest
	}

	private const PersuasionDifficulty _difficulty = PersuasionDifficulty.Medium;

	private List<PersuasionTask> _allReservations;

	[SaveableField(1)]
	private List<PersuasionAttempt> _previousDefectionPersuasionAttempts;

	private float _maximumScoreCap;

	private float _successValue;

	private float _criticalSuccessValue;

	private float _criticalFailValue;

	private float _failValue;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LordDefectionCampaignBehavior()
	{
		throw null;
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
	public void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearPersuasion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionTask GetFailedPersuasionTask(DefectionReservationType reservationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionTask GetAnyFailedPersuasionTask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionTask GetCurrentPersuasionTask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddDialogs(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddLordDefectionPersuasionOptions(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool defection_barter_successful_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void defection_successful_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_recruit_1_persuade_option_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_lord_recruit_1_persuade_option_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_lord_recruit_2_persuade_option_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_lord_recruit_3_persuade_option_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_lord_recruit_4_persuade_option_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DefectionPersuasionOption1ClickableOnCondition1(out TextObject hintText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DefectionPersuasionOption2ClickableOnCondition2(out TextObject hintText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DefectionPersuasionOption3ClickableOnCondition3(out TextObject hintText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DefectionPersuasionOption4ClickableOnCondition4(out TextObject hintText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_recruit_2_persuade_option_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_recruit_3_persuade_option_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_recruit_4_persuade_option_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionArgs SetupDefectionPersuasionOption1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionArgs SetupDefectionPersuasionOption2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionArgs SetupDefectionPersuasionOption3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionArgs SetupDefectionPersuasionOption4()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_start_defection_with_prisoner_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_persuade_option_reaction_pre_reject_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_persuade_option_reaction_on_condition()
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
	private void conversation_on_end_persuasion_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool conversation_lord_player_has_failed_in_defection_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool conversation_lord_recruit_check_if_reservations_met_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool conversation_lord_check_if_ready_to_join_faction_without_barter_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void conversation_lord_defect_to_clan_without_barter_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool conversation_lord_check_if_ready_to_join_faction_with_barter_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PersuasionTask> GetPersuasionTasksForDefection(Hero forLord, Hero newLiege)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool conversation_player_is_asking_to_recruit_enemy_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool conversation_player_is_asking_to_recruit_neutral_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_suggest_treason_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool conversation_lord_from_ruling_clan_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool conversation_lord_redirects_to_clan_leader_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void persuasion_redierect_player_finish_on_consequece()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_lord_can_recruit_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void start_lord_defection_persuasion_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_clear_persuasion_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_leave_faction_barter_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanAttemptToPersuade(Hero targetHero, int reservationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveOldAttempts()
	{
		throw null;
	}
}
