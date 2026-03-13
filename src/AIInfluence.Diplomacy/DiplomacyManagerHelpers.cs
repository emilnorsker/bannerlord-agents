using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace AIInfluence.Diplomacy;

public static class DiplomacyManagerHelpers
{
	public static bool IsPlayerKingdom(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return false;
		}
		return kingdom.Leader == Hero.MainHero;
	}

	public static bool IsLeaderPrisonerOfPlayer(Kingdom kingdom)
	{
		if (((kingdom != null) ? kingdom.Leader : null) == null)
		{
			return false;
		}
		Hero leader = kingdom.Leader;
		if (!leader.IsPrisoner)
		{
			return false;
		}
		if (leader.PartyBelongedToAsPrisoner == PartyBase.MainParty)
		{
			return true;
		}
		Clan clan = Hero.MainHero.Clan;
		if (((clan != null) ? clan.Kingdom : null) != null && Hero.MainHero.Clan.Kingdom.Leader == Hero.MainHero && leader.CurrentSettlement != null && leader.CurrentSettlement.Owner == Hero.MainHero)
		{
			return true;
		}
		return false;
	}
}
