using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

internal class ScriptingInterfaceBase : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceBase()
	{
		throw null;
	}
}
