using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace StoryMode.GameComponents.CampaignBehaviors;

public class AchievementsCampaignBehavior : CampaignBehaviorBase
{
	private class AchievementMissionLogic : MissionLogic
	{
		private Action<Agent, Agent> OnAgentRemovedAction;

		private Action<Agent, WeaponComponentData, BoneBodyPartType, int> OnAgentHitAction;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AchievementMissionLogic(Action<Agent, Agent> onAgentRemoved, Action<Agent, WeaponComponentData, BoneBodyPartType, int> onAgentHitAction)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, bool isSiegeEngineHit, in Blow blow, in AttackCollisionData collisionData, float damagedHp, float hitDistance, float shotDifficulty)
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCacheAndInitializeAchievementVariables_003Ed__66 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AchievementsCampaignBehavior _003C_003E4__this;

		private int _003CneededIntegerCount_003E5__2;

		private TaskAwaiter<int[]> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private const float SettlementCountStoredInIntegerSet = 30f;

	private const string CreatedKingdomCountStatID = "CreatedKingdomCount";

	private const string ClearedHideoutCountStatID = "ClearedHideoutCount";

	private const string RepelledSiegeAssaultStatID = "RepelledSiegeAssaultCount";

	private const string KingOrQueenKilledInBattleStatID = "KingOrQueenKilledInBattle";

	private const string SuccessfulSiegeCountStatID = "SuccessfulSiegeCount";

	private const string WonTournamentCountStatID = "WonTournamentCount";

	private const string HighestTierSwordCraftedStatID = "HighestTierSwordCrafted";

	private const string SuccessfulBattlesAgainstArmyCountStatID = "SuccessfulBattlesAgainstArmyCount";

	private const string DefeatedArmyWhileAloneCountStatID = "DefeatedArmyWhileAloneCount";

	private const string TotalTradeProfitStatID = "TotalTradeProfit";

	private const string MaxDailyTributeGainStatID = "MaxDailyTributeGain";

	private const string MaxDailyIncomeStatID = "MaxDailyIncome";

	private const string CapturedATownAloneCountStatID = "CapturedATownAloneCount";

	private const string DefeatedTroopCountStatID = "DefeatedTroopCount";

	private const string FarthestHeadStatID = "FarthestHeadShot";

	private const string ButtersInInventoryStatID = "ButtersInInventoryCount";

	private const string ReachedClanTierSixStatID = "ReachedClanTierSix";

	private const string OwnedFortificationCountStatID = "OwnedFortificationCount";

	private const string HasOwnedCaravanAndWorkshopStatID = "HasOwnedCaravanAndWorkshop";

	private const string ExecutedLordWithMinus100RelationStatID = "ExecutedLordRelation100";

	private const string HighestSkillValueStatID = "HighestSkillValue";

	private const string LeaderOfTournamentStatID = "LeaderOfTournament";

	private const string FinishedTutorialStatID = "FinishedTutorial";

	private const string DefeatedSuperiorForceStatID = "DefeatedSuperiorForce";

	private const string BarbarianVictoryStatID = "BarbarianVictory";

	private const string ImperialVictoryStatID = "ImperialVictory";

	private const string AssembledDragonBannerStatID = "AssembledDragonBanner";

	private const string CompletedAllProjectsStatID = "CompletedAllProjects";

	private const string ClansUnderPlayerKingdomCountStatID = "ClansUnderPlayerKingdomCount";

	private const string HearthBreakerStatID = "Hearthbreaker";

	private const string ProposedAndWonAPolicyStatID = "ProposedAndWonAPolicy";

	private const string BestServedColdStatID = "BestServedCold";

	private const string DefeatedRadagosInDUelStatID = "RadagosDefeatedInDuel";

	private const string GreatGrannyStatID = "GreatGranny";

	private const string NumberOfChildrenStatID = "NumberOfChildrenBorn";

	private const string UndercoverStatID = "CompletedAnIssueInHostileTown";

	private const string EnteredEverySettlemenStatID = "EnteredEverySettlement";

	private bool _deactivateAchievements;

	private int _cachedCreatedKingdomCount;

	private int _cachedHideoutClearedCount;

	private int _cachedHighestSkillValue;

	private int _cachedRepelledSiegeAssaultCount;

