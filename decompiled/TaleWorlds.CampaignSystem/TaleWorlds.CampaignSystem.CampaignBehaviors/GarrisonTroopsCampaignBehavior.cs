using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class GarrisonTroopsCampaignBehavior : CampaignBehaviorBase
{
	private struct ArmyGarrisonTransferDataArgs
	{
		public Settlement Settlement;

		public List<(MobileParty, int)> ArmyPartiesIdealPartySizes;

		public int TotalIdealPartySize;

		public int TotalMenCount;

		public int SettlementFinalMenCount;

		public int SettlementCurrentMenCount;

		public bool IsLeavingTroopsToGarrison;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<(MobileParty, int)> GetTroopsToLeaveDataForArmy()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<(MobileParty, int)> GetTroopsToTakeDataForArmy()
		{
			throw null;
		}
	}

	private struct PartyGarrisonTransferDataArgs
	{
		public Settlement Settlement;

		public MobileParty MobileParty;

		public int PartyIdealPartySize;

		public int SettlementIdealPartySize;

		public int TotalIdealPartySize;

		public int TotalMenCount;

		public int PartyCurrentMenCount;

		public int SettlementFinalMenCount;

		public int SettlementCurrentMenCount;

		public bool IsLeavingTroopsToGarrison;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumberOfTroopsToLeaveForParty()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumberOfTroopsToTakeForParty()
		{
			throw null;
		}
	}

	private const int PartyMinMenNumberAfterDonation = 30;

	private const int MinGarrisonNumberForTown = 125;

	private const int MinGarrisonNumberForCastle = 75;

	private const int MaxGarrisonNumberForTown = 750;

	private const int MaxGarrisonNumberForCastle = 500;

	private Settlement _newlyConqueredFortification;

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
	private void OnNewGameCreatedPartialFollowUpEvent(CampaignGameStarter starter, int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillGarrisonPartyOnNewGame(Town fortification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementEntered(MobileParty mobileParty, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ManageGarrisonForArmy(MobileParty armyLeaderParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectArmyGarrisonTransferDataArgs(MobileParty armyLeaderParty, Settlement settlement, out ArmyGarrisonTransferDataArgs armyGarrionTransferDataArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryToLeaveTroopsToGarrisonForArmy(in ArmyGarrisonTransferDataArgs armyGarrisonTransferDataArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryToTakeTroopsFromGarrisonForArmy(in ArmyGarrisonTransferDataArgs armyGarrisonTransferDataArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateSettlementIdealPartySizeWithEffects(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ManageGarrisonForParty(MobileParty mobileParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectPartyGarrisonTransferData(MobileParty mobileParty, Settlement settlement, out PartyGarrisonTransferDataArgs partyGarrisonTransferDataArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryToLeaveTroopsToGarrisonForParty(in PartyGarrisonTransferDataArgs partyGarrisonTransferDataArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryToTakeTroopsFromGarrisonForParty(in PartyGarrisonTransferDataArgs partyGarrisonTransferDataArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<(MobileParty, int)> CalculateMobilePartiesIdealPartySizes(MobileParty armyLeaderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateMobilePartySizeLimitWithFoodAndWage(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateMaxGarrisonSizeTownCanFeed(Town town, bool includeMarketStocks = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateSettlementGarrisonPartySizeLimitWithFoodAndWage(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetProsperityEffectForTown(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CharacterObject GetASuitableCharacterFromPartyRosterByWeight(TroopRoster troopRoster, bool archersAreHighPriority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LeaveTroopsToGarrison(MobileParty mobileParty, Settlement settlement, int numberOfTroopsToLeave, bool archersAreHighPriority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TakeTroopsFromGarrison(MobileParty mobileParty, Settlement settlement, int numberOfTroopsToTake, bool archersAreHighPriority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyKingdomInfluenceBonusForLeavingTroopToGarrison(MobileParty mobileParty, Settlement settlement, TroopRoster troopsToBeTransferred)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GarrisonTroopsCampaignBehavior()
	{
		throw null;
	}
}
