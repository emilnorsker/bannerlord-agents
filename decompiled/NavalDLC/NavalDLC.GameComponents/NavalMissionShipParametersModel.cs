using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace NavalDLC.GameComponents;

public class NavalMissionShipParametersModel : MissionShipParametersModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateMainDeckCrewSize(IShipOrigin shipOrigin, Agent captain)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateWindBonus(IShipOrigin shipOrigin, Agent captain, float baseSailForceMagnitude)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateOarForceMultiplier(Agent pilotAgent, float baseOarForceMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionShipParametersModel()
	{
		throw null;
	}
}
