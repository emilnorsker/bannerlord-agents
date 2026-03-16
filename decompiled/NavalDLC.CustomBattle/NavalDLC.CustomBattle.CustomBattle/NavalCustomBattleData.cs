using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.CustomBattle.CustomBattle;

public struct NavalCustomBattleData
{
	[CompilerGenerated]
	private sealed class _003Cget_PlayerSides_003Ed__12 : IEnumerable<Tuple<string, NavalCustomBattlePlayerSide>>, IEnumerable, IEnumerator<Tuple<string, NavalCustomBattlePlayerSide>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Tuple<string, NavalCustomBattlePlayerSide> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		Tuple<string, NavalCustomBattlePlayerSide> IEnumerator<Tuple<string, NavalCustomBattlePlayerSide>>.Current
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
		public _003Cget_PlayerSides_003Ed__12(int _003C_003E1__state)
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
		IEnumerator<Tuple<string, NavalCustomBattlePlayerSide>> IEnumerable<Tuple<string, NavalCustomBattlePlayerSide>>.GetEnumerator()
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
	private sealed class _003Cget_Characters_003Ed__14 : IEnumerable<BasicCharacterObject>, IEnumerable, IEnumerator<BasicCharacterObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private BasicCharacterObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		BasicCharacterObject IEnumerator<BasicCharacterObject>.Current
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
		public _003Cget_Characters_003Ed__14(int _003C_003E1__state)
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
		IEnumerator<BasicCharacterObject> IEnumerable<BasicCharacterObject>.GetEnumerator()
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
	private sealed class _003Cget_Factions_003Ed__16 : IEnumerable<BasicCultureObject>, IEnumerable, IEnumerator<BasicCultureObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private BasicCultureObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		BasicCultureObject IEnumerator<BasicCultureObject>.Current
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
		public _003Cget_Factions_003Ed__16(int _003C_003E1__state)
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
		IEnumerator<BasicCultureObject> IEnumerable<BasicCultureObject>.GetEnumerator()
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
	private sealed class _003Cget_ShipHulls_003Ed__18 : IEnumerable<ShipHull>, IEnumerable, IEnumerator<ShipHull>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ShipHull _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		ShipHull IEnumerator<ShipHull>.Current
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
		public _003Cget_ShipHulls_003Ed__18(int _003C_003E1__state)
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
		IEnumerator<ShipHull> IEnumerable<ShipHull>.GetEnumerator()
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
	private sealed class _003Cget_TimesOfDay_003Ed__20 : IEnumerable<Tuple<string, NavalCustomBattleTimeOfDay>>, IEnumerable, IEnumerator<Tuple<string, NavalCustomBattleTimeOfDay>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Tuple<string, NavalCustomBattleTimeOfDay> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		Tuple<string, NavalCustomBattleTimeOfDay> IEnumerator<Tuple<string, NavalCustomBattleTimeOfDay>>.Current
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
		public _003Cget_TimesOfDay_003Ed__20(int _003C_003E1__state)
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
		IEnumerator<Tuple<string, NavalCustomBattleTimeOfDay>> IEnumerable<Tuple<string, NavalCustomBattleTimeOfDay>>.GetEnumerator()
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
	private sealed class _003Cget_Seasons_003Ed__22 : IEnumerable<Tuple<string, string>>, IEnumerable, IEnumerator<Tuple<string, string>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Tuple<string, string> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		Tuple<string, string> IEnumerator<Tuple<string, string>>.Current
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
		public _003Cget_Seasons_003Ed__22(int _003C_003E1__state)
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
		IEnumerator<Tuple<string, string>> IEnumerable<Tuple<string, string>>.GetEnumerator()
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
	private sealed class _003Cget_WindStrengths_003Ed__24 : IEnumerable<Tuple<string, float>>, IEnumerable, IEnumerator<Tuple<string, float>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Tuple<string, float> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		Tuple<string, float> IEnumerator<Tuple<string, float>>.Current
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
		public _003Cget_WindStrengths_003Ed__24(int _003C_003E1__state)
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
		IEnumerator<Tuple<string, float>> IEnumerable<Tuple<string, float>>.GetEnumerator()
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
	private sealed class _003Cget_WindDirections_003Ed__26 : IEnumerable<Tuple<string, NavalCustomBattleWindConfig.Direction>>, IEnumerable, IEnumerator<Tuple<string, NavalCustomBattleWindConfig.Direction>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Tuple<string, NavalCustomBattleWindConfig.Direction> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		Tuple<string, NavalCustomBattleWindConfig.Direction> IEnumerator<Tuple<string, NavalCustomBattleWindConfig.Direction>>.Current
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
		public _003Cget_WindDirections_003Ed__26(int _003C_003E1__state)
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
		IEnumerator<Tuple<string, NavalCustomBattleWindConfig.Direction>> IEnumerable<Tuple<string, NavalCustomBattleWindConfig.Direction>>.GetEnumerator()
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

	public string SceneId;

	public string SeasonId;

	public BasicCharacterObject PlayerCharacter;

	public CustomBattleCombatant PlayerParty;

	public CustomBattleCombatant EnemyParty;

	public List<IShipOrigin> PlayerShips;

	public List<IShipOrigin> EnemyShips;

	public float TimeOfDay;

	public float WindStrength;

	public NavalCustomBattleWindConfig.Direction WindDirection;

	public TerrainType Terrain;

	public static IEnumerable<Tuple<string, NavalCustomBattlePlayerSide>> PlayerSides
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_PlayerSides_003Ed__12))]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<BasicCharacterObject> Characters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_Characters_003Ed__14))]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<BasicCultureObject> Factions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_Factions_003Ed__16))]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<ShipHull> ShipHulls
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_ShipHulls_003Ed__18))]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<Tuple<string, NavalCustomBattleTimeOfDay>> TimesOfDay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_TimesOfDay_003Ed__20))]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<Tuple<string, string>> Seasons
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_Seasons_003Ed__22))]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<Tuple<string, float>> WindStrengths
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_WindStrengths_003Ed__24))]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<Tuple<string, NavalCustomBattleWindConfig.Direction>> WindDirections
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_WindDirections_003Ed__26))]
		get
		{
			throw null;
		}
	}
}
