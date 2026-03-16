using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem;

[AttributeUsage(AttributeTargets.Interface)]
public class SaveableInterfaceAttribute : Attribute
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
	public SaveableInterfaceAttribute(int saveId)
	{
		throw null;
	}
}
