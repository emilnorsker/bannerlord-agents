using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Menu.TownManagement;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Clan;

public class ClanPartyRoleSelectionPopupWidget : AutoClosePopupWidget
{
	private List<Widget> _toggleWidgets;

	private Widget _activeToggleWidget;

	[Editor(false)]
	public Widget ActiveToggleWidget
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
	public ClanPartyRoleSelectionPopupWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddToggleWidget(Widget widget)
	{
		throw null;
	}
}
