using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.Actions;

public static class ChangeShipOwnerAction
{
	public enum ShipOwnerChangeDetail
	{
		ApplyByTrade,
		ApplyByTransferring,
		ApplyByLooting,
		ApplyByMobilePartyCreation,
		ApplyByProduction
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(PartyBase newOwner, Ship ship, ShipOwnerChangeDetail changeDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByTransferring(PartyBase newOwner, Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByTrade(PartyBase newOwner, Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByLooting(PartyBase newOwner, Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByProduction(PartyBase newOwner, Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByMobilePartyCreation(PartyBase newOwner, Ship ship)
	{
		throw null;
	}
}
