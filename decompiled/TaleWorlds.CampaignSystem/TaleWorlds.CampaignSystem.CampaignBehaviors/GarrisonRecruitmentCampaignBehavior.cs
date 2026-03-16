using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class GarrisonRecruitmentCampaignBehavior : CampaignBehaviorBase, IGarrisonRecruitmentBehavior
{
	public struct VolunteerTroop : IComparable
	{
		public Hero OwnerNotable;

		public int NotableVolunteerArrayIndex;

		public int Wage;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public VolunteerTroop(Hero ownerNotable, int notableVolunteerArrayIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int CompareTo(object obj)
		{
			throw null;
		}
	}

	private SortedSet<VolunteerTroop> _volunteerListCache;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static CharacterObject GetBasicTroopForTown(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDailySettlementTick(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickAutoRecruitmentGarrisonChange(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickGarrisonChangeForTown(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleGarrisonXpChange(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RepopulateVolunteerListCache(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber GetAutoRecruitmentGarrisonChangeExplainedNumber(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber GetBaseGarrisonChangeExplainedNumber(Town town, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ExplainedNumber GetGarrisonChangeExplainedNumber(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanSettlementAutoRecruit(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SettlementCheckGarrisonChangeCommonCondition(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GarrisonRecruitmentCampaignBehavior()
	{
		throw null;
	}
}
