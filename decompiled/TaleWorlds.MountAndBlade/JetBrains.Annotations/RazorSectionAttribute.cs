using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, Inherited = true)]
public sealed class RazorSectionAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public RazorSectionAttribute()
	{
		throw null;
	}
}
