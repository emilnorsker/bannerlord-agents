using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
[MessageDescription("LobbyServer", "Client", true)]
public class EnterCustomBattleWithPartyAnswer : Message
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
	public EnterCustomBattleWithPartyAnswer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EnterCustomBattleWithPartyAnswer(bool successful)
	{
		throw null;
	}
}
