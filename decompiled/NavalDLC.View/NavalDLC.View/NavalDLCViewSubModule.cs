using System.Runtime.CompilerServices;
using NavalDLC.View.Overlay;
using NavalDLC.View.VisualOrders;
using TaleWorlds.Core;
using TaleWorlds.Engine.Options;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ScreenSystem;

namespace NavalDLC.View;

public class NavalDLCViewSubModule : MBSubModuleBase
{
	private NavalShipVisualOrderProvider _shipVisualOrderProvider;

	private NavalTroopVisualOrderProvider _troopVisualOrderProvider;

	private NavalGameMenuOverlayProvider _gameMenuOverlayProvider;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCViewSubModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnNewGameCreated(Game game, object initializerObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterGameLoaded(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameInitializationFinished(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameEnd(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleUnloaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSubModuleDeactivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSubModuleActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterTooltipTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnregisterTooltipTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterHotKeyContexts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnControllerTypeChanged(ControllerTypes newType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNativeOptionChanged(NativeOptionsType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnScreenPushed(ScreenBase pushedScreen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterGameInitializationFinished(Game game, object starterObject)
	{
		throw null;
	}
}
