using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Objects.Usables;

public class ClimbingMachine : UsableMachine
{
	private const float ClimbingEndDisplacement = 0.3f;

	private const float ClimbingSpeed = 1.4f;

	private const float EndingAnimationTriggerDifference = 1.8f;

	private const string ClimbingLoopActionName = "act_climb_net";

	private const string ClimbingEndActionName = "act_climb_net_ending";

	private const string ClimbingEndContinueActionName = "act_climb_net_ending_continue";

	private ActionIndexCache _climbingLoop;

	private ActionIndexCache _climbingEnd;

	private ActionIndexCache _climbingEndContinue;

	private GameEntity _climbEndingPoint;

	private float _usageDuration;

	public override float SinkingReferenceOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUseAction(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClimbingMachine()
	{
		throw null;
	}
}
