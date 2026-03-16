using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Parameter, Inherited = true)]
public sealed class InstantHandleAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public InstantHandleAttribute()
	{
		throw null;
	}
}
