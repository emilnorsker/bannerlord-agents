using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.CustomBattle;

[GameStateScreen(typeof(CustomBattleState))]
public class CustomBattleScreen : ScreenBase, IGameStateListener
{
	private CustomBattleState _customBattleState;

	private GauntletLayer _gauntletLayer;

	private GauntletMovieIdentifier _gauntletMovie;

	private CustomBattleVM _dataSource;

	private bool _isMovieLoaded;

	private int _isFirstFrameCounter;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomBattleScreen(CustomBattleState customBattleState)
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
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void UpdateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadMovie()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnloadMovie()
	{
		throw null;
	}
}
