using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.GameComponents;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.SaveSystem;

namespace NavalDLC.CampaignBehaviors;

public class PiratesCampaignBehavior : CampaignBehaviorBase, IPiratePatrolBehavior
{
	private class PatrolZone
	{
		[SaveableField(0)]
		public readonly CampaignVec2 Position;

		[SaveableField(1)]
		public readonly float Radius;

		public int Density
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PatrolZone(CampaignVec2 position, float radius)
		{
			throw null;
		}
	}

	private class PiratesCampaignBehaviorSaveDefiner : SaveableTypeDefiner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public PiratesCampaignBehaviorSaveDefiner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineClassTypes()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineContainerDefinitions()
		{
			throw null;
		}
	}

	private const float PirateStartGoldPerBandit = 10f;

	private const float PatrollingScore = 5f;

	private const float DefaultPatrolRadius = 20f;

	private const float WeakPirateRemovalStrengthThreshold = 0.7f;

	private Dictionary<Clan, List<PatrolZone>> _patrolZones;

	private Dictionary<MobileParty, PatrolZone> _assignedZones;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DiscardShips(MobileParty pirateParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyDestroyed(MobileParty party, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreated(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssignPatrolZones()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoaded(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUp(CampaignGameStarter starter, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryRemoveWeakPirate(MobileParty pirateParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssignPatrolZones(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool FindIdenticalZone(CampaignVec2 position, float radius, out PatrolZone zone)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PatrolZone GetClosestPatrolZone(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustAssignedPatrolZones()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPirateParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PatrolZone> GetPatrolZones(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PatrolZone> GetAllPatrolZones()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PatrolZone GetAssignedZone(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssignPartyToZone(PatrolZone zone, MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnassignPartyFromZone(PatrolZone assignedZone, MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrySpawnPirateParties(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetPirateData(Clan clan, out int pirateMemberCount, out int maximumPirateCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPirateParty(Clan clan, PatrolZone patrolZone)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CampaignVec2 GetSpawnPosition(PatrolZone zone)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetZoneDistance(PatrolZone p1, PatrolZone p2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PatrolZone GetRandomSuitableZone(Clan clan, List<PatrolZone> zones, ref int iter, ref int bestScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanSpawnPiratePartyInZone(Clan clan, PatrolZone zone)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPirateClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePirateParty(MobileParty pirateParty, Clan faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPointVisibleToPlayer(PatrolZone zone)
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
	public float GetPatrolRadius(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PiratesCampaignBehavior()
	{
		throw null;
	}
}
