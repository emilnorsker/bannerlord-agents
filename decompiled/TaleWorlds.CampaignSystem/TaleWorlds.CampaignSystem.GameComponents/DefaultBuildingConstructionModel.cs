using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultBuildingConstructionModel : BuildingConstructionModel
{
	private const float HammerMultiplier = 0.01f;

	private const int VeryLowLoyaltyValue = 25;

	private const float MediumLoyaltyValue = 50f;

	private const float HighLoyaltyValue = 75f;

	private const float HighestLoyaltyValue = 100f;

	private static readonly TextObject ProductionFromMarketText;

	private static readonly TextObject BoostText;

	private static readonly TextObject HighLoyaltyBonusText;

	private static readonly TextObject LowLoyaltyPenaltyText;

	private static readonly TextObject VeryLowLoyaltyPenaltyText;

	private readonly TextObject CultureText;

	public override int TownBoostCost
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int TownBoostBonus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int CastleBoostCost
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int CastleBoostBonus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateDailyConstructionPower(Town town, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateDailyConstructionPowerWithoutBoost(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetBoostAmount(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetBoostCost(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateDailyConstructionPowerInternal(Town town, ref ExplainedNumber result, bool omitBoost = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultBuildingConstructionModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultBuildingConstructionModel()
	{
		throw null;
	}
}
