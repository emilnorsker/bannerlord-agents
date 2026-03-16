using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.Options;

namespace TaleWorlds.MountAndBlade.Options;

public class ActionOptionData : IOptionData
{
	private TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType _managedType;

	private NativeOptions.NativeOptionsType _nativeType;

	private string _actionOptionTypeId;

	public Action OnAction
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
	public ActionOptionData(TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType managedType, Action onAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActionOptionData(NativeOptions.NativeOptionsType nativeType, Action onAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActionOptionData(string optionTypeId, Action onAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Commit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetDefaultValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetOptionType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetValue(bool forceRefresh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetValue(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (string, bool) GetIsDisabledAndReasonID()
	{
		throw null;
	}
}
