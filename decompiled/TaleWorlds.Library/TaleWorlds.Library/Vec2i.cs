using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

[Serializable]
public struct Vec2i : IEquatable<Vec2i>
{
	public int X;

	public int Y;

	public static readonly Vec2i Side;

	public static readonly Vec2i Forward;

	public static readonly Vec2i One;

	public static readonly Vec2i Zero;

	public int Item1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Item2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2i(int x = 0, int y = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(Vec2i a, Vec2i b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(Vec2i a, Vec2i b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(Vec2i value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Vec2i()
	{
		throw null;
	}
}
