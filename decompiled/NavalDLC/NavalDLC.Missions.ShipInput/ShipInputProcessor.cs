using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.ShipActuators;

namespace NavalDLC.Missions.ShipInput;

public class ShipInputProcessor
{
	private MissionShip _ownerShip;

	private float _rowerThrust;

	private float _rowerRotation;

	private float _rudderRotation;

	private float _squareSailSetting;

	private float _lateenSailSetting;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipInputProcessor(MissionShip ownerShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipActuatorRecord OnParallelFixedTick(float fixedDt, in ShipInputRecord inputRecord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deallocate()
	{
		throw null;
	}
}
