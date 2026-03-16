using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.LinQuick;

internal static class Error
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Exception ArgumentNull(string s)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Exception ArgumentOutOfRange(string s)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Exception MoreThanOneElement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Exception MoreThanOneMatch()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Exception NoElements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Exception NoMatch()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Exception NotSupported()
	{
		throw null;
	}
}
