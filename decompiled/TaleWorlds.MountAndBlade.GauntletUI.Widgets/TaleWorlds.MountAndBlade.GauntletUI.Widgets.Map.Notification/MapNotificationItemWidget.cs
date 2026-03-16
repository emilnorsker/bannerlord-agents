using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.ExtraWidgets;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Map.Notification;

public class MapNotificationItemWidget : BrushWidget
{
	private bool _ringHoverBegan;

	private bool _extensionHoverBegan;

	private bool _removeHoverBegan;

	private bool _removeInitiated;

	private bool _imageDetermined;

	private bool _sizeDetermined;

	private bool _isExtended;

	private bool _isFocusItem;

	private float _defaultWidth;

	private float _extendedWidth;

	private bool _isInspectionForced;

	private string _notificationType;

	private Sprite _defaultWidthSprite;

	private Sprite _extendedWidthSprite;

	private Widget _notificationRingWidget;

	private Widget _notificationRingImageWidget;

	private Widget _notificationExtensionWidget;

	private Widget _notificationTextContainerWidget;

	private ButtonWidget _removeNotificationButtonWidget;

	private RichTextWidget _notificationDescriptionText;

	private InputKeyVisualWidget _removeButtonVisualWidget;

	[Editor(false)]
	public bool IsFocusItem
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
	public float DefaultWidth
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
	public float ExtendedWidth
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
	public ButtonWidget RemoveNotificationButtonWidget
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
	public Widget NotificationRingImageWidget
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
	public bool IsInspectionForced
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
	public string NotificationType
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
	public Sprite DefaultWidthSprite
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
	public Sprite ExtendedWidthSprite
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
	public Widget NotificationRingWidget
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
	public Widget NotificationExtensionWidget
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
	public Widget NotificationTextContainerWidget
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
	public RichTextWidget NotificationDescriptionText
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
	public InputKeyVisualWidget RemoveButtonVisualWidget
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
	public MapNotificationItemWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshHorizontalPositioning(float dt, bool shouldExtend)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRemoveClick(Widget button)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInspectionClick(Widget button)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveButtonWidgetPropertyChanged(PropertyOwnerObject widget, string propertyName, bool propertyValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RingWidgetOnPropertyChanged(PropertyOwnerObject widget, string propertyName, bool propertyValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InspectionWidgetsEventFire(Widget widget, string eventName, object[] eventParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExtensionWidgetOnPropertyChanged(PropertyOwnerObject widget, string propertyName, bool propertyValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float LocalLerp(float start, float end, float delta)
	{
		throw null;
	}
}
