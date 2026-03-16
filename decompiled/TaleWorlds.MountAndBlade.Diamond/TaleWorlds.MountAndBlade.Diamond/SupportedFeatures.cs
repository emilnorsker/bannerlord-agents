using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class SupportedFeatures
{
	public int Features;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SupportedFeatures()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SupportedFeatures(int features)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SupportsFeatures(Features feature)
	{
		throw null;
	}
}
