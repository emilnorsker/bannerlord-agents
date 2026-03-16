using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension.Standalone.Native.Windows;

public struct Point
{
	public int X;

	public int Y;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Point(int x, int y)
	{
		throw null;
	}
}
