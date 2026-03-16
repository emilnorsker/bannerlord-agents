using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class BehaviorSkirmish : BehaviorComponent
{
	private enum BehaviorState
	{
		Approaching,
		Shooting,
		PullingBack
	}

	private bool _cantShoot;

	private float _cantShootDistance;

	private bool _alternatePositionUsed;

	private WorldPosition _alternatePosition;

	private BehaviorState _behaviorState;

	private Timer _cantShootTimer;

	private Timer _pullBackTimer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorSkirmish(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBehaviorActivatedAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetAiWeight()
	{
		throw null;
	}
}
