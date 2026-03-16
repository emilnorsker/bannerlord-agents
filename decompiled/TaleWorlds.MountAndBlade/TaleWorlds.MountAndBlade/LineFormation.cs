using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class LineFormation : IFormationArrangement
{
	[CompilerGenerated]
	private sealed class _003CGetOrderedUnitPositionIndicesAux_003Ed__102 : IEnumerable<Vec2i>, IEnumerable, IEnumerator<Vec2i>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vec2i _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private int fileIndexEnd;

		public int _003C_003E3__fileIndexEnd;

		private int fileIndexBegin;

		public int _003C_003E3__fileIndexBegin;

		private int rankIndexBegin;

		public int _003C_003E3__rankIndexBegin;

		private int rankIndexEnd;

		public int _003C_003E3__rankIndexEnd;

		private int _003CfileCount_003E5__2;

		private int _003CcenterFileIndex_003E5__3;

		private int _003CrankIndex_003E5__4;

		private int _003CfileIndexOffset_003E5__5;

		Vec2i IEnumerator<Vec2i>.Current
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
		public _003CGetOrderedUnitPositionIndicesAux_003Ed__102(int _003C_003E1__state)
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
		IEnumerator<Vec2i> IEnumerable<Vec2i>.GetEnumerator()
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
	private sealed class _003CGetUnavailableUnitPositions_003Ed__107 : IEnumerable<Vec2>, IEnumerable, IEnumerator<Vec2>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vec2 _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public LineFormation _003C_003E4__this;

		private int _003CfileIndex_003E5__2;

		private int _003CrankIndex_003E5__3;

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
		public _003CGetUnavailableUnitPositions_003Ed__107(int _003C_003E1__state)
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
	private sealed class _003C_003Ec__DisplayClass116_0
	{
		public Func<IFormationUnit, bool> currentCondition;

		public Func<IFormationUnit, bool> _003C_003E9__0;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass116_0()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal bool _003CGetUnitsToPopWithCondition_003Eb__0(IFormationUnit uu)
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetUnitsToPopWithCondition_003Ed__116 : IEnumerable<IFormationUnit>, IEnumerable, IEnumerator<IFormationUnit>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IFormationUnit _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Func<IFormationUnit, bool> currentCondition;

		public Func<IFormationUnit, bool> _003C_003E3__currentCondition;

		public LineFormation _003C_003E4__this;

		private int count;

		public int _003C_003E3__count;

		private _003C_003Ec__DisplayClass116_0 _003C_003E8__1;

		private IEnumerator<IFormationUnit> _003C_003E7__wrap1;

		private int _003Ci_003E5__3;

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
		public _003CGetUnitsToPopWithCondition_003Ed__116(int _003C_003E1__state)
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

	protected const int UnitPositionAvailabilityValueOfUnprocessed = 0;

	protected const int UnitPositionAvailabilityValueOfUnavailable = 1;

	protected const int UnitPositionAvailabilityValueOfAvailable = 2;

	private static readonly Vec2i InvalidPositionIndex;

	protected readonly IFormation owner;

	private MBList2D<IFormationUnit> _units2D;

	private MBList2D<IFormationUnit> _units2DWorkspace;

	private MBList<IFormationUnit> _allUnits;

	private bool _isBatchRemovingUnits;

	private readonly List<int> _gapFillMinRanksPerFileForBatchRemove;

	private bool _batchRemoveInvolvesUnavailablePositions;

	private MBList<IFormationUnit> _unpositionedUnits;

	protected MBList2D<int> UnitPositionAvailabilities;

	private MBList2D<int> _unitPositionAvailabilitiesWorkspace;

	private MBList2D<WorldPosition> _globalPositions;

	private MBList2D<WorldPosition> _globalPositionsWorkspace;

	private readonly MBWorkspace<MBQueue<(IFormationUnit, int, int)>> _displacedUnitsWorkspace;

	private readonly MBWorkspace<MBArrayList<Vec2i>> _finalOccupationsWorkspace;

	private readonly MBWorkspace<MBQueue<Vec2i>> _toBeFilledInGapsWorkspace;

	private readonly MBWorkspace<MBArrayList<Vec2i>> _finalVacanciesWorkspace;

	private readonly MBWorkspace<MBArrayList<Vec2i>> _filledInGapsWorkspace;

	private readonly MBWorkspace<MBArrayList<Vec2i>> _toBeEmptiedOutUnitPositionsWorkspace;

	private MBArrayList<bool> _filledInUnitPositionsTable;

	private MBArrayList<Vec2i> _cachedOrderedUnitPositionIndices;

	private MBArrayList<Vec2i> _cachedOrderedAndAvailableUnitPositionIndices;

	private MBArrayList<Vec2> _cachedOrderedLocalPositions;

	private Func<LineFormation, int, int, bool> _shiftUnitsBackwardsPredicateDelegate;

	private Func<LineFormation, int, int, bool> _shiftUnitsForwardsPredicateDelegate;

	private bool _isCavalry;

	private bool _isStaggered;

	private readonly bool _isDeformingOnWidthChange;

	private bool _isMiddleFrontUnitPositionReserved;

	protected bool IsTransforming;

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

	public bool AreLocalPositionsDirty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
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

	public virtual float IntervalMultiplier
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

	public virtual float DistanceMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected float UnitDiameter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual float Width
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

	public virtual float Depth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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

	private int MinimumFileCount
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

	public float MinimumFlankWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual float MinimumWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float MinimumInterval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual float MaximumWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsStaggered
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

	public virtual bool? IsLoose
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool PostponeReconstructUnitsFromUnits2D
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
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
	public int GetFileCountFromWidth(float width)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected int GetUnitCountWithOverride()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LineFormation(IFormation ownerFormation, bool isStaggered = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected LineFormation(IFormation ownerFormation, bool isDeformingOnWidthChange, bool isStaggered = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual IFormationArrangement Clone(IFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void DeepCopyFrom(IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool IsUnitPositionRestrained(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void MakeRestrainedPositionsUnavailable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected IFormationUnit GetUnitAt(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUnitPositionAvailable(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2i GetNearestAvailableNeighbourPositionIndex(int fileIndex, int rankIndex)
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
	private static Vec2i GetOrderedUnitPositionIndexAux(int fileIndexBegin, int fileIndexEnd, int rankIndexBegin, int rankIndexEnd, int unitIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2i GetOrderedUnitPositionIndex(int unitIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetOrderedUnitPositionIndicesAux_003Ed__102))]
	private static IEnumerable<Vec2i> GetOrderedUnitPositionIndicesAux(int fileIndexBegin, int fileIndexEnd, int rankIndexBegin, int rankIndexEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IEnumerable<Vec2i> GetOrderedUnitPositionIndices()
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
	[IteratorStateMachine(typeof(_003CGetUnavailableUnitPositions_003Ed__107))]
	public IEnumerable<Vec2> GetUnavailableUnitPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InsertUnit(IFormationUnit unit, int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AddUnit(IFormationUnit unit)
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
	public List<IFormationUnit> GetUnitsToPop(int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PickUnitsWithRespectToPosition(Agent agent, float distanceSquared, ref LinkedList<Tuple<IFormationUnit, float>> collection, ref List<IFormationUnit> chosenUnits, int countToChoose, bool chooseClosest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetUnitsToPopWithCondition_003Ed__116))]
	public IEnumerable<IFormationUnit> GetUnitsToPopWithCondition(int count, Func<IFormationUnit, bool> currentCondition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryToKeepDepth()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<IFormationUnit> GetUnitsToPop(int count, Vec3 targetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveUnit(IFormationUnit unit, bool fillInTheGap, bool isRemovingFromAnUnavailablePosition = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool TryGetUnitPositionIndexFromLocalPosition(Vec2 localPosition, out int fileIndex, out int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual Vec2 GetLocalPositionOfUnit(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual Vec2 GetLocalPositionOfUnitWithAdjustment(int fileIndex, int rankIndex, float distanceBetweenAgentsAdjustment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual Vec2 GetLocalDirectionOfUnit(int fileIndex, int rankIndex)
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
	public virtual Vec2? GetLocalDirectionOfUnitOrDefault(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition? GetWorldPositionOfUnitOrDefault(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReconstructUnitsFromUnits2D()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillInTheGapsOfFormationAfterRemove(bool hasUnavailablePositions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WidenFormation(LineFormation formation, int fileCountFromBothFlanks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WidenFormation(LineFormation formation, int fileCountFromLeftFlank, int fileCountFromRightFlank)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetToBeFilledInAndToBeEmptiedOutUnitPositions(LineFormation formation, MBQueue<Vec2i> toBeFilledInUnitPositions, MBArrayList<Vec2i> toBeEmptiedOutUnitPositions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec2i GetUnitPositionForFillInFromNearby(LineFormation formation, int relocationFileIndex, int relocationRankIndex, Func<LineFormation, int, int, bool> predicate, bool isRelocationUnavailable = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec2i GetUnitPositionForFillInFromNearby(LineFormation formation, int relocationFileIndex, int relocationRankIndex, Func<LineFormation, int, int, bool> predicate, Vec2i lastFinalOccupation, bool isRelocationUnavailable = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ShiftUnitsForwardsForWideningFormation(LineFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void DeepenFormation(LineFormation formation, int rankCountFromFront, int rankCountFromRear)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool IsDeepenApplicable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Deepen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DeepenForVacancy(LineFormation formation, int requestedVacancyCount, int fileOffsetFromLeftFlank, int fileOffsetFromRightFlank)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool IsNarrowApplicable(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void NarrowFormation(LineFormation formation, int fileCountFromBothFlanks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool ShiftUnitsBackwardsForNewUnavailableUnitPositions(LineFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ShiftUnitsBackwardsForNarrowingFormation(LineFormation formation, int fileCountFromLeftFlank, int fileCountFromRightFlank)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ShiftUnitsBackwardsAux(LineFormation formation, MBQueue<(IFormationUnit, int, int)> displacedUnits, MBArrayList<Vec2i> finalOccupations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void NarrowFormation(LineFormation formation, int fileCountFromLeftFlank, int fileCountFromRightFlank)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void NarrowFormationAux(LineFormation formation, int fileCountFromLeftFlank, int fileCountFromRightFlank)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ShortenFormation(LineFormation formation, int front, int rear)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Shorten()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetFrontAndRearOfFile(int fileIndex, out bool isFileEmtpy, out int rankIndexOfFront, out int rankIndexOfRear, bool includeUnavailablePositions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetFlanksOfRank(int rankIndex, out bool isRankEmpty, out int fileIndexOfLeftFlank, out int fileIndexOfRightFlank, bool includeUnavailablePositions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FillInTheGapsOfFile(LineFormation formation, int fileIndex, int rankIndex = 0, bool isCheckingLastRankForEmptiness = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FillInTheGapsOfFileAux(LineFormation formation, int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FillInTheGapsOfMiddleRanks(LineFormation formation, List<IFormationUnit> relocatedUnits = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AlignRankToLeft(LineFormation formation, int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AlignRankToRight(LineFormation formation, int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AlignLastRank(LineFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CountUnitsAtRank(int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsRankEmpty(int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsFileFullyOccupied(int fileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsRankFullyOccupied(int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static IFormationUnit GetUnitToFillIn(LineFormation formation, int relocationFileIndex, int relocationRankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void RelocateUnit(IFormationUnit unit, int fileIndex, int rankIndex)
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
	public void GetFormationInfo(out int fileCount, out int rankCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void AssertUnit(IFormationUnit unit, bool isAssertingUnitPositionAvailability = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void AssertUnpositionedUnit(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetUnitsDistanceToFrontLine(IFormationUnit unit)
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
	public void SwitchUnitLocationsWithUnpositionedUnit(IFormationUnit firstUnit, IFormationUnit secondUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchUnitLocations(IFormationUnit firstUnit, IFormationUnit secondUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchUnitLocationsWithBackMostUnit(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeforeFormationFrameChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BatchUnitPositionAvailabilities(bool isUpdatingCachedOrderedLocalPositions = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationFrameChanged(bool updateCachedOrderedLocalPositions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TryReaddingUnpositionedUnits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreLastRanksCompletelyUnavailable(int numberOfRanksToCheck = 3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateLocalPositionErrors(bool recalculateErrors)
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
	private void AssertFilePositions(int fileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void AssertRankPositions(int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationDispersed()
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
	public virtual void TurnBackwards()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetOccupationWidth(int unitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvalidateCacheOfUnitAux(Vec2 roundedLocalPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2? CreateNewPosition(int unitIndex)
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
	public static float CalculateWidth(float interval, float unitDiameter, int unitCountOnLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormFromFlankWidth(int unitCountOnLine, bool skipSingleFileChangesForPerformance = false)
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
	private Vec2i GetMiddleFrontUnitPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetLocalPositionOfReservedUnitPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnTickOccasionallyOfUnit(IFormationUnit unit, bool arrangementChangeAllowed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetDirectionChangeTendencyOfUnit(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCachedOrderedAndAvailableUnitPositionIndicesCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2i GetCachedOrderedAndAvailableUnitPositionIndexAt(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetGlobalPositionAtIndex(int indexX, int indexY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LineFormation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFormationArrangement.GetAllUnits(in MBList<IFormationUnit> allUnitsListToBeFilledIn)
	{
		throw null;
	}
}
