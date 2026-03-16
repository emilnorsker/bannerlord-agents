using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class MatchmakingWaitTimeStats
{
	private List<MatchmakingWaitTimeRegionStats> _regionStats;

	public static MatchmakingWaitTimeStats Empty
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
	static MatchmakingWaitTimeStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchmakingWaitTimeStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRegionStats(MatchmakingWaitTimeRegionStats regionStats)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchmakingWaitTimeRegionStats GetRegionStats(string region)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetWaitTime(string region, string gameType, WaitTimeStatType statType)
	{
		throw null;
	}
}
