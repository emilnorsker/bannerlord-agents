using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class ViewMethod : Attribute
{
	public string Name
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
	public ViewMethod(string name)
	{
		throw null;
	}
}
