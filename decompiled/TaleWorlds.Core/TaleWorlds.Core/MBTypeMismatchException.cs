using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBTypeMismatchException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBTypeMismatchException(string exceptionString)
	{
		throw null;
	}
}
