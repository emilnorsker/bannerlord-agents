using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
[MessageDescription("LobbyServer", "Client", true)]
public class PartyInvitationInvalidMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyInvitationInvalidMessage()
	{
		throw null;
	}
}
