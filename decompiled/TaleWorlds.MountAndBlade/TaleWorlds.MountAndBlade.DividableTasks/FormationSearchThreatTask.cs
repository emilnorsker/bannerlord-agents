using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.DividableTasks;

public class FormationSearchThreatTask : DividableTask
{
	private Agent _targetAgent;

	private const float CheckCountRatio = 0.1f;

	private RangedSiegeWeapon _weapon;

	private Formation _formation;

	private int _storedIndex;

	private int _checkCountPerTick;

	private bool _result;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool UpdateExtra()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Prepare(Formation formation, RangedSiegeWeapon weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetResult(out Agent targetAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FormationSearchThreatTask()
	{
		throw null;
	}
}
