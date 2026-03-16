using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace NavalDLC.ComponentInterfaces;

public abstract class ShipPhysicsParametersModel : MBGameModel<ShipPhysicsParametersModel>
{
	public abstract float GetWaterDensity();

	public abstract float GetAirDensity();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ShipPhysicsParametersModel()
	{
		throw null;
	}
}
