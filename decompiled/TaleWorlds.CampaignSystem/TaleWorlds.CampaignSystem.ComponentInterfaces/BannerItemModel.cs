using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class BannerItemModel : MBGameModel<BannerItemModel>
{
	public abstract IEnumerable<ItemObject> GetPossibleRewardBannerItems();

	public abstract IEnumerable<ItemObject> GetPossibleRewardBannerItemsForHero(Hero hero);

	public abstract int GetBannerItemLevelForHero(Hero hero);

	public abstract bool CanBannerBeUpdated(ItemObject item);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BannerItemModel()
	{
		throw null;
	}
}
