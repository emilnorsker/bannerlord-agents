using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class ColumnFormation : IFormationArrangement
{
	[CompilerGenerated]
	private sealed class _003CGetOrderedUnitPositionIndices_003Ed__80 : IEnumerable<(int, int)>, IEnumerable, IEnumerator<(int, int)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (int, int) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public ColumnFormation _003C_003E4__this;

		private int _003CrankIndex_003E5__2;

		private int _003CcolumnIndex_003E5__3;

		(int, int) IEnumerator<(int, int)>.Current
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
		public _003CGetOrderedUnitPositionIndices_003Ed__80(int _003C_003E1__state)
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
		IEnumerator<(int, int)> IEnumerable<(int, int)>.GetEnumerator()
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
	private sealed class _003CGetUnitsToPopWithCondition_003Ed__93 : IEnumerable<IFormationUnit>, IEnumerable, IEnumerator<IFormationUnit>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IFormationUnit _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public ColumnFormation _003C_003E4__this;

		private Func<IFormationUnit, bool> currentCondition;

		public Func<IFormationUnit, bool> _003C_003E3__currentCondition;

		private int count;

		public int _003C_003E3__count;

		private int _003CrankIndex_003E5__2;

		private int _003CcolumnIndex_003E5__3;

		IFormationUnit IEnumerator<IFormationUnit>.Current
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
		public _003CGetUnitsToPopWithCondition_003Ed__93(int _003C_003E1__state)
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
		IEnumerator<IFormationUnit> IEnumerable<IFormationUnit>.GetEnumerator()
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
	private sealed class _003CGetUnavailableUnitPositions_003Ed__101 : IEnumerable<Vec2>, IEnumerable, IEnumerator<Vec2>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vec2 _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		Vec2 IEnumerator<Vec2>.Current
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
		public _003CGetUnavailableUnitPositions_003Ed__101(int _003C_003E1__state)
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
		IEnumerator<Vec2> IEnumerable<Vec2>.GetEnumerator()
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
	private sealed class _003CGetUnitsAtVanguardFile_003Ed__143<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable where T : IFormationUnit
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public ColumnFormation _003C_003E4__this;

		private int _003CfileIndex_003E5__2;

		private int _003CrankIndex_003E5__3;

		T IEnumerator<T>.Current
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
		public _003CGetUnitsAtVanguardFile_003Ed__143(int _003C_003E1__state)
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
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
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

	public static readonly int ArrangementAspectRatio;

	private readonly IFormation owner;

	private IFormationUnit _vanguard;

	private MBList2D<IFormationUnit> _units2D;

	private MBList2D<IFormationUnit> _units2DWorkspace;

	private MBList<IFormationUnit> _allUnits;

	private bool isExpandingFromRightSide;

	private bool IsMiddleFrontUnitPositionReserved;

	private bool _isMiddleFrontUnitPositionUsedByVanguardInFormation;

	public IFormationUnit Vanguard
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public int ColumnCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	protected int FileCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int RankCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int VanguardFileIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected float Distance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DistanceMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected float Interval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float IntervalMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float FlankWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public List<Vec2> UnitPositionsOnVanguardFileIndex
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

	public float Depth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RankDepth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MinimumWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaximumWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MinimumFlankWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool? IsLoose
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int UnitCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int PositionedUnitCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IFormationArrangement.AreLocalPositionsDirty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public event Action OnWidthChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnShapeChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ColumnFormation(IFormation ownerFormation, IFormationUnit vanguard = null, int columnCount = 1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFormationArrangement Clone(IFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeepCopyFrom(IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFormationUnit GetPlayerUnit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<IFormationUnit> GetAllUnits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllUnits(in MBList<IFormationUnit> allUnitsListToBeFilledIn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList<IFormationUnit> GetUnpositionedUnits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsUnitPositionAvailable(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetNextVacancy(out int fileIndex, out int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IFormationUnit GetLastUnit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Deepen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReconstructUnitsFromUnits2D()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Deepen(ColumnFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Shorten()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Shorten(ColumnFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AddUnit(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IFormationUnit TryGetUnit(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustFollowDataOfUnitPosition(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShiftUnitsForward(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShiftUnitsBackwardForMakingRoomForVanguard(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsLastRankEmpty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveUnit(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFormationUnit GetUnit(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBatchRemoveStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBatchRemoveEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void AssertUnitPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void AssertUnit(IFormationUnit unit, bool isAssertingFollowed = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetColumnOffsetFromColumnIndex(int columnIndex, bool isExpandingFromRightSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IFormationUnit GetUnitToFollow(IFormationUnit unit, out int columnOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetOrderedUnitPositionIndices_003Ed__80))]
	private IEnumerable<(int, int)> GetOrderedUnitPositionIndices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 GetLocalPositionOfUnit(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 GetLocalDirectionOfUnit(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorldPosition? GetWorldPositionOfUnit(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? GetLocalPositionOfUnitOrDefault(int unitIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? GetLocalDirectionOfUnitOrDefault(int unitIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition? GetWorldPositionOfUnitOrDefault(int unitIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? GetLocalPositionOfUnitOrDefault(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? GetLocalPositionOfUnitOrDefaultWithAdjustment(IFormationUnit unit, float distanceBetweenAgentsAdjustment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition? GetWorldPositionOfUnitOrDefault(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? GetLocalDirectionOfUnitOrDefault(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<IFormationUnit> GetUnitsToPop(int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<IFormationUnit> GetUnitsToPop(int count, Vec3 targetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetUnitsToPopWithCondition_003Ed__93))]
	public IEnumerable<IFormationUnit> GetUnitsToPopWithCondition(int count, Func<IFormationUnit, bool> currentCondition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchUnitLocations(IFormationUnit firstUnit, IFormationUnit secondUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SwitchUnitLocationsAux(IFormationUnit firstUnit, IFormationUnit secondUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchUnitLocationsWithUnpositionedUnit(IFormationUnit firstUnit, IFormationUnit secondUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchUnitLocationsWithBackMostUnit(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetUnitsDistanceToFrontLine(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? GetLocalDirectionOfRelativeFormationLocation(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? GetLocalWallDirectionOfRelativeFormationLocation(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetUnavailableUnitPositions_003Ed__101))]
	public IEnumerable<Vec2> GetUnavailableUnitPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetOccupationWidth(int unitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? CreateNewPosition(int unitIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvalidateCacheOfUnitAux(Vec2 roundedLocalPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeforeFormationFrameChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationFrameChanged(bool updateCachedOrderedLocalPositions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 CalculateArrangementOrientation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUnitLostMount(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTurnBackwardsNecessary(Vec2 previousPosition, WorldPosition? newPosition, Vec2 previousDirection, bool hasNewDirection, Vec2? newDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TurnBackwards()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationDispersed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void RearrangeFrom(IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void RearrangeTo(IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void RearrangeTransferUnits(IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetVanguard(IFormationUnit vanguard)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected int GetUnitCountWithOverride()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetColumnCount(int columnCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormFromWidth(float width)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFormationUnit GetNeighborUnitOfLeftSide(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IFormationUnit GetNeighborUnitOfRightSide(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReserveMiddleFrontUnitPosition(IFormationUnit vanguard)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseMiddleFrontUnitPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (int, int) GetMiddleFrontUnitPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetLocalPositionOfReservedUnitPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTickOccasionallyOfUnit(IFormationUnit unit, bool arrangementChangeAllowed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBList<IFormationUnit> GetUnitsBehind(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SwitchUnitIfLeftBehind(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetUnitToFollow(IFormationUnit unit, IFormationUnit unitToFollow, int columnOffset = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 GetFollowVector(int columnOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetDirectionChangeTendencyOfUnit(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBList<IFormationUnit> GetUnitsAtRanks(int rankIndex1, int rankIndex2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetUnitsAtVanguardFile_003Ed__143<>))]
	public IEnumerable<T> GetUnitsAtVanguardFile<T>() where T : IFormationUnit
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateLocalPositionErrors(bool recalculateErrors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Vec2> GetUnitPositionsOnVanguardFileIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ColumnFormation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFormationArrangement.GetAllUnits(in MBList<IFormationUnit> allUnitsListToBeFilledIn)
	{
		throw null;
	}
}
