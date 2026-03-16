using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameMenus;

public class GameMenuCallbackManager
{
	private Dictionary<string, GameMenuInitializationHandlerDelegate> _gameMenuInitializationHandlers;

	private Dictionary<string, Dictionary<string, GameMenuEventHandlerDelegate>> _eventHandlers;

	public static GameMenuCallbackManager Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenuCallbackManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillInitializationHandlers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly[] GetAssemblies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGameLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillInitializationHandlerWith(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillEventHandlers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillEventHandlersWith(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeState(string menuId, MenuContext state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnConsequence(string menuId, GameMenuOption gameMenuOption, MenuContext state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetMenuOptionTooltip(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetVirtualMenuOptionTooltip(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetVirtualMenuOptionText(MenuContext menuContext, int virtualMenuItemIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetMenuOptionText(MenuContext menuContext, int menuItemNumber)
	{
		throw null;
	}
}
