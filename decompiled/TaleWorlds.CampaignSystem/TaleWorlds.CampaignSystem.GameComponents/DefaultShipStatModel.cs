using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultShipStatModel : ShipStatModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipFlagshipScore(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultShipStatModel()
	{
		throw null;
	}
}
