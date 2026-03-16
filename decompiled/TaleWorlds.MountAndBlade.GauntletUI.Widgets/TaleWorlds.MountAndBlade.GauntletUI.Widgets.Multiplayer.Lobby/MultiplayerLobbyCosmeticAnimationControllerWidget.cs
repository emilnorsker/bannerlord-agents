using System;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Multiplayer.Lobby;

public class MultiplayerLobbyCosmeticAnimationControllerWidget : Widget
{
	private static readonly Color DefaultColor;

	private int _cosmeticRarity;

	private float _minAlphaChangeDuration;

	private float _maxAlphaChangeDuration;

	private float _minAlphaLowerBound;

	private float _minAlphaUpperBound;

	private float _maxAlphaLowerBound;

	private float _maxAlphaUpperBound;

	private Color _rarityCommonColor;

	private Color _rarityRareColor;

	private Color _rarityUniqueColor;

	private BasicContainer _animationPartContainer;

	[Editor(false)]
	public int CosmeticRarity
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
	public float MinAlphaChangeDuration
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
	public float MaxAlphaChangeDuration
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
	public float MinAlphaLowerBound
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
	public float MinAlphaUpperBound
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
	public float MaxAlphaLowerBound
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
	public float MaxAlphaUpperBound
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
	public Color RarityCommonColor
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
	public Color RarityRareColor
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
	public Color RarityUniqueColor
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
	public BasicContainer AnimationPartContainer
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
	private double GetRandomDoubleBetween(double min, double max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerLobbyCosmeticAnimationControllerWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RestartAllAnimations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAllAnimationPartColors()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartAllAnimations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopAllAnimations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartAnimationOfPart(MultiplayerLobbyCosmeticAnimationPartWidget part)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopAnimationOfPart(MultiplayerLobbyCosmeticAnimationPartWidget part)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetColorOfPart(MultiplayerLobbyCosmeticAnimationPartWidget part)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyActionOnAllAnimations(Action<MultiplayerLobbyCosmeticAnimationPartWidget> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAnimationPartAdded(Widget parent, Widget child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MultiplayerLobbyCosmeticAnimationControllerWidget()
	{
		throw null;
	}
}
