using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultInventoryCapacityModel : InventoryCapacityModel
{
	private const int _itemAverageWeight = 10;

	private const float TroopsFactor = 2f;

	private const float SpareMountsFactor = 2f;

	private const float PackAnimalsFactor = 10f;

	private static readonly TextObject _textTroops;

	private static readonly TextObject _textBase;

	private static readonly TextObject _textSpareMounts;

	private static readonly TextObject _textPackAnimals;

	private static readonly TextObject _textMountsAndPackAnimals;

	private static readonly TextObject _textLiveStocksAnimals;

	private static readonly TextObject _textItems;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetItemAverageWeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetItemEffectiveWeight(EquipmentElement equipmentElement, MobileParty mobileParty, bool isCurrentlyAtSea, out TextObject description)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateInventoryCapacity(MobileParty mobileParty, bool isCurrentlyAtSea, bool includeDescriptions = false, int additionalTroops = 0, int additionalSpareMounts = 0, int additionalPackAnimals = 0, bool includeFollowers = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateTotalWeightCarried(MobileParty mobileParty, bool isCurrentlyAtSea, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultInventoryCapacityModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultInventoryCapacityModel()
	{
		throw null;
	}
}
