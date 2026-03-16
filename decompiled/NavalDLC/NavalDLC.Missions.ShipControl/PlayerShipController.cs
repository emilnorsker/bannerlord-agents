using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.ShipInput;

namespace NavalDLC.Missions.ShipControl;

public class PlayerShipController : ShipController
{
	private ShipInputRecord _inputRecord;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerShipController(MissionShip ownerShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInput(in ShipInputRecord inputRecord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ShipInputRecord Update(float dt)
	{
		throw null;
	}
}
