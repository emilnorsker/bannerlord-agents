using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace TaleWorlds.ScreenSystem;

public static class ScreenManager
{
	public delegate void OnPushScreenEvent(ScreenBase pushedScreen);

	public delegate void OnPopScreenEvent(ScreenBase poppedScreen);

	public delegate void OnControllerDisconnectedEvent();

	public delegate bool OnPlatformTextRequestedDelegate(string initialText, string descriptionText, int maxLength, int keyboardTypeEnum);

	private static IScreenManagerEngineConnection _engineInterface;

	private static Vec2 _usableArea;

	private static ObservableCollection<ScreenBase> _screenList;

	private static ObservableCollection<GlobalLayer> _globalLayers;

	private static List<ScreenLayer> _sortedLayers;

	private static ScreenLayer[] _sortedActiveLayersCopyForUpdate;

	private static bool _isSortedActiveLayersDirty;

	private static bool _isScreenDebugInformationEnabled;

	private static List<InputKey> _lastMouseActiveKeys;

	public static bool DisableScreenManagerTicks;

	private static bool _activeMouseVisible;

	private static IReadOnlyList<int> _lastPressedKeys;

	private static bool _globalOrderDirty;

	private static ScreenLayer _mouseDownLayer;

	private static bool _isWindowFocused;

	private static bool _isRefreshActive;

	public static IScreenManagerEngineConnection EngineInterface
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static float Scale
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

	public static Vec2 UsableArea
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public static bool IsEnterButtonRDown
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsLateTickInProgress
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

	public static List<ScreenLayer> SortedLayers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ScreenBase TopScreen
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

	public static ScreenLayer FocusedLayer
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

	public static ScreenLayer FirstHitLayer
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

	public static bool IsWindowFocused
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static event OnPushScreenEvent OnPushScreen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event OnPopScreenEvent OnPopScreen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event OnControllerDisconnectedEvent OnControllerDisconnected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action FocusGained
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event OnPlatformTextRequestedDelegate PlatformTextRequested
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScreenManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnLayerActiveStateChanged(ScreenLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize(IScreenManagerEngineConnection engineInterface)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RefreshGlobalOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveGlobalLayer(GlobalLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddGlobalLayer(GlobalLayer layer, bool isFocusable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnConstrainStateChanged(bool isConstrained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ScreenTypeExistsAtList(ScreenBase screen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UpdateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetSuspendLayer(ScreenLayer layer, bool isSuspended)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void DeactivateAndFinalizeAllScreens()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LateTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool OnPlatformScreenKeyboardRequested(string initialText, string descriptionText, int maxLength, int keyboardTypeEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnOnscreenKeyboardDone(string inputText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnOnscreenKeyboardCanceled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnGameWindowFocusChange(bool focusGained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReplaceTopScreen(ScreenBase screen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ScreenLayer> GetPersistentInputRestrictions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetAndActivateRootScreen(ScreenBase screen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CleanAndPushScreen(ScreenBase screen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("cb_clear_siege_machine_selection", "ui")]
	public static string ClearSiegeMachineSelection(List<string> args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("cb_copy_battle_layout_to_clipboard", "ui")]
	public static string CopyCustomBattle(List<string> args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("cb_apply_battle_layout_from_string", "ui")]
	public static string ApplyCustomBattleLayout(List<string> args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PushScreen(ScreenBase screen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PopScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CleanScreens()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ScreenBase FindPredecessor(ScreenBase screen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Update(IReadOnlyList<int> lastKeysPressed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool? GetMouseInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<InputKey> GetActiveMouseKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EarlyUpdate(Vec2 usableArea)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void LateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void UpdateMouseVisibility()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsControllerActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMouseCursorHidden()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMouseCursorActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsLayerBlockedAtPosition(ScreenLayer layer, Vector2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SetMouseVisible(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetMouseVisibility()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TrySetFocus(ScreenLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TryLoseFocus(ScreenLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool FocusTest(ScreenLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnScaleChange(float newScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnControllerDisconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SetSortedLayersDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnScreenListChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnLayerAddedToTopLayer(ScreenLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnLayerRemovedFromTopLayer(ScreenLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnGlobalListChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_screen_debug_information_enabled", "ui")]
	public static string SetScreenDebugInformationEnabled(List<string> args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetScreenDebugInformationEnabled(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ShowScreenDebugInformation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnUsableAreaChanged(Vec2 newUsableArea)
	{
		throw null;
	}
}
