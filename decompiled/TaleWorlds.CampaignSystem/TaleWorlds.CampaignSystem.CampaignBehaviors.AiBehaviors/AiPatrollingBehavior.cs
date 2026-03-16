using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Siege;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors.AiBehaviors;

public class AiPatrollingBehavior : CampaignBehaviorBase
{
	private const float BasePatrolScore = 1.44f;

	private const float MinimumDistanceScore = 0.2f;

	private const float MaximumDistanceScore = 1f;

	private IDisbandPartyCampaignBehavior _disbandPartyCampaignBehavior;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBlockadeActivated(SiegeEvent siegeEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipOwnerChanged(Ship ship, PartyBase oldOwner, ChangeShipOwnerAction.ShipOwnerChangeDetail changeDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipDestroyed(PartyBase owner, Ship ship, DestroyShipAction.ShipDestroyDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckPartyIfNeeded(PartyBase party)
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
	private void AiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetDistanceScoreForNavalPatrolling(Settlement targetSettlement, MobileParty mobileParty, out float bestDistanceScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetDistanceScoreForLandPatrolling(Settlement targetSettlement, MobileParty mobileParty, float distanceToFurthestAllySettlementToFactionMidSettlement, out float bestDistanceScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculatePatrollingScoreForSettlement(Settlement settlement, PartyThinkParams p, float scoreAdjustment, bool isNavalPatrolling)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AiPatrollingBehavior()
	{
		throw null;
	}
}
