using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class TacticSallyOutDefense : TacticComponent
{
	private enum WeaponsToBeDefended
	{
		Unset,
		NoWeapons,
		OnlyRangedWeapons,
		OnePrimary,
		TwoPrimary,
		ThreePrimary
	}

	private bool _hasBattleBeenJoined;

	private WorldPosition SallyOutDefensePosition;

	private Formation _cavalryFormation;

	private readonly TeamAISallyOutDefender _teamAISallyOutDefender;

	private List<SiegeWeapon> _destructableSiegeWeapons;

	private WeaponsToBeDefended _weaponsToBeDefendedState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ManageFormationCounts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Engage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TacticSallyOutDefense(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CalculateHasBattleBeenJoined()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CheckAndSetAvailableFormationsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DefendCenterLocation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DefendTwoMainPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DefendSingleMainPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyDefenseBasedOnState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override float GetTacticWeight()
	{
		throw null;
	}
}
