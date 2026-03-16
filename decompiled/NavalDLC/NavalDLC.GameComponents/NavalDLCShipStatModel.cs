using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;

namespace NavalDLC.GameComponents;

public class NavalDLCShipStatModel : ShipStatModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipFlagshipScore(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetShipTierf(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCShipStatModel()
	{
		throw null;
	}
}
