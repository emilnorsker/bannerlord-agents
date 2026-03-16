using System.Runtime.CompilerServices;
using Helpers;
using SandBox.BoardGames.MissionLogics;
using TaleWorlds.Library;

namespace SandBox.BoardGames.AI;

public abstract class BoardGameAIBase
{
	public enum AIState
	{
		NeedsToRun,
		ReadyToRun,
		Running,
		AbortRequested,
		Aborted,
		Done
	}

	private const float AIDecisionDuration = 1.5f;

	protected bool MayForfeit;

	protected int MaxDepth;

	private float _aiDecisionTimer;

	private readonly ITask _aiTask;

	private readonly object _stateLock;

	private volatile AIState _state;

	public AIState State
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Move RecentMoveCalculated
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

	public bool AbortRequested
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected AIDifficulty Difficulty
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

	protected MissionBoardGameLogic BoardGameHandler
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BoardGameAIBase(AIDifficulty difficulty, MissionBoardGameLogic boardGameHandler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual Move CalculatePreMovementStageMove()
	{
		throw null;
	}

	public abstract Move CalculateMovementStageMove();

	protected abstract void InitializeDifficulty();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool WantsToForfeit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnSetGameOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDifficulty(AIDifficulty difficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float HowLongDidAIThinkAboutMove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateThinkingAboutMove(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateThinkingAboutMoveOnSeparateThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetThinking()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanMakeMove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculatePreMovementStageOnSeparateThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateMovementStageMoveOnSeparateThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool OnBeginSeparateThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnExitSeparateThread(Move calculatedMove)
	{
		throw null;
	}
}
