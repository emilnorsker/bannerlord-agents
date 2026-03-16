using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public class MBInvalidReferenceException : ObjectSystemException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBInvalidReferenceException(string exceptionString)
	{
		throw null;
	}
}
