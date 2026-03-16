using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;
using TaleWorlds.MountAndBlade.Diamond.Ranked;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class GetPlayerGameTypeRankInfoMessageResult : FunctionResult
{
	[JsonProperty]
	public GameTypeRankInfo[] GameTypeRankInfo
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
	public GetPlayerGameTypeRankInfoMessageResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GetPlayerGameTypeRankInfoMessageResult(GameTypeRankInfo[] gameTypeRankInfo)
	{
		throw null;
	}
}
