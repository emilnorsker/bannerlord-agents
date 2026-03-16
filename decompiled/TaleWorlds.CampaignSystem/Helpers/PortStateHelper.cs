using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace Helpers;

public static class PortStateHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenAsTrade(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenAsLoot(MBReadOnlyList<Ship> lootShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenAsRestricted(Town town, TextObject restrictedReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenAsStoryMode(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenAsManageFleet(MBReadOnlyList<Ship> leftShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenAsManageOtherFleet(PartyBase other, Action onEndAction)
	{
		throw null;
	}
}
