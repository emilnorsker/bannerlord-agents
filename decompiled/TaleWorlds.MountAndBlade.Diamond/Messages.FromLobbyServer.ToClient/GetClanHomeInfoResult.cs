using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;
using TaleWorlds.MountAndBlade.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class GetClanHomeInfoResult : FunctionResult
{
	[JsonProperty]
	public ClanHomeInfo ClanHomeInfo
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
	public GetClanHomeInfoResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GetClanHomeInfoResult(ClanHomeInfo clanHomeInfo)
	{
		throw null;
	}
}
