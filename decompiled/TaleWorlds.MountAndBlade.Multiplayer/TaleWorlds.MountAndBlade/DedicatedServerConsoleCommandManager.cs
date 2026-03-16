using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace TaleWorlds.MountAndBlade;

public static class DedicatedServerConsoleCommandManager
{
	private static readonly List<Type> _commandHandlerTypes;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DedicatedServerConsoleCommandManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddType(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HandleConsoleCommand(string command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[ConsoleCommandMethod("list", "Displays a list of all multiplayer options, their values and other possible commands")]
	private static void ListAllCommands()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[ConsoleCommandMethod("set_winner_team", "Sets the winner team of flag domination based multiplayer missions.")]
	private static void SetWinnerTeam(string winnerTeamAsString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[ConsoleCommandMethod("set_server_bandwidth_limit_in_mbps", "Overrides server's older bandwidth limit in megabit(s) per second.")]
	private static void SetServerBandwidthLimitInMbps(string bandwidthLimitAsString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[ConsoleCommandMethod("set_server_tickrate", "Overrides server's older tickrate setting.")]
	private static void SetServerTickRate(string tickrateAsString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[ConsoleCommandMethod("stats", "Displays some game statistics, like FPS and players on the server.")]
	private static void ShowStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[ConsoleCommandMethod("open_monitor", "Opens up the monitor window with continuous data-representations on server performance and network usage.")]
	private static void OpenMonitor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[ConsoleCommandMethod("crash_game", "Crashes the game process.")]
	private static void CrashGame()
	{
		throw null;
	}
}
