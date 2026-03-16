using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBNotFoundException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBNotFoundException(string exceptionString)
	{
		throw null;
	}
}
