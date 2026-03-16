using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CraftingSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign.Order;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;

public class WeaponDesignVM : ViewModel
{
	[Flags]
	public enum CraftingPieceTierFilter
	{
		None = 0,
		Tier1 = 1,
		Tier2 = 2,
		Tier3 = 4,
		Tier4 = 8,
		Tier5 = 0x10,
		All = 0x1F
	}

	public class PieceTierComparer : IComparer<CraftingPieceVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(CraftingPieceVM x, CraftingPieceVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PieceTierComparer()
		{
			throw null;
		}
	}

	public class TemplateComparer : IComparer<CraftingTemplate>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(CraftingTemplate x, CraftingTemplate y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TemplateComparer()
		{
			throw null;
		}
	}

	public class WeaponPropertyComparer : IComparer<CraftingListPropertyItem>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(CraftingListPropertyItem x, CraftingListPropertyItem y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WeaponPropertyComparer()
		{
			throw null;
		}
	}

	private CraftingPieceTierFilter _currentTierFilter;

	public const int MAX_SKILL_LEVEL = 300;

	public ItemObject CraftedItemObject;

	private int _selectedWeaponClassIndex;

	private readonly List<CraftingPiece> _newlyUnlockedPieces;

	private readonly List<CraftingTemplate> _primaryUsages;

	private readonly PieceTierComparer _pieceTierComparer;

	private readonly TemplateComparer _templateComparer;

	private readonly ICraftingCampaignBehavior _craftingBehavior;

	private readonly Action _onRefresh;

	private readonly Action _onWeaponCrafted;

	private readonly Func<CraftingAvailableHeroItemVM> _getCurrentCraftingHero;

	private readonly Action<CraftingOrder> _refreshHeroAvailabilities;

	private Func<WeaponComponentData, ItemObject.ItemUsageSetFlags> _getItemUsageSetFlags;

	private Crafting _crafting;

	private bool _updatePiece;

	private Dictionary<CraftingPiece.PieceTypes, CraftingPieceListVM> _pieceListsDictionary;

	private Dictionary<CraftingPiece, CraftingPieceVM> _pieceVMs;

	private TextObject _difficultyTextobj;

	private TextObject _orderDifficultyTextObj;

	private bool _isAutoSelectingPieces;

	private bool _shouldRecordHistory;

	private MBBindingList<TierFilterTypeVM> _tierFilters;

	private string _currentCraftedWeaponTemplateId;

	private string _chooseOrderText;

	private string _chooseWeaponTypeText;

	private string _currentCraftedWeaponTypeText;

	private MBBindingList<CraftingPieceListVM> _pieceLists;

	private int _selectedPieceTypeIndex;

	private bool _showOnlyUnlockedPieces;

	private string _missingPropertyWarningText;

	private bool _isInFinalCraftingStage;

	private string _componentSizeLbl;

	private string _itemName;

	private string _difficultyText;

	private int _bladeSize;

	private int _pommelSize;

	private int _handleSize;

	private int _guardSize;

	private CraftingPieceVM _selectedBladePiece;

	private CraftingPieceVM _selectedGuardPiece;

	private CraftingPieceVM _selectedHandlePiece;

	private CraftingPieceVM _selectedPommelPiece;

	private CraftingPieceListVM _activePieceList;

	private CraftingPieceListVM _bladePieceList;

	private CraftingPieceListVM _guardPieceList;

	private CraftingPieceListVM _handlePieceList;

	private CraftingPieceListVM _pommelPieceList;

	private string _alternativeUsageText;

	private string _defaultUsageText;

	private bool _isScabbardVisible;

	private bool _currentWeaponHasScabbard;

	public SelectorVM<CraftingSecondaryUsageItemVM> _secondaryUsageSelector;

	private ItemCollectionElementViewModel _craftedItemVisual;

	private MBBindingList<CraftingListPropertyItem> _primaryPropertyList;

	private MBBindingList<WeaponDesignResultPropertyItemVM> _designResultPropertyList;

	private int _currentDifficulty;

	private int _currentOrderDifficulty;

	private int _maxDifficulty;

	private string _currentDifficultyText;

	private string _currentOrderDifficultyText;

	private string _currentCraftingSkillValueText;

	private bool _isCurrentHeroAtMaxCraftingSkill;

	private int _currentHeroCraftingSkill;

	private bool _isWeaponCivilian;

	private HintViewModel _scabbardHint;

	private HintViewModel _randomizeHint;

	private HintViewModel _undoHint;

	private HintViewModel _redoHint;

	private HintViewModel _showOnlyUnlockedPiecesHint;

	private BasicTooltipViewModel _orderDisabledReasonHint;

	private CraftingOrderItemVM _activeCraftingOrder;

	private CraftingOrderPopupVM _craftingOrderPopup;

	private WeaponClassSelectionPopupVM _weaponClassSelectionPopup;

	private string _freeModeButtonText;

	private bool _isOrderButtonActive;

	private bool _isInOrderMode;

	private WeaponDesignResultPopupVM _craftingResultPopup;

	private MBBindingList<ItemFlagVM> _weaponFlagIconsList;

	private CraftingHistoryVM _craftingHistory;

	private TextObject _currentCraftingSkillText;

