using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.GauntletUI;

public class GauntletUISubModule : MBSubModuleBase
{
	private bool _initialized;

	private bool _isMultiplayer;

	private GauntletQueryManager _queryManager;

	private SpriteCategory _fullBackgroundCategory;

	private SpriteCategory _fullscreensCategory;

	private bool _isTouchpadMouseActive;

	private bool _areResourcesDirty;

	private bool _loadingWindowCreated;

	public static GauntletUISubModule Instance
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
	public GauntletUISubModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshResources(bool initialLoad)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnControllerTypeChanged(ControllerTypes newType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnControllerDisconnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnManagedOptionChanged(ManagedOptionsType changedManagedOptionsType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnNewModuleLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleUnloaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBeforeInitialModuleScreenSetAsRoot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMultiplayerGameStart(Game game, object starterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameEnd(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("clear", "chatlog")]
	public static string ClearChatLog(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("can_focus_while_in_mission", "chatlog")]
	public static string SetCanFocusWhileInMission(List<string> strings)
	{
		throw null;
	}
}
