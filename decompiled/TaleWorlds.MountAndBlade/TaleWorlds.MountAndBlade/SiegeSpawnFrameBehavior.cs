using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Objects;

namespace TaleWorlds.MountAndBlade;

public class SiegeSpawnFrameBehavior : SpawnFrameBehaviorBase
{
	public const string SpawnZoneTagAffix = "sp_zone_";

	public const string SpawnZoneEnableTagAffix = "enable_";

	public const string SpawnZoneDisableTagAffix = "disable_";

	public const int StartingActiveSpawnZoneIndex = 0;

	private List<GameEntity>[] _spawnPointsByTeam;

	private List<GameEntity>[] _spawnZonesByTeam;

	private int _activeSpawnZoneIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MatrixFrame GetSpawnFrame(Team team, bool hasMount, bool isInitialSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFlagDeactivated(FlagCapturePoint flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeSpawnFrameBehavior()
	{
		throw null;
	}
}
