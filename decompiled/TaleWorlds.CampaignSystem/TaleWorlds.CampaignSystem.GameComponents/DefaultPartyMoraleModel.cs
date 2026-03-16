using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultPartyMoraleModel : PartyMoraleModel
{
	private const float BaseMoraleValue = 50f;

	private readonly TextObject _recentEventsText;

	private readonly TextObject _starvationMoraleText;

	private readonly TextObject _noWageMoraleText;

	private readonly TextObject _foodBonusMoraleText;

	private readonly TextObject _partySizeMoraleText;

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
	private int GetStarvationMoralePenalty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetNoWageMoralePenalty(MobileParty party)
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
	private void CalculateFoodVarietyMoraleBonus(MobileParty party, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetPartySizeMoraleEffect(MobileParty mobileParty, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CheckPerkEffectOnPartyMorale(MobileParty party, PerkObject perk, bool isInfoNeeded, TextObject newInfo, int perkEffect, out TextObject outNewInfo, out int outPerkEffect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetMoraleEffectsFromPerks(MobileParty party, ref ExplainedNumber bonus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateTroopTierRatio(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetMoraleEffectsFromSkill(MobileParty party, ref ExplainedNumber bonus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetEffectivePartyMorale(MobileParty mobileParty, bool includeDescription = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultPartyMoraleModel()
	{
		throw null;
	}
}
