using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Source.Missions;

public class BattleSpawnLogic : MissionLogic
{
	public const string BattleTag = "battle_set";

	public const string SallyOutTag = "sally_out_set";

	public const string ReliefForceAttackTag = "relief_force_attack_set";

	private const string SpawnPointSetCommonTag = "spawnpoint_set";

	private readonly string _selectedSpawnPointSetTag;

	private bool _isScenePrepared;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleSpawnLogic(string selectedSpawnPointSetTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}
}
