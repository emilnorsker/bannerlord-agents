using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class GetBannerlordIDMessageResult : FunctionResult
{
	[JsonProperty]
	public string BannerlordID
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
	public GetBannerlordIDMessageResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GetBannerlordIDMessageResult(string bannerlordID)
	{
		throw null;
	}
}
