using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics.Arena;

public class ArenaAgentStateDeciderLogic : MissionLogic, IAgentStateDecider, IMissionBehavior
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentState GetAgentState(Agent effectedAgent, float deathProbability, out bool usedSurgery)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArenaAgentStateDeciderLogic()
	{
		throw null;
	}
}
