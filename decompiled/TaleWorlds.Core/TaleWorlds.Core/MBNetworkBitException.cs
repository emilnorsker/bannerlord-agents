using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MBNetworkBitException : MBException
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBNetworkBitException(string exceptionString)
	{
		throw null;
	}
}
