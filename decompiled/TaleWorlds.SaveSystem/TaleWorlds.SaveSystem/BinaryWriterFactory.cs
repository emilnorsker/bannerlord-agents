using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem;

internal static class BinaryWriterFactory
{
	private static ThreadLocal<Stack<BinaryWriter>> _binaryWriters;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BinaryWriter GetBinaryWriter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReleaseBinaryWriter(BinaryWriter writer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Release()
	{
		throw null;
	}
}
