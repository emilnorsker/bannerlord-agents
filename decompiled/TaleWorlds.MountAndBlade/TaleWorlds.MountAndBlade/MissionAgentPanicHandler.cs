using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class MissionAgentPanicHandler : MissionLogic
{
	private readonly List<Agent> _panickedAgents;

	private readonly List<Formation> _panickedFormations;

	private readonly List<Team> _panickedTeams;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAgentPanicHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentPanicked(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}
}
