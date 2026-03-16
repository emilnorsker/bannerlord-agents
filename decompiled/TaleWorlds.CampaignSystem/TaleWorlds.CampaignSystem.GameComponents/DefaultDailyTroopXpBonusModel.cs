using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultDailyTroopXpBonusModel : DailyTroopXpBonusModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateDailyTroopXpBonus(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateTroopXpBonusInternal(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateGarrisonXpBonusMultiplier(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultDailyTroopXpBonusModel()
	{
		throw null;
	}
}
