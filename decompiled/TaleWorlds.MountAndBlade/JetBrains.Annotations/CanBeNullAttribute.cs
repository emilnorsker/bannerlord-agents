using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
public sealed class CanBeNullAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public CanBeNullAttribute()
	{
		throw null;
	}
}
