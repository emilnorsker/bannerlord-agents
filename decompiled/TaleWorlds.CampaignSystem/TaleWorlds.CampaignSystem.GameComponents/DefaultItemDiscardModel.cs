using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultItemDiscardModel : ItemDiscardModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool PlayerCanDonateItem(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetXpBonusForDiscardingItem(ItemObject item, int amount = 1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetXpBonusForDiscardingItems(ItemRoster itemRoster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultItemDiscardModel()
	{
		throw null;
	}
}
