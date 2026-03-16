using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public struct ArrangementOrder
{
	public enum ArrangementOrderEnum
	{
		Circle,
		Column,
		Line,
		Loose,
		Scatter,
		ShieldWall,
		Skein,
		Square
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public WorldPosition center;

		public float distanceMultiplied;

		public int count;

		public List<WorldPosition> positions;

		public Scene scene;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass19_0()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal WorldPosition _003CCreateStrategicAreas_003Eb__0()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal WorldPosition[] _003CCreateStrategicAreas_003Eb__1()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCreateStrategicAreas_003Ed__19 : IEnumerable<StrategicArea>, IEnumerable, IEnumerator<StrategicArea>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private StrategicArea _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private WorldPosition center;

		public WorldPosition _003C_003E3__center;

		private int count;

		public int _003C_003E3__count;

		private Mission mission;

		public Mission _003C_003E3__mission;

		private float distance;

		public float _003C_003E3__distance;

		private WorldPosition target;

		public WorldPosition _003C_003E3__target;

		private _003C_003Ec__DisplayClass19_0 _003C_003E8__1;

		private float width;

		public float _003C_003E3__width;

		private int capacity;

		public int _003C_003E3__capacity;

		private BattleSideEnum side;

		public BattleSideEnum _003C_003E3__side;

		private Vec2 _003Cdirection_003E5__2;

		private List<WorldPosition>.Enumerator _003C_003E7__wrap2;

		StrategicArea IEnumerator<StrategicArea>.Current
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
		public _003CCreateStrategicAreas_003Ed__19(int _003C_003E1__state)
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
		IEnumerator<StrategicArea> IEnumerable<StrategicArea>.GetEnumerator()
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

	private float? _walkRestriction;

	private float? _runRestriction;

	private int _unitSpacing;

	public readonly ArrangementOrderEnum OrderEnum;

	public static readonly ArrangementOrder ArrangementOrderCircle;

	public static readonly ArrangementOrder ArrangementOrderColumn;

	public static readonly ArrangementOrder ArrangementOrderLine;

	public static readonly ArrangementOrder ArrangementOrderLoose;

	public static readonly ArrangementOrder ArrangementOrderScatter;

	public static readonly ArrangementOrder ArrangementOrderShieldWall;

	public static readonly ArrangementOrder ArrangementOrderSkein;

	public static readonly ArrangementOrder ArrangementOrderSquare;

	public OrderType OrderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetUnitSpacingOf(ArrangementOrderEnum a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetUnitLooseness(ArrangementOrderEnum a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArrangementOrder(ArrangementOrderEnum orderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMovementSpeedRestriction(out float? runRestriction, out float? walkRestriction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFormationArrangement GetArrangement(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnApply(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SoftUpdate(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Agent.UsageDirection GetShieldDirectionOfUnit(Formation formation, Agent unit, ArrangementOrderEnum orderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetUnitSpacing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Rearrange(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RearrangeAux(Formation formation, bool isDirectly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TransposeLineFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCancel(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static StrategicArea CreateStrategicArea(Scene scene, WorldPosition position, Vec2 direction, float width, int capacity, BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CCreateStrategicAreas_003Ed__19))]
	private static IEnumerable<StrategicArea> CreateStrategicAreas(Mission mission, int count, WorldPosition center, float distance, WorldPosition target, float width, int capacity, BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsStrategicAreaClose(StrategicArea strategicArea, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickOccasionally(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArrangementOrderEnum GetNativeEnum()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(ArrangementOrder a1, ArrangementOrder a2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(ArrangementOrder a1, ArrangementOrder a2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnOrderPositionChanged(Formation formation, Vec2 previousOrderPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetArrangementOrderDefensiveness(ArrangementOrderEnum orderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetArrangementOrderDefensivenessChange(ArrangementOrderEnum previousOrderEnum, ArrangementOrderEnum nextOrderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float CalculateFormationDirectionEnforcingFactorForRank(int formationRankIndex, int rankCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ArrangementOrder()
	{
		throw null;
	}
}
