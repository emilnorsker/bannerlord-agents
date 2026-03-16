using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class BehaviorUseSiegeMachines : BehaviorComponent
{
	private enum BehaviorState
	{
		Unset,
		Follow,
		ClimbSiegeTower,
		Stop
	}

	private List<SiegeWeapon> _primarySiegeWeapons;

	private TeamAISiegeComponent _teamAISiegeComponent;

	private MovementOrder _followEntityOrder;

	private GameEntity _followedEntity;

	private MovementOrder _stopOrder;

	private BehaviorState _behaviorState;

	public override float NavmeshlessTargetPositionPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorUseSiegeMachines(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetBehaviorString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RecreateFollowEntityOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnValidBehaviorSideChanged()
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
