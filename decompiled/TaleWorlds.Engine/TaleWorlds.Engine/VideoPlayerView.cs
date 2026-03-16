using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineClass("rglVideo_player_view")]
public sealed class VideoPlayerView : View
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal VideoPlayerView(UIntPtr meshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VideoPlayerView CreateVideoPlayerView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlayVideo(string videoFileName, string soundFileName, float framerate, bool looping)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopVideo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsVideoFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizePlayer()
	{
		throw null;
	}
}
