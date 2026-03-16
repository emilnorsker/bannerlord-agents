using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
[MessageDescription("LobbyServer", "Client", true)]
public class KickedFromClanMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public KickedFromClanMessage()
	{
		throw null;
	}
}
