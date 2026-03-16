using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;
using TaleWorlds.MountAndBlade.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class GetAverageMatchmakingWaitTimesResult : FunctionResult
{
	[JsonProperty]
	public MatchmakingWaitTimeStats MatchmakingWaitTimeStats
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
	public GetAverageMatchmakingWaitTimesResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GetAverageMatchmakingWaitTimesResult(MatchmakingWaitTimeStats matchmakingWaitTimeStats)
	{
		throw null;
	}
}
