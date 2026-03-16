using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public sealed class ManagedScriptHolder : DotNetObject
{
	private class BehaviorTickRecord
	{
		private readonly List<ScriptComponentBehavior> _scriptComponents;

		private readonly List<ScriptComponentBehavior> _addTo;

		private readonly List<ScriptComponentBehavior> _removeFrom;

		public List<ScriptComponentBehavior> ScriptComponents
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BehaviorTickRecord(int initialCapacity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void AddToRec(ScriptComponentBehavior sc)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void RemoveFromRec(ScriptComponentBehavior sc, bool checkForDoubleRemove = true)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void TickRec()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal bool ContainsOrToBeAdded(ScriptComponentBehavior sc)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal int GetWillBeRemovedCount()
		{
			throw null;
		}
	}

	private static readonly ScriptComponentBehavior.TickRequirement[] TickRequirementEnumValues;

	public object AddRemoveLockObject;

	private readonly BehaviorTickRecord _toTick;

	private readonly BehaviorTickRecord _toParallelTick;

	private readonly BehaviorTickRecord _toParallelTick2;

	private readonly BehaviorTickRecord _toParallelTick3;

	private readonly BehaviorTickRecord _toTickOccasionally;

	private readonly BehaviorTickRecord _toTickForEditor;

	private readonly BehaviorTickRecord _toFixedParallelTick;

	private readonly BehaviorTickRecord _toFixedTick;

	private int _nextIndexToTickOccasionally;

	private readonly TWParallel.ParallelForWithDtAuxPredicate TickComponentsParallelAuxMTPredicate;

	private readonly TWParallel.ParallelForWithDtAuxPredicate TickComponentsParallel2AuxMTPredicate;

	private readonly TWParallel.ParallelForWithDtAuxPredicate TickComponentsParallel3AuxMTPredicate;

	private readonly TWParallel.ParallelForWithDtAuxPredicate TickComponentsFixedParallelAuxMTPredicate;

	private readonly TWParallel.ParallelForWithDtAuxPredicate TickComponentsOccasionallyParallelAuxMTPredicate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static ManagedScriptHolder CreateManagedScriptHolder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ManagedScriptHolder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	public void SetScriptComponentHolder(ScriptComponentBehavior sc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BehaviorTickRecord GetRecordFromEnum(ScriptComponentBehavior.TickRequirement tickRecEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateTickRequirement(ScriptComponentBehavior sc, ScriptComponentBehavior.TickRequirement oldTickRequirement, ScriptComponentBehavior.TickRequirement newTickRequirement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	public void RemoveScriptComponentFromAllTickLists(ScriptComponentBehavior sc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal int GetNumberOfScripts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickComponentsParallelAuxMT(int startInclusive, int endExclusive, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickComponentsParallel2AuxMT(int startInclusive, int endExclusive, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickComponentsParallel3AuxMT(int startInclusive, int endExclusive, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickComponentsOccasionallyParallelAuxMT(int startInclusive, int endExclusive, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickComponentsFixedParallelAuxMT(int startInclusive, int endExclusive, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal void FixedTickComponents(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal void TickComponents(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal void TickComponentsEditor(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ManagedScriptHolder()
	{
		throw null;
	}
}
