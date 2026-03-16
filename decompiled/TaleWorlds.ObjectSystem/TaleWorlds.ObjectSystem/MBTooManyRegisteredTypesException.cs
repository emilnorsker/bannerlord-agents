using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public class MBTooManyRegisteredTypesException : ObjectSystemException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBTooManyRegisteredTypesException()
	{
		throw null;
	}
}
