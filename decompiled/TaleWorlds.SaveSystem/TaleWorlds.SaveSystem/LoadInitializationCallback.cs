using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem;

[AttributeUsage(AttributeTargets.Method)]
public class LoadInitializationCallback : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public LoadInitializationCallback()
	{
		throw null;
	}
}
