using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct LineSegment2D
{
	public Vec2 Point1;

	public Vec2 Point2;

	public Vec2 Normal;

	public Vec2 this[int index]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LineSegment2D(Vec2 point1, Vec2 point2)
	{
		throw null;
	}
}
