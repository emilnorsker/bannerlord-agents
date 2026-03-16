using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class AspMvcMasterAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcMasterAttribute()
	{
		throw null;
	}
}
