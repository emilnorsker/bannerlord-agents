using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class FoodConsumptionBehavior : CampaignBehaviorBase
{
	private int _lastItemVersion;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DailyTickParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyAttachedParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PartyConsumeFood(MobileParty mobileParty, bool starvingCheck = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SlaughterLivestock(MobileParty party, int partyRemainingFoodPercentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAnimalBreeding(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeFoodConsumption(MobileParty party, ref int partyRemainingFoodPercentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FoodConsumptionBehavior()
	{
		throw null;
	}
}
