using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
public sealed class AspMvcPartialViewAttribute : PathReferenceAttribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcPartialViewAttribute()
	{
		throw null;
	}
}
