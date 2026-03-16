using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Localization;

public class LocalizationException : Exception
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public LocalizationException()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LocalizationException(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LocalizationException(string message, Exception inner)
	{
		throw null;
	}
}
