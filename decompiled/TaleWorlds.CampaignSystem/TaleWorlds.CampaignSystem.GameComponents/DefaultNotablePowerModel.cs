using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultNotablePowerModel : NotablePowerModel
{
	private struct NotablePowerRank
	{
		public readonly TextObject Name;

		public readonly int MinPowerValue;

		public readonly float InfluenceBonus;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NotablePowerRank(TextObject name, int minPowerValue, float influenceBonus)
		{
			throw null;
		}
	}

	private NotablePowerRank[] NotablePowerRanks;

	private TextObject _currentRankEffect;

	private TextObject _militiaEffect;

	private TextObject _rulerClanEffect;

	private TextObject _propertyEffect;

	public override int NotableDisappearPowerLimit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int RegularNotableMaxPowerLevel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateDailyPowerChangeForHero(Hero hero, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateDailyPowerChangePerPropertyOwned(Hero hero, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateDailyPowerChangeForAffiliationWithRulerClan(ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateDailyPowerChangeForInfluentialNotables(Hero hero, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculatePowerChangeFromIssues(Hero hero, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetPowerRankName(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetInfluenceBonusToClan(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NotablePowerRank GetPowerRank(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInitialPower(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInitialNotableSupporterCost(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultNotablePowerModel()
	{
		throw null;
	}
}
