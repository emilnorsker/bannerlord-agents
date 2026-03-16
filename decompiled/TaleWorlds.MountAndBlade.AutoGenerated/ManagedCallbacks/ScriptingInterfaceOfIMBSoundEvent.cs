using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBSoundEvent : IMBSoundEvent
{
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
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PlaySoundDelegate(int fmodEventIndex, in Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PlaySoundWithIntParamDelegate(int fmodEventIndex, int paramIndex, float paramVal, in Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PlaySoundWithParamDelegate(int soundCodeId, SoundEventParameter parameter, in Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PlaySoundWithStrParamDelegate(int fmodEventIndex, byte[] paramName, float paramVal, in Vec3 position);

	private static readonly Encoding _utf8;

	public static CreateEventFromExternalFileDelegate call_CreateEventFromExternalFileDelegate;

	public static CreateEventFromSoundBufferDelegate call_CreateEventFromSoundBufferDelegate;

	public static PlaySoundDelegate call_PlaySoundDelegate;

	public static PlaySoundWithIntParamDelegate call_PlaySoundWithIntParamDelegate;

	public static PlaySoundWithParamDelegate call_PlaySoundWithParamDelegate;

	public static PlaySoundWithStrParamDelegate call_PlaySoundWithStrParamDelegate;

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
	public bool PlaySound(int fmodEventIndex, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool PlaySoundWithIntParam(int fmodEventIndex, int paramIndex, float paramVal, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool PlaySoundWithParam(int soundCodeId, SoundEventParameter parameter, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool PlaySoundWithStrParam(int fmodEventIndex, string paramName, float paramVal, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBSoundEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBSoundEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMBSoundEvent.PlaySound(int fmodEventIndex, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMBSoundEvent.PlaySoundWithIntParam(int fmodEventIndex, int paramIndex, float paramVal, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMBSoundEvent.PlaySoundWithStrParam(int fmodEventIndex, string paramName, float paramVal, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IMBSoundEvent.PlaySoundWithParam(int soundCodeId, SoundEventParameter parameter, in Vec3 position)
	{
		throw null;
	}
}
