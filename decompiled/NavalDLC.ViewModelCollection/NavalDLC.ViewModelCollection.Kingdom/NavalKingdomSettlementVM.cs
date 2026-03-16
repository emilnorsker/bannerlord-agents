using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Settlements;

namespace NavalDLC.ViewModelCollection.Kingdom;

public class NavalKingdomSettlementVM : KingdomSettlementVM
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalKingdomSettlementVM(Action<KingdomDecision> forceDecision, Action<Settlement> onGrantFief)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override KingdomSettlementItemVM CreateSettlementItemVM(Settlement settlement, Action<KingdomSettlementItemVM> onSelect)
	{
		throw null;
	}
}
