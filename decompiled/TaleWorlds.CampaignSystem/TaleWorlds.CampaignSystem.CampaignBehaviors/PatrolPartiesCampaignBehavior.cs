using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class PatrolPartiesCampaignBehavior : CampaignBehaviorBase, IPatrolPartiesCampaignBehavior
{
	private const float BasePatrolScore = 1.25f;

	private const float VisitHomeSettlementPartySizeRatioThreshold = 5f;

	private const float VisitHomeSettlementBaseScore = 0.15f;

	private const float ConsiderReplenishPartySizeRatioThreshold = 0.15f;

	private const float BaseReplenishmentChance = 0.005f;

	private Dictionary<Settlement, CampaignTime> _partyGenerationQueue;

	private Dictionary<Settlement, CampaignTime> _lastHomeSettlementVisitTimes;

	private Dictionary<Settlement, CampaignTime> _lastHomeSettlementVisitTimesCoastal;

	private Dictionary<Settlement, CampaignTime> _interactedPatrolParties;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBuildingLevelChanged(Town town, Building building, int levelChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTickParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReplenishParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SortRoster(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreated(CampaignGameStarter starter, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDialogs(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition_dont_attack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_start_enemy_leave_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void patrol_attack_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_hideout_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition_security_start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition_security()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition_hideout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereHideoutNearSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void patrol_talk_start_enemy_leave_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_common_condition_enemy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition_player_is_attacker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition_player_is_not_attacker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition_non_enemy_attack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition_enemy_attack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void patrol_talk_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool patrol_talk_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetStatusText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetIntroText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementOwnerChangedEvent(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateVisitHomeSettlementScore(MobileParty mobileParty, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanVisitSettlement(MobileParty mobileParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSettlementScoreAdjustment(Settlement settlement, bool isNavalPatrolling)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculatePatrollingScoreForSettlement(Settlement settlement, PartyThinkParams p, bool isNavalPatrolling)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MobilePartyDestroyed(MobileParty party, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanSettlementSpawnNewPartyCurrently(Settlement settlement, bool includeReason, out TextObject reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MobilePartyCreated(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetLastHomeSettlementVisitTime(MobileParty mobileParty, out CampaignTime campaignTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetLastHomeSettlementVisitTime(MobileParty mobileParty, CampaignTime time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveLastVisitEntry(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSettlementParties(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveSettlementParties(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSettlementQueue(Settlement settlement, CampaignTime time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPatrolParty(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetSettlementPatrolStatus(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PatrolPartiesCampaignBehavior()
	{
		throw null;
	}
}
