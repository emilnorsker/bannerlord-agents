using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CraftingSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign.Order;

public class CraftingOrderPopupVM : ViewModel
{
	private class OrderComparer : IComparer<CraftingOrder>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(CraftingOrder x, CraftingOrder y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderComparer()
		{
			throw null;
		}
	}

	private Action<CraftingOrderItemVM> _onDoneAction;

	private Func<CraftingAvailableHeroItemVM> _getCurrentCraftingHero;

	private Func<CraftingOrder, IEnumerable<CraftingStatData>> _getOrderStatDatas;

	private readonly ICraftingCampaignBehavior _craftingBehavior;

	private bool _isVisible;

	private int _questType;

	private string _orderCountText;

	private MBBindingList<CraftingOrderItemVM> _craftingOrders;

	private CraftingOrderItemVM _selectedCraftingOrder;

	public bool HasOrders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasEnabledOrders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsVisible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public int QuestType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string OrderCountText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public CraftingOrderItemVM SelectedCraftingOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<CraftingOrderItemVM> CraftingOrders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CraftingOrderPopupVM(Action<CraftingOrderItemVM> onDoneAction, Func<CraftingAvailableHeroItemVM> getCurrentCraftingHero, Func<CraftingOrder, IEnumerable<CraftingStatData>> getOrderStatDatas)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshOrders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CampaignUIHelper.IssueQuestFlags GetQuestFlagsForOrder(CraftingOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectOrder(CraftingOrderItemVM order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOpenPopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteCloseWithoutSelection()
	{
		throw null;
	}
}
