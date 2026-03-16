using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.BoardGames.MissionLogics;
using SandBox.BoardGames.Pawns;
using SandBox.BoardGames.Tiles;

namespace SandBox.BoardGames;

public class BoardGameMuTorere : BoardGameBase
{
	public struct BoardInformation
	{
		public readonly PawnInformation[] PawnInformation;

		public readonly TileBaseInformation[] TileInformation;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BoardInformation(ref PawnInformation[] pawns, ref TileBaseInformation[] tiles)
		{
			throw null;
		}
	}

	public struct PawnInformation
	{
		public readonly int X;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PawnInformation(int x)
		{
			throw null;
		}
	}

	public const int WhitePawnCount = 4;

	public const int BlackPawnCount = 4;

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
	public BoardGameMuTorere(MissionBoardGameLogic mission, PlayerTurn startingPlayer)
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
	public override void InitializeCapturedUnitsZones()
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
	protected override void OnAfterBoardSetUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TileMuTorere FindTileByCoordinate(int x)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardInformation TakePawnsSnapshot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UndoMove(ref BoardInformation board)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AIMakeMove(Move move)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TileBase FindAvailableTile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PreplaceUnits()
	{
		throw null;
	}
}
