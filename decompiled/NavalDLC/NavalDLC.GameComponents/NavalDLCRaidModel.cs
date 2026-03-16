using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.GameComponents;

public class NavalDLCRaidModel : RaidModel
{
	public override int GoldRewardForEachLostHearth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateHitDamage(MapEventSide attackerSide, float settlementHitPoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBReadOnlyList<(ItemObject, float)> GetCommonLootItemScores()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCRaidModel()
	{
		throw null;
	}
}
