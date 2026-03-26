using System;
using System.Reflection;
using AIInfluence.Behaviors.RolePlay;
using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(ItemMenuVM), "RefreshItemTooltips")]
public static class RPItemTooltipPatch
{
	private static void Postfix(ItemMenuVM __instance, SPItemVM item, ItemVM comparedItem, int alternativeUsageIndex = 0)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		try
		{
			EquipmentElement equipmentElement = ((ItemVM)item).ItemRosterElement.EquipmentElement;
			string text = null;
			if (RPItemManager.Instance?.GetItemData(((MBObjectBase)equipmentElement.Item).StringId) is RPItemData rd && !string.IsNullOrEmpty(rd.Description))
				text = rd.Description;
			else if ((int)equipmentElement.Item.ItemType == 22 && equipmentElement.Item.ItemComponent is RPItemComponent rPItemComponent && rPItemComponent.Description != null && !string.IsNullOrEmpty(((object)rPItemComponent.Description).ToString()))
				text = ((object)rPItemComponent.Description).ToString();
			if (string.IsNullOrEmpty(text))
				return;
			MethodInfo method = typeof(ItemMenuVM).GetMethod("CreateProperty", BindingFlags.Instance | BindingFlags.NonPublic);
			if (method != null)
			{
				PropertyInfo property = typeof(ItemMenuVM).GetProperty("TargetItemProperties", BindingFlags.Instance | BindingFlags.Public);
				if (property != null && property.GetValue(__instance) is MBBindingList<ItemMenuTooltipPropertyVM> val)
				{
					method.Invoke(__instance, new object[5] { val, "", text, 0, null });
				}
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[RP_ITEM_TOOLTIP_PATCH] Error adding description to tooltip: " + ex.Message);
		}
	}
}
