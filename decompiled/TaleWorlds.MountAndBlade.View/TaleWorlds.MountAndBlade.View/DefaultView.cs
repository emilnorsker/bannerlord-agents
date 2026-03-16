using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View;

public class DefaultView : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultView()
	{
		throw null;
	}
}
