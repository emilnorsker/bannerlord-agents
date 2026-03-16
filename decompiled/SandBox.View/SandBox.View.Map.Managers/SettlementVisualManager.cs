using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.Map.Visuals;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.View.Map.Managers;

public class SettlementVisualManager : EntityVisualManagerBase<PartyBase>
{
	private const string _emptyAttackerRangedDecalMaterialName = "decal_siege_ranged";

	private const string _attackerRamMachineDecalMaterialName = "decal_siege_ram";

	private const string _attackerTowerMachineDecalMaterialName = "decal_siege_tower";

	private const string _attackerRangedMachineDecalMaterialName = "decal_siege_ranged";

	private const string _defenderRangedMachineDecalMaterialName = "decal_defender_ranged_siege";

	private const uint _preperationOrEnemySiegeEngineDecalColor = 4287064638u;

	private const uint _normalStartSiegeEngineDecalColor = 4278394186u;

	private const float _defenderMachineCircleDecalScale = 0.25f;

	private const float _attackerMachineDecalScale = 0.38f;

	private bool _isNewDecalScaleImplementationEnabled;

	private const uint _normalEndSiegeEngineDecalColor = 4284320212u;

	private const uint _hoveredSiegeEngineDecalColor = 4293956364u;

	private const uint _withMachineSiegeEngineDecalColor = 4283683126u;

	private const float _machineDecalAnimLoopTime = 0.5f;

	private readonly Dictionary<PartyBase, SettlementVisual> _settlementVisuals;

	private readonly List<SettlementVisual> _visualsFlattened;

	private int _dirtyPartyVisualCount;

	private SettlementVisual[] _dirtyPartiesList;

	private UIntPtr _hoveredSiegeEntityID;

	private bool _playerSiegeMachineSlotMeshesAdded;

	private MapView _mapSiegeOverlayView;

	private GameEntity[] _defenderMachinesCircleEntities;

	private GameEntity[] _attackerRamMachinesCircleEntities;

	private GameEntity[] _attackerTowerMachinesCircleEntities;

	private GameEntity[] _attackerRangedMachinesCircleEntities;

	private float _timeSinceCreation;

	public override int Priority
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static SettlementVisualManager Current
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
	public override bool OnVisualIntersected(Ray mouseRay, UIntPtr[] intersectedEntityIDs, Intersection[] intersectionInfos, int entityCount, Vec3 worldMouseNear, Vec3 worldMouseFar, Vec3 terrainIntersectionPoint, ref MapEntityVisual hoveredVisual, ref MapEntityVisual selectedVisual)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnMouseClick(MapEntityVisual visualOfSelectedEntity, Vec3 intersectionPoint, PathFaceRecord mouseOverFaceIndex, bool isDoubleClick)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MapEntityVisual<PartyBase> GetVisualOfEntity(PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SettlementVisual GetSettlementVisual(Settlement settlement)
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
	private void TickSiegeMachineCircles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddNewPartyVisualForParty(PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private uint GetDesiredDecalColor(bool isHovered, bool isEnemy, bool isEmpty, bool isPlayerLeader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetDesiredMaterialName(bool isRanged, bool isAttacker, bool isTower)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveSiegeCircleVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshMapSiegeOverlayRequired()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeSiegeCircleVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSiegeEngineHover(UIntPtr newID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSiegeEngineHoverEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SettlementVisualManager()
	{
		throw null;
	}
}
