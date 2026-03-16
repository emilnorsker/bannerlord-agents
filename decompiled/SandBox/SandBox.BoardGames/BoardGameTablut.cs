using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.BoardGames.MissionLogics;
using SandBox.BoardGames.Pawns;
using SandBox.BoardGames.Tiles;

namespace SandBox.BoardGames;

public class BoardGameTablut : BoardGameBase
{
	public struct PawnInformation
	{
		public int X;

		public int Y;

		public bool IsCaptured;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PawnInformation(int x, int y, bool captured)
		{
			throw null;
		}
	}

	public struct BoardInformation
	{
		public readonly PawnInformation[] PawnInformation;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BoardInformation(ref PawnInformation[] pawns)
		{
			throw null;
		}
	}

	public enum State
	{
		InProgress,
		Aborted,
		PlayerWon,
		AIWon
	}

	public const int BoardWidth = 9;

	public const int BoardHeight = 9;

	public const int AttackerPawnCount = 16;

	public const int DefenderPawnCount = 9;

	private BoardInformation _startState;

	public override int TileCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override bool RotateBoard
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override bool PreMovementStagePresent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override bool DiceRollRequired
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private PawnTablut King
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardGameTablut(MissionBoardGameLogic mission, PlayerTurn startingPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsCitadelTile(int tileX, int tileY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void InitializeUnits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void InitializeTiles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void InitializeSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<Move> CalculateValidMoves(PawnBase pawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetPawnCaptured(PawnBase pawn, bool fake = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnAfterBoardSetUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PawnBase SelectPawn(PawnBase pawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void MovePawnToTileDelayed(PawnBase pawn, TileBase tile, bool instantMove, bool displayMessage, float delay)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SwitchPlayerTurn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CheckGameEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AIMakeMove(Move move)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAvailableMoves(PawnTablut pawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Move GetRandomAvailableMove(PawnTablut pawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Move GetWinningMoveIfPresent(BoardGameSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardInformation TakeBoardSnapshot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UndoMove(ref BoardInformation board)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public State CheckGameState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTile(TileBase tile, int x, int y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TileBase GetTile(int x, int y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PreplaceUnits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RestoreStartingBoard()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AddValidMove(List<Move> moves, PawnBase pawn, int x, int y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfPawnCapturedEnemyPawn(PawnTablut pawn, bool fake, TileBase victimTile, Tile2D helperTile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfPawnCaptures(PawnTablut pawn, bool fake = false)
	{
		throw null;
	}
}
