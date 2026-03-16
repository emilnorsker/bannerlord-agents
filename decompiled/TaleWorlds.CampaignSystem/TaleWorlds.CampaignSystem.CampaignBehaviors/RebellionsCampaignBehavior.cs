using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class RebellionsCampaignBehavior : CampaignBehaviorBase
{
	private const int UpdateClanAfterDays = 30;

	private const int LoyaltyAfterRebellion = 100;

	private const int InitialRelationPenalty = -80;

	private const int InitialRelationBoostWithOtherFactions = 10;

	private const int InitialRelationBoost = 60;

	private const int InitialRelationBetweenRebelHeroes = 10;

	private const int RebelClanStartingRenownMin = 200;

	private const int RebelClanStartingRenownMax = 300;

	private const int RebelHeroAgeMin = 25;

	private const int RebelHeroAgeMax = 40;

	private const float MilitiaGarrisonRatio = 1.4f;

	private const float ThrowGarrisonTroopToPrisonPercentage = 0.5f;

	private const float ThrowMilitiaTroopToGarrisonPercentage = 0.6f;

	private const float DailyRebellionCheckChance = 0.25f;

	private Dictionary<Clan, int> _rebelClansAndDaysPassedAfterCreation;

	private Dictionary<CultureObject, Dictionary<int, int>> _cultureIconIdAndFrequencies;

	private bool _rebellionEnabled;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RebellionsCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSiegeStarted(SiegeEvent siegeEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndSetTownRebelliousState(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanDestroyed(Clan destroyedClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckRebellionEvent(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartRebellionEvent(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyRebellionConsequencesToSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateRebelPartyAndClan(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Hero CreateRebelLeader(CharacterObject templateCharacter, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Hero CreateRebelGovernor(CharacterObject templateCharacter, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Hero CreateRebelSupporterHero(CharacterObject templateCharacter, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Hero CreateRebelHeroInternal(CharacterObject templateCharacter, Settlement settlement, Dictionary<SkillObject, int> startingSkills)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetClanIdForNewRebelClan(CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeIconIdAndFrequencies()
	{
		throw null;
	}
}
