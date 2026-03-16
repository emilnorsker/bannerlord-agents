using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace NavalDLC.GameComponents;

public class NavalDLCShipCostModel : ShipCostModel
{
	private const float BuyPenalty = 1.5f;

	private const float RepairPenalty = 0.25f;

	private const float SellPenalty = 0.3f;

	private const float UpgradePiecePenalty = 0.3f;

	private const float AIClansShipValueDiscountRatio = 0.01f;

	private const float RoyalNavyPrerogativeMultiplier = 0.9f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipTradeValue(Ship ship, PartyBase seller, PartyBase buyer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetShipBaseValue(Ship ship, bool applyAiDiscount, PartyBase owner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipRepairCost(Ship ship, PartyBase owner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetShipUpgradePieceCost(Ship ship, ShipUpgradePiece piece, PartyBase owner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetShipUpgradePieceValueInternal(Ship ship, ShipUpgradePiece piece, PartyBase owner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipSellingPenalty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCShipCostModel()
	{
		throw null;
	}
}
