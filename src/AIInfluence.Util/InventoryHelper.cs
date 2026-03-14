using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIInfluence.Behaviors.RolePlay;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Util;

public static class InventoryHelper
{
	public static ItemRoster GetHeroItemRoster(Hero hero, bool isPlayer = false)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		if (hero == null)
		{
			return null;
		}
		if (isPlayer)
		{
			MobileParty mainParty = MobileParty.MainParty;
			return (mainParty != null) ? mainParty.ItemRoster : null;
		}
		MobileParty partyBelongedTo = hero.PartyBelongedTo;
		if (((partyBelongedTo != null) ? partyBelongedTo.ItemRoster : null) != null)
		{
			return hero.PartyBelongedTo.ItemRoster;
		}
		if ((int)hero.Occupation != 16 && !hero.IsWanderer)
		{
			if (hero.Clan == null)
			{
				CharacterObject characterObject = hero.CharacterObject;
				if (characterObject != null && (int)characterObject.Occupation == 16)
				{
					goto IL_0095;
				}
			}
			Settlement currentSettlement = hero.CurrentSettlement;
			if (((currentSettlement != null) ? currentSettlement.ItemRoster : null) != null)
			{
				return hero.CurrentSettlement.ItemRoster;
			}
			return null;
		}
		goto IL_0095;
		IL_0095:
		return null;
	}

	public static string GetInventorySummary(Hero hero, bool isPlayer = false)
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Invalid comparison between Unknown and I4
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null)
		{
			return "No inventory data available.";
		}
		ItemRoster heroItemRoster = GetHeroItemRoster(hero, isPlayer);
		if (heroItemRoster == null || heroItemRoster.Count == 0)
		{
			return "Inventory is empty or no party available.";
		}
		bool flag = !isPlayer && hero.PartyBelongedTo == null && hero.CurrentSettlement != null;
		object obj = hero.CurrentSettlement;
		if (obj == null)
		{
			MobileParty partyBelongedTo = hero.PartyBelongedTo;
			obj = ((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null);
			if (obj == null)
			{
				Hero mainHero = Hero.MainHero;
				obj = ((mainHero != null) ? mainHero.CurrentSettlement : null);
				if (obj == null)
				{
					Hero mainHero2 = Hero.MainHero;
					if (mainHero2 == null)
					{
						obj = null;
					}
					else
					{
						MobileParty partyBelongedTo2 = mainHero2.PartyBelongedTo;
						obj = ((partyBelongedTo2 != null) ? partyBelongedTo2.CurrentSettlement : null);
					}
				}
			}
		}
		Settlement val = (Settlement)obj;
		StringBuilder stringBuilder = new StringBuilder();
		if (flag)
		{
			string text = (hero.CurrentSettlement.IsVillage ? "village" : (hero.CurrentSettlement.IsTown ? "town" : (hero.CurrentSettlement.IsCastle ? "castle" : "settlement")));
			string text2 = ((object)hero.CurrentSettlement.Name)?.ToString() ?? "settlement";
			stringBuilder.AppendLine("**NOTE: This is the " + text + " inventory of " + text2 + ", not your personal inventory.**");
			stringBuilder.AppendLine();
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		foreach (ItemRosterElement item3 in heroItemRoster)
		{
			ItemRosterElement current = item3;
			if ((current).Amount <= 0)
			{
				continue;
			}
			EquipmentElement equipmentElement = (current).EquipmentElement;
			ItemObject item = (equipmentElement).Item;
			if (item == null)
			{
				continue;
			}
			string item2;
			if (item.ItemComponent is RPItemComponent)
			{
				string text3 = ((!(item.ItemComponent is RPItemComponent rPItemComponent)) ? null : ((object)rPItemComponent.Description)?.ToString()) ?? "";
				item2 = (string.IsNullOrEmpty(text3) ? $"{item.Name} (id:{((MBObjectBase)item).StringId}): {(current).Amount}" : $"{item.Name} (id:{((MBObjectBase)item).StringId}): {(current).Amount} - Description: {text3}");
			}
			else
			{
				int num = item.Value;
				bool flag2 = false;
				if (val != null)
				{
					try
					{
						if (val.IsTown && val.Town != null)
						{
							num = ((SettlementComponent)val.Town).GetItemPrice(item, (MobileParty)null, false);
							flag2 = true;
						}
						else if (val.IsVillage && val.Village != null)
						{
							num = ((SettlementComponent)val.Village).GetItemPrice(item, (MobileParty)null, false);
							flag2 = true;
						}
					}
					catch
					{
						num = item.Value;
					}
				}
				string text4 = (flag2 ? "avg market price" : "base value");
				item2 = $"{item.Name} (id:{((MBObjectBase)item).StringId}): {(current).Amount} (approx. {num} gold each, {text4})";
			}
			if (item.IsFood)
			{
				list.Add(item2);
			}
			else if (item.IsTradeGood || item.IsAnimal)
			{
				if (item.IsMountable)
				{
					list3.Add(item2);
				}
				else
				{
					list2.Add(item2);
				}
			}
			else if (item.IsMountable)
			{
				list3.Add(item2);
			}
			else if ((int)item.Tier >= 3 || (current).Amount >= 5)
			{
				list4.Add(item2);
			}
		}
		if (list.Any())
		{
			stringBuilder.AppendLine("  - Food: " + string.Join(", ", list));
		}
		if (list2.Any())
		{
			stringBuilder.AppendLine("  - Goods: " + string.Join(", ", list2));
		}
		if (list3.Any())
		{
			stringBuilder.AppendLine("  - Mounts/Livestock: " + string.Join(", ", list3));
		}
		if (list4.Any() && list4.Count < 10)
		{
			stringBuilder.AppendLine("  - Equipment: " + string.Join(", ", list4));
		}
		if (stringBuilder.Length == 0)
		{
			return "Inventory contains only common equipment.";
		}
		return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
	}

	private static bool FindAndUnequipItem(Hero hero, string itemId, int amount, out ItemObject itemObject, out string errorReason)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		itemObject = null;
		errorReason = null;
		if (((hero != null) ? hero.CharacterObject : null) == null)
		{
			errorReason = "Hero or character object is null.";
			return false;
		}
		Equipment[] array = (Equipment[])(object)new Equipment[2] { hero.BattleEquipment, hero.CivilianEquipment };
		int num = 0;
		List<(Equipment, EquipmentIndex)> list = new List<(Equipment, EquipmentIndex)>();
		Equipment[] array2 = array;
		EquipmentElement val3;
		foreach (Equipment val in array2)
		{
			if (val == null)
			{
				continue;
			}
			for (int j = 0; j < 12; j++)
			{
				EquipmentIndex val2 = (EquipmentIndex)j;
				val3 = val[val2];
				ItemObject item = (val3).Item;
				if (item != null && ((MBObjectBase)item).StringId == itemId)
				{
					if (itemObject == null)
					{
						itemObject = item;
					}
					num++;
					list.Add((val, val2));
				}
			}
		}
		if (itemObject == null || num < amount)
		{
			errorReason = $"Not enough equipped items '{itemId}' (Found: {num}, Needed: {amount}).";
			return false;
		}
		foreach (var (val4, val5) in list.Take(amount))
		{
			val3 = (val4[val5] = default(EquipmentElement));
		}
		return true;
	}

	public static bool TransferItem(string itemId, int amount, Hero fromHero, Hero toHero, out string errorReason)
	{
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		errorReason = null;
		if (string.IsNullOrEmpty(itemId) || amount <= 0 || fromHero == null || toHero == null)
		{
			errorReason = "Invalid parameters.";
			return false;
		}
		ItemRoster heroItemRoster = GetHeroItemRoster(fromHero, fromHero == Hero.MainHero);
		ItemRoster heroItemRoster2 = GetHeroItemRoster(toHero, toHero == Hero.MainHero);
		if (heroItemRoster2 == null)
		{
			errorReason = $"{toHero.Name} has no inventory to receive items.";
			return false;
		}
		ItemRosterElement? val = null;
		ItemObject itemObject = null;
		bool flag = false;
		if (heroItemRoster != null)
		{
			foreach (ItemRosterElement item2 in heroItemRoster)
			{
				ItemRosterElement current = item2;
				EquipmentElement equipmentElement = (current).EquipmentElement;
				ItemObject item = (equipmentElement).Item;
				if (((item != null) ? ((MBObjectBase)item).StringId : null) == itemId)
				{
					val = current;
					equipmentElement = (current).EquipmentElement;
					itemObject = (equipmentElement).Item;
					break;
				}
			}
		}
		if (itemObject == null)
		{
			if (FindAndUnequipItem(fromHero, itemId, amount, out itemObject, out errorReason))
			{
				flag = true;
				if (heroItemRoster == null)
				{
					errorReason = $"{fromHero.Name} has no inventory to transfer equipped items to.";
					return false;
				}
				heroItemRoster.AddToCounts(itemObject, amount);
			}
			else
			{
				itemObject = ((IEnumerable<ItemObject>)Items.All).FirstOrDefault((Func<ItemObject, bool>)((ItemObject x) => ((MBObjectBase)x).StringId == itemId));
				if (itemObject == null)
				{
					errorReason = $"Item '{itemId}' not found in {fromHero.Name}'s inventory or equipment.";
					return false;
				}
				if (heroItemRoster == null)
				{
					string arg = ((object)itemObject.Name)?.ToString() ?? itemId;
					errorReason = $"Item '{arg}' not found in {fromHero.Name}'s inventory or equipment.";
					return false;
				}
				int itemNumber = heroItemRoster.GetItemNumber(itemObject);
				if (itemNumber <= 0)
				{
					string arg2 = ((object)itemObject.Name)?.ToString() ?? itemId;
					errorReason = $"Item '{arg2}' not found in {fromHero.Name}'s inventory or equipment.";
					return false;
				}
				if (itemNumber < amount)
				{
					errorReason = $"Not enough '{itemObject.Name}' (Has: {itemNumber}, Needed: {amount}).";
					return false;
				}
			}
		}
		else
		{
			ItemRosterElement value = val.Value;
			if ((value).Amount < amount)
			{
				value = val.Value;
				int num = amount - (value).Amount;
				if (!FindAndUnequipItem(fromHero, itemId, num, out var itemObject2, out var _))
				{
					TextObject name = itemObject.Name;
					value = val.Value;
					errorReason = $"Not enough '{name}' (Has: {(value).Amount} in inventory, Needed: {amount}).";
					return false;
				}
				if (((MBObjectBase)itemObject2).StringId != itemId)
				{
					errorReason = "Item mismatch: found " + ((MBObjectBase)itemObject2).StringId + " instead of " + itemId + ".";
					return false;
				}
				flag = true;
				heroItemRoster.AddToCounts(itemObject, num);
			}
		}
		try
		{
			if (heroItemRoster == null)
			{
				errorReason = $"{fromHero.Name} has no inventory to transfer items from.";
				return false;
			}
			heroItemRoster.AddToCounts(itemObject, -amount);
			heroItemRoster2.AddToCounts(itemObject, amount);
			return true;
		}
		catch (Exception ex)
		{
			errorReason = "Exception during transfer: " + ex.Message;
			return false;
		}
	}
}
