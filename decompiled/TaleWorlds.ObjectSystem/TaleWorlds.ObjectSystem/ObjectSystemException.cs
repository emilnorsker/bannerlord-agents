using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public class ObjectSystemException : Exception
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ObjectSystemException(string message, Exception innerException)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ObjectSystemException(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ObjectSystemException()
	{
		throw null;
	}
}
