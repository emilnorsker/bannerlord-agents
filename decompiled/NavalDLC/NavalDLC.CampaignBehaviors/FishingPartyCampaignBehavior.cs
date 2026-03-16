using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.CampaignBehaviors;

public class FishingPartyCampaignBehavior : CampaignBehaviorBase
{
	private ItemObject Fish;

	private int[] _invalidFishingTerrainTypes;

	private const float FishingZoneThreatClosenessDistanceSquared = 16f;

	private const float MinDistanceForInteractionSquared = 0.01f;

	private const int MinFishCountToDropOff = 5;

	private const float MinFishingTimeInHours = 8f;

	private const float MaxFishingTimeInHours = 10f;

	private const float MinRoamingTimeInDays = 1f;

	private const float MaxRoamingTimeInDays = 3f;

	private const float MaxFishToCatchPerHour = 1f;

	private float _maxDistanceBetweenPointsInFishingSpots
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float _minDistanceBetweenPointsInFishingSpots
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanHaveFishingParties(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanCreateFishingParties(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float EndingRoamingChance(FishingPartyComponent fishingParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float EndingFishingChance(FishingPartyComponent fishingParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetIdealFishingPartySize(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetIdealFishingPartyCount(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCachedData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameEarlyLoaded(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDailySettlementTick(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreated(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryReinforceParty(FishingPartyComponent fishingParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CatchFish(FishingPartyComponent fishingParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHourlyTickParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDropOff(FishingPartyComponent fishingParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartRoaming(FishingPartyComponent fishingParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartDropOff(FishingPartyComponent fishingParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GoToNewFishingPoint(FishingPartyComponent fishingParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("show_drop_off", "campaign")]
	public static string show_drop_off(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FishingPartyCampaignBehavior()
	{
		throw null;
	}
}
