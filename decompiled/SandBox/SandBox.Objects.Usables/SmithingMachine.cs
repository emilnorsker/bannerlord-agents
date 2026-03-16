using System.Runtime.CompilerServices;
using SandBox.Objects.AnimationPoints;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.Usables;

public class SmithingMachine : UsableMachine
{
	private enum State
	{
		Stable,
		Preparation,
		Working,
		Paused,
		UseAnvilPoint
	}

	private const string MachineIdleAnimationName = "anim_merchant_smithing_machine_idle";

	private const string MachineIdleWithBlendInAnimationName = "anim_merchant_smithing_machine_idle_with_blend_in";

	private const string MachineUseAnimationName = "anim_merchant_smithing_machine_loop";

	private static readonly ActionIndexCache[] _actionsWithoutLeftHandItem;

	private AnimationPoint _anvilUsePoint;

	private AnimationPoint _machineUsePoint;

	private State _state;

	private Timer _disableTimer;

	private float _remainingTimeToReset;

	private bool _leftItemIsVisible;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SmithingMachine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SmithingMachine()
	{
		throw null;
	}
}
