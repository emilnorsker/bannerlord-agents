using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.Actions;

public static class ChangeOwnerOfSettlementAction
{
	public enum ChangeOwnerOfSettlementDetail
	{
		Default,
		BySiege,
		ByBarter,
		ByLeaveFaction,
		ByKingDecision,
		ByGift,
		ByRebellion,
		ByClanDestruction
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Settlement settlement, Hero newOwner, Hero capturerHero, ChangeOwnerOfSettlementDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDefault(Hero hero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByKingDecision(Hero hero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyBySiege(Hero newOwner, Hero capturerHero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByLeaveFaction(Hero hero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByBarter(Hero hero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByRebellion(Hero hero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDestroyClan(Settlement settlement, Hero newOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByGift(Settlement settlement, Hero newOwner)
	{
		throw null;
	}
}
