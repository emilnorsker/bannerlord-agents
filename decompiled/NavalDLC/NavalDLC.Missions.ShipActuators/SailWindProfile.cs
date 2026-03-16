using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.Missions.ShipActuators;

public class SailWindProfile
{
	private const int BinCount = 36;

	private const float BinAngleInDegrees = 10f;

	private static SailWindProfile _instance;

	private (float dragCoef, float liftCoef)[][] _sailWindProfiles;

	public static SailWindProfile Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsSailWindProfileInitialized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeProfile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeProfileForEditor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FinalizeProfile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillSailProfiles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SailWindProfile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float ComputeSailThrustValue(SailType sailType, Vec2 sailDir, Vec2 desiredThrustDir, Vec2 windDir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetMaximumSailForceCoefficients(SailType sailType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetSailForceCoefficients(SailType sailType, Vec2 sailDir, Vec2 windDir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (float dragCoef, float liftCoef) GetSailCoefs(float angleOfAttackInRadians, SailType sailType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (float dragCoef, float liftCoef)[] GenerateLateenSailWindProfile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (float dragCoef, float liftCoef)[] GenerateSquareSailWindProfile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAngleOfAttack(in Vec2 sailDir, in Vec2 windDir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float NormalizeThrustValue(float thrustValue, float minThrustValue, float maxThrustValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SailWindProfile()
	{
		throw null;
	}
}
