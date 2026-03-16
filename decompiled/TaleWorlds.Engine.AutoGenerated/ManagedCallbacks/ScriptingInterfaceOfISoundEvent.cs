using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfISoundEvent : ISoundEvent
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int CreateEventDelegate(int fmodEventIndex, UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int CreateEventFromExternalFileDelegate(byte[] programmerSoundEventName, byte[] filePath, UIntPtr scene, [MarshalAs(UnmanagedType.U1)] bool is3d, [MarshalAs(UnmanagedType.U1)] bool isBlocking);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int CreateEventFromSoundBufferDelegate(byte[] programmerSoundEventName, ManagedArray soundBuffer, UIntPtr scene, [MarshalAs(UnmanagedType.U1)] bool is3d, [MarshalAs(UnmanagedType.U1)] bool isBlocking);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int CreateEventFromStringDelegate(byte[] eventName, UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetEventIdFromStringDelegate(byte[] eventName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetEventMinMaxDistanceDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetTotalEventCountDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsPausedDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsPlayingDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsValidDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PauseEventDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PlayExtraEventDelegate(int soundId, byte[] eventName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PlaySound2DDelegate(int fmodEventIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseEventDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResumeEventDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEventMinMaxDistanceDelegate(int fmodEventIndex, Vec3 radius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEventParameterAtIndexDelegate(int soundId, int parameterIndex, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEventParameterFromStringDelegate(int eventId, byte[] name, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEventPositionDelegate(int eventId, ref Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEventVelocityDelegate(int eventId, ref Vec3 velocity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSwitchDelegate(int soundId, byte[] switchGroupName, byte[] newSwitchStateName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool StartEventDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool StartEventInPositionDelegate(int eventId, ref Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StopEventDelegate(int eventId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TriggerCueDelegate(int eventId);

	private static readonly Encoding _utf8;

	public static CreateEventDelegate call_CreateEventDelegate;

	public static CreateEventFromExternalFileDelegate call_CreateEventFromExternalFileDelegate;

	public static CreateEventFromSoundBufferDelegate call_CreateEventFromSoundBufferDelegate;

	public static CreateEventFromStringDelegate call_CreateEventFromStringDelegate;

	public static GetEventIdFromStringDelegate call_GetEventIdFromStringDelegate;

	public static GetEventMinMaxDistanceDelegate call_GetEventMinMaxDistanceDelegate;

	public static GetTotalEventCountDelegate call_GetTotalEventCountDelegate;

	public static IsPausedDelegate call_IsPausedDelegate;

	public static IsPlayingDelegate call_IsPlayingDelegate;

	public static IsValidDelegate call_IsValidDelegate;

	public static PauseEventDelegate call_PauseEventDelegate;

	public static PlayExtraEventDelegate call_PlayExtraEventDelegate;

	public static PlaySound2DDelegate call_PlaySound2DDelegate;

	public static ReleaseEventDelegate call_ReleaseEventDelegate;

	public static ResumeEventDelegate call_ResumeEventDelegate;

	public static SetEventMinMaxDistanceDelegate call_SetEventMinMaxDistanceDelegate;

	public static SetEventParameterAtIndexDelegate call_SetEventParameterAtIndexDelegate;

	public static SetEventParameterFromStringDelegate call_SetEventParameterFromStringDelegate;

	public static SetEventPositionDelegate call_SetEventPositionDelegate;

	public static SetEventVelocityDelegate call_SetEventVelocityDelegate;

	public static SetSwitchDelegate call_SetSwitchDelegate;

	public static StartEventDelegate call_StartEventDelegate;

	public static StartEventInPositionDelegate call_StartEventInPositionDelegate;

	public static StopEventDelegate call_StopEventDelegate;

	public static TriggerCueDelegate call_TriggerCueDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CreateEvent(int fmodEventIndex, UIntPtr scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CreateEventFromExternalFile(string programmerSoundEventName, string filePath, UIntPtr scene, bool is3d, bool isBlocking)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CreateEventFromSoundBuffer(string programmerSoundEventName, byte[] soundBuffer, UIntPtr scene, bool is3d, bool isBlocking)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CreateEventFromString(string eventName, UIntPtr scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetEventIdFromString(string eventName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetEventMinMaxDistance(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalEventCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPaused(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlaying(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsValid(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PauseEvent(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlayExtraEvent(int soundId, string eventName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool PlaySound2D(int fmodEventIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseEvent(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResumeEvent(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEventMinMaxDistance(int fmodEventIndex, Vec3 radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEventParameterAtIndex(int soundId, int parameterIndex, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEventParameterFromString(int eventId, string name, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEventPosition(int eventId, ref Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEventVelocity(int eventId, ref Vec3 velocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSwitch(int soundId, string switchGroupName, string newSwitchStateName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartEvent(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartEventInPosition(int eventId, ref Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopEvent(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerCue(int eventId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfISoundEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfISoundEvent()
	{
		throw null;
	}
}
