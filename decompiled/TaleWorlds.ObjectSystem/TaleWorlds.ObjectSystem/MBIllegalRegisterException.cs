using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public class MBIllegalRegisterException : ObjectSystemException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBIllegalRegisterException()
	{
		throw null;
	}
}
