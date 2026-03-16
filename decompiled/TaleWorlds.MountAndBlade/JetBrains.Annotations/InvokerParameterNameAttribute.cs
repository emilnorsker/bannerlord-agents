using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
public sealed class InvokerParameterNameAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public InvokerParameterNameAttribute()
	{
		throw null;
	}
}
