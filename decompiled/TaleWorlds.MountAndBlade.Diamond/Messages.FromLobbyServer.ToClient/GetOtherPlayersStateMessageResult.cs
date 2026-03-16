using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.PlayerServices;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class GetOtherPlayersStateMessageResult : FunctionResult
{
	[JsonProperty]
	public List<(PlayerId, AnotherPlayerData)> States
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
	public GetOtherPlayersStateMessageResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GetOtherPlayersStateMessageResult(List<(PlayerId, AnotherPlayerData)> states)
	{
		throw null;
	}
}
