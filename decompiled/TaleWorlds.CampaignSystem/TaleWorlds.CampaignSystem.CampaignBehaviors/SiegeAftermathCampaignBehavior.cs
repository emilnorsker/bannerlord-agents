using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class SiegeAftermathCampaignBehavior : CampaignBehaviorBase
{
	private MobileParty _besiegerParty;

	private Clan _prevSettlementOwnerClan;

	private SiegeAftermathAction.SiegeAftermath _playerEncounterAftermath;

	private Dictionary<MobileParty, float> _siegeEventPartyContributions;

	private Dictionary<Building, int> _playerEncounterAftermathDamagedBuildings;

	private bool _wasPlayerArmyMember;

	private float _settlementProsperityCache;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus(CampaignGameStarter gameSystemInitializer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSiegeAftermathApplied(MobileParty attackerParty, Settlement settlement, SiegeAftermathAction.SiegeAftermath aftermathType, Clan previousSettlementOwner, Dictionary<MobileParty, float> partyContributions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SiegeAftermathAction.SiegeAftermath DetermineSiegeAftermathOnEncounterLeaderDeath(MobileParty attackerParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMobilePartyLeaderAliveForSiegeAftermath(MobileParty attackerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SiegeAftermathAction.SiegeAftermath DetermineAISiegeAftermath(MobileParty attackerParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBuildingLevelChanged(Town town, Building building, int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePlayerDeathDuringSiegeAftermath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void menu_settlement_taken_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void menu_settlement_taken_player_leader_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void menu_settlement_taken_player_army_member_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void menu_settlement_taken_player_participant_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void menu_settlement_taken_continue_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool menu_settlement_taken_devastate_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void menu_settlement_taken_devastate_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool continue_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool menu_settlement_taken_pillage_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void menu_settlement_taken_pillage_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool menu_settlement_taken_show_mercy_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void menu_settlement_taken_show_mercy_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetSiegeAftermathConsequencesText(MobileParty attackerParty, Settlement settlement, SiegeAftermathAction.SiegeAftermath aftermath, bool isTooltip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void siege_aftermath_contextual_summary_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSiegeAftermathProsperityPenalty(MobileParty attackerParty, Settlement settlement, SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetSiegeAftermathProjectsLoss(MobileParty attackerParty, SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSiegeAftermathLoyaltyPenalty(SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSiegeAftermathNotablePowerModifierForAftermath(SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSiegeAftermathPartyMoraleBonus(MobileParty attackerParty, Settlement settlement, SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetSiegeAftermathArmyGoldGain(MobileParty attackerParty, Settlement settlement, SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetSiegeAftermathPartyGoldGain(float totalArmyGoldGain, float partyContributionPercentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetSiegeAftermathRelationChangeWithLord(Hero hero, SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetSiegeAftermathRelationChangeWithMercifulLord(SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetSiegeAftermathRelationPenaltyWithSettlementOwner(SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSiegeAftermathInfluenceCost(MobileParty attackerParty, Settlement settlement, SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsSiegeAftermathPossible(MobileParty attackerParty, Settlement settlement, SiegeAftermathAction.SiegeAftermath aftermathType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeAftermathCampaignBehavior()
	{
		throw null;
	}
}
