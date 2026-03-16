using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class TerminatesProgramAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public TerminatesProgramAttribute()
	{
		throw null;
	}
}
