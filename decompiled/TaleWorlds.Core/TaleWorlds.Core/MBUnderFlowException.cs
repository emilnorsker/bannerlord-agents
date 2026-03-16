using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBUnderFlowException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBUnderFlowException()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBUnderFlowException(string parameterName)
	{
		throw null;
	}
}
