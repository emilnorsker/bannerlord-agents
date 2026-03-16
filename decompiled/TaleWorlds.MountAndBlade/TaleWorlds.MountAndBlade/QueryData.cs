using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class QueryData<T> : IQueryData
{
	private T _cachedValue;

	private float _expireTime;

	private readonly float _lifetime;

	private readonly Func<T> _valueFunc;

	private IQueryData[] _syncGroup;

	public T Value
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QueryData(Func<T> valueFunc, float lifetime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QueryData(Func<T> valueFunc, float lifetime, T defaultCachedValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Evaluate(float currentTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetValue(T value, float currentTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetCachedValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetCachedValueUnlessTooOld()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetCachedValueWithMaxAge(float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Expire()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetupSyncGroup(params IQueryData[] groupItems)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSyncGroup(IQueryData[] syncGroup)
	{
		throw null;
	}
}