	[DataSourceProperty]
	public MBBindingList<TierFilterTypeVM> TierFilters
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
	public string CurrentCraftedWeaponTemplateId
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
	public string ChooseOrderText
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
	public string ChooseWeaponTypeText
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
	public string CurrentCraftedWeaponTypeText
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
	public MBBindingList<CraftingPieceListVM> PieceLists
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
	public int SelectedPieceTypeIndex
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
	public bool ShowOnlyUnlockedPieces
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
	public string MissingPropertyWarningText
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
	public WeaponDesignResultPopupVM CraftingResultPopup
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
	public bool IsOrderButtonActive
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
	public bool IsInOrderMode
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
	public bool IsInFreeMode
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
	public string FreeModeButtonText
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
	public CraftingOrderItemVM ActiveCraftingOrder
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
	public CraftingOrderPopupVM CraftingOrderPopup
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
	public WeaponClassSelectionPopupVM WeaponClassSelectionPopup
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
	public MBBindingList<CraftingListPropertyItem> PrimaryPropertyList
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
	public MBBindingList<WeaponDesignResultPropertyItemVM> DesignResultPropertyList
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
	public SelectorVM<CraftingSecondaryUsageItemVM> SecondaryUsageSelector
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
	public ItemCollectionElementViewModel CraftedItemVisual
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
	public bool IsInFinalCraftingStage
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
	public string ItemName
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
	public bool IsScabbardVisible
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
	public bool CurrentWeaponHasScabbard
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
	public int CurrentDifficulty
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
	public int CurrentOrderDifficulty
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
	public int MaxDifficulty
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
	public bool IsCurrentHeroAtMaxCraftingSkill
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
	public int CurrentHeroCraftingSkill
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
	public string CurrentDifficultyText
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
	public string CurrentOrderDifficultyText
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
	public string CurrentCraftingSkillValueText
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
	public string DifficultyText
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
	public string DefaultUsageText
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
	public string AlternativeUsageText
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
	public BasicTooltipViewModel OrderDisabledReasonHint
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
	public HintViewModel ShowOnlyUnlockedPiecesHint
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
	public CraftingPieceListVM ActivePieceList
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
	public CraftingPieceListVM BladePieceList
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
	public CraftingPieceListVM GuardPieceList
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
	public CraftingPieceListVM HandlePieceList
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
	public CraftingPieceListVM PommelPieceList
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
	public CraftingPieceVM SelectedBladePiece
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
	public CraftingPieceVM SelectedGuardPiece
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
	public CraftingPieceVM SelectedHandlePiece
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
	public CraftingPieceVM SelectedPommelPiece
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
	public int ActivePieceSize
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
	public int BladeSize
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
	public int GuardSize
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
	public int HandleSize
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
	public int PommelSize
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
	public string ComponentSizeLbl
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
	public bool IsWeaponCivilian
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
	public HintViewModel ScabbardHint
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
	public HintViewModel RandomizeHint
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
	public HintViewModel UndoHint
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
	public HintViewModel RedoHint
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
	public MBBindingList<ItemFlagVM> WeaponFlagIconsList
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
	public CraftingHistoryVM CraftingHistory
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
	public WeaponDesignVM(Crafting crafting, ICraftingCampaignBehavior craftingBehavior, Action onRefresh, Action onWeaponCrafted, Func<CraftingAvailableHeroItemVM> getCurrentCraftingHero, Action<CraftingOrder> refreshHeroAvailabilities, Func<WeaponComponentData, ItemObject.ItemUsageSetFlags> getItemUsageSetFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnCraftingLogicRefreshed(Crafting newCraftingLogic)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FilterPieces(CraftingPieceTierFilter filter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewPieceUnlocked(CraftingPiece piece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetUnlockedPartsCount(CraftingTemplate template)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WeaponClassVM GetCurrentWeaponClass()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectItemFromHistory(WeaponDesignSelectorVM selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPieceNewlyUnlocked(CraftingPiece piece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnsetPieceNewlyUnlocked(CraftingPieceVM pieceVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectPieceTierFilter(CraftingPieceTierFilter filter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectPieceType(CraftingPiece.PieceTypes pieceType, bool fromClick = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectDefaultPiecesForCurrentTemplate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeDefaultFromLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshPieceFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddClassFlagsToPiece(CraftingPieceVM piece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSecondaryUsageIndex(SelectorVM<CraftingSecondaryUsageItemVM> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBBindingList<WeaponDesignResultPropertyItemVM> GetResultPropertyList(CraftingSecondaryUsageItemVM usageItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectPrimaryWeaponClass(CraftingTemplate template)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshWeaponDesignMode(CraftingOrderItemVM orderToSelect, int classIndex = -1, bool doNotAutoSelectPieces = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCraftingOrderSelected(CraftingOrderItemVM selectedOrder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOpenOrderPopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteCloseOrderPopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOpenOrdersTab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOpenWeaponClassSelectionPopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOpenFreeBuildTab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateCraftingResultPopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSecondaryUsageChangedFromPopup(CraftingSecondaryUsageItemVM usage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteToggleShowOnlyUnlockedPieces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteUndo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRedo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnCraftingHeroChanged(CraftingAvailableHeroItemVM newHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeModeIfHeroIsUnavailable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteBeginHeroHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteEndHeroHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRandomize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteChangeScabbardVisibility()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectWeapon(ItemObject itemObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanCompleteOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteFinalizeCrafting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoesCurrentItemHaveSecondaryUsage(int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrySetSecondaryUsageIndex(int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshAlternativeUsageList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IEnumerable<CraftingStatData> GetOrderStatDatas(CraftingOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshWeaponFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSetItemPieceManually(CraftingPieceVM piece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSetItemPiece(CraftingPieceVM piece, int scalePercentage = 0, bool shouldUpdateWholeWeapon = true, bool forceUpdatePiece = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshDifficulty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetCurrentDifficultyText(int skillValue, int difficultyValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetCurrentOrderDifficultyText(int orderDifficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshCurrentHeroSkillLevel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HaveUnlockedAllSelectedPieces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddHistoryKey()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchToPiece(WeaponDesignElement usedPiece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetDesignManually(CraftingTemplate craftingTemplate, (CraftingPiece, int)[] pieces, bool forceChangeTemplate = false)
	{
		throw null;
	}
}
