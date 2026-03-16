using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.View.Map.Visuals;

public class SettlementVisual : MapEntityVisual<PartyBase>
{
	private struct SiegeBombardmentData
	{
		public Vec3 LaunchGlobalPosition;

		public Vec3 TargetPosition;

		public MatrixFrame ShooterGlobalFrame;

		public MatrixFrame TargetAlignedShooterGlobalFrame;

		public float MissileSpeed;

		public float Gravity;

		public float LaunchAngle;

		public float RotationDuration;

		public float ReloadDuration;

		public float AimingDuration;

		public float MissileLaunchDuration;

		public float FireDuration;

		public float FlightDuration;

		public float TotalDuration;
	}

	private const string CircleTag = "map_settlement_circle";

	private const string BannerPlaceHolderTag = "map_banner_placeholder";

	private const string MapSiegeEngineTag = "map_siege_engine";

	private const string MapBreachableWallTag = "map_breachable_wall";

	private const string MapDefenderEngineTag = "map_defensive_engine";

	private const string MapSiegeEngineRamTag = "map_siege_ram";

	private const string TownPhysicalTag = "bo_town";

	private const string MapSiegeEngineTowerTag = "map_siege_tower";

	private const string MapPreparationTag = "siege_preparation";

	private const string BurnedTag = "looted";

	private GameEntity[] _attackerRangedEngineSpawnEntities;

	private GameEntity[] _attackerBatteringRamSpawnEntities;

	private GameEntity[] _defenderBreachableWallEntitiesCacheForCurrentLevel;

	private GameEntity[] _attackerSiegeTowerSpawnEntities;

	private GameEntity[] _defenderRangedEngineSpawnEntitiesForAllLevels;

	private GameEntity[] _defenderRangedEngineSpawnEntitiesCacheForCurrentLevel;

	private GameEntity[] _defenderBreachableWallEntitiesForAllLevels;

	private readonly List<(GameEntity, BattleSideEnum, int, MatrixFrame, GameEntity)> _siegeRangedMachineEntities;

	private readonly List<(GameEntity, BattleSideEnum, int, MatrixFrame, GameEntity)> _siegeMeleeMachineEntities;

	private readonly List<(GameEntity, BattleSideEnum, int)> _siegeMissileEntities;

	private Dictionary<int, List<GameEntity>> _gateBannerEntitiesWithLevels;

	private uint _currentLevelMask;

	private MatrixFrame _hoveredSiegeEntityFrame;

	private UpgradeLevelMask _currentSettlementUpgradeLevelMask;

	private Scene _mapScene;

	private List<GameEntity> TownPhysicalEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public override MapEntityVisual AttachedTo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override CampaignVec2 InteractionPositionForPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private Scene MapScene
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GameEntity StrategicEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SettlementVisual(PartyBase entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsEnemyOf(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsAllyOf(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnPartyRemoved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec3 GetVisualPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsVisibleOrFadingOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHover()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTrackAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnMapClick(bool followModifierUsed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnOpenEncyclopedia()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ReleaseResources()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetPartyIcon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ValidateIsDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Dictionary<int, List<GameEntity>> GetGateBannerEntitiesWithLevels()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBannerPositionForParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnMapHoverSiegeEngineEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshPartyIcon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnStartup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Tick(float dt, ref int dirtyPartiesCount, ref SettlementVisual[] dirtyPartiesList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnMapHoverSiegeEngine(MatrixFrame engineFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveSiege()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSiegeIconComponents(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSiegeMachine(SiegeEngineType type, MatrixFrame globalFrame, BattleSideEnum side, int wallLevel, int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSiegeMissile(SiegeEngineType type, MatrixFrame globalFrame, BattleSideEnum side, int missileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetLevelMask(uint newMask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshLevelMask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static uint GetLevelOfProduction(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSettlementLevelVisibility()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateSiegeEngineFrameListsFromChildren(List<GameEntity> children)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateDefenderSiegeEntitiesCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshWallState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshTownPhysicalEntitiesState(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshSiegePreparations(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame[] GetAttackerTowerSiegeEngineFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame[] GetAttackerBatteringRamSiegeEngineFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame[] GetAttackerRangedSiegeEngineFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame[] GetDefenderRangedSiegeEngineFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame[] GetBreachableWallFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateDataAndDurationsForSiegeMachine(int machineSlotIndex, SiegeEngineType machineType, BattleSideEnum side, SiegeBombardTargets targetType, int targetSlotIndex, out SiegeBombardmentData bombardmentData)
	{
		throw null;
	}
}
