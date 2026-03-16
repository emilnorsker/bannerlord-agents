using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

internal class MessageBuffer
{
	internal const int MessageHeaderSize = 4;

	internal byte[] Buffer
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

	internal int DataLength
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
	internal MessageBuffer(byte[] buffer, int dataLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MessageBuffer(byte[] buffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal string GetDebugText()
	{
		throw null;
	}
}
