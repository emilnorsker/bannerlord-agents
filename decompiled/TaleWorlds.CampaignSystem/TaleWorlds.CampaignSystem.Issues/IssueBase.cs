using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Issues;

public abstract class IssueBase : MBObjectBase
{
	internal enum IssueState
	{
		Ongoing,
		SolvingWithQuestSolution,
		SolvingWithAlternativeSolution,
		SolvingWithLordSolution
	}

	[Flags]
	public enum AlternativeSolutionScaleFlag : uint
	{
		None = 0u,
		Duration = 1u,
		RequiredTroops = 2u,
		Casualties = 4u,
		FailureRisk = 8u
	}

	[Flags]
	protected enum PreconditionFlags : uint
	{
		None = 0u,
		Relation = 1u,
		Skill = 2u,
		Money = 4u,
		Renown = 8u,
		Influence = 0x10u,
		Wounded = 0x20u,
		AtWar = 0x40u,
		ClanTier = 0x80u,
		NotEnoughTroops = 0x100u,
		NotInSameFaction = 0x200u,
		PartySizeLimit = 0x400u,
		ClanIsMercenary = 0x800u,
		MainHeroIsKingdomLeader = 0x4000u,
		PlayerIsOwnerOfSettlement = 0x8000u,
		CompanionLimitReached = 0x10000u
	}

	public enum IssueUpdateDetails
	{
		None,
		PlayerStartedIssueQuestClassicSolution,
		PlayerSentTroopsToQuest,
		SentTroopsFinishedQuest,
		SentTroopsFailedQuest,
		IssueFinishedWithSuccess,
		IssueFinishedWithBetrayal,
		IssueFinishedByAILord,
		IssueFail,
		IssueCancel,
		IssueTimedOut
	}

	public enum IssueFrequency
	{
		VeryCommon,
		Common,
		Rare
	}

	public const int IssueRelatedConversationPriority = 125;

	[SaveableField(27)]
	private float _totalTroopXpAmount;

	[SaveableField(30)]
	public readonly TroopRoster AlternativeSolutionSentTroops;

	[SaveableField(35)]
	private SkillObject _companionRewardSkill;

	[SaveableField(14)]
	private readonly MBList<JournalLog> _journalEntries;

	[SaveableField(11)]
	private IssueState _issueState;

	[SaveableField(12)]
	public CampaignTime IssueDueTime;

	[SaveableField(16)]
	public CampaignTime IssueCreationTime;

	[SaveableField(13)]
	private Hero _issueOwner;

	[SaveableField(26)]
	private float _issueDifficultyMultiplier;

	[SaveableField(32)]
	private bool _areIssueEffectsResolved;

	[SaveableField(33)]
	private int _alternativeSolutionCasualtyCount;

	[SaveableField(34)]
	private float _failureChance;

	[SaveableField(31)]
	private readonly List<ITrackableCampaignObject> _trackedObjects;

	protected virtual bool IssueQuestCanBeDuplicated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual int RelationshipChangeWithIssueOwner
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

	public abstract TextObject IssueBriefByIssueGiver { get; }

	public abstract TextObject IssueAcceptByPlayer { get; }

	public virtual TextObject IssuePlayerResponseAfterLordExplanation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssuePlayerResponseAfterAlternativeExplanation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract TextObject IssueQuestSolutionExplanationByIssueGiver { get; }

	public virtual TextObject IssueAlternativeSolutionExplanationByIssueGiver
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionExplanationByIssueGiver
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract TextObject IssueQuestSolutionAcceptByPlayer { get; }

	public virtual TextObject IssueAlternativeSolutionAcceptByPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueAlternativeSolutionResponseByIssueGiver
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionAcceptByPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionResponseByIssueGiver
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionCounterOfferBriefByOtherNpc
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionCounterOfferExplanationByOtherNpc
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionCounterOfferAcceptByPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionCounterOfferDeclineByPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionCounterOfferAcceptResponseByOtherNpc
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueLordSolutionCounterOfferDeclineResponseByOtherNpc
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueAsRumorInSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual int AlternativeSolutionBaseNeededMenCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	protected virtual int AlternativeSolutionBaseDurationInDaysInternal
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[SaveableProperty(25)]
	public CampaignTime AlternativeSolutionReturnTimeForTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public abstract bool IsThereAlternativeSolution { get; }

	protected virtual TextObject AlternativeSolutionStartLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	protected virtual TextObject AlternativeSolutionEndLogDefault
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsThereDiscussDialogFlow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual int CompanionSkillRewardXP
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[SaveableProperty(31)]
	public CampaignTime AlternativeSolutionIssueEffectClearTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public Hero AlternativeSolutionHero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueDiscussAlternativeSolution
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueAlternativeSolutionSuccessLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject IssueAlternativeSolutionFailLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public abstract bool IsThereLordSolution { get; }

