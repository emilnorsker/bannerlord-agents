using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class MatchmakingQueueStats
{
	[JsonProperty]
	public List<MatchmakingQueueRegionStats> RegionStats;

	public static MatchmakingQueueStats Empty
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

	[JsonIgnore]
	public int TotalCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[JsonIgnore]
	public int AverageWaitTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MatchmakingQueueStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchmakingQueueStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRegionStats(MatchmakingQueueRegionStats matchmakingQueueRegionStats)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchmakingQueueRegionStats GetRegionStats(string region)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetQueueCountOf(string region, string[] gameTypes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string[] GetRegionNames()
	{
		throw null;
	}
}
