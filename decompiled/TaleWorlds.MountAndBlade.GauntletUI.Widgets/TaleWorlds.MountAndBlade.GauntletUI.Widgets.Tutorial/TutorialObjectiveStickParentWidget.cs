using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Tutorial;

public class TutorialObjectiveStickParentWidget : TextWidget
{
	public class StickAnimStage
	{
		public enum AnimTypes
		{
			Movement,
			FadeInLocal,
			FadeOutLocal,
			FadeInGlobal,
			FadeOutGlobal,
			Stay
		}

		private float _totalTime;

		public bool IsCompleted
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

		public float AnimTime
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

		public Vec2 Direction
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

		public AnimTypes AnimType
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

		public Widget WidgetToManipulate
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
		private StickAnimStage()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static StickAnimStage CreateMovementStage(float movementTime, Vec2 direction, Widget widgetToManipulate)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static StickAnimStage CreateFadeInStage(float fadeInTime, Widget widgetToManipulate, bool isGlobal)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static StickAnimStage CreateStayStage(float stayTime)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Tick(float dt)
		{
			throw null;
		}
	}

	private const float LongStayTime = 1f;

	private const float ShortStayTime = 0.1f;

	private const float FadeInTime = 0.15f;

	private const float FadeOutTime = 0.15f;

	private const float SingleMovementDirection = 20f;

	private const float MovementTime = 0.15f;

	private const float ParentActiveAlpha = 0.5f;

	private Queue<List<StickAnimStage>> _animQueue;

	private int _movementType;

	public Widget StickMiddle
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

	[Editor(false)]
	public int MovementType
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
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TutorialObjectiveStickParentWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetAnim()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAnimQueue()
	{
		throw null;
	}
}
