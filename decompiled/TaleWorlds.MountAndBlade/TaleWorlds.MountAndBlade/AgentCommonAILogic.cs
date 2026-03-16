using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class AgentCommonAILogic : MissionLogic
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentCreated(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnAgentControllerChanged(Agent agent, AgentControllerType oldController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentCommonAILogic()
	{
		throw null;
	}
}
