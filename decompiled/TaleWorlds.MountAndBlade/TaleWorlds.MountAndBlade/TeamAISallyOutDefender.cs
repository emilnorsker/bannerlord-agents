using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TeamAISallyOutDefender : TeamAISiegeComponent
{
	public readonly Func<WorldPosition> DefensePosition;

	public List<ArcherPosition> ArcherPositions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TeamAISallyOutDefender(Mission currentMission, Team currentTeam, float thinkTimerTime, float applyTimerTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUnitAddedToFormationForTheFirstTime(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 CalculateSallyOutReferencePosition(FormationAI.BehaviorSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}
}
