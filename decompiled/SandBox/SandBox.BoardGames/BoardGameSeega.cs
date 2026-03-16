using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.BoardGames.MissionLogics;
using SandBox.BoardGames.Pawns;
using SandBox.BoardGames.Tiles;
using TaleWorlds.Library;

namespace SandBox.BoardGames;

public class BoardGameSeega : BoardGameBase
{
	public class BarrierInfo
	{
		public bool IsHorizontal;

		public int Position;

		public bool PlayerOne;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BarrierInfo(bool isHor, int pos, bool playerOne)
		{
			throw null;
		}
	}

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

		public readonly bool MovedThisTurn;

		public readonly bool IsCaptured;

		public readonly Vec3 Position;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PawnInformation(int x, int y, int prevX, int prevY, bool movedThisTurn, bool captured, Vec3 position)
		{
			throw null;
		}
	}

	private const int CentralTileX = 2;

	private const int CentralTileY = 2;

	public static readonly int BoardWidth;

	public static readonly int BoardHeight;

	private Dictionary<PawnBase, int> _blockingPawns;

	private BoardInformation _startState;

	private bool _placementStageOver;

	public override int TileCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override int UnitsToPlacePerTurnInPreMovementStage
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
	public BoardGameSeega(MissionBoardGameLogic mission, PlayerTurn startingPlayer)
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
	public override void SetPawnCaptured(PawnBase pawn, bool aiSimulation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPawnArrivesGoalPosition(PawnBase pawn, Vec3 prevPos, Vec3 currentPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SwitchPlayerTurn()
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
	public Dictionary<PawnBase, int> GetBlockingPawns(bool playerOneBlocked)
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
	public TileBase GetTile(int x, int y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTile(TileBase tile, int x, int y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsCentralTile(Tile2D tile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsOnCentralTile(PawnSeega pawn)
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
	private bool CheckPlacementStageOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfPawnCapturedEnemyPawn(PawnSeega pawn, bool aiSimulation, Tile2D victimTile, TileBase helperTile, bool setCaptured)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CheckIfPawnCaptures(PawnSeega pawn, bool aiSimulation = false, bool setCaptured = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfPlayerIsStuck(bool playerOne)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FocusBlockingPawns()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnfocusBlockingPawns()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BarrierInfo CheckIfBarrier(Vec2i pawnNewPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfUnitsIsolatedByBarrier(Vec2i pawnNewPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BoardGameSeega()
	{
		throw null;
	}
}
