using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
[MessageDescription("LobbyServer", "Client", true)]
public class CancelFindGameMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public CancelFindGameMessage()
	{
		throw null;
	}
}
