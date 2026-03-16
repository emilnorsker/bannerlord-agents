using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class ClanCreationSuccessfulMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanCreationSuccessfulMessage()
	{
		throw null;
	}
}
