using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class ClanCreationFailedMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanCreationFailedMessage()
	{
		throw null;
	}
}
