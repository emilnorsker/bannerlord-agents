using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;

namespace NavalDLC.GameComponents;

public class NavalDLCCampaignShipDamageModel : CampaignShipDamageModel
{
	private const float MaximumDamageToShip = 10000f;

	private const float MinimumDamageToShip = 1f;

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
	private float CalculateOpenSeaAttritionDamageForShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCCampaignShipDamageModel()
	{
		throw null;
	}
}
