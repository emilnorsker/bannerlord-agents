using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class AspMvcTemplateAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcTemplateAttribute()
	{
		throw null;
	}
}
