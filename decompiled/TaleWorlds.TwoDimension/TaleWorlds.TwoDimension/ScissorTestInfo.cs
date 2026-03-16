using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public struct ScissorTestInfo
{
	private float _x;

	private float _x2;

	private float _y;

	private float _y2;

	public float X
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float X2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Y
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Y2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScissorTestInfo(float x, float y, float x2, float y2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReduceToIntersection(ScissorTestInfo other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SimpleRectangle GetSimpleRectangle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCollide(in Rectangle2D other)
	{
		throw null;
	}
}
