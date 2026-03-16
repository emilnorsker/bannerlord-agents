using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class SiegeQuerySystem
{
	private enum RegionEnum
	{
		Left,
		LeftClose,
		Middle,
		MiddleClose,
		Right,
		RightClose,
		Inside
	}

	private const float LaneProximityDistance = 15f;

	private readonly Team _attackerTeam;

	public Vec2 DefenderLeftToDefenderMidDir;

	public Vec2 DefenderMidToDefenderRightDir;

	private readonly QueryData<int> _leftRegionMemberCount;

	private readonly QueryData<int> _leftCloseAttackerCount;

	private readonly QueryData<int> _middleRegionMemberCount;

	private readonly QueryData<int> _middleCloseAttackerCount;

	private readonly QueryData<int> _rightRegionMemberCount;

	private readonly QueryData<int> _rightCloseAttackerCount;

	private readonly QueryData<int> _insideAttackerCount;

	private readonly QueryData<int> _leftDefenderCount;

	private readonly QueryData<int> _middleDefenderCount;

	private readonly QueryData<int> _rightDefenderCount;

	public int LeftRegionMemberCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int LeftCloseAttackerCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int MiddleRegionMemberCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int MiddleCloseAttackerCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int RightRegionMemberCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int RightCloseAttackerCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int InsideAttackerCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int LeftDefenderCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int MiddleDefenderCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int RightDefenderCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 LeftDefenderOrigin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 MidDefenderOrigin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 RightDefenderOrigin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 LeftAttackerOrigin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 MiddleAttackerOrigin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 RightAttackerOrigin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec2 LeftToMidDir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec2 MidToLeftDir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec2 MidToRightDir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec2 RightToMidDir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeQuerySystem(Team team, IEnumerable<SiegeLane> lanes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int LocateAttackers(RegionEnum region)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Expire()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeTelemetryScopeNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int DeterminePositionAssociatedSide(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AreSidesRelated(FormationAI.BehaviorSide side, int connectedSides)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int SideDistance(int connectedSides, int side)
	{
		throw null;
	}
}
