using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class GetDedicatedCustomServerAuthTokenMessageResult : FunctionResult
{
	[JsonProperty]
	public string AuthToken
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
	public GetDedicatedCustomServerAuthTokenMessageResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GetDedicatedCustomServerAuthTokenMessageResult(string authToken)
	{
		throw null;
	}
}
