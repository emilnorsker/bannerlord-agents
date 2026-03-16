using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBNotNullParameterException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBNotNullParameterException(string parameterName)
	{
		throw null;
	}
}
