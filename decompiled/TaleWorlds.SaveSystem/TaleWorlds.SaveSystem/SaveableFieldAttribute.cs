using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem;

[AttributeUsage(AttributeTargets.Field)]
public class SaveableFieldAttribute : Attribute
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
	public SaveableFieldAttribute(short localSaveId)
	{
		throw null;
	}
}
