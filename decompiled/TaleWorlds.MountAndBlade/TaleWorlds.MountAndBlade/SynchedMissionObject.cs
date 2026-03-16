using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class SynchedMissionObject : MissionObject
{
	private enum SynchState
	{
		SynchronizeCompleted,
		SynchronizePosition,
		SynchronizeFrame,
		SynchronizeFrameOverTime
	}

	[Flags]
	public enum SynchFlags : uint
	{
		SynchNone = 0u,
		SynchTransform = 1u,
		SynchAnimation = 2u,
		SynchBodyFlags = 4u,
		SyncColors = 8u,
		SynchAll = uint.MaxValue
	}

	private SynchFlags _initialSynchFlags;

	private SynchState _synchState;

	private MatrixFrame _lastSynchedFrame;

	private MatrixFrame _firstFrame;

	private float _timer;

	private float _duration;

	public uint Color
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

	public uint Color2
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

	public bool SynchronizeCompleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSynchState(SynchState newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLocalPositionSmoothStep(ref Vec3 targetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetVisibleSynched(bool value, bool forceChildrenVisible = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetPhysicsStateSynched(bool value, bool setChildren = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetDisabledSynched()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFrameSynched(ref MatrixFrame frame, bool isClient = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalFrameSynched(ref MatrixFrame frame, bool isClient = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFrameSynchedOverTime(ref MatrixFrame frame, float duration, bool isClient = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalFrameSynchedOverTime(ref MatrixFrame frame, float duration, bool isClient = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnimationAtChannelSynched(string animationName, int channelNo, float animationSpeed = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnimationAtChannelSynched(int animationIndex, int channelNo, float animationSpeed = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnimationChannelParameterSynched(int channelNo, float parameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PauseSkeletonAnimationSynched()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResumeSkeletonAnimationSynched()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BurstParticlesSynched(bool doChildren = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyImpulseSynched(Vec3 localPosition, Vec3 impulse)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddBodyFlagsSynched(BodyFlags flags, bool applyToChildren = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveBodyFlagsSynched(BodyFlags flags, bool applyToChildren = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTeamColors(uint color, uint color2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetTeamColorsSynched(uint color, uint color2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void WriteToNetwork()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnAfterReadFromNetwork((BaseSynchedMissionObjectReadableRecord, ISynchedMissionObjectReadableRecord) synchedMissionObjectReadableRecord, bool allowVisibilityUpdate = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SynchedMissionObject()
	{
		throw null;
	}
}
