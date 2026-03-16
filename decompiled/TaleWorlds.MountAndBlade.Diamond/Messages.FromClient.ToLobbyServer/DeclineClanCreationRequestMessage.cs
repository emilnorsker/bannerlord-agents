using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class DeclineClanCreationRequestMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public DeclineClanCreationRequestMessage()
	{
		throw null;
	}
}
