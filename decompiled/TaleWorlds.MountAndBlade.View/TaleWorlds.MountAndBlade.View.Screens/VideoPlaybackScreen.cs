using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.View.Screens;

public class VideoPlaybackScreen : ScreenBase, IGameStateListener
{
	protected VideoPlaybackState _videoPlaybackState;

	protected VideoPlayerView _videoPlayerView;

	protected float _totalElapsedTimeSinceVideoStart;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VideoPlaybackScreen(VideoPlaybackState videoPlaybackState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected sealed override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnVideoPlaybackTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}
}
