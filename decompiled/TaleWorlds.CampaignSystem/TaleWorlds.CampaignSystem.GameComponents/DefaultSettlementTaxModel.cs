using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementTaxModel : SettlementTaxModel
{
	private readonly TextObject ProsperityText;

	private static readonly TextObject VeryLowLoyalty;

	public override float SettlementCommissionRateTown
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float SettlementCommissionRateVillage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int SettlementCommissionDecreaseSecurityThreshold
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaximumDecreaseBasedOnSecuritySecurity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTownTaxRatio(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetVillageTaxRatio(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTownCommissionChangeBasedOnSecurity(Town town, float commission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateTownTax(Town town, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateDailyTax(Town town, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateDailyTaxInternal(Town town, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateSettlementTaxDueToSecurity(Town town, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateSettlementTaxDueToLoyalty(Town town, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateSettlementTaxDueToBuildings(Town town, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculatePolicyGoldCut(Town town, float rawTax, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSettlementTaxChangeDueToIssues(Town center, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateVillageTaxFromIncome(Village village, int marketIncome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementTaxModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultSettlementTaxModel()
	{
		throw null;
	}
}
