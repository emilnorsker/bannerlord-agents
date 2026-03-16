using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public class MBOutOfRangeException : ObjectSystemException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBOutOfRangeException(string parameterName)
	{
		throw null;
	}
}
