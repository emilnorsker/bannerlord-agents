using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.BoardGames.AI;
using SandBox.BoardGames.MissionLogics;
using SandBox.BoardGames.Pawns;
using SandBox.BoardGames.Tiles;
using TaleWorlds.Engine;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace SandBox.BoardGames;

public abstract class BoardGameBase
{
	public const string StringBoardGame = "str_boardgame";

	public const string StringForfeitQuestion = "str_boardgame_forfeit_question";

	public const string StringMovePiecePlayer = "str_boardgame_move_piece_player";

	public const string StringMovePieceOpponent = "str_boardgame_move_piece_opponent";

	public const string StringCapturePiecePlayer = "str_boardgame_capture_piece_player";

	public const string StringCapturePieceOpponent = "str_boardgame_capture_piece_opponent";

	public const string StringVictoryMessage = "str_boardgame_victory_message";

	public const string StringDefeatMessage = "str_boardgame_defeat_message";

	public const string StringDrawMessage = "str_boardgame_draw_message";

	public const string StringNoAvailableMovesPlayer = "str_boardgame_no_available_moves_player";

	public const string StringNoAvailableMovesOpponent = "str_boardgame_no_available_moves_opponent";

	public const string StringSeegaBarrierByP1DrawMessage = "str_boardgame_seega_barrier_by_player_one_draw_message";

	public const string StringSeegaBarrierByP2DrawMessage = "str_boardgame_seega_barrier_by_player_two_draw_message";

	public const string StringSeegaBarrierByP1VictoryMessage = "str_boardgame_seega_barrier_by_player_one_victory_message";

	public const string StringSeegaBarrierByP2VictoryMessage = "str_boardgame_seega_barrier_by_player_two_victory_message";

	public const string StringSeegaBarrierByP1DefeatMessage = "str_boardgame_seega_barrier_by_player_one_defeat_message";

	public const string StringSeegaBarrierByP2DefeatMessage = "str_boardgame_seega_barrier_by_player_two_defeat_message";

	public const string StringRollDicePlayer = "str_boardgame_roll_dice_player";

	public const string StringRollDiceOpponent = "str_boardgame_roll_dice_opponent";

	protected const int InvalidDice = -1;

	protected const float DelayBeforeMovingAnyPawn = 0.25f;

	protected const float DelayBetweenPawnMovementsBegin = 0.15f;

	private const float DiceRollAnimationDuration = 1f;

	private const float DraggingDuration = 0.2f;

	private const int UnitsToPlacePerTurnInMovementStage = 1;

	protected uint PawnSelectedFactor;

	protected uint PawnUnselectedFactor;

	protected MissionBoardGameLogic MissionHandler;

	protected GameEntity BoardEntity;

	protected GameEntity DiceBoard;

	protected bool JustStoppedDraggingUnit;

	protected CapturedPawnsPool PlayerOnePool;

	protected bool ReadyToPlay;

	protected CapturedPawnsPool PlayerTwoPool;

	protected bool SettingUpBoard;

	protected bool HasToMovePawnsAcross;

	protected float DiceRollAnimationTimer;

	protected int MovesLeftToEndTurn;

	protected bool DiceRollAnimationRunning;

	protected int DiceRollSoundCodeID;

	private List<Move> _validMoves;

	private PawnBase _selectedUnit;

	private Vec3 _userRayBegin;

	private Vec3 _userRayEnd;

	private float _draggingTimer;

	private bool _draggingSelectedUnit;

	private float _rotationApplied;

	private float _rotationTarget;

	private bool _rotationCompleted;

	private bool _deselectUnit;

	private bool _firstTickAfterReady;

	private bool _waitingAIForfeitResponse;

	public abstract int TileCount { get; }

	protected abstract bool RotateBoard { get; }

	protected abstract bool PreMovementStagePresent { get; }

	protected abstract bool DiceRollRequired { get; }

	protected virtual int UnitsToPlacePerTurnInPreMovementStage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual PawnBase SelectedUnit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public TextObject Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public bool InPreMovementStage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public TileBase[] Tiles
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public List<PawnBase> PlayerOneUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public List<PawnBase> PlayerTwoUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public int LastDice
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public bool IsReady
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public PlayerTurn PlayerWhoStarted
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

	public GameOverEnum GameOverInfo
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

	public PlayerTurn PlayerTurn
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	protected IInputContext InputManager
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected List<PawnBase> PawnSelectFilter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	protected BoardGameAIBase AIOpponent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool DiceRolled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BoardGameBase(MissionBoardGameLogic mission, TextObject name, PlayerTurn startingPlayer)
	{
		throw null;
	}

	public abstract void InitializeUnits();

	public abstract void InitializeTiles();

	public abstract void InitializeSound();

	public abstract List<Move> CalculateValidMoves(PawnBase pawn);

	protected abstract PawnBase SelectPawn(PawnBase pawn);

	protected abstract bool CheckGameEnded();

	protected abstract void OnAfterBoardSetUp();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnAfterBoardRotated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBeforeEndTurn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void RollDice()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void UpdateAllTilesPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void InitializeDiceBoard()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnPawnArrivesGoalPosition(PawnBase pawn, Vec3 prevPos, Vec3 currentPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void HandlePreMovementStage(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void InitializeCapturedUnitsZones()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void HandlePreMovementStageAI(Move move)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetPawnCaptured(PawnBase pawn, bool fake = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual List<List<Move>> CalculateAllValidMoves(BoardGameSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SwitchPlayerTurn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void MovePawnToTile(PawnBase pawn, TileBase tile, bool instantMove = false, bool displayMessage = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void MovePawnToTileDelayed(PawnBase pawn, TileBase tile, bool instantMove, bool displayMessage, float delay)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnAfterDiceRollAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUserRay(Vec3 rayBegin, Vec3 rayEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStartingPlayer(PlayerTurn player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGameOverInfo(GameOverEnum info)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasMovesAvailable(ref List<List<Move>> moves)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalMovesAvailable(ref List<List<Move>> moves)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlayDiceRollSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPlayerOneUnitsAlive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPlayerTwoUnitsAlive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPlayerOneUnitsDead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPlayerTwoUnitsDead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void RemovePawnFromBoard(PawnBase pawn, float speed, bool instantMove = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceDice(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected PawnBase InitializeUnit(PawnBase pawnToInit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected Move HandlePlayerInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected PawnBase GetHoveredPawnIfAny()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected TileBase GetHoveredTileIfAny()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CheckSwitchPlayerTurn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnVictory(string message = "str_boardgame_victory_message")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnAfterEndTurn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnDefeat(string message = "str_boardgame_defeat_message")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnDraw(string message = "str_boardgame_draw_message")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeforeSelectedUnitChanged(PawnBase oldSelectedUnit, PawnBase newSelectedUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void EndTurn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ClearValidMoves()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAfterSelectedUnitChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTurn(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoneSettingUpBoard()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void HideAllValidTiles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ShowAllValidTiles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnfocusAllPawns()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MovingPawnPresent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SwitchToWaiting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnAIWantsForfeit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAllPawnsPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAIForfeitAccepted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAIForfeitRejected()
	{
		throw null;
	}
}
