using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
public sealed class CannotApplyEqualityOperatorAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public CannotApplyEqualityOperatorAttribute()
	{
		throw null;
	}
}
