using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class LeaveMissionLogic : MissionLogic
{
	private string _menuId;

	private Timer _isAgentDeadTimer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LeaveMissionLogic(string leaveMenuId = "settlement_player_unconscious")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}
}
