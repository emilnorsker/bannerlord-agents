using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.ExtraWidgets;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Multiplayer.Lobby;

public class MultiplayerLobbyBattleRewardWidget : Widget
{
	private const string _rewardImpactSoundEventName = "inventory/perk";

	private float _buttonAnimationStartWidth;

	private float _buttonAnimationStartHeight;

	private float _buttonAnimationEndWidth;

	private float _buttonAnimationEndHeight;

	private float _iconAnimationStartWidget;

	private float _iconAnimationStartHeight;

	private float _iconAnimationEndWidth;

	private float _iconAnimationEndHeight;

	private ButtonWidget _rewardIconButton;

	private Widget _rewardIcon;

	private TextWidget _rewardTextDescription;

	private ValueBasedVisibilityWidget _rewardToShow;

	private bool _isAnimationStarted;

	private bool _isTextAnimationStarted;

	private bool _isInPreAnimationState;

	private float _animationStartTime;

	private float _textAnimationStartTime;

	public float AnimationDuration
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

	public float TextRevealAnimationDuration
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

	public float AnimationInitialScaleMultiplier
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
	public MultiplayerLobbyBattleRewardWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartPreAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndAnimation()
	{
		throw null;
	}
}
