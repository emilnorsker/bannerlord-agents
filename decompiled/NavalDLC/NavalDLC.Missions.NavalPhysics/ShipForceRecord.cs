using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.Missions.NavalPhysics;

public struct ShipForceRecord
{
	public readonly MBReadOnlyList<ShipForce> LeftOarForces;

	public readonly MBReadOnlyList<ShipForce> RightOarForces;

	public readonly MBReadOnlyList<ShipForce> SailForces;

	public readonly ShipForce RudderForce;

	public bool HasLeftOarForces
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasRightOarForces
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasSailForces
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipForceRecord(MBReadOnlyList<ShipForce> leftOarForces, MBReadOnlyList<ShipForce> rightOarForces, in MBReadOnlyList<ShipForce> sailForces, in ShipForce rudderForce)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ShipForceRecord None()
	{
		throw null;
	}
}
