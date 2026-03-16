using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Settlements;

namespace NavalDLC.ViewModelCollection.Kingdom;

public class NavalKingdomManagementVM : KingdomManagementVM
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalKingdomManagementVM(Action onClose, Action onManageArmy, Action<Army> onShowArmyOnMap)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override KingdomSettlementVM CreateSettlementVM(Action<KingdomDecision> forceDecision, Action<Settlement> onGrantFief)
	{
		throw null;
	}
}
