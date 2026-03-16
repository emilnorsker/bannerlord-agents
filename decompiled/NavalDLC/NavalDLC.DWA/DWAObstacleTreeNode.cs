using System.Runtime.CompilerServices;

namespace NavalDLC.DWA;

internal class DWAObstacleTreeNode
{
	public DWAObstacleVertex Obstacle;

	public DWAObstacleTreeNode Left;

	public DWAObstacleTreeNode Right;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DWAObstacleTreeNode()
	{
		throw null;
	}
}
