using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.DWA;

public class DWASimulator
{
	internal const int MaxObstacleVertexCount = 32;

	private MBList<DWAAgent> _agentsData;

	private MBList<DWAObstacleVertex> _obstaclesData;

	private DWAKdTree _kdTree;

	private MBList<int> _obstacleIndices;

	private MBList<int> _removedAgentIndices;

	private bool _isInitialized;

	private int _currentAgentIndexToProcess;

	private DWAAgent[] _agentsToProcess;

	private int _agentsToProcessCount;

	private DWAThread[] _processThreads;

	private DWASimulatorParameters _parameters;

	private ushort _parity;

	private readonly ParallelForAuxPredicate RunSampleThreadsAuxParallelPredicate;

	public bool IsInitialized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal ref readonly DWASimulatorParameters Parameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumObstacles
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal MBReadOnlyList<DWAAgent> AgentsIncludingRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal MBReadOnlyList<DWAObstacleVertex> Obstacles
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DWASimulator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetParameters(in DWASimulatorParameters newParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DWAAgentState GetAgentAgentNeighbor(int agentId, int neighborIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IDWAObstacleVertex GetAgentObstacleNeighbor(int agentId, int neighborIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DWAAgentState GetAgentState(int agentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAgentNumAgentNeighbors(int agentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAgentNumObstacleNeighbors(int agentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IDWAObstacleVertex GetObstacle(int obstacleId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IDWAObstacleVertex GetNextObstacleOfObstacle(int obstacleId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IDWAObstacleVertex GetPrevObstacleOfObstacle(int obstacleId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddAgent(IDWAAgentDelegate agentDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveAgent(IDWAAgentDelegate agentDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAgent(int agentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddObstacle(MBList<Vec3> vertices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool QueryVisibility(Vec2 point1, Vec2 point2, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RunSampleThreadsAuxParallel(int startInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddObstacleVertex(DWAObstacleVertex newObstacle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ComputeAgentNeighbors(DWAAgent agent, float rangeSq, ushort parity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ComputeObstacleNeighbors(DWAAgent agent, float rangeSq)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeAndUpdateAgentsToProcess(ushort parity, ref int currentAgentIndexToProcess, out int agentsToProcessCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeAndForecastNeighbors(ushort parity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearProcessThreads()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InsertRemovedIndex(int removedIndex)
	{
		throw null;
	}
}
