using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.View.Map.Visuals;
using SandBox.View.Map.Managers;
using SandBox.View.Map.Visuals;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.View.Map.Managers;

public class NavalMobilePartyVisualManager : EntityVisualManagerBase<PartyBase>
{
	private const float DamageSoundCooldown = 2f;

	private static int _shipDamageSoundEventId;

	private readonly Dictionary<PartyBase, NavalMobilePartyVisual> _partiesAndVisuals;

	private readonly List<NavalMobilePartyVisual> _visualsFlattened;

	private int _dirtyPartyVisualCount;

	private NavalMobilePartyVisual[] _dirtyPartiesList;

	private float _timeElapsedSinceLastShipDamageSoundPlayed;

	private float _mainPartyPreviousShipDamageTriggerHealthPercent;

	private readonly List<NavalMobilePartyVisual> _fadingPartiesFlatten;

	private readonly HashSet<NavalMobilePartyVisual> _fadingPartiesSet;

	private readonly List<GameEntity> _bridgeEntityCache;

	public static NavalMobilePartyVisualManager Current
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
	public override void OnTick(float realDt, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ClearVisualMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MapEntityVisual<PartyBase> GetVisualOfEntity(PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnVisualIntersected(Ray mouseRay, UIntPtr[] intersectedEntityIDs, Intersection[] intersectionInfos, int entityCount, Vec3 worldMouseNear, Vec3 worldMouseFar, Vec3 terrainIntersectionPoint, ref MapEntityVisual hoveredVisual, ref MapEntityVisual selectedVisual)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMobilePartyVisual GetPartyVisual(PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RegisterFadingVisual(NavalMobilePartyVisual visual)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GameEntity GetNearbyBridgeToParty(PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyNavigationStateChanged(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerShipDamageSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyLeftSiegeEvent(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyJoinedToSiegeEvent(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyDestroyed(MobileParty mobileParty, PartyBase _)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyCreated(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnRegisterFadingVisual(NavalMobilePartyVisual visual)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddNewPartyVisualForParty(MobileParty mobileParty, bool shouldTick = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemovePartyVisualForParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMobilePartyVisualManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NavalMobilePartyVisualManager()
	{
		throw null;
	}
}
