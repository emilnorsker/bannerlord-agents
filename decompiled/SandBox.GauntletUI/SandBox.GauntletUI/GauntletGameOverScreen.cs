using System.Runtime.CompilerServices;
using SandBox.ViewModelCollection.GameOver;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI;

[GameStateScreen(typeof(GameOverState))]
public class GauntletGameOverScreen : ScreenBase, IGameOverStateHandler, IGameStateListener
{
	private SpriteCategory _gameOverCategory;

	private GameOverVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private readonly GameOverState _gameOverState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletGameOverScreen(GameOverState gameOverState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CloseGameOverScreen()
	{
		throw null;
	}
}
