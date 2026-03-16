using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class MissionTimer
{
	private MissionTime _startTime;

	private float _duration;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionTimer(float duration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionTime GetStartTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTimerDuration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRemainingTimeInSeconds(bool synched = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Check(bool reset = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Set(float timeInSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDuration(float duration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionTimer CreateSynchedTimerClient(float startTimeInSeconds, float duration)
	{
		throw null;
	}
}
