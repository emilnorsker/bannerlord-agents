using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.MountAndBlade.Diamond.Cosmetics;
using TaleWorlds.MountAndBlade.Diamond.Lobby.LocalData;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Armory.CosmeticCategory;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Armory.CosmeticItem;
using TaleWorlds.MountAndBlade.ViewModelCollection.Input;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Armory;

public class MPArmoryCosmeticsVM : ViewModel
{
	public enum ClothingCategory
	{
		Invalid = -1,
		ClothingCategoriesBegin = 0,
		All = 0,
		HeadArmor = 1,
		Cape = 2,
		BodyArmor = 3,
		HandArmor = 4,
		LegArmor = 5,
		ClothingCategoriesEnd = 6
	}

	[Flags]
	public enum TauntCategoryFlag
	{
		None = 0,
		UsableWithMount = 1,
		UsableWithOneHanded = 2,
		UsableWithTwoHanded = 4,
		UsableWithBow = 8,
		UsableWithCrossbow = 0x10,
		UsableWithShield = 0x20,
		All = 0x3F
	}

	public abstract class CosmeticItemComparer : IComparer<MPArmoryCosmeticItemBaseVM>
	{
		private bool _isAscending;

		protected int _sortMultiplier
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAscending)
		{
			throw null;
		}

		public abstract int Compare(MPArmoryCosmeticItemBaseVM x, MPArmoryCosmeticItemBaseVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected CosmeticItemComparer()
		{
			throw null;
		}
	}

