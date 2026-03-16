using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
public class PlatformPlayerJoinedToPlayerSessionMessageResult : FunctionResult
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
	public PlatformPlayerJoinedToPlayerSessionMessageResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlatformPlayerJoinedToPlayerSessionMessageResult(bool successful)
	{
		throw null;
	}
}
