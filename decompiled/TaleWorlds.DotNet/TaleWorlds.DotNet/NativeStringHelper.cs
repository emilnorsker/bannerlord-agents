using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

internal static class NativeStringHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static UIntPtr CreateRglVarString(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static UIntPtr GetThreadLocalCachedRglVarString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void SetRglVarString(UIntPtr pointer, string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DeleteRglVarString(UIntPtr pointer)
	{
		throw null;
	}
}
