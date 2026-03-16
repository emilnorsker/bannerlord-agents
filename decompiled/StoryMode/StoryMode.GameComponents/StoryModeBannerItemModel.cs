using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;

namespace StoryMode.GameComponents;

public class StoryModeBannerItemModel : BannerItemModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IEnumerable<ItemObject> GetPossibleRewardBannerItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanBannerBeUpdated(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsItemDragonBanner(ItemObject item)
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
	public StoryModeBannerItemModel()
	{
		throw null;
	}
}
