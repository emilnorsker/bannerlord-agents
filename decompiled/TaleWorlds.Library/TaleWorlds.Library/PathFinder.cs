using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public abstract class PathFinder
{
	public static float BuildingCost;

	public static float WaterCost;

	public static float ShallowWaterCost;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PathFinder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Destroy()
	{
		throw null;
	}

	public abstract void Initialize(Vec3 bbSize);

	public abstract bool FindPath(Vec3 wSource, Vec3 wDestination, List<Vec3> path, float craftWidth = 5f);

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PathFinder()
	{
		throw null;
	}
}
