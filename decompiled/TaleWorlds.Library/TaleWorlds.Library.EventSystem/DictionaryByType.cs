using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.EventSystem;

public class DictionaryByType
{
	private readonly IDictionary<Type, object> _eventsByType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add<T>(Action<T> value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Remove<T>(Action<T> value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvokeActions<T>(T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Action<T>> Get<T>()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGet<T>(out List<Action<T>> value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IDictionary<Type, object> GetClone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DictionaryByType()
	{
		throw null;
	}
}
