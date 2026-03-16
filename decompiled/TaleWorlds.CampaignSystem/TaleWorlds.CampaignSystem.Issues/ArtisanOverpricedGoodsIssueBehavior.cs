using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Issues;

public class ArtisanOverpricedGoodsIssueBehavior : CampaignBehaviorBase
{
	public class ArtisanOverpricedGoodsIssue : IssueBase
	{
		private const int RequiredTradeSkillLevelForSendingComp = 120;

		private const int BaseRewardGold = 300;

		private const int IssueDuration = 30;

		private const int QuestTimeLimit = 30;

		private const int MinimumAlternativeTroopTier = 2;

		[SaveableField(13)]
		private int _goldReward;

		[SaveableField(10)]
		private ItemObject _requestedTradeGood;

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

		public override AlternativeSolutionScaleFlag AlternativeSolutionScaleFlags
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

		[SaveableProperty(12)]
		private int RequestedTradeGoodAmount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		private int RequiredGoldForAlternativeSolution
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[SaveableProperty(11)]
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

		public override TextObject IssueLordSolutionExplanationByIssueGiver
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

		public override TextObject IssueLordSolutionCounterOfferBriefByOtherNpc
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

		public override TextObject IssueAlternativeSolutionSuccessLog
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
		internal static void AutoGeneratedStaticCollectObjectsArtisanOverpricedGoodsIssue(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValueRequestedTradeGoodAmount(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValueCounterOfferHero(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_goldReward(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_requestedTradeGood(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void LordSolutionConsequenceWithRefuseCounterOffer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void LordSolutionConsequenceWithAcceptCounterOffer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ArtisanOverpricedGoodsIssue(Hero issueOwner, Hero counterOfferHero, ItemObject requestedTradeGood)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override float GetIssueEffectAmountInternal(IssueEffect issueEffect)
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
		public override void AlternativeSolutionStartConsequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AlternativeSolutionEndWithSuccessConsequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool LordSolutionCondition(out TextObject explanation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplySuccessRewards(Hero issueGiver)
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
		private void CalculateTradeGoodsAmountAndReward()
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
	}

	public class ArtisanOverpricedGoodsIssueQuest : QuestBase
	{
		[SaveableField(20)]
		private int _rewardGold;

		[SaveableField(30)]
		private readonly ItemObject _requestedTradeGood;

		[SaveableField(60)]
		private readonly int _requestedTradeGoodAmount;

		[SaveableField(40)]
		private int _givenTradeGoods;

		[SaveableField(50)]
		private JournalLog _playerStartsQuestLog;

		public override TextObject Title
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private Hero AntagonistHero
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

		private TextObject TimeoutQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsArtisanOverpricedGoodsIssueQuest(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_rewardGold(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_requestedTradeGood(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_requestedTradeGoodAmount(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_givenTradeGoods(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_playerStartsQuestLog(object o)
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
		public ArtisanOverpricedGoodsIssueQuest(string questId, Hero questGiver, CampaignTime dueTime, ItemObject requestedTradeGood, int rewardGold, int requestedTradeGoodAmount, Hero counterOfferHero)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void SetDialogs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int GetAvailableRequestedItemCountOnPlayer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DeliverItemsPartiallyOnConsequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DeliverItemsFullyOnConsequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void QuestAcceptedConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetMerchantDialogFlow()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsSuitableToTalk()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AcceptCounterOffer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnCompleteWithSuccess()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnFailed()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnTimedOut()
		{
			throw null;
		}
	}

	public class ArtisanOverpricedGoodsIssueTypeDefiner : SaveableTypeDefiner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ArtisanOverpricedGoodsIssueTypeDefiner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineClassTypes()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_PossibleRequestedItems_003Ed__6 : IEnumerable<ItemObject>, IEnumerable, IEnumerator<ItemObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ItemObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		ItemObject IEnumerator<ItemObject>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003Cget_PossibleRequestedItems_003Ed__6(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<ItemObject> IEnumerable<ItemObject>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	private const IssueBase.IssueFrequency ArtisanOverpricedGoodsIssueFrequency = IssueBase.IssueFrequency.Common;

	private const float HighestPriceIndexAtTown = 2f;

	private static IEnumerable<ItemObject> PossibleRequestedItems
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_PossibleRequestedItems_003Ed__6))]
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
	public void OnCheckForIssue(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Hero GetAntagonistMerchant(Hero issueOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConditionsHold(Hero IssueOwner, out Hero antagonistMerchant, out ItemObject requestedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IssueBase OnStartIssue(in PotentialIssueData pid, Hero issueOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArtisanOverpricedGoodsIssueBehavior()
	{
		throw null;
	}
}
