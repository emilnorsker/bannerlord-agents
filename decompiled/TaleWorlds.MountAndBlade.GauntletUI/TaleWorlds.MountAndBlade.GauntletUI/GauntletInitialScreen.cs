using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;
using TaleWorlds.MountAndBlade.ViewModelCollection.InitialMenu;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.GauntletUI;

[GameStateScreen(typeof(InitialState))]
public class GauntletInitialScreen : MBInitialScreenBase, IChatLogHandlerScreen
{
	private GauntletLayer _gauntletLayer;

	private GauntletLayer _gauntletBrightnessLayer;

	private GauntletLayer _gauntletExposureLayer;

	private InitialMenuVM _dataSource;

	private BrightnessOptionVM _brightnessOptionDataSource;

	private ExposureOptionVM _exposureOptionDataSource;

	private GauntletMovieIdentifier _brightnessOptionMovie;

	private GauntletMovieIdentifier _exposureOptionMovie;

	private SpriteCategory _upsellCategory;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletInitialScreen(InitialState initialState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGainNavigationAfterFrames(int frameCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameContentUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCloseBrightness(bool isConfirm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenExposureControl()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCloseExposureControl(bool isConfirm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryUpdateChatLogLayerParameters(ref bool isTeamChatAvailable, ref bool inputEnabled, ref bool isToggleChatHintAvailable, ref bool isMouseVisible, ref InputContext inputContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshUpsellSpriteCategory()
	{
		throw null;
	}
}
