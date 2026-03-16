using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class BehaviorTacticalCharge : BehaviorComponent
{
	private enum ChargeState
	{
		Undetermined,
		Charging,
		ChargingPast,
		Reforming,
		Bracing
	}

	private ChargeState _chargeState;

	private FormationQuerySystem _lastTarget;

	private Vec2 _initialChargeDirection;

	private float _desiredChargeStopDistance;

	private WorldPosition _lastReformDestination;

	private Timer _chargingPastTimer;

	private Timer _reformTimer;

	private Vec2 _bracePosition;

	public override float NavmeshlessTargetPositionPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorTacticalCharge(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ChargeState CheckAndChangeState()
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
	public override TextObject GetBehaviorString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateAIWeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetAiWeight()
	{
		throw null;
	}
}
