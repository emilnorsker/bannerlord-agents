using System;
using System.Linq;
using System.Reflection;
using AIInfluence.Behaviors.RolePlay;
using Bannerlord.GameMaster.Items;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class RpWeaponForgeScript
{
	public static ItemObject RestoreForgedWeaponFromRpData(RPItemData d)
	{
		ItemObject t = MBObjectManager.Instance.GetObject<ItemObject>(d.BaseItemId);
		if (t?.WeaponComponent == null)
			return null;
		ItemObject w = (ItemObject)typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(t, null);
		((MBObjectBase)w).StringId = d.ItemId;
		typeof(ItemObject).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(w, new TextObject(d.Name ?? "", null), null);
		MBObjectManager.Instance.RegisterObject(w);
		return w;
	}

	public static void ForgeToNpcBag(Hero npc, string query, ItemTypes types, string culture, int tier, string modToken, string displayName, string description = null)
	{
		ItemRoster bag = npc.PartyBelongedTo.ItemRoster;
		ItemObject t = ItemQueries.QueryItems(query, types, true, tier, culture ?? "", false, "tier", true).FirstOrDefault(i => i.WeaponComponent != null) ?? throw new InvalidOperationException("no weapon match for " + displayName);
		(ItemModifier m, string err) = ItemModifierHelper.ParseModifier(modToken);
		if (err != null)
			throw new InvalidOperationException(err);
		if (m != null && !ItemModifierHelper.CanHaveModifier(t))
			throw new InvalidOperationException(t.Name + " cannot have quality modifiers.");
		ItemObject w = (ItemObject)typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(t, null);
		string id = "rp_w_" + Guid.NewGuid().ToString("N").Substring(0, 8);
		((MBObjectBase)w).StringId = id;
		typeof(ItemObject).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(w, new TextObject(displayName ?? "", null), null);
		MBObjectManager.Instance.RegisterObject(w);
		bag.AddToCounts(new EquipmentElement(w, m), 1);
		RPItemManager.Instance.RegisterForgedWeapon(w, ((MBObjectBase)t).StringId, displayName, description, ((MBObjectBase)npc).StringId, m, ((MBObjectBase)npc).StringId);
	}
}
