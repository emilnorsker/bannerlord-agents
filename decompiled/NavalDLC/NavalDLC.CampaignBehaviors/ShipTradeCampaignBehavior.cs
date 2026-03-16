using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace NavalDLC.CampaignBehaviors;

public class ShipTradeCampaignBehavior : CampaignBehaviorBase
{
	private const float ShipSellingChance = 0.1f;

	private const float ShipTransferringChance = 0.75f;

	private const float ClanGoldRatioToBuyShip = 0.2f;

	public static bool DebugNavalLordParties;

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
	private void OnNewGameCreatedPartialFollowUp(CampaignGameStarter starter, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderPurchasingShip(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetClanShipPurchaseChance(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryPurchasingShipFromTown(MobileParty mobileParty, Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MobileParty GetPartyToGiveShipTo(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Town GetTownToBuyShipFrom(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanClanBuyShipFromTown(Clan clan, Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderSwappingClanLeaderShips(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderSwappingShipsBetweenClanParties(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderSellingShips(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TryGetShipToSell(MobileParty mobileParty, out Ship shipToSell)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Town GetTownToSellShip(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetTotalNumberOfWarShipsInClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanPartyTradeShip(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipOwnerChanged(Ship ship, PartyBase oldOwner, ShipOwnerChangeDetail details)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipRepaired(Ship ship, Settlement repairPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSettlementEntered(MobileParty mobileParty, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipTradeCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ShipTradeCampaignBehavior()
	{
		throw null;
	}
}
