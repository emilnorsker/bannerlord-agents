using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Missions.Objectives;

public abstract class MissionObjective
{
	public struct GenericMissionObjectiveBuilder
	{
		internal GenericMissionObjective Objective;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetName(TextObject name)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetDescription(TextObject description)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetObjectiveGiver(BasicCharacterObject objectiveGiver)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetInitialTargets(params MissionObjectiveTarget[] targets)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetIsActivationRequirementsMetCallback(Func<MissionObjective, bool> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetIsCompletionRequirementsMetCallback(Func<MissionObjective, bool> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetOnStartCallback(Action<MissionObjective> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetOnCompleteCallback(Action<MissionObjective> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetOnTickCallback(Action<MissionObjective, float> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveBuilder SetProgressCallback(Func<MissionObjective, MissionObjectiveProgressInfo> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MissionObjective Build()
		{
			throw null;
		}
	}

	public struct GenericMissionObjectiveTargetBuilder<T>
	{
		internal GenericMissionObjectiveTarget<T> Target;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveTargetBuilder<T> SetIsActiveCallback(Func<T, bool> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveTargetBuilder<T> SetGetGlobalPositionCallback(Func<T, Vec3> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GenericMissionObjectiveTargetBuilder<T> SetGetNameCallback(Func<T, TextObject> callback)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MissionObjectiveTarget<T> Build()
		{
			throw null;
		}
	}

	private MBList<MissionObjectiveTarget> _targets;

	private TextObject _cachedName;

	private TextObject _cachedDescription;

	public abstract string UniqueId { get; }

	public abstract TextObject Name { get; }

	public abstract TextObject Description { get; }

	public bool IsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsStarted
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

	public bool IsCompleted
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

	public Mission Mission
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

	public BasicCharacterObject ObjectiveGiver
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

	public event Action OnUpdated
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
	public MissionObjective(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Complete()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckNameUpdates()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual MissionObjectiveProgressInfo GetCurrentProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool GetIsActivationRequirementsMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool GetIsCompletionRequirementsMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetObjectiveGiver(BasicCharacterObject objectiveGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTarget(MissionObjectiveTarget target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveTarget(MissionObjectiveTarget target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearTargets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<MissionObjectiveTarget> GetTargetsCopy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MBReadOnlyList<TTarget> GetTargetsCopy<TTarget>() where TTarget : MissionObjectiveTarget
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool IsActivationRequirementsMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool IsCompletionRequirementsMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnComplete()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnTargetAdded(MissionObjectiveTarget target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnTargetRemoved(MissionObjectiveTarget target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnTargetsCleared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GenericMissionObjectiveBuilder CreateGenericObjectiveBuilder(Mission mission, string id, TextObject name = null, TextObject description = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GenericMissionObjectiveTargetBuilder<T> CreateGenericTargetBuilder<T>(T target, TextObject name, Vec3 staticPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GenericMissionObjectiveTargetBuilder<T> CreateGenericTargetBuilder<T>(T target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GenericMissionObjectiveTargetBuilder<T> CreateGenericTargetBuilder<T>(T target, TextObject name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GenericMissionObjectiveTargetBuilder<T> CreateGenericTargetBuilder<T>(T target, Vec3 staticPosition)
	{
		throw null;
	}
}
