using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Objects.Siege;

public class MultiplayerSiegeTowerSpawner : SiegeTowerSpawner
{
	private const float MaxHitPoint = 15000f;

	private const float MinimumSpeed = 0.5f;

	private const float MaximumSpeed = 1f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AssignParameters(SpawnerEntityMissionHelper _spawnerMissionHelper)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerSiegeTowerSpawner()
	{
		throw null;
	}
}
