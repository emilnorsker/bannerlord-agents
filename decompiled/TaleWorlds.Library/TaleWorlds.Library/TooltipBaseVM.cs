using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public abstract class TooltipBaseVM : ViewModel
{
	protected readonly Type _invokedType;

	protected object[] _invokedArgs;

	protected bool _isPeriodicRefreshEnabled;

	protected float _periodicRefreshDelay;

	private float _periodicRefreshTimer;

	private bool _isActive;

	private bool _isExtended;

	[DataSourceProperty]
	public bool IsActive
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
	public bool IsExtended
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
	public TooltipBaseVM(Type invokedType, object[] invokedArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnFinalizeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void InvokeRefreshData<T>(T tooltip) where T : TooltipBaseVM
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnPeriodicRefresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnIsExtendedChanged()
	{
		throw null;
	}
}
