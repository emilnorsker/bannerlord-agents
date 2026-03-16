using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public struct SimpleRectangle
{
	public float X;

	public float Y;

	public float X2;

	public float Y2;

	public float Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Height
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SimpleRectangle(float x, float y, float width, float height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCollide(SimpleRectangle other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 GetCenter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSubRectOf(SimpleRectangle other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsValid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPointInside(Vector2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReduceToIntersection(SimpleRectangle other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SimpleRectangle Lerp(SimpleRectangle from, SimpleRectangle to, float ratio)
	{
		throw null;
	}
}
