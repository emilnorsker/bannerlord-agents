using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension.Standalone.Native.Windows;

public struct BlendFunction
{
	public byte BlendOp;

	public byte BlendFlags;

	public byte SourceConstantAlpha;

	public byte AlphaFormat;

	public static readonly BlendFunction Default;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlendFunction(AlphaFormatFlags op, byte flags, byte alpha, AlphaFormatFlags format)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BlendFunction()
	{
		throw null;
	}
}
