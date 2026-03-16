using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class DefaultItemCategorySelector : ItemCategorySelector
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ItemCategory GetItemCategoryForItem(ItemObject itemObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultItemCategorySelector()
	{
		throw null;
	}
}
