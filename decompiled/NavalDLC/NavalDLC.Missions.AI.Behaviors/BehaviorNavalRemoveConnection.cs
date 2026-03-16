using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.Behaviors;

public sealed class BehaviorNavalRemoveConnection : NavalBehaviorComponent
{
	private NavalShipsLogic _navalShipsLogic;

	private MissionShip _formationMainShip;

	private bool _readyToSeparate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorNavalRemoveConnection(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshShipReferences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ResetBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBehaviorActivatedAux()
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
