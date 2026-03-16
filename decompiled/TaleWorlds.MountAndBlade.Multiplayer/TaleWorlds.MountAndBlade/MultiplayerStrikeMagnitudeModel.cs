using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerStrikeMagnitudeModel : StrikeMagnitudeCalculationModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateStrikeMagnitudeForMissile(in AttackInformation attackInformation, in AttackCollisionData collisionData, in MissionWeapon weapon, float missileSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateStrikeMagnitudeForSwing(in AttackInformation attackInformation, in AttackCollisionData collisionData, in MissionWeapon weapon, float swingSpeed, float impactPoint, float extraLinearSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateStrikeMagnitudeForUnarmedAttack(in AttackInformation attackInformation, in AttackCollisionData collisionData, float progressEffect, float momentumRemaining)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateStrikeMagnitudeForThrust(in AttackInformation attackInformation, in AttackCollisionData collisionData, in MissionWeapon weapon, float thrustWeaponSpeed, float extraLinearSpeed, bool isThrown = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float ComputeRawDamage(DamageTypes damageType, float magnitude, float armorEffectiveness, float absorbedDamageRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetBluntDamageFactorByDamageType(DamageTypes damageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateHorseArcheryFactor(BasicCharacterObject characterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerStrikeMagnitudeModel()
	{
		throw null;
	}
}
