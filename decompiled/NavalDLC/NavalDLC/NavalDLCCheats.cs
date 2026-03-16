using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace NavalDLC;

public static class NavalDLCCheats
{
	public const string DLCNotActive = "DLC is not active.";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckCheatUsage(ref string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("damage_player_ships", "naval")]
	public static string DamagePlayerShips(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("add_ship_to_player", "naval")]
	public static string AddShipToPlayer(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindAnchorSettlementForParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("unlock_figurehead", "naval")]
	public static string UnlockFigurehead(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("list_all_ship_names", "naval")]
	public static string ListAllShipNames(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("list_all_figurehead_names", "naval")]
	public static string ListAllFigureheads(List<string> strings)
	{
		throw null;
	}
}
