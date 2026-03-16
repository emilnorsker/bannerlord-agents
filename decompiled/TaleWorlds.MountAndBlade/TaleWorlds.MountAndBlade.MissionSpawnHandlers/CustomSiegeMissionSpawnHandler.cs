using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.MissionSpawnHandlers;

public class CustomSiegeMissionSpawnHandler : CustomMissionSpawnHandler
{
	private CustomBattleCombatant[] _battleCombatants;

	private bool _spawnWithHorses;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomSiegeMissionSpawnHandler(IBattleCombatant defenderBattleCombatant, IBattleCombatant attackerBattleCombatant, bool spawnWithHorses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}
}
