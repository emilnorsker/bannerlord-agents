using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace Helpers;

public static class SettlementHelper
{
	[CompilerGenerated]
	private sealed class _003CGetAllHeroesOfSettlement_003Ed__25 : IEnumerable<Hero>, IEnumerable, IEnumerator<Hero>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Hero _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Settlement settlement;

		public Settlement _003C_003E3__settlement;

		private bool includePrisoners;

		public bool _003C_003E3__includePrisoners;

		private List<MobileParty>.Enumerator _003C_003E7__wrap1;

		private List<Hero>.Enumerator _003C_003E7__wrap2;

		private List<TaleWorlds.CampaignSystem.Roster.TroopRosterElement>.Enumerator _003C_003E7__wrap3;

		Hero IEnumerator<Hero>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetAllHeroesOfSettlement_003Ed__25(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally2()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally3()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Hero> IEnumerable<Hero>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	private static readonly string[] StuffToCarryForMan;

	private static readonly string[] StuffToCarryForWoman;

	private static int _stuffToCarryIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetRandomStuff(bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindNearestSettlementToSettlement(Settlement fromSettlement, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindNearestSettlementToMobileParty(MobileParty mobileParty, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindNearestSettlementToPoint(in CampaignVec2 point, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hideout FindNearestHideoutToSettlement(Settlement fromSettlement, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hideout FindNearestHideoutToMobileParty(MobileParty fromMobileParty, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Town FindNearestTownToSettlement(Settlement fromSettlement, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Town FindNearestTownToMobileParty(MobileParty mobileParty, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindNextSettlementAroundMobileParty(MobileParty mobileParty, MobileParty.NavigationType navCapabilities, float maxDistance, int lastIndex, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindNearestCastleToSettlement(Settlement fromSettlement, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindNearestCastleToMobileParty(MobileParty mobileParty, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindNearestFortificationToSettlement(Settlement fromSettlement, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindNearestFortificationToMobileParty(MobileParty mobileParty, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindFurthestFortificationToSettlement(MBReadOnlyList<Town> candidates, MobileParty.NavigationType navCapabilities, Settlement fromSettlement, out float furthestDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Village FindNearestVillageToSettlement(Settlement fromSettlement, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Village FindNearestVillageToMobileParty(MobileParty fromParty, MobileParty.NavigationType navCapabilities, Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Settlement FindRandomInternal(Func<Settlement, bool> condition, IEnumerable<Settlement> settlementsToIterate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindRandomSettlement(Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindRandomHideout(Func<Settlement, bool> condition = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TakeEnemyVillagersOutsideSettlements(Settlement settlementWhichChangedFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement GetRandomTown(Clan fromFaction = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement GetBestSettlementToSpawnAround(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetAllHeroesOfSettlement_003Ed__25))]
	public static IEnumerable<Hero> GetAllHeroesOfSettlement(Settlement settlement, bool includePrisoners)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsGarrisonStarving(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SpawnNotablesIfNeeded(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExplainedNumber GetGarrisonChangeExplainedNumber(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetNeighborScoreForConsideringClan(Settlement settlement, Clan consideringClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SettlementHelper()
	{
		throw null;
	}
}
