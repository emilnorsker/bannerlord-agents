using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public sealed class BehaviorCautiousAdvance : BehaviorComponent
{
	private enum BehaviorState
	{
		Approaching,
		Shooting,
		PullingBack
	}

	private bool _isInShieldWallDistance;

	private bool _switchedToShieldWallRecently;

	private Timer _switchedToShieldWallTimer;

	private Vec2 _reformPosition;

	private Formation _archerFormation;

	private bool _cantShoot;

	private float _cantShootDistance;

	private BehaviorState _behaviorState;

	private Timer _cantShootTimer;

	private Vec2 _shootPosition;

	private FormationQuerySystem _targetFormation;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorCautiousAdvance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorCautiousAdvance(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBehaviorActivatedAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorCanceled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetAiWeight()
	{
		throw null;
	}
}
