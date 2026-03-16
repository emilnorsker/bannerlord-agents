using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class StandingPoint : UsableMissionObject
{
	public struct StackArray8StandingPoint
	{
		private StandingPoint _element0;

		private StandingPoint _element1;

		private StandingPoint _element2;

		private StandingPoint _element3;

		private StandingPoint _element4;

		private StandingPoint _element5;

		private StandingPoint _element6;

		private StandingPoint _element7;

		public const int Length = 8;

		public StandingPoint this[int index]
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
	}

	private struct AgentDistanceCache
	{
		public Vec2 AgentPosition;

		public Vec2 StandingPointPosition;

		public float PathDistance;
	}

	private enum ValidControllerType
	{
		None,
		PlayerOnly,
		AIOnly,
		PlayerOrAI
	}

	public bool AutoSheathWeapons;

	public bool AutoEquipWeaponsOnUseStopped;

	private bool _autoAttachOnUsingStopped;

	private Action<Agent, bool> _onUsingStoppedAction;

	public bool AutoWieldWeapons;

	public readonly bool TranslateUser;

	public bool HasRecentlyBeenRechecked;

	private Dictionary<Agent, AgentDistanceCache> _cachedAgentDistances;

	[EditableScriptComponentVariable(true, "")]
	private bool _useOwnPositionInsteadOfWorldPosition;

	[EditableScriptComponentVariable(true, "")]
	private float _customPlayerInteractionDistance;

	private bool _needsSingleThreadTickOnce;

	private ValidControllerType _validControllerType;

	protected BattleSideEnum StandingPointSide;

	public virtual Agent.AIScriptedFrameFlags DisableScriptedFrameFlags
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool DisableCombatActionsOnUse
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[EditableScriptComponentVariable(false, "")]
	public Agent FavoredUser
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

	public virtual bool PlayerStopsUsingWhenInteractsWithOther
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool UseOwnPositionInsteadOfWorldPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CustomPlayerInteractionDistance
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
	public void OnParentMachinePhysicsStateChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickAux(bool isParallel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTickParallel3(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool DoesActionTypeStopUsingGameObject(Agent.ActionCodeType actionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUse(Agent userAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WorldFrame GetUserFrameForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool HasAlternative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetUsageScoreForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetUsageScoreForAgent((Agent, float) agentPair)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupOnUsingStoppedBehavior(bool autoAttach, Action<Agent, bool> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetPathDistance(Agent agent, ref WorldPosition userPosition, ref WorldPosition agentPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual bool IsUsableBySide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsUsableByAgent(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsableByAIOnly()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsableByPlayerOnly()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsableByPlayerOrAI()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StandingPoint()
	{
		throw null;
	}
}
