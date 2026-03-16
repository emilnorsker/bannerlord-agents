using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class QuitFromMatchmakerGameMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuitFromMatchmakerGameMessage()
	{
		throw null;
	}
}