	private int _cachedCapturedTownAloneCount;

	private int _cachedKingOrQueenKilledInBattle;

	private int _cachedSuccessfulSiegeCount;

	private int _cachedWonTournamentCount;

	private int _cachedSuccessfulBattlesAgainstArmyCount;

	private int _cachedSuccessfulBattlesAgainstArmyAloneCount;

	private int _cachedTotalTradeProfit;

	private int _cachedMaxDailyIncome;

	private int _cachedDefeatedTroopCount;

	private int _cachedFarthestHeadShot;

	private ItemObject _butter;

	private List<Settlement> _orderedSettlementList;

	private int[] _settlementIntegerSetList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRulingClanChanged(Kingdom kingdom, Clan newRulingCLan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnIssueUpdated(IssueBase issueBase, IssueUpdateDetails detail, Hero issueSolver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHideoutBattleCompleted(BattleSideEnum winnerSide, HideoutEventComponent hideoutEventComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeforeHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConfigChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroCreated(Hero hero, bool isBornNaturally)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CCacheAndInitializeAchievementVariables_003Ed__66))]
	private void CacheAndInitializeAchievementVariables()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanDestroyed(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewItemCrafted(ItemObject itemObject, ItemModifier overriddenItemModifier, bool isCraftingOrderItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBuildingLevelChanged(Town town, Building building, int levelChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestCompleted(QuestBase quest, QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTournamentFinish(CharacterObject winner, MBReadOnlyList<CharacterObject> participants, Town town, ItemObject prize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSiegeCompleted(Settlement siegeSettlement, MobileParty attackerParty, bool isWin, BattleTypes battleType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayerInventoryExchange(List<(ItemRosterElement, int)> purchasedItems, List<(ItemRosterElement, int)> soldItems, bool isTrading)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckAchievementSystemActivity(out TextObject reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementEnter(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckEnteredEverySettlement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheHighestSkillValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionStarted(IMission obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAgentHit(Agent affectorAgent, WeaponComponentData attackerWeapon, BoneBodyPartType victimBoneBodyPartType, int hitDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressChildCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckGrandparent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRadagosDuelWon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckBestServedCold(Hero victim, Hero killer, KillCharacterActionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckProposedAndWonPolicy(KingdomDecision decision, DecisionOutcome chosenOutcome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckKingdomDecisionConcluded(KingdomDecision decision, DecisionOutcome chosenOutcome, bool isPlayerInvolved)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckHeroMarriage(Hero hero1, Hero hero2, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressClansUnderKingdomCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressSuccessfulBattlesAgainstArmyCount(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressSuccessfulBattlesAgainstArmyAloneCount(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressDailyTribute()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float CalculateTributeShareFactor(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressDailyIncome()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressTotalTradeProfit(int profit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckProjectsInSettlement(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressHighestTierSwordCrafted(ItemObject itemObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressAssembledDragonBanner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressImperialBarbarianVictory(QuestBase quest, QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckDefeatedSuperiorForce(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckTutorialFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressSuccessfulSiegeCount(MobileParty attackerParty, bool isWin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressCapturedATownAlone(MobileParty attackerParty, bool isWin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressRepelSiegeAssaultCount(Settlement siegeSettlement, bool isWin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressRepelSiegeAssaultCount(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressTournamentRank(CharacterObject winner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressHeroSkillValue(Hero hero, SkillObject skill, int change = 1, bool shouldNotify = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressHideoutClearedCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckExecutedLordRelation(Hero victim, Hero killer, KillCharacterActionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressKingOrQueenKilledInBattle(Hero victim, Hero killer, KillCharacterActionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressTournamentWonCount(CharacterObject winner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressOwnedWorkshopCount(Workshop workshop, Hero oldOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressOwnedCaravanCount(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressHasOwnedCaravanAndWorkshop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressOwnedFortificationCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressCreatedKingdomCount(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProgressClanTier(Clan clan, bool shouldNotify)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateAchievements(TextObject reason = null, bool showMessage = true, bool temporarily = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetStatInternal(string statId, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AchievementsCampaignBehavior()
	{
		throw null;
	}
}
