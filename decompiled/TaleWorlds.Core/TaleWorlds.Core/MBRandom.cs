using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public static class MBRandom
{
	public const int MaxSeed = 2000;

	private static MBFastRandom _internalRandom;

	private static readonly MBFastRandom NondeterministicRandom;

	private static MBFastRandom Random
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static float RandomFloat
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static float RandomFloatNormal
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static float NondeterministicRandomFloat
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static int NondeterministicRandomInt
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float RandomFloatRanged(float maxVal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float RandomFloatRanged(float minVal, float maxVal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int RandomInt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int RandomInt(int maxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int RandomInt(int minValue, int maxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int RoundRandomized(float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T ChooseWeighted<T>(IReadOnlyList<(T, float)> weightList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T ChooseWeighted<T>(IReadOnlyList<(T, float)> weightList, out int chosenIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float RandomFloatGaussian(float center, float spread, float min, float max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetSeed(uint seed, uint seed2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int RandomIntWithSeed(uint seed, uint seed2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float RandomFloatWithSeed(uint seed, uint seed2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MBRandom()
	{
		throw null;
	}
}
