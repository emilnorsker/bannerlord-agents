using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

public class ManagedFromNativeCallback : Attribute
{
	public bool IsMultiThreadCallable;

	public string[] Conditionals
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ManagedFromNativeCallback(string[] conditionals = null, bool isMultiThreadCallable = false)
	{
		throw null;
	}
}
