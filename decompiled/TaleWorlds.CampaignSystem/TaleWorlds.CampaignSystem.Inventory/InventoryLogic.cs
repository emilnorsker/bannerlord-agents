using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Helpers;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Inventory;

public class InventoryLogic
{
	public enum TransferType
	{
		Neutral,
		Sell,
		Buy
	}

	public enum InventorySide
	{
		OtherInventory = 0,
		PlayerInventory = 1,
		CivilianEquipment = 2,
		BattleEquipment = 3,
		StealthEquipment = 4,
		None = -1
	}

	public delegate void AfterResetDelegate(InventoryLogic inventoryLogic, bool fromCancel);

	public delegate void TotalAmountChangeDelegate(int newTotalAmount);

	public delegate void ProcessResultListDelegate(InventoryLogic inventoryLogic, List<TransferCommandResult> results);

	private class PartyEquipment
	{
		public Dictionary<CharacterObject, Equipment[]> CharacterEquipments
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
		public PartyEquipment(MobileParty party)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InitializeCopyFrom(MobileParty party)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void ResetEquipment(MobileParty ownerParty)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetReference(PartyEquipment partyEquipment)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsEqual(PartyEquipment partyEquipment)
		{
			throw null;
		}
	}

	private class ItemLog : IReadOnlyCollection<int>, IEnumerable<int>, IEnumerable
	{
		private List<int> _transactions;

		private bool _isSelling;

		public bool IsSelling
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddTransaction(int price, bool isSelling)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RemoveLastTransaction()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RecordTransaction(int price, bool isSelling)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool GetLastTransaction(out int price, out bool isSelling)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IEnumerator<int> GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemLog()
		{
			throw null;
		}
	}

	public class CapacityData
	{
		private readonly Func<int> _getCapacity;

		private readonly Func<TextObject> _getCapacityExceededWarningText;

		private readonly Func<TextObject> _getCapacityExceededHintText;

		private readonly bool _forceTransaction;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CapacityData(Func<int> getCapacity, Func<TextObject> getCapacityExceededWarningText, Func<TextObject> getCapacityExceededHintText, bool forceTransaction = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetCapacity()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool CanForceTransaction()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TextObject GetCapacityExceededWarningText()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TextObject GetCapacityExceededHintText()
		{
			throw null;
		}
	}

	private class TransactionHistory
	{
		private Dictionary<EquipmentElement, ItemLog> _transactionLogs;

		public bool IsEmpty
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void RecordTransaction(EquipmentElement elementToTransfer, bool isSelling, int price)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Clear()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool GetLastTransfer(EquipmentElement equipmentElement, out int lastPrice, out bool lastIsSelling)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal List<(ItemRosterElement, int)> GetTransferredItems(bool isSelling)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal List<(ItemRosterElement, int)> GetBoughtItems()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal List<(ItemRosterElement, int)> GetSoldItems()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TransactionHistory()
		{
			throw null;
		}
	}

	private ItemRoster[] _rosters;

	private ItemRoster[] _rostersBackup;

	private IWorkshopWarehouseCampaignBehavior _workshopWarehouseBehavior;

	public bool IsPreviewingItem;

	private PartyEquipment _partyInitialEquipment;

	private float _xpGainFromDonations;

	private int _transactionDebt;

	private bool _playerAcceptsTraderOffer;

	private TransactionHistory _transactionHistory;

	private Dictionary<ItemCategory, float> _itemCategoryAverages;

	private bool _useBasePrices;

	public InventoryScreenHelper.InventoryCategoryType MerchantItemType;

	private InventoryScreenHelper.InventoryMode _inventoryMode;

	public bool DisableNetwork
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public Action<int> TotalAmountChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public Action DonationXpChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public TroopRoster RightMemberRoster
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

	public TroopRoster LeftMemberRoster
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

	public CharacterObject InitialEquipmentCharacter
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

	public bool IsTrading
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

	public bool IsSpecialActionsPermitted
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

	public CharacterObject OwnerCharacter
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

	public MobileParty OwnerParty
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

	public PartyBase OtherParty
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

	public IMarketData MarketData
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

	public CapacityData OtherSideCapacityData
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

