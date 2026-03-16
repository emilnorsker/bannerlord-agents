using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

public class MessageId : Attribute
{
	public byte Id
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
	public MessageId(byte id)
	{
		throw null;
	}
}
