using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

internal class LibraryInterfaceBase : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public LibraryInterfaceBase()
	{
		throw null;
	}
}
