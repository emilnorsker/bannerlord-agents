using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem;

[AttributeUsage(AttributeTargets.Property)]
public class SaveablePropertyAttribute : Attribute
{
	public short LocalSaveId
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
	public SaveablePropertyAttribute(short localSaveId)
	{
		throw null;
	}
}
