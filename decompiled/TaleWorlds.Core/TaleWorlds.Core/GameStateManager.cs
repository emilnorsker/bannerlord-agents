using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class GameStateManager
{
	public enum GameStateManagerType
	{
		Game,
		Global
	}

	private struct GameStateJob
	{
		public enum JobType
		{
			None,
			Push,
			Pop,
			CleanAndPushState,
			CleanStates
		}

		public readonly JobType Job;

		public readonly GameState GameState;

		public readonly int PopLevel;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GameStateJob(JobType job, GameState gameState, int popLevel)
		{
			throw null;
		}
	}

	private static GameStateManager _current;

	public static string StateActivateCommand;

	private readonly List<GameState> _gameStates;

	private readonly List<IGameStateManagerListener> _listeners;

	private readonly List<WeakReference> _activeStateDisableRequests;

	private readonly Queue<GameStateJob> _gameStateJobs;

	public static GameStateManager Current
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

	public IReadOnlyCollection<IGameStateManagerListener> Listeners
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GameStateManagerType CurrentType
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

	public IGameStateManagerOwner Owner
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

	public IEnumerable<GameState> GameStates
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool ActiveStateDisabledByUser
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GameState ActiveState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameStateManager(IGameStateManagerOwner owner, GameStateManagerType gameStateManagerType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GameState FindPredecessor(GameState gameState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RegisterListener(IGameStateManagerListener listener)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool UnregisterListener(IGameStateManagerListener listener)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetListenerOfType<T>()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterActiveStateDisableRequest(object requestingInstance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterActiveStateDisableRequest(object requestingInstance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSavedGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T LastOrDefault<T>() where T : GameState
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T CreateState<T>() where T : GameState, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T CreateState<T>(params object[] parameters) where T : GameState, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleCreateState(GameState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CleanRequests()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PushState(GameState gameState, int level = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PopState(int level = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CleanAndPushState(GameState gameState, int level = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CleanStates(int level = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPushState(GameState gameState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPopState(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCleanAndPushState(GameState gameState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCleanStates(int popLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoGameStateJobs()
	{
		throw null;
	}
}
