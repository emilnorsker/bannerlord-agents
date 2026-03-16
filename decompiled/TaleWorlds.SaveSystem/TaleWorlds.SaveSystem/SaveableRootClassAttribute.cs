using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem;

[AttributeUsage(AttributeTargets.Class)]
public class SaveableRootClassAttribute : Attribute
{
	public int SaveId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveableRootClassAttribute(int saveId)
	{
		throw null;
	}
}
