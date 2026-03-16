using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using SandBox.Objects.Usables;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.AgentBehaviors;

public class FleeBehavior : AgentBehavior
{
	private abstract class FleeGoalBase
	{
		protected readonly AgentNavigator _navigator;

		protected readonly Agent _ownerAgent;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected FleeGoalBase(AgentNavigator navigator, Agent ownerAgent)
		{
			throw null;
		}

		public abstract void TargetReached();

		public abstract void GoToTarget();

		public abstract bool IsGoalAchievable();

		public abstract bool IsGoalAchieved();
	}

	private class FleeAgentTarget : FleeGoalBase
	{
		public Agent Savior
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FleeAgentTarget(AgentNavigator navigator, Agent ownerAgent, Agent savior)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void GoToTarget()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsGoalAchievable()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsGoalAchieved()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void TargetReached()
		{
			throw null;
		}
	}

	private class FleePassageTarget : FleeGoalBase
	{
		public Passage EscapePortal
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FleePassageTarget(AgentNavigator navigator, Agent ownerAgent, Passage escapePortal)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void GoToTarget()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsGoalAchievable()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsGoalAchieved()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void TargetReached()
		{
			throw null;
		}
	}

	private class FleePositionTarget : FleeGoalBase
	{
		public Vec3 Position
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FleePositionTarget(AgentNavigator navigator, Agent ownerAgent, Vec3 position)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void GoToTarget()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsGoalAchievable()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsGoalAchieved()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void TargetReached()
		{
			throw null;
		}
	}

	private class FleeCoverTarget : FleeGoalBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public FleeCoverTarget(AgentNavigator navigator, Agent ownerAgent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void GoToTarget()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsGoalAchievable()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsGoalAchieved()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void TargetReached()
		{
			throw null;
		}
	}

	private enum State
	{
		None,
		Afraid,
		LookForPlace,
		Flee,
		Complain
	}

	private enum FleeTargetType
	{
		Indoor,
		Guard,
		Cover
	}

	public const float ScoreThreshold = 1f;

	public const float DangerDistance = 5f;

	public const float ImmediateDangerDistance = 2f;

	public const float DangerDistanceSquared = 25f;

	public const float ImmediateDangerDistanceSquared = 4f;

	private readonly MissionAgentHandler _missionAgentHandler;

	private readonly MissionFightHandler _missionFightHandler;

	private State _state;

	private readonly BasicMissionTimer _reconsiderFleeTargetTimer;

	private const float ReconsiderImmobilizedFleeTargetTime = 0.5f;

	private const float ReconsiderDefaultFleeTargetTime = 1f;

	private FleeGoalBase _selectedGoal;

	private BasicMissionTimer _scareTimer;

	private float _scareTime;

	private BasicMissionTimer _complainToGuardTimer;

	private const float ComplainToGuardTime = 2f;

	private FleeTargetType _selectedFleeTargetType;

	private FleeTargetType SelectedFleeTargetType
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FleeBehavior(AgentBehaviorGroup behaviorGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetDangerPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereDanger()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetPathScore(WorldPosition startWorldPos, WorldPosition targetWorldPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LookForPlace()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldChangeTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereASafePlaceToEscape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<(float, Passage)> GetAvailablePassageScores(int maxPaths = 10)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<(float, Agent)> GetAvailableGuardScores(int maxGuards = 5)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Flee()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BeAfraid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetDebugInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetAvailability(bool isSimulation)
	{
		throw null;
	}
}
