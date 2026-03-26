using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
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
	private static bool ModifierAllowedOn(ItemObject template, ItemModifier m)
	{
		if (m == null || template == null)
			return true;
		MethodInfo x = typeof(ItemObject).GetMethod("IsValidModifier", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		object r = x?.Invoke(template, new object[] { m });
		return r is bool ok ? ok : true;
	}

	private static string ValidModifierHint(ItemObject t)
	{
		if (t == null)
			return "";
		IEnumerable<string> names = ItemModifierHelper.GetAllModifiers().Where(m => ModifierAllowedOn(t, m)).Take(24).Select(m => m.Name.ToString());
		return " Retry with one of these modifier names for this template: " + string.Join(", ", names) + ".";
	}

	public static ItemObject RestoreForgedWeaponFromRpData(RPItemData d)
	{
		ItemObject already = MBObjectManager.Instance.GetObject<ItemObject>(d.ItemId);
		if (already != null)
		{
			typeof(ItemObject).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(already, new TextObject(d.Name ?? "", null), null);
			return already;
		}
		ItemObject t = MBObjectManager.Instance.GetObject<ItemObject>(d.BaseItemId);
		if (t?.WeaponComponent == null)
			return null;
		// Shallow clone: native item templates treat WeaponComponent as immutable after init.
		ItemObject w = (ItemObject)typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(t, null);
		((MBObjectBase)w).StringId = d.ItemId;
		typeof(ItemObject).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(w, new TextObject(d.Name ?? "", null), null);
		if (MBObjectManager.Instance.GetObject<ItemObject>(d.ItemId) == null)
			MBObjectManager.Instance.RegisterObject(w);
		else
			w = MBObjectManager.Instance.GetObject<ItemObject>(d.ItemId);
		return w;
	}

	/// <summary>Adds the forged weapon to the NPC party roster and returns it. Caller may transfer to the player.</summary>
	public static ItemObject ForgeToNpcBag(Hero npc, string query, ItemTypes types, string culture, int tier, string modToken, string displayName, string description = null)
	{
		ItemRoster bag = npc?.PartyBelongedTo?.ItemRoster ?? throw new InvalidOperationException((((object)npc?.Name)?.ToString() ?? "NPC") + " does not belong to a party.");
		ItemObject t = ItemQueries.QueryItems(query, types, true, tier, culture ?? "", false, "tier", true).FirstOrDefault(i => i.WeaponComponent != null) ?? throw new InvalidOperationException("no weapon match for " + displayName);
		ItemModifier m = null;
		if (!string.IsNullOrWhiteSpace(modToken))
		{
			(ItemModifier pm, string err) = ItemModifierHelper.ParseModifier(modToken);
			if (err != null)
				throw new InvalidOperationException(err + (err.IndexOf("Did you mean", StringComparison.OrdinalIgnoreCase) >= 0 ? "" : ValidModifierHint(t)));
			if (!ItemModifierHelper.CanHaveModifier(t))
				throw new InvalidOperationException(t.Name + " cannot have quality modifiers.");
			if (!ModifierAllowedOn(t, pm))
				throw new InvalidOperationException("That modifier cannot be applied to this weapon." + ValidModifierHint(t));
			m = pm;
		}
		// Shallow clone: native item templates treat WeaponComponent as immutable after init.
		ItemObject w = (ItemObject)typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(t, null);
		string id = "rp_w_" + Guid.NewGuid().ToString("N").Substring(0, 8);
		((MBObjectBase)w).StringId = id;
		typeof(ItemObject).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(w, new TextObject(displayName ?? "", null), null);
		if (MBObjectManager.Instance.GetObject<ItemObject>(id) != null)
			throw new InvalidOperationException("weapon id collision: " + id);
		RPItemManager.Instance.RegisterForgedWeapon(w, ((MBObjectBase)t).StringId, displayName, description, ((MBObjectBase)npc).StringId, m, ((MBObjectBase)npc).StringId);
		bag.AddToCounts(new EquipmentElement(w, m), 1);
		return w;
	}
}
