using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultBannerItemModel : BannerItemModel
{
	public const int BannerLevel1 = 1;

	public const int BannerLevel2 = 2;

	public const int BannerLevel3 = 3;

	private const string MapBannerId = "campaign_banner_small";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IEnumerable<ItemObject> GetPossibleRewardBannerItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IEnumerable<ItemObject> GetPossibleRewardBannerItemsForHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetBannerItemLevelForHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanBannerBeUpdated(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultBannerItemModel()
	{
		throw null;
	}
}
