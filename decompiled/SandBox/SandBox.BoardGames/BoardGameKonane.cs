using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.BoardGames.MissionLogics;
using SandBox.BoardGames.Pawns;
using SandBox.BoardGames.Tiles;
using TaleWorlds.Library;

namespace SandBox.BoardGames;

public class BoardGameKonane : BoardGameBase
{
	public struct BoardInformation
	{
		public readonly PawnInformation[] PawnInformation;

		public readonly TileBaseInformation[,] TileInformation;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BoardInformation(ref PawnInformation[] pawns, ref TileBaseInformation[,] tiles)
		{
			throw null;
		}
	}

	public struct PawnInformation
	{
		public readonly int X;

		public readonly int Y;

		public readonly int PrevX;

		public readonly int PrevY;

		public readonly bool IsCaptured;

		public readonly Vec3 Position;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PawnInformation(int x, int y, int prevX, int prevY, bool captured, Vec3 position)
		{
			throw null;
		}
	}

	public const int WhitePawnCount = 18;

	public const int BlackPawnCount = 18;

	public static readonly int BoardWidth;

	public static readonly int BoardHeight;

	public List<PawnBase> RemovablePawns;

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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardGameKonane(MissionBoardGameLogic mission, PlayerTurn startingPlayer)
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
	protected override PawnBase SelectPawn(PawnBase pawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandlePreMovementStage(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandlePreMovementStageAI(Move move)
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
	protected override void OnAfterBoardSetUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AIMakeMove(Move move)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CheckForRemovablePawns(bool playerOne)
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
	protected void CheckWhichPawnsAreCaptured(PawnKonane pawn, bool fake = false)
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
	private void FocusRemovablePawns()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnFocusRemovablePawns()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAllGoalPositions(PawnKonane pawn, Tile2D prevTile, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckPlacementStageOver()
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
	static BoardGameKonane()
	{
		throw null;
	}
}
