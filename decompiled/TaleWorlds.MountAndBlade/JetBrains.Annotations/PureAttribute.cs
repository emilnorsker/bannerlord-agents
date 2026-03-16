using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method, Inherited = true)]
public sealed class PureAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public PureAttribute()
	{
		throw null;
	}
}
