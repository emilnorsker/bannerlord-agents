using System.Runtime.CompilerServices;

namespace psai.net;

public class AudioData
{
	public string filePathRelativeToProjectDir;

	public string moduleId;

	public int sampleCountTotal;

	public int sampleCountPreBeat;

	public int sampleCountPostBeat;

	public int sampleRateHz;

	public float bpm;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AudioData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFullLengthInMilliseconds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPreBeatZoneInMilliseconds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPostBeatZoneInMilliseconds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSampleCountByMilliseconds(int milliSeconds)
	{
		throw null;
	}
}
