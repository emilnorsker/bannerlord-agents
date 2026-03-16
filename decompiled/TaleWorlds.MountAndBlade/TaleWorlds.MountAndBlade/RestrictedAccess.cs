using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class RestrictedAccess : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public RestrictedAccess()
	{
		throw null;
	}
}
