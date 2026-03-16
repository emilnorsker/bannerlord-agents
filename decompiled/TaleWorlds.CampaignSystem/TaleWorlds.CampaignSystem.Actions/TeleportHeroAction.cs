using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.Actions;

public static class TeleportHeroAction
{
	public enum TeleportationDetail
	{
		ImmediateTeleportToSettlement,
		ImmediateTeleportToParty,
		ImmediateTeleportToPartyAsPartyLeader,
		DelayedTeleportToSettlement,
		DelayedTeleportToParty,
		DelayedTeleportToSettlementAsGovernor,
		DelayedTeleportToPartyAsPartyLeader
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Hero hero, Settlement targetSettlement, MobileParty targetParty, TeleportationDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyImmediateTeleportToSettlement(Hero heroToBeMoved, Settlement targetSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyImmediateTeleportToParty(Hero heroToBeMoved, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyImmediateTeleportToPartyAsPartyLeader(Hero heroToBeMoved, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyDelayedTeleportToSettlement(Hero heroToBeMoved, Settlement targetSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyDelayedTeleportToParty(Hero heroToBeMoved, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyDelayedTeleportToSettlementAsGovernor(Hero heroToBeMoved, Settlement targetSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyDelayedTeleportToPartyAsPartyLeader(Hero heroToBeMoved, MobileParty party)
	{
		throw null;
	}
}
