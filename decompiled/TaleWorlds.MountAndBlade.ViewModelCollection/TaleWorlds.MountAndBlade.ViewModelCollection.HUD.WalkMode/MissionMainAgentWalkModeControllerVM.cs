using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.HUD.WalkMode;

public class MissionMainAgentWalkModeControllerVM : ViewModel
{
	public delegate bool GetIsWalkModeActivatedDelegate();

	public delegate void SetIsWalkModeActivatedDelegate(bool value);

	public delegate bool GetCanChangeWalkModeActivatedDelegate();

	private MBBindingList<WalkModeItemVM> _controlModes;

	private WalkModeItemVM _lastUsedItem;

	private bool _isEnabled;

	[DataSourceProperty]
	public MBBindingList<WalkModeItemVM> ControlModes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public WalkModeItemVM LastUsedItem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionMainAgentWalkModeControllerVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddWalkMode(string typeId, TextObject name, GetIsWalkModeActivatedDelegate getIsActive, SetIsWalkModeActivatedDelegate setIsActive, GetCanChangeWalkModeActivatedDelegate canChangeActive, HotKey hotKey, bool isHotkeyConsoleOnly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddWalkMode(string typeId, TextObject name, GetIsWalkModeActivatedDelegate getIsActive, SetIsWalkModeActivatedDelegate setIsActive, GetCanChangeWalkModeActivatedDelegate canChangeActive, GameKey hotKey, bool isHotkeyConsoleOnly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemToggled(WalkModeItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnabled(bool isEnabled)
	{
		throw null;
	}
}
