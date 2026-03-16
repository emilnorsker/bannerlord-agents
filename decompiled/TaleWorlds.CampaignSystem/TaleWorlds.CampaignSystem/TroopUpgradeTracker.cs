using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem;

public class TroopUpgradeTracker
{
	[CompilerGenerated]
	private sealed class _003CCheckSkillUpgrades_003Ed__7 : IEnumerable<SkillObject>, IEnumerable, IEnumerator<SkillObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private SkillObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public TroopUpgradeTracker _003C_003E4__this;

		private Hero hero;

		public Hero _003C_003E3__hero;

		private int[] _003ColdSkillLevels_003E5__2;

		private int _003Ci_003E5__3;

		private SkillObject _003Cskill_003E5__4;

		private int _003CnewSkillLevel_003E5__5;

		SkillObject IEnumerator<SkillObject>.Current
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
		public _003CCheckSkillUpgrades_003Ed__7(int _003C_003E1__state)
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
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<SkillObject> IEnumerable<SkillObject>.GetEnumerator()
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

	private Dictionary<Tuple<PartyBase, CharacterObject>, int> _upgradedRegulars;

	private List<MapEventParty> _mapEventParties;

	private Dictionary<Hero, int[]> _heroSkills;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TroopUpgradeTracker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddParty(MapEventParty mapEventParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveParty(MapEventParty mapEventParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTrackedTroop(PartyBase party, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CCheckSkillUpgrades_003Ed__7))]
	public IEnumerable<SkillObject> CheckSkillUpgrades(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CheckUpgradedCount(PartyBase party, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateReadyToUpgradeSafe(ref TroopRosterElement el, PartyBase owner)
	{
		throw null;
	}
}
