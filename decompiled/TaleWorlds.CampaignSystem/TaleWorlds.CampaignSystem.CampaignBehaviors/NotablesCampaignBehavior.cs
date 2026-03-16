using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class NotablesCampaignBehavior : CampaignBehaviorBase
{
	private const int CaravanGoldLowLimit = 5000;

	private const int RemoveNotableCharacterAfterDays = 7;

	private Dictionary<Settlement, int> _settlementPassedDaysForWeeklyTick;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NotablesCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroCreated(Hero hero, bool isBornNaturally)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WeeklyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineRelation(Hero hero1, Hero hero2, float randomValue, float chanceOfConflict)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialRelationsBetweenNotablesAndLords()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnNewGameCreatedPartialFollowUp(CampaignGameStarter starter, int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateNotableRelations(Hero notable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateNotableSupport(Hero notable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndMakeNotableDisappear(Hero notable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ManageCaravanExpensesOfNotable(Hero notable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetNotableDisappearProbability(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeDeadNotable(Hero deadNotable, Hero newNotable, Settlement notableSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnNotablesAtGameStart()
	{
		throw null;
	}
}
