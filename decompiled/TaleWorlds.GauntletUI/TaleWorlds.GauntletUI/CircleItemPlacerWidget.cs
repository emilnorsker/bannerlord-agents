using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.GauntletUI;

public class CircleItemPlacerWidget : Widget
{
	private float _centerDistanceAnimationTimer;

	private float _centerDistanceAnimationDuration;

	private float _centerDistanceAnimationInitialValue;

	private float _centerDistanceAnimationTarget;

	public float DistanceFromCenterModifier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public Widget DirectionWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float DirectionWidgetDistanceMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool ActivateOnlyWithController
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CircleItemPlacerWidget(UIContext context)
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
	private void UpdateItemPlacement()
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
