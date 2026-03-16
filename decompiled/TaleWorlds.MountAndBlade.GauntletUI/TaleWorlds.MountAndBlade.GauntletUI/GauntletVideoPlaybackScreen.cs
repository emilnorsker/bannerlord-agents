using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.MountAndBlade.ViewModelCollection.VideoPlayback;

namespace TaleWorlds.MountAndBlade.GauntletUI;

[GameStateScreen(typeof(VideoPlaybackState))]
public class GauntletVideoPlaybackScreen : VideoPlaybackScreen
{
	private GauntletLayer _layer;

	private VideoPlaybackVM _dataSource;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletVideoPlaybackScreen(VideoPlaybackState videoPlaybackState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnVideoPlaybackTick(float dt)
	{
		throw null;
	}
}
