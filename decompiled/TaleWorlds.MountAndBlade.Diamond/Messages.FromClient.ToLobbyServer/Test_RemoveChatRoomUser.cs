using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class Test_RemoveChatRoomUser : Message
{
	[JsonProperty]
	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Test_RemoveChatRoomUser()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Test_RemoveChatRoomUser(string name)
	{
		throw null;
	}
}
