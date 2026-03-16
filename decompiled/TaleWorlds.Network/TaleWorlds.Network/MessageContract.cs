using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

public abstract class MessageContract
{
	private Type _myType;

	private static Dictionary<Type, byte> MessageContracts
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

	private static Dictionary<Type, MessageContractCreator> MessageContractCreators
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

	public byte MessageId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MessageContract()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static byte GetContractId(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MessageContractCreator GetContractCreator(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InitializeMessageContract(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MessageContract()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MessageContract CreateMessageContract(Type messageContractType)
	{
		throw null;
	}

	public abstract void SerializeToNetworkMessage(INetworkMessageWriter networkMessage);

	public abstract void DeserializeFromNetworkMessage(INetworkMessageReader networkMessage);
}
