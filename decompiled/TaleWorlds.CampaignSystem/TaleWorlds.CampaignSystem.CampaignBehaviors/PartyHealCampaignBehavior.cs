using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class PartyHealCampaignBehavior : CampaignBehaviorBase
{
	private Dictionary<PartyBase, float> _overflowedHealingForRegulars;

	private Dictionary<PartyBase, float> _overflowedHealingForHeroes;

	private Dictionary<PartyBase, float> _overflowedHealingForPrisonerRegulars;

	private Dictionary<PartyBase, float> _overflowedHealingForPrisonerHeroes;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyDestroyed(MobileParty mobileParty, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerBattleEnd(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBattleEndCheckPerkEffects(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanHourlyTick(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuarterDailyPartyTick(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDailyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryHealOrWoundParty(PartyBase partyBase, float healFrequencyPerDay)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryToHealOrWoundPrisoners(PartyBase partyBase, float healFrequencyPerDay)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryToHealOrWoundMembers(PartyBase partyBase, float healFrequencyPerDay)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ManageHealingOfPrisonerRegulars(PartyBase partyBase, ref float prisonerRegularsHealingValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ManageHealingOfPrisonerHeroes(PartyBase partyBase, ref float prisonerHeroesHealingValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HealMemberHeroes(PartyBase partyBase, ref float heroesHealingValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ReduceHpMemberHeroes(PartyBase partyBase, ref float heroesHealingValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HealMemberRegulars(PartyBase partyBase, ref float regularsHealingValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ReduceHpMemberRegulars(PartyBase partyBase, ref float regularsHealingValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyHealCampaignBehavior()
	{
		throw null;
	}
}
