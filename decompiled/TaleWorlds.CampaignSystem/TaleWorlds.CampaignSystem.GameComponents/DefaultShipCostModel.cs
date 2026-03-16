using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultShipCostModel : ShipCostModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipTradeValue(Ship ship, PartyBase seller, PartyBase buyer)
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
	public override float GetShipSellingPenalty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultShipCostModel()
	{
		throw null;
	}
}
