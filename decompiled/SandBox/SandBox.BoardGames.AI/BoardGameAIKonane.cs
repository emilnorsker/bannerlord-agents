using System.Runtime.CompilerServices;
using Helpers;
using SandBox.BoardGames.MissionLogics;

namespace SandBox.BoardGames.AI;

public class BoardGameAIKonane : BoardGameAIBase
{
	private readonly BoardGameKonane _board;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardGameAIKonane(AIDifficulty difficulty, MissionBoardGameLogic boardGameHandler)
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
}
