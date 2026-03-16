using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace SandBox.View.Map;

public class MapViewsContainer
{
	public readonly ObservableCollection<MapView> MapViews;

	private List<MapView> _mapViewsCopyCache;

	private bool _isViewListDirty;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapViewsContainer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(MapView mapView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Remove(MapView mapView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Contains(MapView mapView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Foreach(Action<MapView> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForeachReverse(Action<MapView> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapView ReturnFirstElementWithCondition(Func<MapView, bool> condition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetMapViewWithType<T>() where T : MapView
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TutorialContexts GetContextToChangeTo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsThereAnyViewIsEscaped()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOpeningEscapeMenuOnFocusChangeAllowedForAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<MapView> GetMapViewsCopy()
	{
		throw null;
	}
}
