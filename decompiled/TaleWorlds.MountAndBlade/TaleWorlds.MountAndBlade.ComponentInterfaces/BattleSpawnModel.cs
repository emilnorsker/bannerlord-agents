using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.ComponentInterfaces;

public abstract class BattleSpawnModel : MBGameModel<BattleSpawnModel>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnMissionEnd()
	{
		throw null;
	}

	public abstract List<(IAgentOriginBase origin, int formationIndex)> GetInitialSpawnAssignments(BattleSideEnum battleSide, List<IAgentOriginBase> troopOrigins);

	public abstract List<(IAgentOriginBase origin, int formationIndex)> GetReinforcementAssignments(BattleSideEnum battleSide, List<IAgentOriginBase> troopOrigins);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BattleSpawnModel()
	{
		throw null;
	}
}
