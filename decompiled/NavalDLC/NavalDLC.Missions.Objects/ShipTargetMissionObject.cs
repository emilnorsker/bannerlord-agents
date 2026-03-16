using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects;

public class ShipTargetMissionObject : MissionObject, ITargetable
{
	private readonly Vec3 BoundingBoxOffset;

	private MissionShip _ship;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TargetFlags GetTargetFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTargetValue(List<Vec3> weaponPositions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetTargetEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetTargetingOffset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleSideEnum GetSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity Entity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (Vec3, Vec3) ComputeGlobalPhysicsBoundingBoxMinMax()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetTargetGlobalVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDestructable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetHitPointsMultiplierOfShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipTargetMissionObject()
	{
		throw null;
	}
}
