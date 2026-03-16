using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public struct LinearFrictionTerm
{
	public readonly float Right;

	public readonly float Left;

	public readonly float Forward;

	public readonly float Backward;

	public readonly float Up;

	public readonly float Down;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static LinearFrictionTerm Invalid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static LinearFrictionTerm One
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LinearFrictionTerm(float right, float left, float forward, float backward, float up, float down)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LinearFrictionTerm operator /(LinearFrictionTerm o, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LinearFrictionTerm operator *(LinearFrictionTerm o, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LinearFrictionTerm ElementWiseProduct(LinearFrictionTerm o)
	{
		throw null;
	}
}
