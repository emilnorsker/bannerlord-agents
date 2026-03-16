using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaleWorlds.Core;

public class MBException : ApplicationException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBException(string message, Exception innerException)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBException(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBException()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBException(SerializationInfo info, StreamingContext context)
	{
		throw null;
	}
}