	public int OtherSideCurrentWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TextObject LeftRosterName
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

	public bool IsDiscardDonating
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

	public bool IsOtherPartyFromPlayerClan
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

	public InventoryListener InventoryListener
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

	public int TotalAmount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public PartyBase OppositePartyFromListener
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SettlementComponent CurrentSettlementComponent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MobileParty CurrentMobileParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int TransactionDebt
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public float XpGainFromDonations
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public event AfterResetDelegate AfterReset
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

	public event ProcessResultListDelegate AfterTransfer
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
	public InventoryLogic(MobileParty ownerParty, CharacterObject ownerCharacter, PartyBase merchantParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventoryLogic(PartyBase merchantParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(ItemRoster leftItemRoster, MobileParty party, bool isTrading, bool isSpecialActionsPermitted, CharacterObject initialCharacterOfRightRoster, InventoryScreenHelper.InventoryCategoryType merchantItemType, IMarketData marketData, bool useBasePrices, InventoryScreenHelper.InventoryMode inventoryMode, TextObject leftRosterName = null, TroopRoster leftMemberRoster = null, CapacityData otherSideCapacityData = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(ItemRoster leftItemRoster, ItemRoster rightItemRoster, TroopRoster rightMemberRoster, bool isTrading, bool isSpecialActionsPermitted, CharacterObject initialCharacterOfRightRoster, InventoryScreenHelper.InventoryCategoryType merchantItemType, IMarketData marketData, bool useBasePrices, InventoryScreenHelper.InventoryMode inventoryMode, TextObject leftRosterName = null, TroopRoster leftMemberRoster = null, CapacityData otherSideCapacityData = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeRosters(ItemRoster leftItemRoster, ItemRoster rightItemRoster, TroopRoster rightMemberRoster, CharacterObject initialCharacterOfRightRoster, TroopRoster leftMemberRoster = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetItemTotalPrice(ItemRosterElement itemRosterElement, int absStockChange, out int lastPrice, bool isBuying)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlayerAcceptTraderOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoneLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<(ItemRosterElement, int)> GetBoughtItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<(ItemRosterElement, int)> GetSoldItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanInventoryCapacityIncrease(InventorySide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetCanItemIncreaseInventoryCapacity(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCategoryAverages()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeXpGainFromDonations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDonationOnTransferItem(ItemRosterElement rosterElement, int amount, bool isBuying, bool isSelling)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAveragePriceFactorItemCategory(ItemCategory category)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsThereAnyChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereAnyChangeBetweenRosters(ItemRoster roster1, ItemRoster roster2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetLogic(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanPlayerCompleteTransaction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanSlaughterItem(ItemRosterElement element, InventorySide sideOfItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSlaughterable(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanDonateItem(ItemRosterElement element, InventorySide sideOfItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDonatable(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInventoryListener(InventoryListener inventoryListener)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetItemPrice(EquipmentElement equipmentElement, bool isBuying = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCostOfItemRosterElement(ItemRosterElement itemRosterElement, InventorySide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAfterTransfer(List<TransferCommandResult> resultList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTransferCommand(TransferCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTransferCommands(IEnumerable<TransferCommand> commands)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckItemRosterHasElement(InventorySide side, ItemRosterElement rosterElement, int number)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessTransferCommand(TransferCommand command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TransferCommandResult> TransferItem(ref TransferCommand transferCommand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsEquipmentSide(InventorySide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsSell(InventorySide fromSide, InventorySide toSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsBuy(InventorySide fromSide, InventorySide toSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SlaughterItem(ItemRosterElement itemRosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DonateItem(ItemRosterElement itemRosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool TransferIsMovementValid(ref TransferCommand transferCommand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoesTransferItemExist(ref TransferCommand transferCommand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransferOne(ItemRosterElement itemRosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetElementCountOnSide(InventorySide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IReadOnlyList<ItemRosterElement> GetElementsInInitialRoster(InventorySide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IReadOnlyList<ItemRosterElement> GetElementsInRoster(InventorySide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCurrentStateAsInitial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemRosterElement? FindItemFromSide(InventorySide side, EquipmentElement item)
	{
		throw null;
	}
}
