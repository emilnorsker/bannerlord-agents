using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.View.Map.Visuals;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace SandBox.View;

public class SandBoxViewVisualManager
{
	private EntitySystem<CampaignEntityVisualComponent> _components;

	private static readonly Comparison<CampaignEntityVisualComponent> _comparisonDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxViewVisualManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void VisualTick(MapScreen screen, float realDt, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTick(float realDt, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearVisualMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool OnMouseClick(MapEntityVisual visualOfSelectedEntity, Vec3 intersectionPoint, PathFaceRecord mouseOverFaceIndex, bool isDoubleClick)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TComponent GetEntityComponent<TComponent>() where TComponent : CampaignEntityVisualComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TComponent AddEntityComponent<TComponent>() where TComponent : CampaignEntityVisualComponent, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEntityComponent<TComponent>() where TComponent : CampaignEntityVisualComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Finalize<TComponent>(TComponent component) where TComponent : CampaignEntityVisualComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEntityComponent<TComponent>(TComponent component) where TComponent : CampaignEntityVisualComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<TComponent> GetComponents<TComponent>() where TComponent : CampaignEntityVisualComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList<CampaignEntityVisualComponent> GetComponents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SortComponents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SandBoxViewVisualManager()
	{
		throw null;
	}
}
