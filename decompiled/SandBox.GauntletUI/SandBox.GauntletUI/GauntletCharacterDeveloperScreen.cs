using System.Runtime.CompilerServices;
using SandBox.View;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI;

[GameStateScreen(typeof(CharacterDeveloperState))]
public class GauntletCharacterDeveloperScreen : ScreenBase, IGameStateListener, IChangeableScreen, ICharacterDeveloperStateHandler
{
	private CharacterDeveloperVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private SpriteCategory _characterdeveloper;

	private readonly CharacterDeveloperState _characterDeveloperState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletCharacterDeveloperScreen(CharacterDeveloperState clanState)
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
	private void CloseCharacterDeveloperScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteConfirm()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSwitchToPreviousTab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSwitchToNextTab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IChangeableScreen.AnyUnsavedChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IChangeableScreen.CanChangesBeApplied()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IChangeableScreen.ApplyChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IChangeableScreen.ResetChanges()
	{
		throw null;
	}
}
