using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.Objects;

[ScriptComponentParams("ship_visual_only", "ship_water_effects")]
public class ShipWaterEffects : ScriptComponentBehavior
{
	internal enum ParticleType
	{
		Movement,
		Splash
	}

	internal enum MovementParticleType
	{
		Small,
		Medium,
		Large
	}

	internal enum ShipHullHeightType
	{
		Small,
		Medium,
		Large
	}

	internal enum ResolutionScale
	{
		one,
		half,
		quarter,
		one_eight,
		one_sixteenth
	}

	private struct FloaterData
	{
		internal float HeightMin;

		internal float VerticalLength;

		internal float HorizontalArea;
	}

	private class WetnessDecalData
	{
		internal Decal Decal;

		internal Vec3 Normal;

		internal Vec3 LocalPosition;

		internal float CurrentAlpha;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WetnessDecalData()
		{
			throw null;
		}
	}

	private struct SliceSampleData
	{
		internal Vec3 localPosition;

		internal Vec3 limitingUpVector;
	}

	private class ParticleData
	{
		internal ParticleSystem MovementParticleSystem;

		internal MatrixFrame LocalFrame;

		internal Vec3 SurfaceNormal;

		internal ParticleSystem CurrentSplashParticle;

		internal float SplashTimer;

		internal float LastSpawnTime;

		internal bool WasAboveWater;

		internal Vec3 SplashVelocity;

		internal Vec3 SplashPosition;

		internal float SplashWaterMultiplier;

		internal List<KeyValuePair<float, SliceSampleData>> PerSlicePositions;

		internal float Size;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ParticleData()
		{
			throw null;
		}
	}

	private class SplashFoamDecal
	{
		internal Decal _splashFoamDecal;

		internal MatrixFrame _currentFrame;

		internal float _cumulativeDtTillStart;

		internal Vec3 _randomScale;

		internal Vec3 _currentSpeed;

		internal Vec3 _sideVectorStart;

		internal Vec3 _sideVectorEnd;

		internal bool _isLeft;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal SplashFoamDecal()
		{
			throw null;
		}
	}

	private const string FloaterHolderTag = "floater_volume_holder";

	private const string FloaterTag = "floater_volume";

	private const string BodyMeshTag = "body_mesh";

	private const string SplashEntityTag = "splash_particles";

	private const string MovementEntityTag = "movement_particles";

	private const string WaterDepthRenderMeshTag = "render_to_depth";

	private const float ParticleSliceHeightDx = 0.5f;

	private const int NumberOfSplashDecal = 50;

	private const float SmallSplashSoundEventMaxDistanceSquared = 400f;

	private static readonly Comparer<KeyValuePair<float, SliceSampleData>> _cacheCompareDelegate;

	[EditableScriptComponentVariable(true, "Water Simulation Bounding Box")]
	private Vec3 _waterSimulationBoundingBox;

	[EditableScriptComponentVariable(true, "Show Water Simulation Bounding Box")]
	private bool _showWaterSimulationBoundingBox;

	[EditableScriptComponentVariable(true, "Reset Water Simulation Bounding Box")]
	private SimpleButton _resetWaterSimulationBoundingBox;

	[EditableScriptComponentVariable(true, "Re-render Depth Texture")]
	private SimpleButton _reRenderDepthTexture;

	[EditableScriptComponentVariable(true, "Reset In-Hull Water")]
	private SimpleButton _resetInHullWater;

	[EditableScriptComponentVariable(true, "Show Hull Water Debug Panel")]
	private bool _showHullWaterDebugPanel;

	[EditableScriptComponentVariable(true, "Hull Water Simulation Resolution Scale")]
	private ResolutionScale _hullWaterResScale;

	[EditableScriptComponentVariable(true, "Hull Water Splash Water Multiplier")]
	private float _hullWaterSplashWaterMultiplier;

	[EditableScriptComponentVariable(true, "Hull Water Splash Point Initial Offset")]
	private float _hullWaterSplashPointInitialOffset;

