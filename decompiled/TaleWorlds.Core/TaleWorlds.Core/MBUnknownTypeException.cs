using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBUnknownTypeException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBUnknownTypeException(string exceptionString)
	{
		throw null;
	}
}
