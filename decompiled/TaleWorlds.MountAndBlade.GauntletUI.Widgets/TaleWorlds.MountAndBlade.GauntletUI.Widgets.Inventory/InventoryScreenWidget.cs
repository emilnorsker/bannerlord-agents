using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.ExtraWidgets;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Inventory;

public class InventoryScreenWidget : Widget
{
	private readonly int TooltipHideFrameLength;

	private Widget _latestMouseDownWidget;

	private InventoryItemButtonWidget _currentHoveredItemWidget;

	private InventoryItemButtonWidget _currentDraggedItemWidget;

	private InventoryItemButtonWidget _lastDisplayedTooltipItem;

	private int _tooltipHiddenFrameCount;

	private int _scrollToBannersInFrames;

	private float _scrollToItemInSeconds;

	private InputKeyVisualWidget _previousCharacterInputKeyVisual;

	private InputKeyVisualWidget _nextCharacterInputKeyVisual;

	private Widget _previousCharacterInputVisualParent;

	private Widget _nextCharacterInputVisualParent;

	private InputKeyVisualWidget _transferInputKeyVisualWidget;

	private RichTextWidget _tradeLabel;

	private Widget _inventoryTooltip;

	private InventoryItemPreviewWidget _itemPreviewWidget;

	private int _transactionCount;

	private int _equipmentMode;

	private int _targetEquipmentIndex;

	private ScrollablePanel _otherInventoryListWidget;

	private ScrollablePanel _playerInventoryListWidget;

	private bool _focusLostThisFrame;

	private bool _isFocusedOnItemList;

	private bool _isBannerTutorialActive;

	private bool _scrollToItem;

	private string _bannerTypeName;

	private string _scrollItemId;

	[Editor(false)]
	public InputKeyVisualWidget TransferInputKeyVisualWidget
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

	public Widget PreviousCharacterInputVisualParent
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

	public Widget NextCharacterInputVisualParent
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

	[Editor(false)]
	public RichTextWidget TradeLabel
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

	[Editor(false)]
	public Widget InventoryTooltip
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

	[Editor(false)]
	public InventoryItemPreviewWidget ItemPreviewWidget
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

	[Editor(false)]
	public int TransactionCount
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

	[Editor(false)]
	public int EquipmentMode
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

	[Editor(false)]
	public int TargetEquipmentIndex
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

	[Editor(false)]
	public ScrollablePanel OtherInventoryListWidget
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

	[Editor(false)]
	public ScrollablePanel PlayerInventoryListWidget
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

	[Editor(false)]
	public bool IsFocusedOnItemList
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

	[Editor(false)]
	public bool IsBannerTutorialActive
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

	[Editor(false)]
	public string BannerTypeName
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

	[Editor(false)]
	public bool ScrollToItem
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

	[Editor(false)]
	public string ScrollItemId
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
	public InventoryScreenWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T IsWidgetChildOfType<T>(Widget currentWidget) where T : Widget
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsWidgetChildOf(Widget parentWidget, Widget currentWidget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsWidgetChildOfId(string parentId, Widget currentWidget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private InventoryListPanel GetCurrentHoveredListPanel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Widget GetFirstBannerItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Widget GetItemWithId(ScrollablePanel listWidget, string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateControllerTransferKeyVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTooltipPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TradeLabelOnPropertyChanged(PropertyOwnerObject owner, string propertyName, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ItemWidgetHoverBegin(InventoryItemButtonWidget itemWidget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ItemWidgetHoverEnd(InventoryItemButtonWidget itemWidget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ItemWidgetDragBegin(InventoryItemButtonWidget itemWidget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ItemWidgetDrop(InventoryItemButtonWidget itemWidget)
	{
		throw null;
	}
}
