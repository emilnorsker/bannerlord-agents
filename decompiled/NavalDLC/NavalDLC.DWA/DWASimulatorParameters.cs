using System.Runtime.CompilerServices;

namespace NavalDLC.DWA;

public struct DWASimulatorParameters
{
	public const int DefaultMaxNumTimeSamples = 12;

	public const int DefaultSamplesPerSecond = 4;

	public const int DefaultAgentsToProcessPerTick = 1;

	public const int DefaultLinearAccelerationResolution = 3;

	public const int DefaultAngularAccelerationResolution = 3;

	public const bool DefaultIgnoreZeroAction = true;

	public const int DefaultMaxAgentNeighbors = 3;

	public const int DefaultMaxObstacleNeighbors = 3;

	private int _numLinearAccelerationSamples;

	private int _numAngularAccelerationSamples;

	private int _totalNumAccelerationSamples;

	private bool _requiresUpdate;

	public int NumTimeSamples
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

	public int SamplesPerSecond
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

	public int AgentsToProcessPerTick
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

	public int LinearAccelerationResolution
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

	public int AngularAccelerationResolution
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

	public int MaxAgentNeighbors
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

	public int MaxObstacleNeighbors
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

	public bool IgnoreZeroAction
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

	public int NumLinearAccelerationSamples
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumAngularAccelerationSamples
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int TotalNumAccelerationSamples
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float TimeHorizon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DeltaTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DWASimulatorParameters(int numTimeSamples, int samplesPerSecond, int agentsToProcessPerTick, int linearAccelerationResolution, int angularAccelerationResolution, bool ignoreZeroAction, int maxAgentNeighbors, int maxObstacleNeighbors, int numLinearAccelerationSamples, int numAngularAccelerationSamples, int totalNumAccelerationSamples, bool requiresUpdate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckRequiresUpdate(bool reset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNumTimeSamples(int numTimeSamples)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSamplesPerSecond(int samplesPerSecond)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentsToProcessPerTick(int agentsToProcessPerTick)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLinearAccelerationResolution(int linearAccelerationResolution)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAngularAccelerationResolution(int angularAccelerationResolution)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIgnoreZeroAction(bool ignoreZeroAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaxAgentNeighbors(int maxAgentNeighbors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaxObstacleNeighbors(int maxObstacleNeighbors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyFrom(in DWASimulatorParameters otherParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RecomputeDerivedParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static DWASimulatorParameters Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ComputeDerivedParameters(int linearAccelerationResolution, int angularAccelerationResolution, bool ignoreZeroAction, out int numLinearAccelerationSamples, out int numAngularAccelerationSamples, out int numTotalAccelerationSamples)
	{
		throw null;
	}
}
