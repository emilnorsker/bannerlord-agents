using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfISoundManager : ISoundManager
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddSoundClientWithIdDelegate(ulong client_id);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddXBOXRemoteUserDelegate(ulong XUID, ulong deviceID, [MarshalAs(UnmanagedType.U1)] bool canSendMicSound, [MarshalAs(UnmanagedType.U1)] bool canSendTextSound, [MarshalAs(UnmanagedType.U1)] bool canSendText, [MarshalAs(UnmanagedType.U1)] bool canReceiveSound, [MarshalAs(UnmanagedType.U1)] bool canReceiveText);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ApplyPushToTalkDelegate([MarshalAs(UnmanagedType.U1)] bool pushed);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearDataToBeSentDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearXBOXSoundManagerDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CompressDataDelegate(ulong clientID, ManagedArray buffer, int length, ManagedArray compressedBuffer, ref int compressedBufferLength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CreateVoiceEventDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DecompressDataDelegate(ulong clientID, ManagedArray compressedBuffer, int compressedBufferLength, ManagedArray decompressedBuffer, ref int decompressedBufferLength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeleteSoundClientWithIdDelegate(ulong client_id);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DestroyVoiceEventDelegate(int id);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FinalizeVoicePlayEventDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetAttenuationPositionDelegate(out Vec3 result);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetDataToBeSentAtDelegate(int index, ManagedArray buffer, IntPtr receivers, [MarshalAs(UnmanagedType.U1)] ref bool transportGuaranteed);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetGlobalIndexOfEventDelegate(byte[] eventFullName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetListenerFrameDelegate(out MatrixFrame result);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetSizeOfDataToBeSentAtDelegate(int index, ref uint byte_count, ref uint numReceivers);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetVoiceDataDelegate(ManagedArray voiceBuffer, int chunkSize, ref int readBytesLength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void HandleStateChangesDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InitializeVoicePlayEventDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InitializeXBOXSoundManagerDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LoadEventFileAuxDelegate(byte[] soundBankName, [MarshalAs(UnmanagedType.U1)] bool decompressSamples);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PauseBusDelegate(byte[] busName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ProcessDataToBeReceivedDelegate(ulong senderDeviceID, ManagedArray data, uint dataSize);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ProcessDataToBeSentDelegate(ref int numData);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveXBOXRemoteUserDelegate(ulong XUID);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResetDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetGlobalParameterDelegate(byte[] parameterName, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetListenerFrameDelegate(ref MatrixFrame frame, ref Vec3 attenuationPosition);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetStateDelegate(byte[] stateGroup, byte[] state);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool StartOneShotEventDelegate(byte[] eventFullName, Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool StartOneShotEventWithIndexDelegate(int index, Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool StartOneShotEventWithParamDelegate(byte[] eventFullName, Vec3 position, byte[] paramName, float paramValue);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StartVoiceRecordDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StopVoiceRecordDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UnpauseBusDelegate(byte[] busName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateVoiceToPlayDelegate(ManagedArray voiceBuffer, int length, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateXBOXChatCommunicationFlagsDelegate(ulong XUID, [MarshalAs(UnmanagedType.U1)] bool canSendMicSound, [MarshalAs(UnmanagedType.U1)] bool canSendTextSound, [MarshalAs(UnmanagedType.U1)] bool canSendText, [MarshalAs(UnmanagedType.U1)] bool canReceiveSound, [MarshalAs(UnmanagedType.U1)] bool canReceiveText);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateXBOXLocalUserDelegate();

	private static readonly Encoding _utf8;

	public static AddSoundClientWithIdDelegate call_AddSoundClientWithIdDelegate;

	public static AddXBOXRemoteUserDelegate call_AddXBOXRemoteUserDelegate;

	public static ApplyPushToTalkDelegate call_ApplyPushToTalkDelegate;

	public static ClearDataToBeSentDelegate call_ClearDataToBeSentDelegate;

	public static ClearXBOXSoundManagerDelegate call_ClearXBOXSoundManagerDelegate;

	public static CompressDataDelegate call_CompressDataDelegate;

	public static CreateVoiceEventDelegate call_CreateVoiceEventDelegate;

	public static DecompressDataDelegate call_DecompressDataDelegate;

	public static DeleteSoundClientWithIdDelegate call_DeleteSoundClientWithIdDelegate;

	public static DestroyVoiceEventDelegate call_DestroyVoiceEventDelegate;

	public static FinalizeVoicePlayEventDelegate call_FinalizeVoicePlayEventDelegate;

	public static GetAttenuationPositionDelegate call_GetAttenuationPositionDelegate;

	public static GetDataToBeSentAtDelegate call_GetDataToBeSentAtDelegate;

	public static GetGlobalIndexOfEventDelegate call_GetGlobalIndexOfEventDelegate;

	public static GetListenerFrameDelegate call_GetListenerFrameDelegate;

	public static GetSizeOfDataToBeSentAtDelegate call_GetSizeOfDataToBeSentAtDelegate;

	public static GetVoiceDataDelegate call_GetVoiceDataDelegate;

	public static HandleStateChangesDelegate call_HandleStateChangesDelegate;

	public static InitializeVoicePlayEventDelegate call_InitializeVoicePlayEventDelegate;

	public static InitializeXBOXSoundManagerDelegate call_InitializeXBOXSoundManagerDelegate;

	public static LoadEventFileAuxDelegate call_LoadEventFileAuxDelegate;

	public static PauseBusDelegate call_PauseBusDelegate;

	public static ProcessDataToBeReceivedDelegate call_ProcessDataToBeReceivedDelegate;

	public static ProcessDataToBeSentDelegate call_ProcessDataToBeSentDelegate;

	public static RemoveXBOXRemoteUserDelegate call_RemoveXBOXRemoteUserDelegate;

	public static ResetDelegate call_ResetDelegate;

	public static SetGlobalParameterDelegate call_SetGlobalParameterDelegate;

	public static SetListenerFrameDelegate call_SetListenerFrameDelegate;

	public static SetStateDelegate call_SetStateDelegate;

	public static StartOneShotEventDelegate call_StartOneShotEventDelegate;

	public static StartOneShotEventWithIndexDelegate call_StartOneShotEventWithIndexDelegate;

	public static StartOneShotEventWithParamDelegate call_StartOneShotEventWithParamDelegate;

	public static StartVoiceRecordDelegate call_StartVoiceRecordDelegate;

	public static StopVoiceRecordDelegate call_StopVoiceRecordDelegate;

	public static UnpauseBusDelegate call_UnpauseBusDelegate;

	public static UpdateVoiceToPlayDelegate call_UpdateVoiceToPlayDelegate;

	public static UpdateXBOXChatCommunicationFlagsDelegate call_UpdateXBOXChatCommunicationFlagsDelegate;

	public static UpdateXBOXLocalUserDelegate call_UpdateXBOXLocalUserDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSoundClientWithId(ulong client_id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddXBOXRemoteUser(ulong XUID, ulong deviceID, bool canSendMicSound, bool canSendTextSound, bool canSendText, bool canReceiveSound, bool canReceiveText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyPushToTalk(bool pushed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearDataToBeSent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearXBOXSoundManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompressData(ulong clientID, byte[] buffer, int length, byte[] compressedBuffer, ref int compressedBufferLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateVoiceEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DecompressData(ulong clientID, byte[] compressedBuffer, int compressedBufferLength, byte[] decompressedBuffer, ref int decompressedBufferLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteSoundClientWithId(ulong client_id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DestroyVoiceEvent(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeVoicePlayEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAttenuationPosition(out Vec3 result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetDataToBeSentAt(int index, byte[] buffer, ulong[] receivers, ref bool transportGuaranteed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGlobalIndexOfEvent(string eventFullName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetListenerFrame(out MatrixFrame result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSizeOfDataToBeSentAt(int index, ref uint byte_count, ref uint numReceivers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetVoiceData(byte[] voiceBuffer, int chunkSize, ref int readBytesLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleStateChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeVoicePlayEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeXBOXSoundManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadEventFileAux(string soundBankName, bool decompressSamples)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PauseBus(string busName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessDataToBeReceived(ulong senderDeviceID, byte[] data, uint dataSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessDataToBeSent(ref int numData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveXBOXRemoteUser(ulong XUID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalParameter(string parameterName, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetListenerFrame(ref MatrixFrame frame, ref Vec3 attenuationPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetState(string stateGroup, string state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartOneShotEvent(string eventFullName, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartOneShotEventWithIndex(int index, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartOneShotEventWithParam(string eventFullName, Vec3 position, string paramName, float paramValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartVoiceRecord()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopVoiceRecord()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnpauseBus(string busName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateVoiceToPlay(byte[] voiceBuffer, int length, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateXBOXChatCommunicationFlags(ulong XUID, bool canSendMicSound, bool canSendTextSound, bool canSendText, bool canReceiveSound, bool canReceiveText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateXBOXLocalUser()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfISoundManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfISoundManager()
	{
		throw null;
	}
}
