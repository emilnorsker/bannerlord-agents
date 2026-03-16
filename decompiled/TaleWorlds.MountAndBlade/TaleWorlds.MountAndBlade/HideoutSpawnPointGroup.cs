using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class HideoutSpawnPointGroup : SynchedMissionObject
{
	private const int NumberOfDefaultFormations = 4;

	public BattleSideEnum Side;

	public int PhaseNumber;

	private GameEntity[] _spawnPoints;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame[] GetSpawnPointFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveWithAllChildren()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HideoutSpawnPointGroup()
	{
		throw null;
	}
}
