using System.Linq;
using System.Reflection;
using Bannerlord.GameMaster.Items;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class RpWeaponForgeScript
{
	public static void ForgeToNpcBag(Hero npc, string query, ItemTypes types, string culture, int tier, string modToken, string displayName)
	{
		ItemRoster bag = npc.PartyBelongedTo.ItemRoster;
		ItemObject template = ItemQueries.QueryItems(query, types, true, tier, culture ?? "", false, "tier", true).FirstOrDefault(i => i.WeaponComponent != null);
		(ItemModifier mod, _) = ItemModifierHelper.ParseModifier(modToken);
		ItemObject w = (ItemObject)typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(template, null);
		((MBObjectBase)w).StringId = "rp_w_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);
		typeof(ItemObject).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(w, new TextObject(displayName), null);
		MBObjectManager.Instance.RegisterObject(w);
		MethodInfo add = typeof(ItemRoster).GetMethod("AddToCounts", new[] { typeof(EquipmentElement), typeof(int) });
		add.Invoke(bag, new object[] { new EquipmentElement(w, mod), 1 });
	}
}
