using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBOutOfRangeException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBOutOfRangeException(string parameterName)
	{
		throw null;
	}
}
