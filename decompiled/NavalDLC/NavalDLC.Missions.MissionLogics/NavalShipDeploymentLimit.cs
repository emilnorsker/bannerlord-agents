using System.Runtime.CompilerServices;

namespace NavalDLC.Missions.MissionLogics;

public struct NavalShipDeploymentLimit
{
	public readonly int PartiesLimit;

	public readonly int SkeletalCrewLimit;

	public readonly int BattleAllocationLimit;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NetDeploymentLimit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalShipDeploymentLimit(int partiesLimit, int skeletalCrewLimit, int battleAllocationLimit = 8)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalShipDeploymentLimit(int commonLimit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalShipDeploymentLimit Invalid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalShipDeploymentLimit Max()
	{
		throw null;
	}
}
