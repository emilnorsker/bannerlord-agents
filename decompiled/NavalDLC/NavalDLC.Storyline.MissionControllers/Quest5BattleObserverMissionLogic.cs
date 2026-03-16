using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Storyline.MissionControllers;

internal class Quest5BattleObserverMissionLogic : BattleObserverMissionLogic
{
	private bool _isGunnarAddedBefore;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quest5BattleObserverMissionLogic()
	{
		throw null;
	}
}
