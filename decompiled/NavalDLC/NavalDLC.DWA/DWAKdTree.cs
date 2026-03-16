using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.DWA;

internal class DWAKdTree
{
	private const int MaxLeafSize = 10;

	private DWAAgent[] _agents;

	private DWAAgentTreeNode[] _agentTree;

	private DWAObstacleTreeNode _obstacleTree;

	private DWASimulator _simulator;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal DWAKdTree(DWASimulator simulator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BuildAgentTree()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BuildObstacleTree()
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
	internal bool QueryVisibility(in Vec2 point1, in Vec2 point2, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BuildAgentTreeRecursive(int begin, int end, int node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DWAObstacleTreeNode BuildObstacleTreeRecursive(IList<DWAObstacleVertex> obstacles)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QueryAgentTreeRecursive(DWAAgent agent, ref float rangeSq, int node, ushort parity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QueryObstacleTreeRecursive(DWAAgent agent, ref float rangeSq, DWAObstacleTreeNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool QueryVisibilityRecursive(in Vec2 q1, in Vec2 q2, float radius, DWAObstacleTreeNode node)
	{
		throw null;
	}
}
