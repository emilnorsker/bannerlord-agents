using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;

namespace NavalDLC.GameComponents;

public class NavalDLCPartyMoraleModel : PartyMoraleModel
{
	public override float HighMoraleValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetDailyStarvationMoralePenalty(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetDailyNoWageMoralePenalty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetStandardBaseMorale(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetVictoryMoraleChange(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDefeatMoraleChange(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetEffectivePartyMorale(MobileParty party, bool includeDescription = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCPartyMoraleModel()
	{
		throw null;
	}
}
