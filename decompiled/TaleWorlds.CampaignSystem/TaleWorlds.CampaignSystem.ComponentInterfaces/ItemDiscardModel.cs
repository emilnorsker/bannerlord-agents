using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class ItemDiscardModel : MBGameModel<ItemDiscardModel>
{
	public abstract int GetXpBonusForDiscardingItems(ItemRoster itemRoster);

	public abstract int GetXpBonusForDiscardingItem(ItemObject item, int amount = 1);

	public abstract bool PlayerCanDonateItem(ItemObject item);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ItemDiscardModel()
	{
		throw null;
	}
}
