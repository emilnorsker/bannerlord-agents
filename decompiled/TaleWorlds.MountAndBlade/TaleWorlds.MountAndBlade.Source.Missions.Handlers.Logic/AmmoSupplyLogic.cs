using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Source.Missions.Handlers.Logic;

public class AmmoSupplyLogic : MissionLogic
{
	private const float CheckTimePeriod = 3f;

	private readonly List<BattleSideEnum> _sideList;

	private readonly BasicMissionTimer _checkTimer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AmmoSupplyLogic(List<BattleSideEnum> sideList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentEligibleForAmmoSupply(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}
}
