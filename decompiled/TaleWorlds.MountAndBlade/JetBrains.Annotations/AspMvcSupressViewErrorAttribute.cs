using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class AspMvcSupressViewErrorAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcSupressViewErrorAttribute()
	{
		throw null;
	}
}
