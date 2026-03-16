using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.GauntletUI;

public class CircleActionSelectorWidget : Widget
{
	private int _currentSelectedIndex;

	private const float _mouseMoveMaxDistance = 125f;

	private const float _gamepadDeadzoneLength = 0.391f;

	private const float _mouseMoveMaxDistanceSquared = 15625f;

	private float _centerDistanceAnimationTimer;

	private float _centerDistanceAnimationDuration;

	private float _centerDistanceAnimationInitialValue;

	private float _centerDistanceAnimationTarget;

	private Vec2 _mouseDirection;

	private Vec2 _mouseMoveAccumulated;

	private bool _isRefreshingSelection;

	private bool _allowInvalidSelection;

	private bool _activateOnlyWithController;

	private bool _isCircularInputDisabled;

	private float _distanceFromCenterModifier;

	private float _directionWidgetDistanceMultiplier;

	private Widget _directionWidget;

	public bool AllowInvalidSelection
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

	public bool ActivateOnlyWithController
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

	public bool IsCircularInputEnabled
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

	public bool IsCircularInputDisabled
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

	public float DistanceFromCenterModifier
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

	public float DirectionWidgetDistanceMultiplier
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

	public Widget DirectionWidget
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
	public CircleActionSelectorWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnChildAdded(Widget child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnChildPropertyChanged(PropertyOwnerObject widget, string propertyName, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AnimateDistanceFromCenter(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AnimateDistanceFromCenterTo(float distanceFromCenter, float animationDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAverageMouseDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateItemPlacement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TrySetSelectedIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnSelectedIndexChanged(int selectedIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCircularInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetIndexOfSelectedItemByAngle(float mouseDirectionAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float AddAngle(float angle1, float angle2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAngleBetweenAngles(float angle, float minAngle, float maxAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float AngleFromDir(Vec2 directionVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 DirFromAngle(float angle)
	{
		throw null;
	}
}
