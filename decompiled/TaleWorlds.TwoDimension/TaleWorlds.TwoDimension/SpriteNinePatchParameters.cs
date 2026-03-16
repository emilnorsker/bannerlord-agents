using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public struct SpriteNinePatchParameters
{
	public static SpriteNinePatchParameters Empty;

	public bool IsValid;

	public int LeftWidth;

	public int RightWidth;

	public int TopHeight;

	public int BottomHeight;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpriteNinePatchParameters(int leftWidth, int rightWidth, int topHeight, int bottomHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SpriteNinePatchParameters()
	{
		throw null;
	}
}
