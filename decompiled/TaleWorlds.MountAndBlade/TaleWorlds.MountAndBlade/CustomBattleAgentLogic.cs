using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class CustomBattleAgentLogic : MissionLogic
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BecomeGhost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomBattleAgentLogic()
	{
		throw null;
	}
}
