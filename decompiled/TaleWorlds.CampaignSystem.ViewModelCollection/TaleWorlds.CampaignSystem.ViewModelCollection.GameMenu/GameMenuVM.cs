using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Tutorial;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu;

public class GameMenuVM : ViewModel
{
	private class GameMenuItemPool<TItem> where TItem : class, new()
	{
		private readonly List<TItem> _pool;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GameMenuItemPool(int initialCapacity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TItem Get()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Release(TItem item)
		{
			throw null;
		}
	}

	private class GameMenuItemComparer : IComparer<GameMenuItemVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(GameMenuItemVM x, GameMenuItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GameMenuItemComparer()
		{
			throw null;
		}
	}

	private bool _isIdle;

	private bool _plunderEventRegistered;

	private GameMenuManager _gameMenuManager;

	private Dictionary<GameMenuOption.LeaveType, GameKey> _shortcutKeys;

	private Dictionary<string, string> _menuTextAttributeStrings;

	private Dictionary<string, object> _menuTextAttributes;

	private TextObject _menuText;

	private GameMenuItemComparer _cachedItemComparer;

	private IViewDataTracker _viewDataTracker;

	private GameMenuItemPool<GameMenuItemVM> _gameMenuItemPool;

	private GameMenuItemPool<GameMenuItemProgressVM> _progressItemPool;

	private List<GameMenuItemVM.GameMenuItemCreationData> _newOptionsCache;

	private MBBindingList<GameMenuItemVM> _itemList;

	private MBBindingList<GameMenuItemProgressVM> _progressItemList;

	private string _titleText;

	private string _contextText;

	private string _background;

	private string _backgroundCopy;

	private string _menuId;

	private bool _isNight;

	private bool _isInSiegeMode;

	private bool _isEncounterMenu;

	private MBBindingList<GameMenuPlunderItemVM> _plunderItems;

	private string _latestTutorialElementID;

	private bool _isTavernButtonHighlightApplied;

	private bool _isSellPrisonerButtonHighlightApplied;

	private bool _isShopButtonHighlightApplied;

	private bool _isRecruitButtonHighlightApplied;

	private bool _isHostileActionButtonHighlightApplied;

	private bool _isTownBesiegeButtonHighlightApplied;

	private bool _isEnterTutorialVillageButtonHighlightApplied;

	private bool _requireContextTextUpdate;

	public MenuContext MenuContext
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

	[DataSourceProperty]
	public bool IsNight
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
	public bool IsInSiegeMode
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
	public bool IsEncounterMenu
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
	public string TitleText
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
	public string ContextText
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
	public MBBindingList<GameMenuItemVM> ItemList
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
	public MBBindingList<GameMenuItemProgressVM> ProgressItemList
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
	public string Background
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
	public string BackgroundCopy
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
	public string MenuId
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
	public MBBindingList<GameMenuPlunderItemVM> PlunderItems
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
	public GameMenuVM(MenuContext menuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIdleMode(bool isIdle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Refresh(bool forceUpdateItems)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshPlunderStatus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFrameTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMenuTextChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateMenuContext(MenuContext newMenuContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddHotKey(GameMenuOption.LeaveType leaveType, GameKey gameKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemsPlundered(MobileParty mobileParty, ItemRoster newItems)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPlunderedItem(ItemRosterElement item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteLink(string link)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTutorialNotificationElementIDChange(TutorialNotificationElementChangeEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SetGameMenuButtonHighlightState(string buttonID, bool state)
	{
		throw null;
	}
}
