using System;
using System.Reflection;
using AIInfluence.Behaviors.RolePlay;
using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Library;
using TaleWorlds.Localization;

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
			EquipmentElement equipmentElement = ((ItemRosterElement)(ref ((ItemVM)item).ItemRosterElement)).EquipmentElement;
			if ((int)(equipmentElement).Item.ItemType != 22 || !((equipmentElement).Item.ItemComponent is RPItemComponent rPItemComponent) || !(rPItemComponent.Description != (TextObject)null) || string.IsNullOrEmpty(((object)rPItemComponent.Description).ToString()))
			{
				return;
			}
			string text = ((object)rPItemComponent.Description).ToString();
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
