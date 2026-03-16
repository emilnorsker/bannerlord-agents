using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.Actions;

public static class EnterSettlementAction
{
	private enum EnterSettlementDetail
	{
		WarParty,
		PartyEntersAlley,
		Character,
		Prisoner
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Hero hero, MobileParty mobileParty, Settlement settlement, EnterSettlementDetail detail, object subject = null, bool isPlayerInvolved = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForParty(MobileParty mobileParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForPartyEntersAlley(MobileParty party, Settlement settlement, Alley alley, bool isPlayerInvolved = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForCharacterOnly(Hero hero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForPrisoner(Hero hero, Settlement settlement)
	{
		throw null;
	}
}
