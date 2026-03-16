using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBMisuseException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBMisuseException(string exceptionString)
	{
		throw null;
	}
}
