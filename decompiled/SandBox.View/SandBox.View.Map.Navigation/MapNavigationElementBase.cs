using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace SandBox.View.Map.Navigation;

public abstract class MapNavigationElementBase : INavigationElement
{
	protected readonly MapNavigationHandler _handler;

	protected readonly IViewDataTracker _viewDataTracker;

	public NavigationPermissionItem Permission
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TextObject Tooltip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TextObject AlertTooltip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract bool IsActive { get; }

	public abstract bool IsLockingNavigation { get; }

	public abstract bool HasAlert { get; }

	public abstract string StringId { get; }

	protected Game _game
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract void OpenView();

	public abstract void OpenView(params object[] parameters);

	public abstract void GoToLink();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapNavigationElementBase(MapNavigationHandler handler)
	{
		throw null;
	}

	protected abstract NavigationPermissionItem GetPermission();

	protected abstract TextObject GetTooltip();

	protected abstract TextObject GetAlertTooltip();
}
