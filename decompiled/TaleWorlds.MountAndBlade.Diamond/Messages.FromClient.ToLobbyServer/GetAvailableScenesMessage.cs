using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class GetAvailableScenesMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public GetAvailableScenesMessage()
	{
		throw null;
	}
}
