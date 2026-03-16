using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

[AttributeUsage(AttributeTargets.All)]
public class CachedDataAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public CachedDataAttribute()
	{
		throw null;
	}
}
