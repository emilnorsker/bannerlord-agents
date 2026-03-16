using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public abstract class GameManagerBase
{
	private EntitySystem<GameManagerComponent> _entitySystem;

	private GameManagerLoadingSteps _stepNo;

	private Game _game;

	private bool _initialized;

	public static GameManagerBase Current
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

	public Game Game
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal set
		{
			throw null;
		}
	}

	public IEnumerable<GameManagerComponent> Components
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract float ApplicationTime { get; }

	public abstract bool CheatMode { get; }

	public abstract bool IsDevelopmentMode { get; }

	public abstract bool IsEditModeOn { get; }

	public abstract UnitSpawnPrioritizations UnitSpawnPrioritization { get; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameManagerBase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameManagerComponent AddComponent(Type componentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T AddComponent<T>() where T : GameManagerComponent, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameManagerComponent GetComponent(Type componentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetComponent<T>() where T : GameManagerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<T> GetComponents<T>() where T : GameManagerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveComponent<T>() where T : GameManagerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveComponent(GameManagerComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGameNetworkBegin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGameNetworkEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerConnect(VirtualPlayer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerDisconnect(VirtualPlayer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnGameEnd(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void DoLoadingForGameManager(GameManagerLoadingSteps gameManagerLoadingStep, out GameManagerLoadingSteps nextStep)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoLoadingForGameManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void InitializeGameStarter(Game game, IGameStarter starterObject)
	{
		throw null;
	}

	public abstract void OnGameStart(Game game, IGameStarter gameStarter);

	public abstract void BeginGameStart(Game game);

	public abstract void OnNewCampaignStart(Game game, object starterObject);

	public abstract void OnAfterCampaignStart(Game game);

	public abstract void RegisterSubModuleObjects(bool isSavedCampaign);

	public abstract void AfterRegisterSubModuleObjects(bool isSavedCampaign);

	public abstract void OnGameInitializationFinished(Game game);

	public abstract void OnNewGameCreated(Game game, object initializerObject);

	public abstract void OnGameLoaded(Game game, object initializerObject);

	public abstract void OnAfterGameLoaded(Game game);

	public abstract void OnAfterGameInitializationFinished(Game game, object initializerObject);

	public abstract void RegisterSubModuleTypes();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void InitializeSubModuleGameObjects(Game game)
	{
		throw null;
	}
}
