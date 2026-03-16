using System.Runtime.CompilerServices;
using Helpers;
using SandBox.BoardGames.MissionLogics;
using SandBox.BoardGames.Pawns;

namespace SandBox.BoardGames.AI;

public class BoardGameAISeega : BoardGameAIBase
{
	private readonly BoardGameSeega _board;

	private readonly int[,] _boardValues;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardGameAISeega(AIDifficulty difficulty, MissionBoardGameLogic boardGameHandler)
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
	public override bool WantsToForfeit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Move CalculatePreMovementStageMove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int NegaMax(int depth, int color, int alpha, int beta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int Evaluation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetPlacementScore(bool player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetSurroundedScore(bool player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetAmountSurroundingThisPawn(PawnSeega pawn)
	{
		throw null;
	}
}
