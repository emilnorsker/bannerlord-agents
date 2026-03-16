using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using SandBox.View.Map.Visuals;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.View.Map.Visuals;

public class NavalMobilePartyVisual : MapEntityVisual<PartyBase>
{
	private struct ShipOar
	{
		internal WeakGameEntity _oarEntity;

		internal float _sideSign;
	}

	public struct BlockadeShipVisual
	{
		public GameEntity ShipEntity;

		public float RockingPhase;
	}

	private class ShipFoamDecal
	{
		internal Decal _splashFoamDecal;

		internal MatrixFrame _currentFrame;

		internal float _cumulativeDtTillStart;

		internal Vec3 _randomScale;

		internal Vec3 _currentSpeed;

		internal Vec3 _sideVectorStart;

		internal Vec3 _sideVectorEnd;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal ShipFoamDecal()
		{
			throw null;
		}
	}

	private const float DefaultWaterLevelZ = 2.58f;

	private const float SailWindVisualAmplifier = 5f;

	private const float BannerWindVisualAmplifier = 3f;

	private const string LeftOarTag = "oar_gate_left";

	private const string RightOarTag = "oar_gate_right";

	private const string BodyMeshTag = "body_mesh";

	private const int NumberOfSplashDecal = 20;

	private float _entityAlpha;

	private bool _isSailFolded;

	private float _sailAlpha;

	private string _flagShipId;

	private bool _isVisualInRaftState;

	private MatrixFrame _firstOarRotationFrameCached;

	private MatrixFrame _secondOarRotationFrameCached;

	private readonly Dictionary<Ship, BlockadeShipVisual> _shipToBlockadeShipVisualCache;

	private readonly List<ShipOar> _oars;

	private readonly List<SailVisual> _sailVisualCache;

	private SoundEvent _sailingSoundEvent;

	private float _oarPhase;

	private float _rockingPhase;

	private float _swayingAngle;

	private float _rollingAngle;

	private CampaignVec2 _targetPositionForSwaying;

	private float _lastFrameLerpedAngle;

	private GameEntity _shipEntity;

	private WeakGameEntity _bodyMeshEntity;

	private GameEntity _currentCollidedBridgeEntity;

	private float _bearingRotation;

	private GameEntity _shipMovementParticleEntity;

	private ParticleSystem _shipMovementParticle;

	private GameEntity _shipStillMovementParticleEntity;

	private ParticleSystem _shipStillMovementParticle;

	private BoundingBox _wakeBB;

	private Scene _ownerSceneCached;

	private ShipFoamDecal[] _splashFoamDecals;

	private Vec3 _lastDecalSpawnPosition;

	private float _nextDecalSpawnMetersSq;

	private int _nextDecalToUse;

	public override float BearingRotation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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

	public override bool IsMobileEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsMainEntity
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
	public NavalMobilePartyVisual(PartyBase partyBase)
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
	public override void OnHover()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec3 GetVisualPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ReleaseResources()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsVisibleOrFadingOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnOpenEncyclopedia()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Tick(float dt, float realDt, ref int dirtyPartiesCount, ref NavalMobilePartyVisual[] dirtyPartiesList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UpdateEntityPosition(float dt, float realDt, bool isVisible = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnStartup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void TickFadingState(float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickTransitionFadeState(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ClearVisualMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ValidateIsDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshPartyIcon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePartyCollider(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetPartyIcon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HideNavalVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetTransitionProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetVisualRotation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMapEventVisualRotation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectOars()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateBearingRotation(float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetOarVerticalAngle(float phase, float verticalBaseAngle, float verticalRotationAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickSailingSound(float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame ComputeOarFrame(ShipOar oar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickOars(float dt, float realDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddShipVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMoving()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickIdleShipAnimation(Ship ship, ref float rockingPhase, ref MatrixFrame entityFrame, bool isBlockadeShip = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFoamDecals(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickSwayingAnimation(ref MatrixFrame entityFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckBridgeFadeState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyWindEffect(Vec2 windVector, Vec2 shipDirection, float realDt, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRaftVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveBlockadeVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasNavalVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddVisualToVisualsOfEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveVisualFromVisualsOfEntities()
	{
		throw null;
	}
}
