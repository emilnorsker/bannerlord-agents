using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultPartyImpairmentModel : PartyImpairmentModel
{
	private const float BaseDisorganizedStateDuration = 6f;

	private static readonly TextObject _settlementInvolvedMapEvent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetSiegeExpectedVulnerabilityTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetDisorganizedStateDuration(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanGetDisorganized(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetVulnerabilityStateDuration(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultPartyImpairmentModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultPartyImpairmentModel()
	{
		throw null;
	}
}
