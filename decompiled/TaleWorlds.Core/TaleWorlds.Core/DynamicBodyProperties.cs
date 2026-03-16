using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

[Serializable]
public struct DynamicBodyProperties
{
	public const float MaxAge = 128f;

	public const float MaxAgeTeenager = 21f;

	public float Age;

	public float Weight;

	public float Build;

	public static readonly DynamicBodyProperties Invalid;

	public static readonly DynamicBodyProperties Default;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicBodyProperties(float age, float weight, float build)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(DynamicBodyProperties a, DynamicBodyProperties b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(DynamicBodyProperties a, DynamicBodyProperties b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(DynamicBodyProperties other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DynamicBodyProperties()
	{
		throw null;
	}
}
