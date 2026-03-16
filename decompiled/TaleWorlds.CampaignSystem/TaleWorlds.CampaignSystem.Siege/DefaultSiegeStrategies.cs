using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Siege;

public class DefaultSiegeStrategies
{
	[CompilerGenerated]
	private sealed class _003Cget_AllAttackerStrategies_003Ed__24 : IEnumerable<SiegeStrategy>, IEnumerable, IEnumerator<SiegeStrategy>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private SiegeStrategy _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		SiegeStrategy IEnumerator<SiegeStrategy>.Current
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
		public _003Cget_AllAttackerStrategies_003Ed__24(int _003C_003E1__state)
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
		IEnumerator<SiegeStrategy> IEnumerable<SiegeStrategy>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003Cget_AllDefenderStrategies_003Ed__26 : IEnumerable<SiegeStrategy>, IEnumerable, IEnumerator<SiegeStrategy>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private SiegeStrategy _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		SiegeStrategy IEnumerator<SiegeStrategy>.Current
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
		public _003Cget_AllDefenderStrategies_003Ed__26(int _003C_003E1__state)
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
		IEnumerator<SiegeStrategy> IEnumerable<SiegeStrategy>.GetEnumerator()
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

	private SiegeStrategy _preserveStrength;

	private SiegeStrategy _prepareAgainstAssault;

	private SiegeStrategy _counterBombardment;

	private SiegeStrategy _prepareAssault;

	private SiegeStrategy _breachWalls;

	private SiegeStrategy _wearOutDefenders;

	private SiegeStrategy _custom;

	private static DefaultSiegeStrategies Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static SiegeStrategy PreserveStrength
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static SiegeStrategy PrepareAgainstAssault
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static SiegeStrategy CounterBombardment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static SiegeStrategy PrepareAssault
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static SiegeStrategy BreachWalls
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static SiegeStrategy WearOutDefenders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static SiegeStrategy Custom
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<SiegeStrategy> AllAttackerStrategies
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_AllAttackerStrategies_003Ed__24))]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<SiegeStrategy> AllDefenderStrategies
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_AllDefenderStrategies_003Ed__26))]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSiegeStrategies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SiegeStrategy Create(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeAll()
	{
		throw null;
	}
}