	protected virtual TextObject LordSolutionStartLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual TextObject LordSolutionCounterOfferAcceptLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual TextObject LordSolutionCounterOfferRefuseLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual int NeededInfluenceForLordSolution
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual Hero CounterOfferHero
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

	public MBReadOnlyList<JournalLog> JournalEntries
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Hero IssueOwner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public abstract TextObject Title { get; }

	[SaveableProperty(15)]
	public QuestBase IssueQuest
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public Settlement IssueSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract TextObject Description { get; }

	[SaveableProperty(22)]
	public bool IsTriedToSolveBefore
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public bool IsOngoingWithoutQuest
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsSolvingWithQuest
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsSolvingWithAlternative
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsSolvingWithLordSolution
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected float IssueDifficultyMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual int RewardGold
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual AlternativeSolutionScaleFlag AlternativeSolutionScaleFlags
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AlternativeSolutionHasCasualties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AlternativeSolutionHasScaledRequiredTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AlternativeSolutionHasScaledDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AlternativeSolutionHasFailureRisk
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueAlternativeSolutionReturnTimeForTroops(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueAlternativeSolutionIssueEffectClearTime(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueIssueQuest(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueIsTriedToSolveBefore(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueAlternativeSolutionSentTroops(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueIssueDueTime(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueIssueCreationTime(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_totalTroopXpAmount(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_companionRewardSkill(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_journalEntries(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_issueState(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_issueOwner(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_issueDifficultyMultiplier(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_areIssueEffectsResolved(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_alternativeSolutionCasualtyCount(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_failureChance(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_trackedObjects(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalAlternativeSolutionNeededMenCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalAlternativeSolutionDurationInDays()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBaseAlternativeSolutionDurationInDays()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool AlternativeSolutionCondition(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void AlternativeSolutionStartConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool DoTroopsSatisfyAlternativeSolution(TroopRoster troopRoster, out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AlternativeSolutionEndWithFailureConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AlternativeSolutionEndWithSuccessConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsTroopTypeNeededByAlternativeSolution(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool LordSolutionCondition(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void LordSolutionConsequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void LordSolutionConsequenceWithRefuseCounterOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void LordSolutionConsequenceWithAcceptCounterOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetActiveIssueEffectAmount(IssueEffect issueEffect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual (SkillObject, int) GetAlternativeSolutionSkill(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual float GetIssueEffectAmountInternal(IssueEffect issueEffect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected IssueBase(Hero issueOwner, CampaignTime issueDueTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeIssueBaseOnLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void HourlyTickWithIssueManager()
	{
		throw null;
	}

	protected abstract void OnGameLoad();

	protected abstract void HourlyTick();

	protected abstract QuestBase GenerateIssueQuest(string questId);

	public abstract IssueFrequency GetFrequency();

	protected abstract bool CanPlayerTakeQuestConditions(Hero issueGiver, out PreconditionFlags flag, out Hero relationHero, out SkillObject skill);

	public abstract bool IssueStayAliveConditions();

	protected abstract void CompleteIssueWithTimedOutConsequences();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AfterIssueCreation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool CanBeCompletedByAI()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnIssueFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHeroCanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHeroCanLeadPartyInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHeroCanHavePartyRoleOrBeGovernorInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHeroCanDieInfoIsRequested(Hero hero, KillCharacterAction.KillCharacterActionDetail causeOfDeath, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHeroCanBecomePrisonerInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHeroCanBeSelectedInInventoryInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHeroCanMoveToSettlementInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHeroCanMarryInfoIsRequested(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void IsSettlementBusy(Settlement settlement, object asker, ref int priority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartIssueWithQuest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartIssueWithAlternativeSolution()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAlternativeSolutionSolvedAndTroopsAreReturning()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void IssueFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithQuest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithTimedOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithStayAliveConditionsFailed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithBetrayal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithFail(TextObject log = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithCancel(TextObject log = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithAiLord(Hero issueSolver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AlternativeSolutionEndWithSuccess()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartIssueWithLordSolution()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BeforeGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithAlternativeSolution()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AlternativeSolutionEndWithFail()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithLordSolutionWithRefuseCounterOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompleteIssueWithLordSolutionWithAcceptCounterOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool CheckPreconditions(Hero issueGiver, out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AfterCreation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeIssueOnSettlementOwnerChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddLog(JournalLog log)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveAllTrackedObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTrackedObject(ITrackableCampaignObject o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleTrackedObjects(bool enableTrack)
	{
		throw null;
	}
}
