using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.Actions;

public static class GiveItemAction
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Hero giver, Hero receiver, PartyBase giverParty, PartyBase receiverParty, in ItemRosterElement itemRosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForHeroes(Hero giver, Hero receiver, in ItemRosterElement itemRosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyForParties(PartyBase giverParty, PartyBase receiverParty, in ItemRosterElement itemRosterElement)
	{
		throw null;
	}
}
