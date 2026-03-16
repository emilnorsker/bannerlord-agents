using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.Party;

public class PartyScreenData : IEnumerable<(TroopRosterElement, bool)>, IEnumerable
{
	[CompilerGenerated]
	private sealed class _003CEnumerateElements_003Ed__41 : IEnumerator<(TroopRosterElement, bool)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (TroopRosterElement, bool) _003C_003E2__current;

		public PartyScreenData _003C_003E4__this;

		private int _003Ci_003E5__2;

		(TroopRosterElement, bool) IEnumerator<(TroopRosterElement, bool)>.Current
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
		public _003CEnumerateElements_003Ed__41(int _003C_003E1__state)
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
	}

	public TroopRoster RightMemberRoster;

	public TroopRoster LeftMemberRoster;

	public TroopRoster RightPrisonerRoster;

	public TroopRoster LeftPrisonerRoster;

	public ItemRoster RightItemRoster;

	public Dictionary<CharacterObject, int> RightRecruitableData;

	public int PartyGoldChangeAmount;

	public (int, int, int) PartyInfluenceChangeAmount;

	public int PartyMoraleChangeAmount;

	public int PartyHorseChangeAmount;

	public List<Tuple<CharacterObject, CharacterObject, int>> UpgradedTroopsHistory;

	public List<Tuple<CharacterObject, int>> TransferredPrisonersHistory;

	public List<Tuple<CharacterObject, int>> RecruitedPrisonersHistory;

	public List<Tuple<EquipmentElement, int>> UsedUpgradeHorsesHistory;

	public PartyBase RightParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public PartyBase LeftParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public Hero RightPartyLeaderHero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public Hero LeftPartyLeaderHero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyScreenData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeCopyFrom(PartyBase rightParty, PartyBase leftParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyFromPartyAndRoster(TroopRoster rightPartyMemberRoster, TroopRoster rightPartyPrisonerRoster, TroopRoster leftPartyMemberRoster, TroopRoster leftPartyPrisonerRoster, PartyBase rightParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyFromScreenData(PartyScreenData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BindRostersFrom(TroopRoster rightPartyMemberRoster, TroopRoster rightPartyPrisonerRoster, TroopRoster leftPartyMemberRoster, TroopRoster leftPartyPrisonerRoster, PartyBase rightParty, PartyBase leftParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<Tuple<Hero, PartyRole>> GetPartyHeroesWithPerks(TroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetUsing(PartyScreenData partyScreenData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsThereAnyTroopTradeDifferenceBetween(PartyScreenData other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<TroopTradeDifference> GetTroopTradeDifferencesFromTo(PartyScreenData toPartyScreenData, PartyScreenLogic.PartyRosterSide side = PartyScreenLogic.PartyRosterSide.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<(TroopRosterElement, bool)> GetLeftSideElements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CEnumerateElements_003Ed__41))]
	private IEnumerator<(TroopRosterElement, bool)> EnumerateElements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerator<(TroopRosterElement, bool)> GetEnumerator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(PartyScreenData a, PartyScreenData b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(PartyScreenData first, PartyScreenData second)
	{
		throw null;
	}
}
