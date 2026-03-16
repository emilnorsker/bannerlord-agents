using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;

namespace NavalDLC.GameComponents;

public class NavalDLCMapVisibilityModel : MapVisibilityModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float MaximumSeeingRange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPartySpottingRangeBase(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetPartySpottingRange(MobileParty party, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPartyRelativeInspectionRange(IMapPoint party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPartySpottingDifficulty(MobileParty spotterParty, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetHideoutSpottingDistance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCMapVisibilityModel()
	{
		throw null;
	}
}
