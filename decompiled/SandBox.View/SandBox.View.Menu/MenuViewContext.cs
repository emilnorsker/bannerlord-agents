using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Engine;
using TaleWorlds.ScreenSystem;

namespace SandBox.View.Menu;

public class MenuViewContext : IMenuContextHandler
{
	private MenuContext _menuContext;

	private MenuView _currentMenuBase;

	private MenuView _currentMenuBackground;

	private MenuView _menuCharacterDeveloper;

	private MenuView _menuOverlayBase;

	private MenuView _menuRecruitVolunteers;

	private MenuView _menuTournamentLeaderboard;

	private MenuView _menuTroopSelection;

	private MenuView _menuTownManagement;

	private SoundEvent _panelSound;

	private SoundEvent _ambientSound;

	private MenuOverlayType _currentOverlayType;

	private ScreenBase _screen;

	private bool _isActive;

	internal GameMenu CurGameMenu
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MenuContext MenuContext
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<MenuView> MenuViews
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
	public MenuViewContext(ScreenBase screen, MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateMenuContext(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddLayer(ScreenLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveLayer(ScreenLayer layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T FindLayer<T>() where T : ScreenLayer
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T FindLayer<T>(string name) where T : ScreenLayer
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnResume()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnHourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearMenuViews()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopAllSounds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayAmbientSound(string ambientSoundID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayPanelSound(string panelSoundID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnAmbientSoundIDSet(string ambientSoundID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnPanelSoundIDSet(string panelSoundID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnMenuCreate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnMenuActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapConversationActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapConversationDeactivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGameStateDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGameStateInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGameStateFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndInitializeOverlay()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseCharacterDeveloper()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MenuView AddMenuView<T>(params object[] parameters) where T : MenuView, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetMenuView<T>() where T : MenuView
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveMenuView(MenuView menuView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnBackgroundMeshNameSet(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnOpenTownManagement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseTownManagement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnOpenRecruitVolunteers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseRecruitVolunteers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnOpenTournamentLeaderboard()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseTournamentLeaderboard()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnOpenTroopSelection(TroopRoster fullRoster, TroopRoster initialSelections, Func<CharacterObject, bool> canChangeStatusOfTroop, Action<TroopRoster> onDone, int maxSelectableTroopCount, int minSelectableTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseTroopSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMenuContextHandler.OnMenuRefresh()
	{
		throw null;
	}
}
