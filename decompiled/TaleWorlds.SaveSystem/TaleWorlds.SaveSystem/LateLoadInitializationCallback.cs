using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem;

[AttributeUsage(AttributeTargets.Method)]
public class LateLoadInitializationCallback : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public LateLoadInitializationCallback()
	{
		throw null;
	}
}
