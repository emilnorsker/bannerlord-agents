using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public class MBTypeNotRegisteredException : ObjectSystemException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBTypeNotRegisteredException()
	{
		throw null;
	}
}
