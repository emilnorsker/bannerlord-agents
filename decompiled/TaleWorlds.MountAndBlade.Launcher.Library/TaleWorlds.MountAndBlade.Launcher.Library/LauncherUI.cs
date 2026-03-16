using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.GauntletUI.PrefabSystem;
using TaleWorlds.MountAndBlade.Launcher.Library.UserDatas;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.Launcher.Library;

public class LauncherUI
{
	private Material _material;

	private TwoDimensionContext _twoDimensionContext;

	private UIContext _context;

	private IGauntletMovie _movie;

	private LauncherVM _viewModel;

	private SpriteData _spriteData;

	private WidgetFactory _widgetFactory;

	private UserDataManager _userDataManager;

	private readonly Action _onClose;

	private readonly Action _onMinimize;

	private Stopwatch _stopwatch;

	public bool HasUnofficialModulesSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string AdditionalArgs
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static event Action<string> OnAddHintInformation
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

	public static event Action OnHideHintInformation
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
	public LauncherUI(UserDataManager userDataManager, UIContext context, Action onClose, Action onMinimize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetLastScreenOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsHitThisFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsBlockedOnPosition(Vector2 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsAvailableForGamepadNavigation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckMouseOverWindowDragArea()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HitTest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddHintInformation(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void HideHintInformation()
	{
		throw null;
	}
}
