using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class MissionCombatantsLogic : MissionLogic
{
	[CompilerGenerated]
	private sealed class _003CGetAllCombatants_003Ed__13 : IEnumerable<IBattleCombatant>, IEnumerable, IEnumerator<IBattleCombatant>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IBattleCombatant _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public MissionCombatantsLogic _003C_003E4__this;

		private IEnumerator<IBattleCombatant> _003C_003E7__wrap1;

		IBattleCombatant IEnumerator<IBattleCombatant>.Current
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
		public _003CGetAllCombatants_003Ed__13(int _003C_003E1__state)
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
		IEnumerator<IBattleCombatant> IEnumerable<IBattleCombatant>.GetEnumerator()
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

	protected readonly IEnumerable<IBattleCombatant> BattleCombatants;

	protected readonly IBattleCombatant PlayerBattleCombatant;

	protected readonly IBattleCombatant DefenderLeaderBattleCombatant;

	protected readonly IBattleCombatant AttackerLeaderBattleCombatant;

	protected readonly Mission.MissionTeamAITypeEnum TeamAIType;

	protected readonly bool IsPlayerSergeant;

	public BattleSideEnum PlayerSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionCombatantsLogic(IEnumerable<IBattleCombatant> battleCombatants, IBattleCombatant playerBattleCombatant, IBattleCombatant defenderLeaderBattleCombatant, IBattleCombatant attackerLeaderBattleCombatant, Mission.MissionTeamAITypeEnum teamAIType, bool isPlayerSergeant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Banner GetBannerForSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetAllCombatants_003Ed__13))]
	public IEnumerable<IBattleCombatant> GetAllCombatants()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddPlayerTeam(BattleSideEnum playerSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddEnemyTeam(BattleSideEnum enemySide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddPlayerAllyTeam(BattleSideEnum playerSide, IBattleCombatant allyCombatant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SupportsAllyTeamOnPlayerSide(IEnumerable<IBattleCombatant> playerSideBattleCombatants, IBattleCombatant playerBattleCombatant, bool isPlayerSergeant, out IBattleCombatant allyCombatant)
	{
		throw null;
	}
}
