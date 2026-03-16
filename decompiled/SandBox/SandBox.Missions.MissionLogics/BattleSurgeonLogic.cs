using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class BattleSurgeonLogic : MissionLogic
{
	private Dictionary<string, Agent> _surgeonAgents;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnGetAgentState(Agent agent, bool usedSurgery)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentCreated(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleSurgeonLogic()
	{
		throw null;
	}
}
