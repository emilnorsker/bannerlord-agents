using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View;

public class OverrideView : Attribute
{
	public Type BaseType
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
	public OverrideView(Type baseType)
	{
		throw null;
	}
}
