using System.Runtime.CompilerServices;

namespace psai.net;

public class PlaybackChannel
{
	private Logik m_logik;

	private int m_timeStampOfPlaybackStart;

	private int m_timeStampOfSnippetLoad;

	private bool m_playbackIsScheduled;

	private bool m_stoppedExplicitly;

	private IAudioPlaybackLayerChannel m_audioPlaybackLayerChannel;

	private float m_masterVolume;

	private float m_fadeOutVolume;

	private bool m_paused;

	private bool m_isMainChannel;

	internal Segment Segment
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

	internal bool Paused
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

	internal float MasterVolume
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

	internal float FadeOutVolume
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
	internal PlaybackChannel(Logik logik, bool isMainChannel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ChannelState GetCurrentChannelState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsPlaying()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void LoadSegment(Segment snippet)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool CheckIfSegmentHadEnoughTimeToLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetMillisecondsSinceSegmentLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetMillisecondsUntilLoadingWillHaveFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void StopChannel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ReleaseSegment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetCountdownToPlaybackInMilliseconds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ScheduleSegmentPlayback(Segment snippet, int delayInMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVolume()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlaybackHasStarted()
	{
		throw null;
	}
}
