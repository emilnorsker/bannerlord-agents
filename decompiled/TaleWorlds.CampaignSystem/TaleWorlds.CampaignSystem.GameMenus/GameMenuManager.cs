using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameMenus;

public class GameMenuManager
{
	private Dictionary<string, GameMenu> _gameMenus;

	public int PreviouslySelectedGameMenuItem;

	public Location NextLocation;

	public Location PreviousLocation;

	public List<Location> MenuLocations;

	public object PreviouslySelectedGameMenuObject;

	public string NextGameMenuId
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

	public GameMenu NextMenu
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenuManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNextMenu(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExitToLast()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal object GetSelectedRepeatableObject(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal object ObjectGetCurrentRepeatableObject(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentRepeatableIndex(MenuContext menuContext, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetMenuOptionConditionsHold(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshMenuOptions(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshMenuOptionConditions(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetMenuOptionIdString(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool GetMenuOptionIsLeave(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RunConsequencesOfMenuOption(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetRepeatObjectList(MenuContext menuContext, IEnumerable<object> list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetVirtualMenuOptionTooltip(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenu.MenuOverlayType GetMenuOverlayType(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetVirtualMenuOptionText(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenuOption GetVirtualGameMenuOption(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetVirtualMenuOptionText2(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetVirtualMenuProgress(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenu.MenuAndOptionType GetVirtualMenuAndOptionType(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetVirtualMenuIsWaitActive(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetVirtualMenuTargetWaitHours(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetVirtualMenuOptionIsEnabled(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetVirtualMenuOptionAmount(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetVirtualMenuOptionIsLeave(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenuOption GetLeaveMenuOption(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RunConsequenceOfVirtualMenuOption(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetVirtualMenuOptionConditionsHold(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFrameTick(MenuContext menuContext, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetMenuText(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetMenuOptionText(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetMenuOptionText2(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetMenuOptionTooltip(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddGameMenu(GameMenu gameMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveRelatedGameMenus(object relatedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveRelatedGameMenuOptions(object relatedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnregisterNonReadyObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenu GetGameMenu(string menuId)
	{
		throw null;
	}
}
