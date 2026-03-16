using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TacticSallyOutHitAndRun : TacticComponent
{
	private enum TacticState
	{
		HeadingOutFromCastle,
		DestroyingSiegeWeapons,
		CavalryRetreating,
		InfantryRetreating
	}

	private TacticState _state;

	private Formation _mainInfantryFormation;

	private MBList<Formation> _archerFormations;

	private MBList<Formation> _cavalryFormations;

	private readonly TeamAISallyOutAttacker _teamAISallyOutAttacker;

	private readonly List<SiegeWeapon> _destructibleEnemySiegeWeapons;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ManageFormationCounts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroySiegeWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CavalryRetreat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InfantryRetreat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HeadOutFromTheCastle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TacticSallyOutHitAndRun(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CheckAndSetAvailableFormationsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndChangeState()
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
