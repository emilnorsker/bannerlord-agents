using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SandBox.BoardGames.AI;

public class TreeNodeTablut
{
	private struct SimulationResult
	{
		public readonly BoardGameTablut.State EndState;

		public readonly int TurnsNeededToReachEndState;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SimulationResult(BoardGameTablut.State s, int turns)
		{
			throw null;
		}
	}

	private enum ExpandResult
	{
		NeedsToBeSimulated,
		AIWon,
		PlayerWon,
		Aborted
	}

	private const float UCTConstant = 1.5f;

	private static int MaxDepth;

	private readonly int _depth;

	private BoardGameTablut.BoardInformation _boardState;

	private TreeNodeTablut _parent;

	private List<TreeNodeTablut> _children;

	private BoardGameSide _lastTurnIsPlayedBy;

	private int _visits;

	private int _wins;

	public Move OpeningMove
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

	private bool IsLeaf
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TreeNodeTablut(BoardGameSide lastTurnIsPlayedBy, int depth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TreeNodeTablut CreateTreeAndReturnRootNode(BoardGameTablut.BoardInformation initialBoardState, int maxDepth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TreeNodeTablut GetChildWithBestScore()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PruneSiblings(TreeNodeTablut node, BoardGameSide winner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TreeNodeTablut Select()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExpandResult Expand()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SimulationResult Simulate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BackPropagate(BoardGameSide winner)
	{
		throw null;
	}
}
