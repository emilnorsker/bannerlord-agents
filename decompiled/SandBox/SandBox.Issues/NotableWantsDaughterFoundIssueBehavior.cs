using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.SaveSystem;

namespace SandBox.Issues;

public class NotableWantsDaughterFoundIssueBehavior : CampaignBehaviorBase
{
	public class NotableWantsDaughterFoundIssueTypeDefiner : SaveableTypeDefiner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public NotableWantsDaughterFoundIssueTypeDefiner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineClassTypes()
		{
			throw null;
		}
	}

	public class NotableWantsDaughterFoundIssue : IssueBase
	{
		private const int TroopTierForAlternativeSolution = 2;

		private const int RequiredSkillLevelForAlternativeSolution = 120;

		public override AlternativeSolutionScaleFlag AlternativeSolutionScaleFlags
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override bool IsThereAlternativeSolution
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override bool IsThereLordSolution
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		protected override int RewardGold
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override int AlternativeSolutionBaseNeededMenCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		protected override int AlternativeSolutionBaseDurationInDaysInternal
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		protected override int CompanionSkillRewardXP
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueBriefByIssueGiver
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueAcceptByPlayer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueQuestSolutionExplanationByIssueGiver
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueAlternativeSolutionExplanationByIssueGiver
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssuePlayerResponseAfterAlternativeExplanation
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueQuestSolutionAcceptByPlayer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueAlternativeSolutionAcceptByPlayer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueDiscussAlternativeSolution
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueAlternativeSolutionResponseByIssueGiver
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		protected override TextObject AlternativeSolutionStartLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueAlternativeSolutionSuccessLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject Title
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject Description
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueAsRumorInSettlement
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NotableWantsDaughterFoundIssue(Hero issueOwner)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override float GetIssueEffectAmountInternal(IssueEffect issueEffect)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AlternativeSolutionEndWithSuccessConsequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AlternativeSolutionEndWithFailureConsequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplySuccessRewards()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnGameLoad()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void HourlyTick()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override QuestBase GenerateIssueQuest(string questId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IssueFrequency GetFrequency()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override (SkillObject, int) GetAlternativeSolutionSkill(Hero hero)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool AlternativeSolutionCondition(out TextObject explanation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool DoTroopsSatisfyAlternativeSolution(TroopRoster troopRoster, out TextObject explanation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsTroopTypeNeededByAlternativeSolution(CharacterObject character)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override bool CanPlayerTakeQuestConditions(Hero issueGiver, out PreconditionFlags flag, out Hero relationHero, out SkillObject skill)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IssueStayAliveConditions()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void CompleteIssueWithTimedOutConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsNotableWantsDaughterFoundIssue(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}
	}

	public class NotableWantsDaughterFoundIssueQuest : QuestBase
	{
		[SaveableField(10)]
		private readonly Hero _daughterHero;

		[SaveableField(20)]
		private readonly Hero _rogueHero;

		private Agent _daughterAgent;

		private Agent _rogueAgent;

		[SaveableField(50)]
		private bool _isQuestTargetMission;

		[SaveableField(60)]
		private bool _didPlayerBeatRouge;

		[SaveableField(70)]
		private bool _exitedQuestSettlementForTheFirstTime;

		[SaveableField(80)]
		private bool _isTrackerLogAdded;

		[SaveableField(90)]
		private bool _isDaughterPersuaded;

		[SaveableField(91)]
		private bool _isDaughterCaptured;

		[SaveableField(100)]
		private bool _acceptedDaughtersEscape;

		[SaveableField(110)]
		private readonly Village _targetVillage;

		[SaveableField(120)]
		private bool _villageIsRaidedTalkWithDaughter;

		[SaveableField(140)]
		private Dictionary<Village, bool> _villagesAndAlreadyVisitedBooleans;

		private Dictionary<string, CharacterObject> _rogueCharacterBasedOnCulture;

		private bool _playerDefeatedByRogue;

		private PersuasionTask _task;

		private const PersuasionDifficulty Difficulty = (PersuasionDifficulty)5;

		private const int MaxAgeForDaughterAndRogue = 25;

		[SaveableField(130)]
		private readonly float _questDifficultyMultiplier;

		public override TextObject Title
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override bool IsRemainingTimeHidden
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private bool DoesMainPartyHasEnoughScoutingSkill
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject PlayerStartsQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject SuccessQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject PlayerDefeatedByRogueLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject FailQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject QuestCanceledWarDeclaredLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject PlayerDeclaredWarQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject VillageRaidedCancelQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NotableWantsDaughterFoundIssueQuest(string questId, Hero questGiver, CampaignTime duration, int baseReward, float issueDifficultyMultiplier)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private CharacterObject GetRogueCharacterBasedOnCulture(string cultureStrId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void SetDialogs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void InitializeQuestOnGameLoad()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void HourlyTick()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsRougeHero(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsDaughterHero(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsMainHero(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool multi_character_conversation_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool daughter_conversation_after_fight_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void multi_agent_conversation_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetRougeDialogFlow()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetDaughterAfterFightDialog()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetDaughterAfterAcceptDialog()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool daughter_conversation_after_accept_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetDaughterAfterPersuadedDialog()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetDaughterDialogWhenVillageRaid()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool daughter_conversation_after_persuaded_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetRougeAfterAcceptDialog()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool rogue_conversation_after_accept_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetRogueAfterPersuadedDialog()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool rogue_conversation_after_persuaded_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnTimedOut()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayerAcceptedDaughtersEscape()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayerWonTheFight()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplyDaughtersEscapeAcceptedFailConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplyDeliveryRejectedFailConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplyDeliverySuccessConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayerRejectsDuelFight()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayerAcceptsDuelFight()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StartConversationAfterFight(bool isPlayerSideWon)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddPersuasionDialogs(DialogFlow dialog)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_selected_option_response_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_selected_option_response_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_select_option_1_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_select_option_2_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_select_option_3_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_select_option_4_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_select_option_1_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_select_option_2_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_select_option_3_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_select_option_4_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PersuasionOptionArgs persuasion_setup_option_1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PersuasionOptionArgs persuasion_setup_option_2()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PersuasionOptionArgs persuasion_setup_option_3()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PersuasionOptionArgs persuasion_setup_option_4()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_clickable_option_1_on_condition(out TextObject hintText)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_clickable_option_2_on_condition(out TextObject hintText)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_clickable_option_3_on_condition(out TextObject hintText)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_clickable_option_4_on_condition(out TextObject hintText)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PersuasionTask GetPersuasionTask()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_start_with_daughter_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void daughter_persuade_to_come_persuasion_success_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool daughter_persuade_to_come_persuasion_failed_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void daughter_persuade_to_come_persuasion_failed_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnSettlementLeft(MobileParty party, Settlement settlement)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnBeforeMissionOpened()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void HandleRogueEquipment()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnMissionEnded(IMission mission)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplyDeliveryFailedDueToDuelLostConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private LocationCharacter CreateQuestLocationCharacter(CharacterObject character, CharacterRelations relation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RemoveQuestCharacters()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SearchTheVillage()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void TalkWithDaughterAfterRaid()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void QuestAcceptedConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CanHeroDie(Hero victim, KillCharacterActionDetail detail, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void RegisterEvents()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnRaidCompleted(BattleSideEnum side, RaidEventComponent raidEventComponent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanMoveToSettlementInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomActionDetail detail, bool showNotification = true)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnWarDeclared(IFaction faction1, IFaction faction2, DeclareWarDetail detail)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsNotableWantsDaughterFoundIssueQuest(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_daughterHero(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_rogueHero(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_isQuestTargetMission(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_didPlayerBeatRouge(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_exitedQuestSettlementForTheFirstTime(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_isTrackerLogAdded(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_isDaughterPersuaded(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_isDaughterCaptured(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_acceptedDaughtersEscape(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetVillage(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_villageIsRaidedTalkWithDaughter(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_villagesAndAlreadyVisitedBooleans(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_questDifficultyMultiplier(object o)
		{
			throw null;
		}
	}

	private const IssueFrequency NotableWantsDaughterFoundIssueFrequency = (IssueFrequency)2;

	private const int IssueDuration = 30;

	private const int QuestTimeLimit = 19;

	private const int BaseRewardGold = 500;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCheckForIssue(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConditionsHold(Hero issueGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IssueBase OnStartIssue(in PotentialIssueData pid, Hero issueOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NotableWantsDaughterFoundIssueBehavior()
	{
		throw null;
	}
}
