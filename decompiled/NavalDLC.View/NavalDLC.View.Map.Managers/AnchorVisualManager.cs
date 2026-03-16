using System;
using System.Runtime.CompilerServices;
using NavalDLC.View.Map.Visuals;
using SandBox.View.Map;
using SandBox.View.Map.Managers;
using SandBox.View.Map.Visuals;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.View.Map.Managers;

public class AnchorVisualManager : EntityVisualManagerBase<AnchorPoint>
{
	private const float DecalEntityHeight = 1f;

	private const uint DecalColor = 4291596077u;

	private AnchorVisual _anchorVisual;

	private DecalEntity _anchorCircleDecal;

	private CampaignVec2 _cachedPosition;

	private (bool, bool) _cachedDisabledValue;

	public static AnchorVisualManager Current
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int Priority
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AnchorVisualManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MapEntityVisual<AnchorPoint> GetVisualOfEntity(AnchorPoint entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnVisualIntersected(Ray mouseRay, UIntPtr[] intersectedEntityIDs, Intersection[] intersectionInfos, int entityCount, Vec3 worldMouseNear, Vec3 worldMouseFar, Vec3 terrainIntersectionPoint, ref MapEntityVisual hoveredVisual, ref MapEntityVisual selectedVisual)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnVisualTick(MapScreen screen, float realDt, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTick(float realDt, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnAnchorPositionUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanPartyHaveAnchor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateNewVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveAnchorVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAnchorVisual()
	{
		throw null;
	}
}
