using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.DWA;

public class DWAAgent
{
	private ushort _lastStateUpdateParity;

	private MBList<KeyValuePair<float, DWAAgent>> _agentNeighbors;

	private MBList<KeyValuePair<float, DWAObstacleVertex>> _obstacleNeighbors;

	private readonly DWASimulator _simulator;

	private DWAAgentState[] _forecastStates;

	private (float distance, float amount) _targetOcclusion;

	public int Id
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

	public ref readonly DWAAgentState State
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<KeyValuePair<float, DWAAgent>> AgentNeighbors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<KeyValuePair<float, DWAObstacleVertex>> ObstacleNeighbors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IDWAAgentDelegate Delegate
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

	public bool IsForecast
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

	public int LastForecastNumTimeSamples
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

	public (float distance, float amount) TargetOcclusion
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DWAAgent(DWASimulator simulator, int id, IDWAAgentDelegate agentDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryUpdateState(ushort parity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsStateUpToDate(ushort parity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeNeighbors(ushort parity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForecastStates(int maxTimeSamples)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForecastTrajectory(float dt, int numTimeSamples)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InsertAgentNeighbor(DWAAgent agent, ref float rangeSq, ushort parity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InsertObstacleNeighbor(DWAObstacleVertex obstacle, ref float rangeSq)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeThreads(in DWASimulatorParameters parameters, DWAThread[] processThreads)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeTargetOcclusion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EvaluateState(in DWAAgentState state, int sampleIndex, out bool hasCollision, out DWAAgent collidedAgent, out DWAObstacleVertex collidedObstacle, out float goalCost, out float proxCost, out float maxPenetration, Vec2[] obstaclePolyBuffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (float dV, float dOmega) SelectAction(DWAThread[] threads, out int selectedActionThreadIndex, out DWAThread selectedActionThread)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void IntegrateState(in DWAAgentState curState, float dt, ref DWAAgentState newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ProximityCost(float signedClearDist, float safetyFactor = 1f)
	{
		throw null;
	}
}
