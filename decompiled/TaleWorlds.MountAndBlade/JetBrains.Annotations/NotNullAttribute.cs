using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
public sealed class NotNullAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NotNullAttribute()
	{
		throw null;
	}
}
