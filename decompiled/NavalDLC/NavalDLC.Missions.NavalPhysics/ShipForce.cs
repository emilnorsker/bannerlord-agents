using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.Missions.NavalPhysics;

public struct ShipForce
{
	public enum SourceType
	{
		None,
		Sail,
		Oar,
		Rudder
	}

	public readonly Vec3 LocalPosition;

	public Vec3 Force;

	public readonly SourceType Source;

	public readonly float GamifiedForceMultiplier;

	public bool IsApplicable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipForce(in Vec3 localPosition, in Vec3 force, SourceType source, float gamifiedForceMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipForce(SourceType source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeRealisticAndGamifiedForceComponents(out Vec3 realisticForce, out Vec3 gamifiedForce)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ShipForce None()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ShipForce None(SourceType source)
	{
		throw null;
	}
}
