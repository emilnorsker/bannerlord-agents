using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultPartyDesertionModel : PartyDesertionModel
{
	private const int MaxAcceptableDesertionCountForNormal = 20;

	private const int MoraleThresholdForParty = 10;

	private const int AverageTroopLevel = 20;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMoraleThresholdForTroopDesertion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDesertionChanceForTroop(MobileParty mobileParty, in TroopRosterElement troopRosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateDesertionChanceFromTroopLevel(float partyMorale, int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TroopRoster GetTroopsToDesert(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetTroopsToDesertDueToMorale(MobileParty mobileParty, TroopRoster troopsToDesert)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetTroopsToDesertDueToWageAndPartySize(MobileParty mobileParty, TroopRoster troopsToDesert)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectTroopsForDesertion(MobileParty mobileParty, TroopRoster troopsToDesert, int maxDesertionCount, bool useProbability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultPartyDesertionModel()
	{
		throw null;
	}
}
