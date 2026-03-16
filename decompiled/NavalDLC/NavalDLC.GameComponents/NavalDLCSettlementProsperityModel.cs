using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace NavalDLC.GameComponents;

public class NavalDLCSettlementProsperityModel : SettlementProsperityModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateProsperityChange(Town fortification, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateHearthChange(Village village, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCSettlementProsperityModel()
	{
		throw null;
	}
}
