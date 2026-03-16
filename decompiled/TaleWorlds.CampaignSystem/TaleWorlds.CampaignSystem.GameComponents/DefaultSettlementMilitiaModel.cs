using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementMilitiaModel : SettlementMilitiaModel
{
	private static readonly TextObject BaseText;

	private static readonly TextObject FromHearthsText;

	private static readonly TextObject FromProsperityText;

	private static readonly TextObject RetiredText;

	private static readonly TextObject MilitiaFromMarketText;

	private static readonly TextObject LowLoyaltyText;

	private static readonly TextObject CultureText;

	private const int AutoSpawnMilitiaDayMultiplierAfterSiege = 25;

	private const int BaseMilitiaChange = 2;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int MilitiaToSpawnAfterSiege(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateMilitiaChange(Settlement settlement, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateVeteranMilitiaSpawnChance(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CalculateMilitiaSpawnRate(Settlement settlement, out float meleeTroopRate, out float rangedTroopRate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ExplainedNumber CalculateMilitiaChangeInternal(Settlement settlement, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetSettlementMilitiaChangeDueToPerks(Settlement settlement, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetSettlementMilitiaChangeDueToPolicies(Settlement settlement, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetSettlementMilitiaChangeDueToIssues(Settlement settlement, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementMilitiaModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultSettlementMilitiaModel()
	{
		throw null;
	}
}
