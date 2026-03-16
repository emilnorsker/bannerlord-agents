using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.DividableTasks;

public class FindMostDangerousThreat : DividableTask
{
	private Agent _targetAgent;

	private FormationSearchThreatTask _formationSearchThreatTask;

	private List<Threat> _threats;

	private RangedSiegeWeapon _weapon;

	private Threat _currentThreat;

	private bool _hasOngoingThreatTask;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FindMostDangerousThreat(DividableTask continueToTask = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool UpdateExtra()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Prepare(List<Threat> threats, RangedSiegeWeapon weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Threat GetResult(out Agent targetAgent)
	{
		throw null;
	}
}
