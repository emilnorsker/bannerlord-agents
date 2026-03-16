using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
public class PSPlayerJoinedToPlayerSessionMessageResult : FunctionResult
{
	[JsonProperty]
	public bool Successful
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
	public PSPlayerJoinedToPlayerSessionMessageResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PSPlayerJoinedToPlayerSessionMessageResult(bool successful)
	{
		throw null;
	}
}
