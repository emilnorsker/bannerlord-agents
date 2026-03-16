using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class TradeRumorsCampaignBehavior : CampaignBehaviorBase, ITradeRumorCampaignBehavior, ICampaignBehavior
{
	[CompilerGenerated]
	private sealed class _003Cget_TradeRumors_003Ed__1 : IEnumerable<TradeRumor>, IEnumerable, IEnumerator<TradeRumor>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private TradeRumor _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public TradeRumorsCampaignBehavior _003C_003E4__this;

		private List<TradeRumor>.Enumerator _003C_003E7__wrap1;

		TradeRumor IEnumerator<TradeRumor>.Current
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
		public _003Cget_TradeRumors_003Ed__1(int _003C_003E1__state)
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
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<TradeRumor> IEnumerable<TradeRumor>.GetEnumerator()
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

	private List<TradeRumor> _tradeRumors;

	private Dictionary<Settlement, CampaignTime> _enteredSettlements;

	public IEnumerable<TradeRumor> TradeRumors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_TradeRumors_003Ed__1))]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTradeRumorIsTaken(List<TradeRumor> newRumors, Settlement sourceSettlement = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTradeRumors(List<TradeRumor> newRumors, Settlement sourceSettlement = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreated(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeleteExpiredEnteredSettlements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSettlementEntered(MobileParty mobileParty, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteExpiredRumors()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddDailyTradeRumors(int numberOfTradeRumors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TradeRumorsCampaignBehavior()
	{
		throw null;
	}
}
