using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

public class MessageContractHandlerManager
{
	private Dictionary<byte, MessageContractHandler> MessageHandlers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	private Dictionary<byte, Type> MessageContractTypes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MessageContractHandlerManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMessageHandler<T>(MessageContractHandlerDelegate<T> handler) where T : MessageContract
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleMessage(MessageContract messageContract)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleNetworkMessage(NetworkMessage networkMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Type GetMessageContractType(byte id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsMessageHandler(byte id)
	{
		throw null;
	}
}
