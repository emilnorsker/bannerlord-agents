using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public class MBCanNotCreatePresumedObjectException : ObjectSystemException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBCanNotCreatePresumedObjectException()
	{
		throw null;
	}
}
