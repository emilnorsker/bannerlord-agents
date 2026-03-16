using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Storyline.MissionControllers;

public class CosmeticShipSpawnMissionLogic : MissionLogic
{
	private const string CosmeticShipSpawnPointTag = "cosmetic_ship_spawn_point";

	private const float AnimationSpeedMultiplier = 0.1f;

	private List<string> _cosmeticShipIdList;

	private Queue<GameEntity> _cosmeticShipSpawnPointEntities;

	private Dictionary<GameEntity, MatrixFrame> _spawnedShipVisuals;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnShip(ShipHull shipHull)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectSailVisuals(WeakGameEntity shipEntity, List<SailVisual> sailVisuals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FoldSails(List<SailVisual> sailVisuals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CosmeticShipSpawnMissionLogic()
	{
		throw null;
	}
}
