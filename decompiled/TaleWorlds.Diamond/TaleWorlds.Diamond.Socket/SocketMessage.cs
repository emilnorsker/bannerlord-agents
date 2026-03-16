using System.Runtime.CompilerServices;
using TaleWorlds.Network;

namespace TaleWorlds.Diamond.Socket;

[MessageId(1)]
public class SocketMessage : MessageContract
{
	public Message Message
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
	public SocketMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SocketMessage(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SerializeToNetworkMessage(INetworkMessageWriter networkMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DeserializeFromNetworkMessage(INetworkMessageReader networkMessage)
	{
		throw null;
	}
}
