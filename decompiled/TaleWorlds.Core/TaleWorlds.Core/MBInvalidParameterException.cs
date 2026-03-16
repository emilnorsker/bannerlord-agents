using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBInvalidParameterException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBInvalidParameterException(string parameterName)
	{
		throw null;
	}
}
