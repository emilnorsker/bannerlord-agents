using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultCampaignShipDamageModel : CampaignShipDamageModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHourlyShipDamage(MobileParty owner, Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetEstimatedSafeSailDuration(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipDamage(Ship ship, Ship rammingShip, float rawDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultCampaignShipDamageModel()
	{
		throw null;
	}
}
