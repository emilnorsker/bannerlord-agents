using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.EventSystem;

public class EventManager
{
	private readonly DictionaryByType _eventsByType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EventManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterEvent<T>(Action<T> eventObjType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterEvent<T>(Action<T> eventObjType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerEvent<T>(T eventObj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IDictionary<Type, object> GetCloneOfEventDictionary()
	{
		throw null;
	}
}
