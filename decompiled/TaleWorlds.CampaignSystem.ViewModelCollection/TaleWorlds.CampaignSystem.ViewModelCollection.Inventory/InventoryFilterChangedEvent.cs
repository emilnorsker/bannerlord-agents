using System.Runtime.CompilerServices;
using TaleWorlds.Library.EventSystem;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;

public class InventoryFilterChangedEvent : EventBase
{
	public SPInventoryVM.Filters NewFilter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventoryFilterChangedEvent(SPInventoryVM.Filters newFilter)
	{
		throw null;
	}
}
