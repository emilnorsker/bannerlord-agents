using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;

namespace NavalDLC.ViewModelCollection.ClanManagement;

public class NavalClanManagementVM : ClanManagementVM
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalClanManagementVM(Action onClose, Action<Hero> showHeroOnMap, Action<Hero> openPartyAsManage, Action openBannerEditor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override ClanFiefsVM CreateFiefsDataSource(Action onRefresh, Action<ClanCardSelectionInfo> openCardSelectionPopup)
	{
		throw null;
	}
}
