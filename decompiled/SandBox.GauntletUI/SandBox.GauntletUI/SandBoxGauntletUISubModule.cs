using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox.GauntletUI;

public class SandBoxGauntletUISubModule : MBSubModuleBase
{
	private class ConversationGameStateManagerListener : IGameStateManagerListener
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		void IGameStateManagerListener.OnCleanStates()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IGameStateManagerListener.OnCreateState(GameState gameState)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IGameStateManagerListener.OnPopState(GameState gameState)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IGameStateManagerListener.OnPushState(GameState gameState, bool isTopGameState)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IGameStateManagerListener.OnSavedGameLoadFinished()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateCampaignMission()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ConversationGameStateManagerListener()
		{
			throw null;
		}
	}

	private bool _gameStarted;

	private bool _initialized;

	private GameStateManager _registeredGameStateManager;

	private bool _initializedConversationHandler;

	private ConversationGameStateManagerListener _conversationListener;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxGauntletUISubModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCampaignStart(Game game, object starterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameEnd(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void BeginGameStart(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnApplicationTick(float dt)
	{
		throw null;
	}
}
