using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class BattlePowerCalculationLogic : MissionLogic, IBattlePowerCalculationLogic, IMissionBehavior
{
	private Dictionary<Team, float>[] _sidePowerData;

	public bool IsTeamPowersCalculated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattlePowerCalculationLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTotalTeamPower(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateTeamPowers()
	{
		throw null;
	}
}
