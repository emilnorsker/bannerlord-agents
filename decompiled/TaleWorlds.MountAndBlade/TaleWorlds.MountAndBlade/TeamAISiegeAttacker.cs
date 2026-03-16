using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TeamAISiegeAttacker : TeamAISiegeComponent
{
	private readonly MBList<ArcherPosition> _archerPositions;

	public MBReadOnlyList<ArcherPosition> ArcherPositions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TeamAISiegeAttacker(Mission currentMission, Team currentTeam, float thinkTimerTime, float applyTimerTime)
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFormationFrameChanged(Agent agent, bool isFrameEnabled, WorldPosition frame)
	{
		throw null;
	}
}
