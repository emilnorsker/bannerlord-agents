using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.ShipInput;

namespace NavalDLC.Missions.ShipControl;

public abstract class ShipController
{
	protected MissionShip _ownerShip;

	protected ShipControllerType _controllerType;

	public bool IsPlayerControlled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAIControlled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ShipControllerType ControllerType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipController(MissionShip ownerShip)
	{
		throw null;
	}

	public abstract ShipInputRecord Update(float dt);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Deallocate()
	{
		throw null;
	}
}
