using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.MissionSpawnHandlers;

public class CustomSallyOutMissionController : SallyOutMissionController
{
	private readonly CustomBattleCombatant[] _battleCombatants;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomSallyOutMissionController(IBattleCombatant defenderBattleCombatant, IBattleCombatant attackerBattleCombatant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void GetInitialTroopCounts(out int besiegedTotalTroopCount, out int besiegerTotalTroopCount)
	{
		throw null;
	}
}
