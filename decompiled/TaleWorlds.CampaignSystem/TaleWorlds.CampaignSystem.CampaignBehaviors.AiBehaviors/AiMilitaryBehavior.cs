using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Siege;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors.AiBehaviors;

public class AiMilitaryBehavior : CampaignBehaviorBase
{
	private const int MinimumInfluenceNeededToCreateArmy = 50;

	private const float MeaningfulCohesionThresholdForArmy = 40f;

	private const float MinimumCohesionScoreThreshold = 0.25f;

	private const float AverageSiegeDurationAsDays = 5.73f;

	private IDisbandPartyCampaignBehavior _disbandPartyCampaignBehavior;

	private readonly HashSet<Settlement> _checkedNeighbors;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSiegeEventStarted(SiegeEvent siegeEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FindBestTargetAndItsValueForFaction(Army.ArmyTypes missionType, PartyThinkParams p, float ourStrength, float newArmyCreatingAdditionalConstant = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetFoodScoreForActionType(PartyThinkParams p, Army.ArmyTypes type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetPartySizeScore(MobileParty mobileParty, Army.ArmyTypes missionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateMilitaryBehaviorForFactionSettlements(IFaction faction, PartyThinkParams p, Army.ArmyTypes missionType, AiBehavior aiBehavior, float ourStrength, float partySizeScore, float cohesionScore, float foodScore, float newArmyCreatingAdditionalConstant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfSettlementIsSuitableForMilitaryAction(Settlement settlement, MobileParty mobileParty, Army.ArmyTypes missionType, bool isCalculatingForNewArmyCreation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateDistanceScoreForBesieging(Settlement targetSettlement, MobileParty mobileParty, out MobileParty.NavigationType bestNavigationType, out float bestDistanceScore, out bool isFromPort, out bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetDistanceScoreForRaiding(Settlement targetSettlement, MobileParty mobileParty, out MobileParty.NavigationType bestNavigationType, out float bestDistanceScore, out bool isFromPort, out bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetDistanceScoreForDefending(Settlement targetSettlement, MobileParty mobileParty, out MobileParty.NavigationType bestNavigationType, out float bestDistanceScore, out bool isFromPort, out bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateMilitaryBehaviorForSettlement(Settlement settlement, Army.ArmyTypes missionType, AiBehavior aiBehavior, PartyThinkParams p, float ourStrength, float partySizeScore, float cohesionScore, float foodScore, float newArmyCreatingAdditionalConstant = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AiMilitaryBehavior()
	{
		throw null;
	}
}
