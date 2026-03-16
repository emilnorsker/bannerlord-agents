using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class BattleSideSpawnPathSelector
{
	public const float MaxNeighborCount = 2f;

	private readonly Mission _mission;

	private readonly SpawnPathData _initialSpawnPath;

	private readonly MBList<SpawnPathData> _reinforcementSpawnPaths;

	public SpawnPathData InitialSpawnPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<SpawnPathData> ReinforcementPaths
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleSideSpawnPathSelector(Mission mission, Path initialPath, float initialPivotRatio, bool initialPathIsInverted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasReinforcementPath(Path path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FindReinforcementPaths()
	{
		throw null;
	}
}
