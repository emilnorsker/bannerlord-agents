using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Issues;

public class ArtisanCantSellProductsAtAFairPriceIssueBehavior : CampaignBehaviorBase
{
	public class ArtisanCantSellProductsAtAFairPriceIssue : IssueBase
	{
		private const int BaseRewardGold = 500;

		private const int IssueDuration = 30;

		private const int QuestTimeLimit = 18;

		private const int RequiredSkillLevelForCompanion = 120;

		[CachedData]
		private readonly MBList<string> _possibleDeliveryItems;

		[SaveableField(10)]
		private ItemObject _rawMaterialsToBeDelivered;

		[SaveableField(20)]
		private Settlement _targetSettlement;

		[SaveableField(40)]
		private Hero _targetHero;

		public override AlternativeSolutionScaleFlag AlternativeSolutionScaleFlags
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

		private int RawMaterialCountToBeDelivered
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

		public override int NeededInfluenceForLordSolution
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

		public override TextObject IssueLordSolutionExplanationByIssueGiver
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

		protected override TextObject LordSolutionStartLog
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

		public override TextObject IssueAsRumorInSettlement
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsArtisanCantSellProductsAtAFairPriceIssue(object o, List<object> collectedObjects)
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
		internal static object AutoGeneratedGetMemberValue_rawMaterialsToBeDelivered(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetSettlement(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetHero(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ArtisanCantSellProductsAtAFairPriceIssue(Hero issueOwner)
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
		protected override void AlternativeSolutionEndWithSuccessConsequence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplySuccessRewards()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplyLordSolutionSuccessRewards()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplyFailureEffects()
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
		protected override bool CanPlayerTakeQuestConditions(Hero issueGiver, out PreconditionFlags flags, out Hero relationHero, out SkillObject skill)
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
	}

	public class ArtisanCantSellProductsAtAFairPriceIssueQuest : QuestBase
	{
		[SaveableField(10)]
		private readonly ItemObject _rawMaterialsToBeDelivered;

		[SaveableField(20)]
		private readonly int _amountOfRawGoodsToBeDelivered;

		[SaveableField(30)]
		private readonly Settlement _targetSettlement;

		[SaveableField(40)]
		private int _deliveredRawGoods;

		[SaveableField(100)]
		private Hero _counterOfferHero;

		[SaveableField(60)]
		private Hero _targetHero;

		[SaveableField(70)]
		private bool _counterOfferGiven;

		[SaveableField(80)]
		private bool _counterOfferRefused;

		[SaveableField(90)]
		private int _rewardGold;

		[SaveableField(212)]
		private JournalLog _playerStartsQuestLog;

		public override bool IsRemainingTimeHidden
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

		private TextObject FailQuestLogText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject FailQuestLogCounterOfferText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		private TextObject OnQuestCancelledDueToWarLogText
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AutoGeneratedStaticCollectObjectsArtisanCantSellProductsAtAFairPriceIssueQuest(object o, List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_rawMaterialsToBeDelivered(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_amountOfRawGoodsToBeDelivered(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetSettlement(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_deliveredRawGoods(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_counterOfferHero(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_targetHero(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_counterOfferGiven(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_counterOfferRefused(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_rewardGold(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AutoGeneratedGetMemberValue_playerStartsQuestLog(object o)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ArtisanCantSellProductsAtAFairPriceIssueQuest(string questId, Hero questGiver, CampaignTime duration, Settlement targetSettlement, ItemObject rawGoodsToBeDelivered, int amountOfRawGoodsToBeDelivered, int rewardGold, Hero targetHero, Hero counterOfferHero)
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
		private int GetAvailableRequestedItemCountOnPlayer(ItemObject item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void BeforeGameMenuOpened(MenuCallbackArgs args)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetCounterOfferDialogFlow()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private DialogFlow GetDeliveryDialogFlow()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DeliverItemsRejectOnConsequence()
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
		private void QuestFailedWithRefusal()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RefuseCounterOfferConsequences()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void RegisterEvents()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnHeroCanHaveCampaignIssuesInfoIsRequested(Hero hero, ref bool result)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnWarDeclared(IFaction faction1, IFaction faction2, DeclareWarAction.DeclareWarDetail detail)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RemoveRequestedItemsFromPlayer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnFailed()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void AfterLoad()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnCompleteWithSuccess()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnTimedOut()
		{
			throw null;
		}
	}

	public class ArtisanCantSellProductsAtAFairPriceIssueTypeDefiner : SaveableTypeDefiner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ArtisanCantSellProductsAtAFairPriceIssueTypeDefiner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineClassTypes()
		{
			throw null;
		}
	}

	private const IssueBase.IssueFrequency ArtisanCantSellProductsAtAFairPriceIssueFrequency = IssueBase.IssueFrequency.Common;

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
	private bool ConditionsHold(Hero issueGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Hero SelectCounterOfferHero(Hero issueGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Settlement SelectTargetSettlement(Hero issueGiver)
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
	public ArtisanCantSellProductsAtAFairPriceIssueBehavior()
	{
		throw null;
	}
}
