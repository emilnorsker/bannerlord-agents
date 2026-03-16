using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class Feature : Attribute
{
	public Features FeatureFlag
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
	public Feature(Features flag)
	{
		throw null;
	}
}
