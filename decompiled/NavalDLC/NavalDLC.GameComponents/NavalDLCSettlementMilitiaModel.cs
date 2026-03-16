using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace NavalDLC.GameComponents;

public class NavalDLCSettlementMilitiaModel : SettlementMilitiaModel
{
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
	public NavalDLCSettlementMilitiaModel()
	{
		throw null;
	}
}
