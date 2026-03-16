using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Multiplayer.Admin;

internal class AdminPanelOptionGroup : IAdminPanelOptionGroup, IAdminPanelTickable
{
	private readonly bool _requiresRestart;

	private readonly string _uniqueId;

	private readonly TextObject _nameTextObj;

	private readonly MBList<IAdminPanelOption> _options;

	private readonly MBList<IAdminPanelAction> _actions;

	private readonly MBList<IAdminPanelTickable> _tickableOptions;

	string IAdminPanelOptionGroup.UniqueId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	TextObject IAdminPanelOptionGroup.Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	MBReadOnlyList<IAdminPanelOption> IAdminPanelOptionGroup.Options
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	MBReadOnlyList<IAdminPanelAction> IAdminPanelOptionGroup.Actions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IAdminPanelOptionGroup.RequiresRestart
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelOptionGroup(string uniqueId, TextObject name, bool requiresRestart = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddOption(IAdminPanelOption option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAction(IAdminPanelAction action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAdminPanelTickable.OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IAdminPanelOptionGroup.OnFinalize()
	{
		throw null;
	}
}
