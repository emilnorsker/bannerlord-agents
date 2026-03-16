using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class SallyOutReinforcementSpawnTimer : ICustomReinforcementSpawnTimer
{
	private BasicMissionTimer _besiegedSideTimer;

	private BasicMissionTimer _besiegerSideTimer;

	private float _besiegedInterval;

	private float _besiegerInterval;

	private float _besiegerIntervalChange;

	private int _besiegerRemainingIntervalChanges;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SallyOutReinforcementSpawnTimer(float besiegedInterval, float besiegerInterval, float besiegerIntervalChange, int besiegerIntervalChangeCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Check(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetTimer(BattleSideEnum side)
	{
		throw null;
	}
}
