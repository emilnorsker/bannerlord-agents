using System;
using System.Runtime.CompilerServices;

namespace psai.net;

internal class ThemeQueueEntry : ICloneable
{
	internal PsaiPlayMode playmode;

	internal int themeId;

	internal float startIntensity;

	internal int restTimeMillis;

	internal bool holdIntensity;

	internal int musicDuration;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ThemeQueueEntry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Clone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}
}
