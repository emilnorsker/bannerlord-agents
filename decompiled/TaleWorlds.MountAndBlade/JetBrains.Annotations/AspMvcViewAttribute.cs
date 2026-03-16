using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
public sealed class AspMvcViewAttribute : PathReferenceAttribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcViewAttribute()
	{
		throw null;
	}
}
