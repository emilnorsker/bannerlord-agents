using System.Runtime.CompilerServices;

namespace TaleWorlds.Diamond;

public sealed class InnerProcessConnectionInformation : IConnectionInformation
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public InnerProcessConnectionInformation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string IConnectionInformation.GetAddress(bool isIpv6Compatible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string IConnectionInformation.GetCountry()
	{
		throw null;
	}
}
