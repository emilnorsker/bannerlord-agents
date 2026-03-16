using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public class SoundEvent
{
	private const int NullSoundId = -1;

	private static readonly SoundEvent NullSoundEvent;

	private int _soundId;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSoundId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SoundEvent(int soundId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SoundEvent CreateEventFromString(string eventId, Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEventMinMaxDistance(Vec3 newRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetEventIdFromString(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool PlaySound2D(int soundCodeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool PlaySound2D(string soundName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetTotalEventCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SoundEvent CreateEvent(int soundCodeId, Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsNullSoundEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Play()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Pause()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Resume()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlayExtraEvent(string eventName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSwitch(string switchGroupName, string newSwitchStateName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerCue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool PlayInPosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Stop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetParameter(string parameterName, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetParameter(int parameterIndex, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetEventMinMaxDistance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPosition(Vec3 vec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVelocity(Vec3 vec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlaying()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPaused()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SoundEvent CreateEventFromSoundBuffer(string eventId, byte[] soundData, Scene scene, bool is3d, bool isBlocking)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SoundEvent CreateEventFromExternalFile(string programmerEventName, string soundFilePath, Scene scene, bool is3d, bool isBlocking)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SoundEvent()
	{
		throw null;
	}
}