	private class CosmeticItemNameComparer : CosmeticItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPArmoryCosmeticItemBaseVM x, MPArmoryCosmeticItemBaseVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CosmeticItemNameComparer()
		{
			throw null;
		}
	}

	private class CosmeticItemCostComparer : CosmeticItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPArmoryCosmeticItemBaseVM x, MPArmoryCosmeticItemBaseVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CosmeticItemCostComparer()
		{
			throw null;
		}
	}

	private class CosmeticItemRarityComparer : CosmeticItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPArmoryCosmeticItemBaseVM x, MPArmoryCosmeticItemBaseVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CosmeticItemRarityComparer()
		{
			throw null;
		}
	}

	private class CosmeticItemCategoryComparer : CosmeticItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPArmoryCosmeticItemBaseVM x, MPArmoryCosmeticItemBaseVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CosmeticItemCategoryComparer()
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnTick_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MPArmoryCosmeticsVM _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CUpdateUsedCosmeticsAux_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public MPArmoryCosmeticsVM _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private readonly Func<List<IReadOnlyPerkObject>> _getSelectedPerks;

	private List<MPArmoryCosmeticItemBaseVM> _allCosmetics;

	private List<string> _ownedCosmetics;

	private Dictionary<string, List<string>> _usedCosmetics;

	private Equipment _selectedClassDefaultEquipment;

	private CosmeticItemComparer _currentItemComparer;

	private List<CosmeticItemComparer> _itemComparers;

	private Dictionary<ClothingCategory, MPArmoryClothingCosmeticCategoryVM> _clothingCategoriesLookup;

	private Dictionary<TauntCategoryFlag, MPArmoryTauntCosmeticCategoryVM> _tauntCategoriesLookup;

	private Dictionary<string, MPArmoryCosmeticItemBaseVM> _cosmeticItemsLookup;

	private MPHeroClass _selectedClass;

	private string _selectedTroopID;

	private bool _isLocalCosmeticsDirty;

	private bool _isNetworkCosmeticsDirty;

	private bool _isSendingCosmeticData;

	private bool _isRetrievingCosmeticData;

	private CosmeticType _currentCosmeticType;

	private ClothingCategory _currentClothingCategory;

	private TauntCategoryFlag _currentTauntCategory;

	private InputKeyItemVM _actionInputKey;

	private InputKeyItemVM _previewInputKey;

	private int _loot;

	private bool _isLoading;

	private bool _hasCosmeticInfoReceived;

	private bool _isManagingTaunts;

	private bool _isTauntAssignmentActive;

	private string _cosmeticInfoErrorText;

	private HintViewModel _allCategoriesHint;

	private HintViewModel _bodyCategoryHint;

	private HintViewModel _headCategoryHint;

	private HintViewModel _shoulderCategoryHint;

	private HintViewModel _handCategoryHint;

	private HintViewModel _legCategoryHint;

	private HintViewModel _resetPreviewHint;

	private MPArmoryCosmeticCategoryBaseVM _activeCategory;

	private MPArmoryCosmeticTauntSlotVM _selectedTauntSlot;

	private MPArmoryCosmeticTauntItemVM _selectedTauntItem;

	private SelectorVM<SelectorItemVM> _sortCategories;

	private SelectorVM<SelectorItemVM> _sortOrders;

	private MBBindingList<MPArmoryCosmeticTauntSlotVM> _tauntSlots;

	private MBBindingList<MPArmoryCosmeticCategoryBaseVM> _availableCategories;

	[DataSourceProperty]
	public InputKeyItemVM ActionInputKey
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
	public InputKeyItemVM PreviewInputKey
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
	public int Loot
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
	public bool IsLoading
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
	public bool HasCosmeticInfoReceived
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
	public bool IsManagingTaunts
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
	public bool IsTauntAssignmentActive
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
	public string CosmeticInfoErrorText
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
	public HintViewModel AllCategoriesHint
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
	public HintViewModel BodyCategoryHint
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
	public HintViewModel HeadCategoryHint
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
	public HintViewModel ShoulderCategoryHint
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
	public HintViewModel HandCategoryHint
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
	public HintViewModel LegCategoryHint
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
	public HintViewModel ResetPreviewHint
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
	public MPArmoryCosmeticCategoryBaseVM ActiveCategory
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
	public MPArmoryCosmeticTauntSlotVM SelectedTauntSlot
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
	public MPArmoryCosmeticTauntItemVM SelectedTauntItem
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
	public SelectorVM<SelectorItemVM> SortCategories
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
	public SelectorVM<SelectorItemVM> SortOrders
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
	public MBBindingList<MPArmoryCosmeticTauntSlotVM> TauntSlots
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
	public MBBindingList<MPArmoryCosmeticCategoryBaseVM> AvailableCategories
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

	public static event Action<MPArmoryCosmeticItemBaseVM> OnCosmeticPreview
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action<MPArmoryCosmeticItemBaseVM> OnRemoveCosmeticFromPreview
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action<List<EquipmentElement>> OnEquipmentRefreshed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public static event Action OnTauntAssignmentRefresh
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPArmoryCosmeticsVM(Func<List<IReadOnlyPerkObject>> getSelectedPerks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCallbacks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeCallbacks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003COnTick_003Ed__38))]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCosmeticItemComparers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeAllCosmetics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClothingCosmeticCategorySelected(MPArmoryClothingCosmeticCategoryVM selectedCosmetic)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTauntCosmeticCategorySelected(MPArmoryTauntCosmeticCategoryVM selectedCosmetic)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshAvailableCategoriesBy(CosmeticType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshPlayerData(PlayerData playerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshCosmeticInfoFromNetwork()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshCosmeticInfoFromNetworkAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CUpdateUsedCosmeticsAux_003Ed__47))]
	private Task<bool> UpdateUsedCosmeticsAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshSelectedClass(MPHeroClass selectedClass, List<IReadOnlyPerkObject> selectedPerks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EquipItemOnHeroPreview(MPArmoryCosmeticItemBaseVM itemVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCosmeticEquipRequested(MPArmoryCosmeticItemBaseVM cosmeticItemVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemEquipRequested(MPArmoryCosmeticClothingItemVM itemVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClothingItemEquipped(MPArmoryCosmeticClothingItemVM itemVM, bool forceRemove = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearTauntSelections()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTauntEquipRequested(MPArmoryCosmeticTauntItemVM tauntItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTauntSlotFocusChanged(MPArmoryCosmeticTauntSlotVM changedSlot, bool isFocused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTauntSlotPreview(MPArmoryCosmeticTauntSlotVM previewSlot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTauntSlotSelected(MPArmoryCosmeticTauntSlotVM selectedSlot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTauntItemEquipped(MPArmoryCosmeticTauntSlotVM equippedSlot, MPArmoryCosmeticTauntItemVM previousTauntItem, bool isSwapping)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnItemObtained(string cosmeticID, int finalLoot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSortCategoryUpdated(SelectorVM<SelectorItemVM> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSortOrderUpdated(SelectorVM<SelectorItemVM> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshFilters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FilterClothingsByCategory(MPArmoryClothingCosmeticCategoryVM clothingCategory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FilterTauntsByCategory(MPArmoryTauntCosmeticCategoryVM tauntCategory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshEquipment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshTaunts(string playerId, MBReadOnlyList<TauntIndexData> registeredTaunts)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTauntAssignmentState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteRefreshCosmeticInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteResetPreview()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshKeyBindings(HotKey actionKey, HotKey previewKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateKeyBindingsForCategory(MPArmoryCosmeticCategoryBaseVM categoryVM)
	{
		throw null;
	}
}
