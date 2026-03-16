using System;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;

namespace NavalDLC.Missions.ShipActuators;

public class OarSidePhaseController
{
	public enum OarSide
	{
		Left,
		Right
	}

	public const float RaisedPhase = MathF.PI;

	public const float LoweredPhase = 0f;

	private OarDeckParameters _averageDeckParameters;

	private float _lastPhase;

	private readonly MissionShip _ownerShip;

	public float Phase
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

	public float CycleArcSizeMult
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

	public float LastSlowDownFactor
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

	public float VisualPhase
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

	public float PhaseRate
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

	public float VisualVerticalBaseAngleOffsetFromShipRoll
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

	public OarSide Side
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OarSidePhaseController(MissionShip ownerShip, OarSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAverageOarDeckParameters(OarDeckParameters averageDeckParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (float, float) ComputeForceAndSlowDownFactor(float rowerNeededPhaseRate, float shipForwardSpeed, float syncPhase, float targetPhaseRate, float oarsmenForceMultiplier, float oarFrictionMultiplier, float maxTipSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhaseData(float phase, float phaseRate, float cycleArcSizeMult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Stop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInRowingMotion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetLastSubmergedHeightFactorForActuators()
	{
		throw null;
	}
}
