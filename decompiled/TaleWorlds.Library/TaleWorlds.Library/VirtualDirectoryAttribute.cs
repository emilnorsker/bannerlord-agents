using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class VirtualDirectoryAttribute : Attribute
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
	public VirtualDirectoryAttribute(string name)
	{
		throw null;
	}
}
