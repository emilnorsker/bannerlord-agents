using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class AspMvcModelTypeAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcModelTypeAttribute()
	{
		throw null;
	}
}
