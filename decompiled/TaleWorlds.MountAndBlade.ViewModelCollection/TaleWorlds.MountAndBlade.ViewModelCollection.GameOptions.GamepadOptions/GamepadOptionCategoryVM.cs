using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Options;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions.GamepadOptions;

public class GamepadOptionCategoryVM : GroupedOptionCategoryVM
{
	private enum GamepadType
	{
		Xbox,
		Playstation4,
		Playstation5
	}

	[CompilerGenerated]
	private sealed class _003CGetActionKeys_003Ed__8 : IEnumerable<GamepadOptionKeyItemVM>, IEnumerable, IEnumerator<GamepadOptionKeyItemVM>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private GamepadOptionKeyItemVM _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		GamepadOptionKeyItemVM IEnumerator<GamepadOptionKeyItemVM>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetActionKeys_003Ed__8(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<GamepadOptionKeyItemVM> IEnumerable<GamepadOptionKeyItemVM>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetMapKeys_003Ed__9 : IEnumerable<GamepadOptionKeyItemVM>, IEnumerable, IEnumerator<GamepadOptionKeyItemVM>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private GamepadOptionKeyItemVM _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		GamepadOptionKeyItemVM IEnumerator<GamepadOptionKeyItemVM>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetMapKeys_003Ed__9(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<GamepadOptionKeyItemVM> IEnumerable<GamepadOptionKeyItemVM>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	private SelectorVM<SelectorItemVM> _categories;

	private int _currentGamepadType;

	private MBBindingList<GamepadOptionKeyItemVM> _leftAnalogKeys;

	private MBBindingList<GamepadOptionKeyItemVM> _rightAnalogKeys;

	private MBBindingList<GamepadOptionKeyItemVM> _dpadKeys;

	private MBBindingList<GamepadOptionKeyItemVM> _rightTriggerAndBumperKeys;

	private MBBindingList<GamepadOptionKeyItemVM> _leftTriggerAndBumperKeys;

	private MBBindingList<GamepadOptionKeyItemVM> _otherKeys;

	private MBBindingList<GamepadOptionKeyItemVM> _faceKeys;

	private MBBindingList<SelectorVM<SelectorItemVM>> _actions;

	[DataSourceProperty]
	public int CurrentGamepadType
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
	public MBBindingList<GamepadOptionKeyItemVM> OtherKeys
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
	public MBBindingList<GamepadOptionKeyItemVM> DpadKeys
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
	public MBBindingList<GamepadOptionKeyItemVM> LeftTriggerAndBumperKeys
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
	public MBBindingList<GamepadOptionKeyItemVM> RightTriggerAndBumperKeys
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
	public MBBindingList<GamepadOptionKeyItemVM> RightAnalogKeys
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
	public MBBindingList<GamepadOptionKeyItemVM> LeftAnalogKeys
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
	public MBBindingList<GamepadOptionKeyItemVM> FaceKeys
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
	public MBBindingList<SelectorVM<SelectorItemVM>> Actions
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
	public GamepadOptionCategoryVM(OptionsVM options, TextObject name, OptionCategory category, bool isEnabled, bool isResetSupported = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCategoryChange(SelectorVM<SelectorItemVM> obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCurrentGamepadType(GamepadType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGamepadActiveStateChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetActionKeys_003Ed__8))]
	private static IEnumerable<GamepadOptionKeyItemVM> GetActionKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetMapKeys_003Ed__9))]
	private static IEnumerable<GamepadOptionKeyItemVM> GetMapKeys()
	{
		throw null;
	}
}
