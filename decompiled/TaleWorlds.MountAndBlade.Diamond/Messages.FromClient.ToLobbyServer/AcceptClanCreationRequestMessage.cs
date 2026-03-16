using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class AcceptClanCreationRequestMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AcceptClanCreationRequestMessage()
	{
		throw null;
	}
}
