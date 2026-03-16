using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class DesertersCampaignBehavior : CampaignBehaviorBase
{
	public const int MinimumDeserterPartyCount = 15;

	public const int MaximumDeserterPartyCount = 40;

	private const int MaxDeserterPartyCountAfterBattle = 3;

	private const int MaxDeserterPartyCountAfterArmyBattle = 5;

	private Clan _deserterClan;

	public static int MergePartiesMaxSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float DesertersSpawnRadiusAroundVillages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private Clan DeserterClan
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTickParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanPartyMerge(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MergeParties(MobileParty party, MobileParty nearbyParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanPartyGenerateDeserters(MapEventParty mapEventParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrySpawnDeserters(MapEvent mapEvent, TroopRoster routedTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetMaxDeserterPartyCountForMapEvent(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TroopRoster> GetRostersSuitableForDeserters(TroopRoster routedTroops, int maxPartyCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnDesertersParty(MapEvent mapEvent, TroopRoster troops, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<Settlement> SelectRandomSettlementsForDeserters(MapEvent mapEvent, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<Settlement> FindSettlementsAroundPoint(in CampaignVec2 point, Func<Settlement, bool> condition, MobileParty.NavigationType navCapabilities, float maxDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMaxVillageDistance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CampaignVec2 GetDeserterSpawnPosition(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeDeserterParty(MobileParty banditParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CreatePartyTrade(MobileParty banditParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GiveFoodToBanditParty(MobileParty banditParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMergeDistance(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsDeserterParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DesertersCampaignBehavior()
	{
		throw null;
	}
}
