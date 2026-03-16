using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions.AuxiliaryKeys;

public class AuxiliaryKeyGroupVM : ViewModel
{
	private readonly Action<KeyOptionVM> _onKeybindRequest;

	private readonly string _categoryId;

	private IEnumerable<HotKey> _keys;

	private string _description;

	private MBBindingList<AuxiliaryKeyOptionVM> _hotKeys;

	[DataSourceProperty]
	public MBBindingList<AuxiliaryKeyOptionVM> HotKeys
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
	public string Description
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
	public AuxiliaryKeyGroupVM(string categoryId, IEnumerable<HotKey> keys, Action<KeyOptionVM> onKeybindRequest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateHotKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetHotKey(AuxiliaryKeyOptionVM option, InputKey newKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGamepadActiveStateChanged()
	{
		throw null;
	}
}
