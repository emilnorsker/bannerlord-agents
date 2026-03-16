using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBIllegalValueException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBIllegalValueException(string exceptionString)
	{
		throw null;
	}
}
