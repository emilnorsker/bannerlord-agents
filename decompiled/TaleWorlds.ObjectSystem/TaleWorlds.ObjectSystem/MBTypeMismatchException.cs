using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public class MBTypeMismatchException : ObjectSystemException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBTypeMismatchException(string exceptionString)
	{
		throw null;
	}
}
