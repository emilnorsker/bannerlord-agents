using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace SandBox.Issues;

public class RuralNotableInnAndOutIssueBehavior : CampaignBehaviorBase
{
	public class RuralNotableInnAndOutIssueTypeDefiner : SaveableTypeDefiner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public RuralNotableInnAndOutIssueTypeDefiner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineClassTypes()
		{
			throw null;
		}
	}

	public class RuralNotableInnAndOutIssue : IssueBase
	{
		private const int CompanionSkillLimit = 120;

		private const int QuestMoneyLimit = 2000;

		private const int AlternativeSolutionGoldCost = 1000;

		private BoardGameType _boardGameType;

		private Settlement _targetSettlement;

		public override AlternativeSolutionScaleFlag AlternativeSolutionScaleFlags
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		protected override bool IssueQuestCanBeDuplicated
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

		protected override TextObject AlternativeSolutionStartLog
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public RuralNotableInnAndOutIssue(Hero issueOwner)
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
		public override bool AlternativeSolutionCondition(out TextObject explanation)
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
		public override bool DoTroopsSatisfyAlternativeSolution(TroopRoster troopRoster, out TextObject explanation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IssueFrequency GetFrequency()
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
		private void InitializeQuestVariables()
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
		protected override bool CanPlayerTakeQuestConditions(Hero issueGiver, out PreconditionFlags flag, out Hero relationHero, out SkillObject skill)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsRuralNotableInnAndOutIssue(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}
	}

	public class RuralNotableInnAndOutIssueQuest : QuestBase
	{
		public const int LesserReward = 800;

		private BoardGameType _boardGameType;

		private Settlement _targetSettlement;

		private bool _checkForBoardGameEnd;

		private bool _playerWonTheGame;

		private bool _applyLesserReward;

		[SaveableField(1)]
		private int _tryCount;

		private TextObject QuestStartLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject SuccessLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject SuccessWithPayingLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject LostLog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject QuestCanceledTargetVillageRaided
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject QuestCanceledWarDeclared
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

		private TextObject QuestCanceledSettlementIsUnderSiege
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject TimeoutLog
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

		public override bool IsRemainingTimeHidden
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public RuralNotableInnAndOutIssueQuest(string questId, Hero giverHero, CampaignTime duration, int rewardGold)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void InitializeQuestVariables()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void QuestAcceptedConsequences()
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
		protected override void RegisterEvents()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnLocationCharactersSimulated()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnVillageBeingRaided(Village village)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnBoardGameEnd(Hero opposingHero, BoardGameState state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnSiegeStarted(SiegeEvent siegeEvent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void SetDialogs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetGameHostDialogFlow()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetGameHostDialogueAfterFirstGame()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool CheckPlayerHasEnoughDenarsClickableCondition(out TextObject explanation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool TavernHostDialogCondition(bool isInitialDialogue = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayerPaid1000QuestSuccess()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplySuccessRewards()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnCompleteWithSuccess()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StartBoardGame()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayerWonTheBoardGame()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayerFailAfterBoardGame()
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
		public override IssueQuestFlags IsLocationTrackedByQuest(Location location)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnTimedOut()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsRuralNotableInnAndOutIssueQuest(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_tryCount(object o)
		{
			throw null;
		}
	}

	private const IssueFrequency RuralNotableInnAndOutIssueFrequency = (IssueFrequency)1;

	private const float IssueDuration = 30f;

	private const float QuestDuration = 14f;

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
	private bool ConditionsHold(Hero issueGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCheckForIssue(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IssueBase OnSelected(in PotentialIssueData pid, Hero issueOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RuralNotableInnAndOutIssueBehavior()
	{
		throw null;
	}
}
