using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class ShipCollisionOutcomeLogic : MissionLogic
{
	private const float EffectCooldownForShipInSeconds = 2f;

	private static readonly int _ramCollisionSoundEffectSoundId;

	private readonly Mission _mission;

	private NavalShipsLogic _navalShipsLogic;

	private float _cameraShakeStartTime;

	private float _cameraShakeCurrentTimeWithFrequency;

	private float _cameraShakeIntensity;

	private Vec2 _cameraShakeInitialVelocity;

	private readonly Dictionary<MissionShip, float> _shipCollisionEffectCooldowns;

	private readonly Queue<(MissionShip, Vec3, Vec2, float)> _agentActionQueue;

	private MBFastRandom _effectRandom;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipCollisionOutcomeLogic(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipRamming(MissionShip rammingShip, MissionShip rammedShip, float damagePercent, bool isFirstImpact, CapsuleData capsuleData, int ramQuality)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipCollision(MissionShip ship, WeakGameEntity targetEntity, Vec3 averageContactPoint, Vec3 totalImpulseOnShip, bool isFirstImpact)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShipCollisionEffect(MissionShip ship, WeakGameEntity targetEntity, Vec3 collisionGlobalPosition, Vec3 collisionDirection, bool shouldMakeSound)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateCooldownForShip(MissionShip ship, float cooldown)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleAgentActions(MissionShip ship, Vec3 collisionGlobalPosition, Vec2 shipDirection, float impactFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ShipCollisionOutcomeLogic()
	{
		throw null;
	}
}
