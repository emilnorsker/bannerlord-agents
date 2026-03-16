using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class AssertionMethodAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AssertionMethodAttribute()
	{
		throw null;
	}
}
