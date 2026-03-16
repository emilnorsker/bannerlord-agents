using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond.Cosmetics.CosmeticTypes;

public class ClothingCosmeticElement : CosmeticElement
{
	public readonly List<string> ReplaceItemsId;

	public readonly List<Tuple<string, string>> ReplaceItemless;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClothingCosmeticElement(string id, CosmeticsManager.CosmeticRarity rarity, int cost, List<string> replaceItemsId, List<Tuple<string, string>> replaceItemless)
	{
		throw null;
	}
}
