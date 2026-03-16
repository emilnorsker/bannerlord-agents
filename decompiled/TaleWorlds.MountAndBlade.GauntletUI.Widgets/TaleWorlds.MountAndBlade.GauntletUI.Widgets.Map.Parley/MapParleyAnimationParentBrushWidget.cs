using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Map.Parley;

public class MapParleyAnimationParentBrushWidget : BrushWidget
{
	private bool _firstFrame;

	private const float _fadeInOutDuration = 0.1f;

	private float _animationDelta;

	private float _targetYOffset;

	private float _minYOffset;

	private const float _fadeInOutYMovement = 50f;

	private float _animationDuration;

	[Editor(false)]
	public float AnimationDuration
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
	public MapParleyAnimationParentBrushWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}
}
