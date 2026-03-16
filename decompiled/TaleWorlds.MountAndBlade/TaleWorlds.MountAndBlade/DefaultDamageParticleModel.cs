using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class DefaultDamageParticleModel : DamageParticleModel
{
	private int _bloodStartHitParticleIndex;

	private int _bloodContinueHitParticleIndex;

	private int _bloodEndHitParticleIndex;

	private int _sweatStartHitParticleIndex;

	private int _sweatContinueHitParticleIndex;

	private int _sweatEndHitParticleIndex;

	private int _missileHitParticleIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultDamageParticleModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetMeleeAttackBloodParticles(Agent attacker, Agent victim, in Blow blow, in AttackCollisionData collisionData, out HitParticleResultData particleResultData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetMeleeAttackSweatParticles(Agent attacker, Agent victim, in Blow blow, in AttackCollisionData collisionData, out HitParticleResultData particleResultData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMissileAttackParticle(Agent attacker, Agent victim, in Blow blow, in AttackCollisionData collisionData)
	{
		throw null;
	}
}
