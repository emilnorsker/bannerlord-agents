using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;
using TaleWorlds.MountAndBlade.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class GetClanLeaderboardResult : FunctionResult
{
	[JsonProperty]
	public ClanLeaderboardInfo ClanLeaderboardInfo
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
	public GetClanLeaderboardResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GetClanLeaderboardResult(ClanLeaderboardInfo info)
	{
		throw null;
	}
}
