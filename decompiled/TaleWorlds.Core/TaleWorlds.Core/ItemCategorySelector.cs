using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public abstract class ItemCategorySelector : MBGameModel<ItemCategorySelector>
{
	public abstract ItemCategory GetItemCategoryForItem(ItemObject itemObject);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ItemCategorySelector()
	{
		throw null;
	}
}
