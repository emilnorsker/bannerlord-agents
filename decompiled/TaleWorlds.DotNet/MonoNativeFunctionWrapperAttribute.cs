using System;
using System.Runtime.CompilerServices;

public class MonoNativeFunctionWrapperAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MonoNativeFunctionWrapperAttribute()
	{
		throw null;
	}
}
