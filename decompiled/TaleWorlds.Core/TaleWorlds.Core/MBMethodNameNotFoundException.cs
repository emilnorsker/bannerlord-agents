using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBMethodNameNotFoundException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBMethodNameNotFoundException(string methodName)
	{
		throw null;
	}
}
