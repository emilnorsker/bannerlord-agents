using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class PlayerQuitFromMatchmakerGameResult : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerQuitFromMatchmakerGameResult()
	{
		throw null;
	}
}
