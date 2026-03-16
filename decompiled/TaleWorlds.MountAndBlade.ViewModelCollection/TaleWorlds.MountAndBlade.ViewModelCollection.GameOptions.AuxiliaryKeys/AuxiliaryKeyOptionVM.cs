using System;
using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions.AuxiliaryKeys;

public class AuxiliaryKeyOptionVM : KeyOptionVM
{
	private readonly Action<AuxiliaryKeyOptionVM, InputKey> _onKeySet;

	public HotKey CurrentHotKey
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
	public AuxiliaryKeyOptionVM(HotKey hotKey, Action<KeyOptionVM> onKeybindRequest, Action<AuxiliaryKeyOptionVM, InputKey> onKeySet)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteKeybindRequest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Set(InputKey newKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override bool IsChanged()
	{
		throw null;
	}
}
