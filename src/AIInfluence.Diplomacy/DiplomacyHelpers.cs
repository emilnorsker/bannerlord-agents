using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace AIInfluence.Diplomacy;

public static class DiplomacyHelpers
{
	public static bool VerifyBattleSides(PartyBase party1, PartyBase party2, out Kingdom kingdom1, out Kingdom kingdom2)
	{
		kingdom1 = null;
		kingdom2 = null;
		if (party1.IsMobile && party1.MobileParty != null && party1.MobileParty.IsBandit)
		{
			return false;
		}
		if (party2.IsMobile && party2.MobileParty != null && party2.MobileParty.IsBandit)
		{
			return false;
		}
		if (party1.MapFaction == null || party1.MapFaction.IsBanditFaction)
		{
			return false;
		}
		if (party2.MapFaction == null || party2.MapFaction.IsBanditFaction)
		{
			return false;
		}
		IFaction mapFaction = party1.MapFaction;
		kingdom1 = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
		IFaction mapFaction2 = party2.MapFaction;
		kingdom2 = (Kingdom)(object)((mapFaction2 is Kingdom) ? mapFaction2 : null);
		if (kingdom1 == null || kingdom2 == null)
		{
			return false;
		}
		if (kingdom1 == kingdom2)
		{
			return false;
		}
		return true;
	}

	public static bool VerifyHeroEventSides(Hero hero1, Hero hero2, out Kingdom kingdom1, out Kingdom kingdom2)
	{
		kingdom1 = null;
		kingdom2 = null;
		if (hero1 == null || hero1.MapFaction == null || hero1.MapFaction.IsBanditFaction)
		{
			return false;
		}
		if (hero2 == null || hero2.MapFaction == null || hero2.MapFaction.IsBanditFaction)
		{
			return false;
		}
		IFaction mapFaction = hero1.MapFaction;
		kingdom1 = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
		IFaction mapFaction2 = hero2.MapFaction;
		kingdom2 = (Kingdom)(object)((mapFaction2 is Kingdom) ? mapFaction2 : null);
		if (kingdom1 == null || kingdom2 == null)
		{
			return false;
		}
		if (kingdom1 == kingdom2)
		{
			return false;
		}
		return true;
	}
}
