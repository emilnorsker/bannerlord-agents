using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class MissionAgentLookHandler : MissionLogic
{
	private class PointOfInterest
	{
		public const int MaxSelectDistanceForAgent = 5;

		public const int MaxSelectDistanceForFrame = 4;

		private readonly int _selectDistance;

		private readonly int _releaseDistanceSquare;

		private readonly Agent _agent;

		private readonly MatrixFrame _frame;

		private readonly bool _ignoreDirection;

		private readonly int _priority;

		public bool IsActive
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PointOfInterest(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PointOfInterest(MatrixFrame frame)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetScore(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Vec3 GetTargetPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Vec3 GetBasicPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsMoving()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private MatrixFrame GetTargetFrame()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsVisibleFor(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsRelevant(Agent agent)
		{
			throw null;
		}
	}

	private class LookInfo
	{
		public readonly Agent Agent;

		public PointOfInterest PointOfInterest;

		public readonly Timer CheckTimer;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public LookInfo(Agent agent, float checkTime)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Reset(PointOfInterest pointOfInterest, float duration)
		{
			throw null;
		}
	}

	private delegate PointOfInterest SelectionDelegate(Agent agent);

	private readonly List<PointOfInterest> _staticPointList;

	private readonly List<LookInfo> _checklist;

	private SelectionDelegate _selectionDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAgentLookHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddStablePointsOfInterest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DebugTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PointOfInterest SelectFirstNonAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PointOfInterest SelectBestOfLimitedNonAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PointOfInterest SelectBest(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PointOfInterest SelectRandomAccordingToScore(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}
}
