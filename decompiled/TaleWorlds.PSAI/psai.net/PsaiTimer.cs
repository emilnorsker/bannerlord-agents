using System.Runtime.CompilerServices;

namespace psai.net;

internal class PsaiTimer
{
	private bool m_isSet;

	private bool m_isPaused;

	private int m_estimatedThresholdReachedTime;

	private int m_estimatedFireTime;

	private int m_timerPausedTimestamp;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetTimer(int delayMillis, int remainingThresholdMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsSet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Stop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetPaused(bool setPaused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetRemainingMillisToFireTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetEstimatedFireTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool ThresholdHasBeenReached()
	{
		throw null;
	}
}
