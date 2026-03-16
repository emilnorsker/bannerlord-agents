using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class NotablePowerManagementBehavior : CampaignBehaviorBase
{
	private const int GoldLimitForNotablesToStartGainingPower = 10000;

	private const int GoldLimitForNotablesToStartLosingPower = 5000;

	private const int GoldNeededToGainOnePower = 500;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroCreated(Hero hero, bool isMaternal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRaidCompleted(BattleSideEnum winnerSide, RaidEventComponent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BalanceGoldAndPowerOfNotable(Hero notable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NotablePowerManagementBehavior()
	{
		throw null;
	}
}
