using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.CampaignBehaviors;

public class StatisticsCampaignBehavior : CampaignBehaviorBase, IStatisticsCampaignBehavior, ICampaignBehavior
{
	private class StatisticsMissionLogic : MissionLogic
	{
		private readonly StatisticsCampaignBehavior behavior;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StatisticsMissionLogic()
		{
			throw null;
		}
	}

	private int _highestTournamentRank;

	private int _numberOfTournamentWins;

	private int _numberOfChildrenBorn;

	private int _numberOfPrisonersRecruited;

	private int _numberOfTroopsRecruited;

	private int _numberOfClansDefected;

	private int _numberOfIssuesSolved;

	private int _totalInfluenceEarned;

	private int _totalCrimeRatingGained;

	private ulong _totalTimePlayedInSeconds;

	private int _numberOfbattlesWon;

	private int _numberOfbattlesLost;

	private int _largestBattleWonAsLeader;

	private int _largestArmyFormedByPlayer;

	private int _numberOfEnemyClansDestroyed;

	private int _numberOfHeroesKilledInBattle;

	private int _numberOfTroopsKnockedOrKilledAsParty;

	private int _numberOfTroopsKnockedOrKilledByPlayer;

	private int _numberOfHeroPrisonersTaken;

	private int _numberOfTroopPrisonersTaken;

	private int _numberOfTownsCaptured;

	private int _numberOfHideoutsCleared;

	private int _numberOfCastlesCaptured;

	private int _numberOfVillagesRaided;

	private CampaignTime _timeSpentAsPrisoner;

	private ulong _totalDenarsEarned;

	private ulong _denarsEarnedFromCaravans;

	private ulong _denarsEarnedFromWorkshops;

	private ulong _denarsEarnedFromRansoms;

	private ulong _denarsEarnedFromTaxes;

	private ulong _denarsEarnedFromTributes;

	private ulong _denarsPaidAsTributes;

	private int _numberOfCraftingPartsUnlocked;

	private int _numberOfWeaponsCrafted;

	private int _numberOfCraftingOrdersCompleted;

	private (string, int) _mostExpensiveItemCrafted;

	private int _numberOfCompanionsHired;

	private Dictionary<Hero, (int, int)> _companionData;

	private int _lastPlayerBattleSize;

	private DateTime _lastGameplayTimeCheck;

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
	private void OnBeforeSave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAfterSessionLaunched(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDefectionPersuasionSucess()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUnitRecruited(CharacterObject character, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMainPartyPrisonerRecruited(FlattenedTroopRoster flattenedTroopRoster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCrimeRatingChanged(IFaction kingdom, float deltaCrimeAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanInfluenceChanged(Clan clan, float change)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTournamentFinished(CharacterObject winner, MBReadOnlyList<CharacterObject> participants, Town town, ItemObject prize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnIssueUpdated(IssueBase issue, IssueUpdateDetails details, Hero issueSolver = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroCreated(Hero hero, bool isBornNaturally = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionStarted(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerPartyKnockedOrKilledTroop(CharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroPrisonerReleased(Hero prisoner, PartyBase party, IFaction capturerFaction, EndCaptivityDetail detail, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHideoutBattleCompleted(BattleSideEnum winnerSide, HideoutEventComponent hideoutEventComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRaidCompleted(BattleSideEnum winnerSide, RaidEventComponent raidEventComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPrisonersTaken(FlattenedTroopRoster troopRoster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroPrisonerTaken(PartyBase capturer, Hero prisoner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnArmyCreated(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyAttachedAnotherParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanDestroyed(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnd(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroOrPartyTradedGold((Hero, PartyBase) giver, (Hero, PartyBase) recipient, (int, string) goldAmount, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerAcceptedRansomOffer(int ransomPrice)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerEarnedGoldFromAsset(AssetIncomeType assetType, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewCompanionAdded(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewItemCrafted(ItemObject itemObject, ItemModifier overriddenItemModifier, bool isCraftingOrderItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCraftingPartUnlocked(CraftingPiece craftingPiece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (string name, int value) GetCompanionWithMostKills()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (string name, int value) GetCompanionWithMostIssuesSolved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHighestTournamentRank()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfTournamentWins()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfChildrenBorn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPrisonersRecruited()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfTroopsRecruited()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfClansDefected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfIssuesSolved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalInfluenceEarned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalCrimeRatingGained()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfBattlesWon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfBattlesLost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetLargestBattleWonAsLeader()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetLargestArmyFormedByPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfEnemyClansDestroyed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfHeroesKilledInBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfTroopsKnockedOrKilledAsParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfTroopsKnockedOrKilledByPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfHeroPrisonersTaken()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfTroopPrisonersTaken()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfTownsCaptured()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfHideoutsCleared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfCastlesCaptured()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfVillagesRaided()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfCraftingPartsUnlocked()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfWeaponsCrafted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfCraftingOrdersCompleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfCompanionsHired()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignTime GetTimeSpentAsPrisoner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetTotalTimePlayedInSeconds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetTotalDenarsEarned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetDenarsEarnedFromCaravans()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetDenarsEarnedFromWorkshops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetDenarsEarnedFromRansoms()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetDenarsEarnedFromTaxes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetDenarsEarnedFromTributes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetDenarsPaidAsTributes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignTime GetTotalTimePlayed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (string, int) GetMostExpensiveItemCrafted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTotalTimePlayedInSeconds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StatisticsCampaignBehavior()
	{
		throw null;
	}
}
