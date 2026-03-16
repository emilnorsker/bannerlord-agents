using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine;

internal class ApplicationInterfaceBase : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public ApplicationInterfaceBase()
	{
		throw null;
	}
}
