using System.Runtime.CompilerServices;

namespace psai.net;

public class AudioPlaybackLayerChannelStandalone : IAudioPlaybackLayerChannel
{
	private AudioData _audioData;

	private int index;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AudioPlaybackLayerChannelStandalone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~AudioPlaybackLayerChannelStandalone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void StopIfPlaying()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult LoadSegment(Segment segment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult ReleaseSegment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult ScheduleSegmentPlayback(Segment snippet, int delayMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult StopChannel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult SetVolume(float volume)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult SetPaused(bool paused)
	{
		throw null;
	}
}
