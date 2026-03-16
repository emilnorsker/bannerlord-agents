using System.Runtime.CompilerServices;
using Helpers;
using SandBox.BoardGames.MissionLogics;

namespace SandBox.BoardGames.AI;

public class BoardGameAIPuluc : BoardGameAIBase
{
	private readonly BoardGamePuluc _board;

	private readonly float[] _diceProbabilities;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardGameAIPuluc(AIDifficulty difficulty, MissionBoardGameLogic boardGameHandler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeDifficulty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Move CalculateMovementStageMove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float ExpectiMax(int depth, BoardGameSide side, bool chanceNode, ref Move bestMove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int Evaluation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetUnitsInSpawn(bool playerOne)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetUnitsBeingCaptured(bool playerOne)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetUnitsInPlay(bool playerOne)
	{
		throw null;
	}
}
