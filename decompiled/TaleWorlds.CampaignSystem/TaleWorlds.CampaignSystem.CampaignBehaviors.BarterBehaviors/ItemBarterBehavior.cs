using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.BarterSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors.BarterBehaviors;

public class ItemBarterBehavior : CampaignBehaviorBase
{
	private class SettlementDistanceCache
	{
		private struct SettlementDistancePair : IComparable<SettlementDistancePair>
		{
			private float _distance;

			public Settlement Settlement;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public SettlementDistancePair(float distance, Settlement settlement)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public int CompareTo(SettlementDistancePair other)
			{
				throw null;
			}
		}

		private Vec2 _latestHeroPosition;

		private List<SettlementDistancePair> _sortedSettlements;

		private List<Settlement> _closestSettlements;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SettlementDistanceCache()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<Settlement> GetClosestSettlements(Vec2 position)
		{
			throw null;
		}
	}

	private const int ItemValueThreshold = 100;

	private SettlementDistanceCache _distanceCache;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckForBarters(BarterData args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateAverageItemValueInNearbySettlements(EquipmentElement itemRosterElement, PartyBase involvedParty, List<Settlement> nearbySettlements)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemBarterBehavior()
	{
		throw null;
	}
}
