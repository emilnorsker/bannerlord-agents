using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class MatchmakingWaitTimeRegionStats
{
	private Dictionary<string, Dictionary<WaitTimeStatType, int>> _gameTypeAverageWaitTimes;

	public string Region
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchmakingWaitTimeRegionStats(string region)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGameTypeAverage(string gameType, WaitTimeStatType statType, int average)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasStatsForGameType(string gameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetWaitTime(string gameType, WaitTimeStatType statType)
	{
		throw null;
	}
}
