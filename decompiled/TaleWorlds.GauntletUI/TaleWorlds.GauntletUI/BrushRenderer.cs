using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI;

public class BrushRenderer
{
	public enum BrushRendererAnimationState
	{
		None,
		PlayingAnimation,
		PlayingBasicTranisition,
		Ended
	}

	private BrushState _startBrushState;

	private BrushState _currentBrushState;

	private Dictionary<string, BrushLayerState> _startBrushLayerState;

	private Dictionary<string, BrushLayerState> _currentBrushLayerState;

	public bool UseLocalTimer;

	private float _brushLocalTimer;

	private float _globalTime;

	private int _offsetSeed;

	private float _randomXOffset;

	private float _randomYOffset;

	private BrushRendererAnimationState _brushRendererAnimationState;

	private Brush _brush;

	private long _latestStyleVersion;

	private string _currentState;

	private Style _styleOfCurrentState;

	private ImageFit _cachedImageFit;

	private float _brushTimer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong LastUpdatedFrameNumber
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

	public bool ForcePixelPerfectPlacement
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

	public Style CurrentStyle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Brush Brush
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

	public string CurrentState
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
	public BrushRenderer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetRandomXOffset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetRandomYOffset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update(ulong frameNumber, float globalAnimTime, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BrushLayerState AnimateBrushLayerState(BrushAnimation animation, BrushLayerAnimation layerAnimation, float brushStateTimer, bool isFirstCycle, BrushLayerState startState, IBrushLayerData source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUpdateNeeded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BrushState AnimateBrushState(BrushAnimation animation, BrushLayerAnimation layerAnimation, float brushStateTimer, bool isFirstCycle, BrushState startState, Style source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EndAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Render(TwoDimensionDrawContext drawContext, in Rectangle2D rect, float scale, float contextAlpha, Vector2 overlayOffset = default(Vector2), Vector2 overlaySize = default(Vector2))
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextMaterial CreateTextMaterial(TwoDimensionDrawContext drawContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RestartAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSeed(int seed)
	{
		throw null;
	}
}
