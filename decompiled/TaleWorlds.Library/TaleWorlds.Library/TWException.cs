using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaleWorlds.Library;

public class TWException : ApplicationException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public TWException(string message, Exception innerException)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TWException(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TWException()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TWException(SerializationInfo info, StreamingContext context)
	{
		throw null;
	}
}
