using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Multiplayer.Admin;

internal class AdminPanelAction : IAdminPanelActionInternal, IAdminPanelAction
{
	private readonly string _uniqueId;

	private TextObject _nameTextObj;

	private TextObject _descriptionTextObj;

	private Action _onActionExecuted;

	public string UniqueId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string Description
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelAction(string uniqueId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAdminPanelAction.OnActionExecuted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool GetIsAvailable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool GetIsDisabled(out string reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelAction BuildName(TextObject name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelAction BuildDescription(TextObject description)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelAction BuildOnActionExecutedCallback(Action onActionExecuted)
	{
		throw null;
	}
}