	[EditableScriptComponentVariable(true, "Hull Water Splash Point Speed Multiplier")]
	private float _hullWaterSplashPointSpeedMultiplier;

	[EditableScriptComponentVariable(true, "Ship Hull Height Type")]
	private ShipHullHeightType _shipHullHeightType;

	[EditableScriptComponentVariable(true, "Movement Particle Height Offset")]
	private float _movementParticleHeightOffset;

	[EditableScriptComponentVariable(true, "Splash Particle Height Offset")]
	private float _splashParticleHeightOffset;

	[EditableScriptComponentVariable(true, "Movement Particle Surface Distance Offset")]
	private float _movementParticleSurfaceDistanceOffset;

	[EditableScriptComponentVariable(true, "Splash Particle Surface Distance Offset")]
	private float _splashParticleSurfaceDistanceOffset;

	[EditableScriptComponentVariable(true, "Movement Particle Type")]
	private MovementParticleType _movementParticleType;

	[EditableScriptComponentVariable(true, "Movement Particle Side Speed Vector")]
	private float _movementParticleSideSpeedVector;

	[EditableScriptComponentVariable(true, "Show Movement Particles")]
	private bool _showMovementParticles;

	[EditableScriptComponentVariable(true, "Show Splash Particles")]
	private bool _showSplashParticles;

	[EditableScriptComponentVariable(true, "Show Water Balance Plane")]
	private bool _showWaterBalancePlane;

	[EditableScriptComponentVariable(true, "Show Wetness Decal Values")]
	private bool _showWetnessDecalValues;

	[EditableScriptComponentVariable(true, "Force Wetness Decal To Full")]
	private bool _forceWetnessDecalsToFull;

	private UIntPtr _waterVisualRecord;

	private GameEntity _movementParticleEntity;

	private GameEntity _splashParticleEntity;

	private readonly List<ParticleData> _movementParticles;

	private readonly List<ParticleData> _splashParticles;

	private readonly MBFastRandom _splashRandom;

	private readonly List<WetnessDecalData> _wetnessDecals;

	private MatrixFrame _previousShipFrame;

	private float _cumulativeDt;

	private bool _inCampaignMode;

	private Scene _ownerSceneCached;

	private int _smallSplashParticleIndex;

	private int _mediumSplashParticleIndex;

	private int _largeSplashParticleIndex;

	private bool _hullLocalFramesSetForMission;

	private bool _wakeAndParticlesEnabled;

	private BoundingBox _bodyBB;

	private readonly SplashFoamDecal[] _splashFoamDecals;

	private int _nextDecalToUse;

	private Vec3 _lastDecalLeftSpawnPosition;

	private Vec3 _lastDecalRightSpawnPosition;

	private float _nextDecalLeftSpawnMetersSq;

	private float _nextDecalRightSpawnMetersSq;

	private Vec3 _previousShipFrameForDecalSpawn;

	private int _leftDecalParticleIndex;

	private int _rightDecalParticleIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipWaterEffects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DummyFunc()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity GetParticleParentEntity(ParticleType particleType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<ParticleData> GetParticleDataList(ParticleType particleType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ParticleSystem CreateMovementParticle(GameEntity parentEntity, MatrixFrame localFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RecomputeWaterSimulationBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FetchEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeWakeCapsuleParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RayCastToEntities(List<WeakGameEntity> rayCastEntities, Vec3 rayStart, Vec3 rayDirection, float maxLength, ref float resultLength, ref Vec3 surfaceNormal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlaceParticles(ParticleType particleType, float waterLineHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetFloaterForceMultiplier()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateWaterBalancePoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndSpawnSplashes(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SnapMovementParticlePositionsToWater(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickHullWater(float dt, bool fromEditor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetHeightCorrectedPosForSlice(ParticleData particleData, float height, ref bool pointIsValid, ref Vec3 limitingVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckWaterVisualRegistry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMeshesToRenderForInHullWater()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableWakeAndParticles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeregisterWaterMeshMaterials()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSplashFoamDecals(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleWetnessDecals(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ShipWaterEffects()
	{
		throw null;
	}
}
