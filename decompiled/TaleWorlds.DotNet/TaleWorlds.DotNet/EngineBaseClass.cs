using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

public abstract class EngineBaseClass : Attribute
{
	public string EngineType
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
	protected EngineBaseClass(string engineType)
	{
		throw null;
	}
}
