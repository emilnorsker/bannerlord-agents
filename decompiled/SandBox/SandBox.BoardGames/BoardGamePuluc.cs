using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.BoardGames.MissionLogics;
using SandBox.BoardGames.Pawns;
using SandBox.BoardGames.Tiles;
using TaleWorlds.Library;

namespace SandBox.BoardGames;

public class BoardGamePuluc : BoardGameBase
{
	public struct PawnInformation
	{
		public readonly int X;

		public readonly bool IsInSpawn;

		public readonly bool IsTopPawn;

		public readonly bool IsCaptured;

		public readonly PawnPuluc.MovementState State;

		public readonly List<PawnPuluc> PawnsBelow;

		public readonly Vec3 Position;

		public readonly PawnPuluc CapturedBy;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PawnInformation(int x, bool inSpawn, bool topPawn, PawnPuluc.MovementState state, List<PawnPuluc> pawnsBelow, bool captured, Vec3 position, PawnPuluc capturedBy)
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

	public const int WhitePawnCount = 6;

	public const int BlackPawnCount = 6;

	public const int TrackTileCount = 11;

	private const int PlayerHomebaseTileIndex = 11;

	private const int OpponentHomebaseTileIndex = 12;

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
	public BoardGamePuluc(MissionBoardGameLogic mission, PlayerTurn startingPlayer)
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
	public override void InitializeDiceBoard()
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
	public override void RollDice()
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
	protected override void UpdateAllTilesPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBeforeEndTurn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void MovePawnToTile(PawnBase pawn, TileBase tile, bool instantMove = false, bool displayMessage = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnAfterDiceRollAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AIMakeMove(Move move)
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
	private bool CanMovePawnToTile(PawnPuluc pawn, int tileCoord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PawnPuluc> GetAllPawnsForTileCoordinate(int x)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PawnPuluc> GetTopPawns(ref List<PawnPuluc> pawns)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PawnPuluc> CheckIfPawnWillCapture(PawnPuluc pawn, int tile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RestoreStartingBoard()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPawnSides()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PawnHasReachedHomeBase(PawnPuluc pawn, bool instantmove, bool fake = false)
	{
		throw null;
	}
}
