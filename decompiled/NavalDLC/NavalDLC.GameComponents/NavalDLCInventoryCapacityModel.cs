using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace NavalDLC.GameComponents;

public class NavalDLCInventoryCapacityModel : InventoryCapacityModel
{
	private static readonly TextObject _textTroopMounts;

	private static readonly TextObject _textMountsAndPackAnimals;

	private static readonly TextObject _textLiveStocksAnimals;

	private static readonly TextObject _textItems;

	private static readonly TextObject _textBaseNavalCapacity;

	private const float CustomMountWeight = 50f;

	private const float CustomPackAnimalWeight = 30f;

	private const float CustomLiveStockWeight = 20f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateInventoryCapacity(MobileParty mobileParty, bool isCurrentlyAtSea, bool includeDescriptions = false, int additionalManOnFoot = 0, int additionalSpareMounts = 0, int additionalPackAnimals = 0, bool includeFollowers = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetItemAverageWeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateTotalWeightCarried(MobileParty mobileParty, bool isCurrentlyAtSea, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetItemEffectiveWeight(EquipmentElement equipmentElement, MobileParty mobileParty, bool isCurrentlyAtSea, out TextObject description)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCInventoryCapacityModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NavalDLCInventoryCapacityModel()
	{
		throw null;
	}
}
