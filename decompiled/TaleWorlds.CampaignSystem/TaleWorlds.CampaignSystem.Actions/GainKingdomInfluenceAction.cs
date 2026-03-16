using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.Actions;

public static class GainKingdomInfluenceAction
{
	private enum InfluenceGainingReason
	{
		Default,
		BeingAtArmy,
		Battle,
		Raiding,
		Besieging,
		CaptureSettlement,
		JoinFaction,
		GivingFood,
		LeaveGarrison,
		BoardGameWon,
		ClanSupport,
		DonatePrisoners,
		SiegeSafePassage
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Hero hero, MobileParty party, float gainedInfluence, InfluenceGainingReason detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForBattle(Hero hero, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForGivingFood(Hero hero1, Hero hero2, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForDefault(Hero hero, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForJoiningFaction(Hero hero, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForDonatePrisoners(MobileParty donatingParty, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForRaidingEnemyVillage(MobileParty side1Party, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForBesiegingEnemySettlement(MobileParty side1Party, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForSiegeSafePassageBarter(MobileParty side1Party, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForCapturingEnemySettlement(MobileParty side1Party, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForLeavingTroopToGarrison(Hero hero, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForBoardGameWon(Hero hero, float value)
	{
		throw null;
	}
}
