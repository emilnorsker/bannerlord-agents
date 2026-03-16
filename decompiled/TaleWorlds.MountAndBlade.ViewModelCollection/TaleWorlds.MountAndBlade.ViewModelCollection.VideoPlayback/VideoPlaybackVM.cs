using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.VideoPlayback;

public class VideoPlaybackVM : ViewModel
{
	private List<SRTHelper.SubtitleItem> subTitleLines;

	private string _subtitleText;

	[DataSourceProperty]
	public string SubtitleText
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
	public VideoPlaybackVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float totalElapsedTimeInVideoInSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SRTHelper.SubtitleItem GetItemInTimeframe(float timeInSecondsInVideo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSubtitles(List<SRTHelper.SubtitleItem> lines)
	{
		throw null;
	}
}
