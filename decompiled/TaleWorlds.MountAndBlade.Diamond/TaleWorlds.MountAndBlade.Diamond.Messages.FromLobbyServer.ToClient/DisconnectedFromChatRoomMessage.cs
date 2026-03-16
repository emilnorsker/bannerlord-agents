using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace TaleWorlds.MountAndBlade.Diamond.Messages.FromLobbyServer.ToClient;

[Serializable]
[MessageDescription("Client", "LobbyServer", true)]
public class DisconnectedFromChatRoomMessage : Message
{
	[JsonProperty]
	public Guid RoomId
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

	[JsonProperty]
	public string RoomName
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
	public DisconnectedFromChatRoomMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DisconnectedFromChatRoomMessage(Guid roomId, string roomName)
	{
		throw null;
	}
}
