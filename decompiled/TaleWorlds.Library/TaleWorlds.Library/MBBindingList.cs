using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class MBBindingList<T> : Collection<T>, IMBBindingList, IList, ICollection, IEnumerable
{
	private readonly List<T> _list;

	private List<ListChangedEventHandler> _eventHandlers;

	public event ListChangedEventHandler ListChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBBindingList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ClearItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InsertItem(int index, T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RemoveItem(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetItem(int index, T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FireListChanged(ListChangedType type, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnListChanged(ListChangedEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Sort()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Sort(IComparer<T> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOrdered(IComparer<T> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyActionOnAllItems(Action<T> action)
	{
		throw null;
	}
}
