using System.Runtime.CompilerServices;

namespace NavalDLC.Missions.ShipActuators;

public struct ShipActuatorRecord
{
	public readonly float RowerThrust;

	public readonly float RowerThrustDoubleTap;

	public readonly float RowerRotation;

	public readonly float RudderRotation;

	public readonly float SquareSailSetting;

	public readonly float LateenSailSetting;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipActuatorRecord(float rowerThrust, float rowerThrustDoubleTap, float rowerRotation, float rudderRotation, float squareSailSetting, float lateenSailSetting)
	{
		throw null;
	}
}
