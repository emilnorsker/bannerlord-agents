using System;
using System.Linq;
using Bannerlord.GameMaster.Items;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace AIInfluence;

public static class RpWeaponForgeScript
{
	public static void ForgeToNpcBag(Hero npc, string query, ItemTypes types, string culture, int tier, string modToken, string displayName)
	{
		ItemRoster bag = npc.PartyBelongedTo.ItemRoster;
		ItemObject t = ItemQueries.QueryItems(query, types, true, tier, culture ?? "", false, "tier", true).FirstOrDefault(i => i.WeaponComponent != null) ?? throw new InvalidOperationException("no weapon match for " + displayName);
		(ItemModifier m, string err) = ItemModifierHelper.ParseModifier(modToken);
		if (err != null)
			throw new InvalidOperationException(err);
		if (m != null && !ItemModifierHelper.CanHaveModifier(t))
			throw new InvalidOperationException(t.Name + " cannot have quality modifiers.");
		bag.AddToCounts(new EquipmentElement(t, m), 1);
	}
}
