using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects;

public class ShipFloatsamManager : ScriptComponentBehavior
{
	private enum DebrisType
	{
		Generic,
		Scrape
	}

	private enum DecalType
	{
		Collision,
		Scrape
	}

	private struct ImpulseRecord
	{
		internal Vec3 AveragePosition;

		internal Vec3 AverageNormal;

		internal float TotalImpulse;

		internal Vec3 Speed;

		internal DebrisType DebrisType;

		internal float InitialSpeedMultiplier;

		internal Vec3 ShipLocalPosition;

		internal Vec3 ShipLocalNormal;

		internal DecalType DecalType;
	}

	private struct ShieldBreakRecord
	{
		internal Vec3 LinearVelocity;

		internal Texture BannerTexture;

		internal MatrixFrame ShipLocalSpawnFrame;

		internal string PrefabName;
	}

	private class ScrapeRecord
	{
		internal ParticleSystem Particle;

		internal float AccumulatedDistance;

		internal Vec3 PreviousPosition;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ScrapeRecord()
		{
			throw null;
		}
	}

	private static readonly string[] GenericPrefabNames;

	private static readonly string[] ScrapeDebrisPrefabNames;

	private static readonly string[] CollisionDecalPrefabNames;

	private static readonly string[] ScrapeDecalPrefabNames;

	private const string RudderPrefabName = "floatable_debris_rudder";

	private const string ShieldPrefabName = "floatable_debris_";

	private const string OarPrefabName = "floatable_debris_oar_a";

	private const string MastPrefabName = "floatable_debris_mast";

	private const string BodyMeshTag = "body_mesh";

	private const string BannerTag = "banner_with_faction_color";

	private const int MaxNumberOfPendingImpulseRecords = 10;

	private const float DebrisBreakImpulseThreshold = 150000f;

	private const int MaxDecalCount = 30;

	private Dictionary<WeakGameEntity, ScrapeRecord> _scrapeRecords;

	private GameEntity _identityFrameParticleParent;

	private int _scrapeParticleIndex;

	private int _collisionHitParticleIndex;

	private int _midCollisionHitParticleIndex;

	private int _bigCollisionHitParticleIndex;

	private readonly MBFastRandom _randomGenerator;

	private ImpulseRecord[] _impulseRecordsToProcess;

	private ShieldBreakRecord[] _shieldBreakRecords;

	private uint _shipColor;

	private int _numberOfPendingImpulseRecords;

	private int _numberOfPendingShieldBreakRecords;

	private uint _shipDecalColor;

	private bool _navalPhysicsSunk;

	private List<GameEntity> _collisionDecals;

	private string _shieldName;

	private BoundingBox _shipBodyBB;

	private NavalFloatsamLogic _floatsamMissionLogic;

	private GameEntity _bodyEntity;

	private MissionShip _ownMissionShipCached;

	private bool _floatsamSystemEnabled;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ShipFloatsamManager()
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
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPhysicsCollision(ref PhysicsContact contact, WeakGameEntity entity0, WeakGameEntity entity1, bool isFirstShape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessImpulseEffects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessShieldBreakRecords()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnBrokenShield(ShieldBreakRecord record)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessImpactEffect(ImpulseRecord record)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetRandomDebrisPrefab(DebrisType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetRandomCollisionDecalPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetRandomScrapeDecalPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetRandomAngularVelocityToEntity(GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckSinking()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShieldDestroyed(DestructableComponent target, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipHit(MissionShip ship, Agent attackerAgent, int damage, Vec3 impactPosition, Vec3 impactDirection, MissionWeapon weapon, int missileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableFloatsamSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ShipFloatsamManager()
	{
		throw null;
	}
}
