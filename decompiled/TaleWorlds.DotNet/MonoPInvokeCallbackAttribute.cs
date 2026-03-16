using System;
using System.Runtime.CompilerServices;

public class MonoPInvokeCallbackAttribute : Attribute
{
	public Type Type;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MonoPInvokeCallbackAttribute(Type type)
	{
		throw null;
	}
}
