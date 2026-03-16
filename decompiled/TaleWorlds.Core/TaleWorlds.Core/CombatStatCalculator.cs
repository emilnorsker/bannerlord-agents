using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public static class CombatStatCalculator
{
	public const float ReferenceSwingSpeed = 22f;

	public const float ReferenceThrustSpeed = 8.5f;

	public const float SwingSpeedConst = 4.5454545f;

	public const float ThrustSpeedConst = 11.764706f;

	public const float DefaultImpactDistanceFromTip = 0.07f;

	public const float ArmLength = 0.5f;

	public const float ArmWeight = 2.5f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CalculateStrikeMagnitudeForSwing(float swingSpeed, float impactPointAsPercent, float weaponWeight, float weaponLength, float weaponInertia, float weaponCoM, float extraLinearSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CalculateStrikeMagnitudeForThrust(float thrustWeaponSpeed, float weaponWeight, float extraLinearSpeed, bool isThrown)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float CalculateStrikeMagnitudeForPassiveUsage(float weaponWeight, float extraLinearSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CalculateBaseBlowMagnitudeForSwing(float angularSpeed, float weaponReach, float weaponWeight, float weaponInertia, float weaponCoM, float impactPoint, float exraLinearSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CalculateBaseBlowMagnitudeForThrust(float linearSpeed, float weaponWeight, float exraLinearSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CalculateBaseBlowMagnitudeForPassiveUsage(float weaponWeight, float extraLinearSpeed)
	{
		throw null;
	}
}
