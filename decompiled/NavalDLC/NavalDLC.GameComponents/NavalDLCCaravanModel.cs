using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace NavalDLC.GameComponents;

public class NavalDLCCaravanModel : CaravanModel
{
	public override int MaxNumberOfItemsToBuyFromSingleCategory
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanHeroCreateCaravan(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetCaravanFormingCost(bool eliteCaravan, bool navalCaravan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetEliteCaravanSpawnChance(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInitialTradeGold(Hero owner, bool navalCaravan, bool largeCaravan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMaxGoldToSpendOnOneItemCategory(MobileParty caravan, ItemCategory itemCategory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetPowerChangeAfterCaravanCreation(Hero hero, MobileParty caravanParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCCaravanModel()
	{
		throw null;
	}
}
