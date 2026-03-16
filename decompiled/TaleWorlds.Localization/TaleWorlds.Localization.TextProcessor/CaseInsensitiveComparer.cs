using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Localization.TextProcessor;

internal class CaseInsensitiveComparer : IEqualityComparer<string>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(string x, string y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHashCode(string x)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CaseInsensitiveComparer()
	{
		throw null;
	}
}
