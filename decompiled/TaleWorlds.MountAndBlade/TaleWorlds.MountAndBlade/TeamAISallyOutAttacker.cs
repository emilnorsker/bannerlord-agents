using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TeamAISallyOutAttacker : TeamAISiegeComponent
{
	public MBList<GameEntity> ArcherPositions;

	public readonly List<UsableMachine> BesiegerRangedSiegeWeapons;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TeamAISallyOutAttacker(Mission currentMission, Team currentTeam, float thinkTimerTime, float applyTimerTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUnitAddedToFormationForTheFirstTime(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}
}
