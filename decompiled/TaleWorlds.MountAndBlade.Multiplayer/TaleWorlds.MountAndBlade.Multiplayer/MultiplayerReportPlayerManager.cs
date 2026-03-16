using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Multiplayer;

public static class MultiplayerReportPlayerManager
{
	private static Dictionary<PlayerId, int> _reportsPerPlayer;

	private const int _maxReportsPerPlayer = 3;

	public static event Action<string, PlayerId, string, bool> ReportHandlers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RequestReportPlayer(string gameId, PlayerId playerId, string playerName, bool isRequestedFromMission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnPlayerReported(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsPlayerReportedOverLimit(PlayerId player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void IncrementReportOfPlayer(PlayerId player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MultiplayerReportPlayerManager()
	{
		throw null;
	}
}
