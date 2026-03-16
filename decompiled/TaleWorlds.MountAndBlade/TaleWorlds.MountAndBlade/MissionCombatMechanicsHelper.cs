using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MissionCombatMechanicsHelper
{
	private const float SpeedBonusFactorForSwing = 0.7f;

	private const float SpeedBonusFactorForThrust = 0.5f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DecideAgentShrugOffBlow(Agent victimAgent, in AttackCollisionData collisionData, in Blow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DecideAgentDismountedByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, in Blow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DecideAgentKnockedBackByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, in Blow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DecideAgentKnockedDownByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, in Blow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DecideMountRearedByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, in Blow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DecideWeaponCollisionReaction(in Blow registeredBlow, in AttackCollisionData collisionData, Agent attacker, Agent defender, in MissionWeapon attackerWeapon, bool isFatalHit, bool isShruggedOff, float momentumRemaining, out MeleeCollisionReaction colReaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsCollisionBoneDifferentThanWeaponAttachBone(in AttackCollisionData collisionData, int weaponAttachBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DecideSweetSpotCollision(in AttackCollisionData collisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetAttackCollisionResults(in AttackInformation attackInformation, bool crushedThrough, float momentumRemaining, bool cancelDamage, ref AttackCollisionData attackCollisionData, out CombatLogData combatLog, out int speedBonus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GetDefendCollisionResults(Agent attackerAgent, Agent defenderAgent, CombatCollisionResult collisionResult, int attackerWeaponSlotIndex, bool isAlternativeAttack, StrikeType strikeType, Agent.UsageDirection attackDirection, float collisionDistanceOnWeapon, float attackProgress, bool attackIsParried, bool isPassiveUsageHit, bool isHeavyAttack, ref float defenderStunPeriod, ref float attackerStunPeriod, ref bool crushedThrough, ref bool chamber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UpdateMomentumRemaining(ref float momentumRemaining, in Blow b, in AttackCollisionData collisionData, Agent attacker, Agent victim, in MissionWeapon attackerWeapon, bool isCrushThrough)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HitWithAnotherBone(in AttackCollisionData collisionData, Agent attacker, in MissionWeapon attackerWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DecideWeaponKnockDown(Agent attackerAgent, Agent victimAgent, WeaponComponentData attackerWeapon, in AttackCollisionData collisionData, in Blow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DecideCombatEffect(float inflictedDamage, float victimMaxHealth, float victimResistance, float attackPenetration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float ChargeDamageDotProduct(in Vec3 victimPosition, in Vec2 chargerMovementDirection, in Vec3 collisionPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float SpeedGraphFunction(float progress, StrikeType strikeType, Agent.UsageDirection attackDir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float ConvertBaseAttackMagnitude(WeaponComponentData weapon, StrikeType strikeType, float baseMagnitude)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec2 GetAgentVelocityContribution(bool hasAgentMountAgent, Vec2 agentMovementVelocity, Vec2 agentMountMovementDirection, float agentMovementDirectionAsAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetEntityDamageMultiplier(bool isAttackerAgentDoingPassiveAttack, WeaponComponentData weapon, DamageTypes damageType, bool isFlammable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float ComputeSpeedBonus(float baseMagnitude, float baseMagnitudeWithoutSpeedBonus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float ComputeRelativeSpeedDiffOfAgents(Agent agentA, Agent agentB)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ComputeBlowDamage(in AttackInformation attackInformation, in AttackCollisionData attackCollisionData, WeaponComponentData attackerWeapon, DamageTypes damageType, float magnitude, int speedBonus, bool cancelDamage, out int inflictedDamage, out int absorbedByArmor, out bool isSneakAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ComputeBlowDamageOnShield(in AttackInformation attackInformation, in AttackCollisionData attackCollisionData, WeaponComponentData attackerWeapon, float blowMagnitude, out int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CalculateBaseMeleeBlowMagnitude(in AttackInformation attackInformation, in AttackCollisionData collisionData, StrikeType strikeType, float progressEffect, float impactPointAsPercent, float exraLinearSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ComputeBlowMagnitude(in AttackCollisionData acd, in AttackInformation attackInformation, float momentumRemaining, bool cancelDamage, bool hitWithAnotherBone, Vec2 attackerVelocity, Vec2 victimVelocity, out float baseMagnitude, out float specialMagnitude, out float movementSpeedDamageModifier, out int speedBonusInt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ComputeBlowMagnitudeMelee(in AttackInformation attackInformation, in AttackCollisionData collisionData, float momentumRemaining, bool cancelDamage, bool hitWithAnotherBone, StrikeType strikeType, Agent.UsageDirection attackDirection, bool attackerIsDoingPassiveAttack, Vec2 attackerVelocity, Vec2 victimVelocity, out float baseMagnitude, out float specialMagnitude, out float movementSpeedDamageModifier, out int speedBonusInt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ComputeBlowMagnitudeFromHorseCharge(in AttackInformation attackInformation, in AttackCollisionData acd, Vec2 attackerAgentVelocity, Vec2 victimAgentVelocity, out float baseMagnitude, out float specialMagnitude)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ComputeBlowMagnitudeMissile(in AttackInformation attackInformation, in AttackCollisionData collisionData, float momentumRemaining, in Vec2 victimVelocity, out float baseMagnitude, out float specialMagnitude)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ComputeBlowMagnitudeFromFall(in AttackInformation attackInformation, in AttackCollisionData acd, out float baseMagnitude, out float specialMagnitude)
	{
		throw null;
	}
}
