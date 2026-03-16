using System.Runtime.CompilerServices;
using SandBox.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions;

public class CoverAnimalAgentComponent : AgentComponent, IFocusable
{
	private enum NavigationState
	{
		WaitingToStart,
		NoTarget,
		GoToTarget,
		AtFinalPosition
	}

	private PatrolPoint[] _patrolPoints;

	private int _currentPatrolAreaIndex;

	private Timer _waitTimer;

	private NavigationState _agentState;

	private WorldPosition _targetPosition;

	private Vec2 _targetDirection;

	private bool _targetReached;

	private float _rangeThreshold;

	public bool IsMovementStarted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAtFinalPoint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FocusableObjectType FocusableObjectType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual bool IsFocusable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CoverAnimalAgentComponent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDynamicPatrolArea(GameEntity parentPatrolPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DebugTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTargetReached()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetFrame(WorldPosition position, float rotation, float rangeThreshold = 1f, AIScriptedFrameFlags flags = (AIScriptedFrameFlags)0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveAnimalToNextPatrolPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFocusGain(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFocusLose(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetInfoTextForBeingNotInteractable(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}
}
