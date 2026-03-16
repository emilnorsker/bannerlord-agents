using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBNullParameterException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBNullParameterException(string parameterName)
	{
		throw null;
	}
}
