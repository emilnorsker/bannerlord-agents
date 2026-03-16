using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
[MessageDescription("LobbyServer", "Client", true)]
public class RejoinRequestRejectedMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public RejoinRequestRejectedMessage()
	{
		throw null;
	}
}
