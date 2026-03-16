using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Objects;

public class FightAreaMarker : AreaMarker
{
	[CompilerGenerated]
	private sealed class _003CGetAgentsInRange_003Ed__1 : IEnumerable<Agent>, IEnumerable, IEnumerator<Agent>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Agent _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Team team;

		public Team _003C_003E3__team;

		private bool humanOnly;

		public bool _003C_003E3__humanOnly;

		public FightAreaMarker _003C_003E4__this;

		private List<Agent>.Enumerator _003C_003E7__wrap1;

		Agent IEnumerator<Agent>.Current
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
		public _003CGetAgentsInRange_003Ed__1(int _003C_003E1__state)
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
		IEnumerator<Agent> IEnumerable<Agent>.GetEnumerator()
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
	private sealed class _003CGetAgentsInRange_003Ed__2 : IEnumerable<Agent>, IEnumerable, IEnumerator<Agent>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Agent _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private BattleSideEnum side;

		public BattleSideEnum _003C_003E3__side;

		public FightAreaMarker _003C_003E4__this;

		private bool humanOnly;

		public bool _003C_003E3__humanOnly;

		private List<Team>.Enumerator _003C_003E7__wrap1;

		private IEnumerator<Agent> _003C_003E7__wrap2;

		Agent IEnumerator<Agent>.Current
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
		public _003CGetAgentsInRange_003Ed__2(int _003C_003E1__state)
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
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Agent> IEnumerable<Agent>.GetEnumerator()
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

	public int SubAreaIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetAgentsInRange_003Ed__1))]
	public IEnumerable<Agent> GetAgentsInRange(Team team, bool humanOnly = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetAgentsInRange_003Ed__2))]
	public IEnumerable<Agent> GetAgentsInRange(BattleSideEnum side, bool humanOnly = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FightAreaMarker()
	{
		throw null;
	}
}
