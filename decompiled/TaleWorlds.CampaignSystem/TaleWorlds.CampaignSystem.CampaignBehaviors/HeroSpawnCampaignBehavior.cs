using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class HeroSpawnCampaignBehavior : CampaignBehaviorBase
{
	private const float DefaultHealingPercentage = 0.015f;

	private const float MinimumScoreForSafeSettlement = 10f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUp(CampaignGameStarter starter, int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnNewGameCreated(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnHeroComesOfAge(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCompanionRemoved(Hero companion, RemoveCompanionAction.RemoveCompanionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroDailyTick(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNonBanditClanDailyTick(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrySpawnHeroesAndParties(Clan clan, bool isNewGame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CanHeroMoveToAnotherSettlement(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetHeroPartyCommandScore(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConsiderSpawningLordParties(Clan clan, bool isNewGame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float CalculateScoreToCreateParty(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Hero GetBestAvailableCommander(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MobileParty SpawnLordParty(Hero hero, bool isNewGame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GiveInitialItemsToParty(MobileParty heroParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CheckAndAssignClanLeader(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Hero CreateMinorFactionHeroFromTemplate(CharacterObject template, Clan faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SpawnMinorFactionHeroes(Clan clan, bool firstTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGovernorChanged(Town fortification, Hero oldGovernor, Hero newGovernor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HeroSpawnCampaignBehavior()
	{
		throw null;
	}
}
