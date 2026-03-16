using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.GauntletUI;

public class KeybindingPopup
{
	private bool _isActiveFirstFrame;

	private GauntletLayer _gauntletLayer;

	private GauntletMovieIdentifier _movie;

	private ScreenBase _targetScreen;

	private Action<Key> _onDone;

	private KeybindingPopupVM _dataSource;

	public bool IsActive
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
	public KeybindingPopup(Action<Key> onDone, ScreenBase targetScreen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnToggle(bool isActive)
	{
		throw null;
	}
}
