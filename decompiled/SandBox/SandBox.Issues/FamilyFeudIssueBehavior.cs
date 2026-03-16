using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.GameMenus;
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

public class FamilyFeudIssueBehavior : CampaignBehaviorBase
{
	public class FamilyFeudIssueTypeDefiner : SaveableTypeDefiner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public FamilyFeudIssueTypeDefiner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineClassTypes()
		{
			throw null;
		}
	}

	public class FamilyFeudIssueMissionBehavior : MissionLogic
	{
		private Action<Agent, Agent, int> OnAgentHitAction;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FamilyFeudIssueMissionBehavior(Action<Agent, Agent, int> agentHitAction)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData)
		{
			throw null;
		}
	}

	public class FamilyFeudIssue : IssueBase
	{
		private const int CompanionRequiredSkillLevel = 120;

		private const int QuestTimeLimit = 20;

		private const int IssueDuration = 30;

		private const int TroopTierForAlternativeSolution = 2;

		[SaveableField(10)]
		private Settlement _targetVillage;

		[SaveableField(20)]
		private Hero _targetNotable;

		public override AlternativeSolutionScaleFlag AlternativeSolutionScaleFlags
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

		protected override int RewardGold
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[SaveableProperty(30)]
		public override Hero CounterOfferHero
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			protected set
			{
				throw null;
			}
		}

		public override int NeededInfluenceForLordSolution
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

		protected override TextObject AlternativeSolutionStartLog
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

		protected override TextObject LordSolutionStartLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		protected override TextObject LordSolutionCounterOfferRefuseLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		protected override TextObject LordSolutionCounterOfferAcceptLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueLordSolutionExplanationByIssueGiver
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssuePlayerResponseAfterLordExplanation
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

		public override TextObject IssueLordSolutionAcceptByPlayer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueLordSolutionResponseByIssueGiver
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueLordSolutionCounterOfferExplanationByOtherNpc
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueLordSolutionCounterOfferBriefByOtherNpc
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueLordSolutionCounterOfferAcceptByPlayer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueLordSolutionCounterOfferAcceptResponseByOtherNpc
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueLordSolutionCounterOfferDeclineByPlayer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public override TextObject IssueLordSolutionCounterOfferDeclineResponseByOtherNpc
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

		public override TextObject IssueAsRumorInSettlement
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FamilyFeudIssue(Hero issueOwner, Hero targetNotable, Settlement targetVillage)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanBeSelectedInInventoryInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanHavePartyRoleOrBeGovernorInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanLeadPartyInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CommonResrictionInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override float GetIssueEffectAmountInternal(IssueEffect issueEffect)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override (SkillObject, int) GetAlternativeSolutionSkill(Hero hero)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void LordSolutionConsequenceWithAcceptCounterOffer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void LordSolutionConsequenceWithRefuseCounterOffer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool LordSolutionCondition(out TextObject explanation)
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
		protected override void AfterIssueCreation()
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
		internal static void AutoGeneratedStaticCollectObjectsFamilyFeudIssue(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValueCounterOfferHero(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetVillage(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetNotable(object o)
		{
			throw null;
		}
	}

	public class FamilyFeudIssueQuest : QuestBase
	{
		private const int CustomCulpritAgentHealth = 350;

		private const int CustomTargetNotableAgentHealth = 350;

		public const string CommonAreaTag = "alley_2";

		[SaveableField(10)]
		private readonly Settlement _targetSettlement;

		[SaveableField(20)]
		private Hero _targetNotable;

		[SaveableField(30)]
		private Hero _culprit;

		[SaveableField(40)]
		private bool _culpritJoinedPlayerParty;

		[SaveableField(50)]
		private bool _checkForMissionEvents;

		[SaveableField(70)]
		private int _rewardGold;

		private bool _isCulpritDiedInMissionFight;

		private bool _isPlayerKnockedOutMissionFight;

		private bool _isNotableKnockedDownInMissionFight;

		private bool _conversationAfterFightIsDone;

		private bool _persuationInDoneAndSuccessfull;

		private bool _playerBetrayedCulprit;

		private Agent _notableAgent;

		private Agent _culpritAgent;

		private CharacterObject _notableGangsterCharacterObject;

		private List<LocationCharacter> _notableThugs;

		private PersuasionTask _task;

		private const PersuasionDifficulty Difficulty = (PersuasionDifficulty)4;

		public override bool IsRemainingTimeHidden
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private bool FightEnded
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

		private TextObject PlayerStartsQuestLogText1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject PlayerStartsQuestLogText2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject SuccessQuestSolutionLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject CulpritJoinedPlayerPartyLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject QuestGiverVillageRaidedBeforeTalkingToCulpritCancel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject TargetVillageRaidedBeforeTalkingToCulpritCancel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject CulpritDiedQuestFail
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject PlayerDiedInNotableBattle
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

		private TextObject CulpritNoLongerAClanMember
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject CompanionLimitReachedQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FamilyFeudIssueQuest(string questId, Hero questGiver, CampaignTime duration, Settlement targetSettlement, Hero targetHero, int rewardGold)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void InitializeQuestDialogs()
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
		private DialogFlow GetNotableDialogFlowBeforeTalkingToCulprit()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetNotableDialogFlowAfterKillingCulprit()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetNotableDialogFlowAfterPlayerBetrayCulprit()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetCulpritDialogFlowAfterCulpritJoin()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetNotableDialogFlowAfterQuestEnd()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetCulpritDialogFlowAfterQuestEnd()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetNotableDialogFlowAfterNotableKnowdown()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool AfterNotableKnowdownEndingCondition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayerAndCulpritKnockedDownNotableQuestSuccess()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void HandleAgentBehaviorAfterQuestConversations()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplySuccessConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool multi_character_conversation_condition_after_fight()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void multi_character_conversation_consequence_after_fight()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetNotableDialogFlowAfterTalkingToCulprit()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsMainAgent(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsTargetNotable(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsCulprit(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool notable_culprit_is_not_near_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool multi_character_conversation_on_condition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddPersuasionDialogs(DialogFlow dialog)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_complete_with_notable_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_failed_with_notable_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void persuasion_failed_with_notable_start_fight_on_consequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool persuasion_failed_with_family_feud_notable_on_condition()
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
		private void persuasion_start_with_notable_on_consequence()
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
		private PersuasionTask GetPersuasionTask()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StartFightWithNotableGang(bool playerBetrayedCulprit)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnAgentHit(Agent affectedAgent, Agent affectorAgent, int damage)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void SetDialogs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void QuestAcceptedConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetCulpritDialogFlow()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetNotableThugDialogFlow()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CulpritJoinedPlayersArmy()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void RegisterEvents()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnGameLoadFinished()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnNewCompanionAdded(Hero hero)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnPerksReset(Hero hero, PerkObject perk)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CheckCompanionLimit()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CanMoveToSettlement(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanBeSelectedInInventoryInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanHavePartyRoleOrBeGovernorInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanLeadPartyInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CommonRestrictionInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CanHeroDie(Hero hero, KillCharacterActionDetail causeOfDeath, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification = true)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnPrisonerTaken(PartyBase capturer, Hero prisoner)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnVillageRaid(Village village)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnCompanionRemoved(Hero companion, RemoveCompanionDetail detail)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnMissionStarted(IMission iMission)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnMissionEnd(IMission mission)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnGameMenuOpened(MenuCallbackArgs args)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnSettlementLeft(MobileParty party, Settlement settlement)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnBeforeMissionOpened()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private LocationCharacter CreateCulpritLocationCharacter(CultureObject culture, CharacterRelations relation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private LocationCharacter CreateNotablesThugs(CultureObject culture, CharacterRelations relation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnMapEventEnded(MapEvent mapEvent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CulpritDiedInNotableFightFail()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnTimedOut()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void TiemoutFailConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsFamilyFeudIssueQuest(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetSettlement(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetNotable(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_culprit(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_culpritJoinedPlayerParty(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_checkForMissionEvents(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_rewardGold(object o)
		{
			throw null;
		}
	}

	private const IssueFrequency FamilyFeudIssueFrequency = (IssueFrequency)2;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCheckForIssue(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConditionsHold(Hero issueGiver, out Settlement otherVillage, out Hero otherNotable)
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
	public FamilyFeudIssueBehavior()
	{
		throw null;
	}
}
