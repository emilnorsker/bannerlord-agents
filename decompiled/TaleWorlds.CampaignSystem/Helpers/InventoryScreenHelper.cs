using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Inventory;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Helpers;

public static class InventoryScreenHelper
{
	public enum InventoryMode
	{
		Default,
		Trade,
		Loot,
		Stash,
		Warehouse
	}

	public delegate void InventoryFinishDelegate();

	[Flags]
	public enum InventoryItemType
	{
		None = 0,
		Weapon = 1,
		Shield = 2,
		HeadArmor = 4,
		BodyArmor = 8,
		LegArmor = 0x10,
		HandArmor = 0x20,
		Horse = 0x40,
		HorseHarness = 0x80,
		Goods = 0x100,
		Book = 0x200,
		Animal = 0x400,
		Cape = 0x800,
		Banner = 0x1000,
		HorseCategory = 0xC0,
		Armors = 0x83C,
		Equipable = 0x18FF,
		All = 0xFFF
	}

	public enum InventoryCategoryType
	{
		None = -1,
		All,
		Armors,
		Weapon,
		Shield,
		HorseCategory,
		Goods,
		CategoryTypeAmount
	}

	private class CaravanInventoryListener : InventoryListener
	{
		private MobileParty _caravan;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CaravanInventoryListener(MobileParty caravan)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int GetGold()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override TextObject GetTraderName()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void SetGold(int gold)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PartyBase GetOppositeParty()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnTransaction()
		{
			throw null;
		}
	}

	private class MerchantInventoryListener : InventoryListener
	{
		private SettlementComponent _settlementComponent;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MerchantInventoryListener(SettlementComponent settlementComponent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override TextObject GetTraderName()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PartyBase GetOppositeParty()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int GetGold()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void SetGold(int gold)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnTransaction()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static InventoryState GetActiveInventoryState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PlayerAcceptTradeOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CloseScreen(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CloseInventoryPresentation(bool fromCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OpenInventoryPresentation(TextObject leftRosterName, Action doneLogicExtrasDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static IMarketData GetCurrentMarketDataForPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsInventoryOfSubParty(MobileParty rightParty, MobileParty leftParty, Action doneLogicExtrasDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsInventoryForCraftedItemDecomposition(MobileParty party, CharacterObject character, Action doneLogicExtrasDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsInventoryOf(MobileParty party, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsInventoryOf(PartyBase rightParty, PartyBase leftParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsInventoryOf(PartyBase rightParty, PartyBase leftParty, CharacterObject character, TextObject leftRosterName = null, InventoryLogic.CapacityData capacityData = null, Action doneLogicExtrasDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsInventory(Action doneLogicExtrasDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenCampaignBattleLootScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsLoot(Dictionary<PartyBase, ItemRoster> itemRostersToLoot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsStash(ItemRoster stash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsWarehouse(ItemRoster stash, InventoryLogic.CapacityData otherSideCapacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsReceiveItems(ItemRoster items, TextObject leftRosterName, Action doneLogicDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenTradeWithCaravanOrAlleyParty(MobileParty caravan, InventoryCategoryType merchantItemType = InventoryCategoryType.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ActivateTradeWithCurrentSettlement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenScreenAsTrade(ItemRoster leftRoster, SettlementComponent settlementComponent, InventoryCategoryType merchantItemType = InventoryCategoryType.None, Action doneLogicExtrasDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static InventoryItemType GetInventoryItemTypeOfItem(ItemObject item)
	{
		throw null;
	}
}
