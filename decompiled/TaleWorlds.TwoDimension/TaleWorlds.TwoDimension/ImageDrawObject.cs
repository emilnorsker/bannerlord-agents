using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension;

public struct ImageDrawObject : IDrawObject
{
	public bool IsValid;

	public float Scale;

	public Rectangle2D Rectangle;

	public Vec3 Uvs;

	public static ImageDrawObject Invalid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IDrawObject.IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	Rectangle2D IDrawObject.Rectangle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	private static ImageDrawObject CreateInvalid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public static ImageDrawObject Create(in Rectangle2D rectangle, in Vec2 uvMin, in Vec2 uvMax)
	{
		throw null;
	}
}
