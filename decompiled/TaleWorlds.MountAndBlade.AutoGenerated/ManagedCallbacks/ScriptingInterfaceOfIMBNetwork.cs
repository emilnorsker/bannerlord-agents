using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBNetwork : IMBNetwork
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int AddNewBotOnServerDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int AddNewPlayerOnServerDelegate([MarshalAs(UnmanagedType.U1)] bool serverPlayer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddPeerToDisconnectDelegate(int peer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BeginBroadcastModuleEventDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BeginModuleEventAsClientDelegate([MarshalAs(UnmanagedType.U1)] bool isReliable);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CanAddNewPlayersOnServerDelegate(int numPlayers);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearReplicationTableStatisticsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate double ElapsedTimeSinceLastUdpPacketArrivedDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EndBroadcastModuleEventDelegate(int broadcastFlags, int targetPlayer, [MarshalAs(UnmanagedType.U1)] bool isReliable);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EndModuleEventAsClientDelegate([MarshalAs(UnmanagedType.U1)] bool isReliable);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetActiveUdpSessionsIpAddressDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetAveragePacketLossRatioDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetDebugUploadsInBitsDelegate(ref GameNetwork.DebugNetworkPacketStatisticsStruct networkStatisticsStruct, ref GameNetwork.DebugNetworkPositionCompressionStatisticsStruct posStatisticsStruct);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetMultiplayerDisabledDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InitializeClientSideDelegate(byte[] serverAddress, int port, int sessionKey, int playerIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InitializeServerSideDelegate(int port);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsDedicatedServerDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PrepareNewUdpSessionDelegate(int player, int sessionKey);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PrintDebugStatsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PrintReplicationTableStatisticsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int ReadByteArrayFromPacketDelegate(ManagedArray buffer, int offset, int bufferCapacity, [MarshalAs(UnmanagedType.U1)] ref bool bufferReadValid);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ReadFloatFromPacketDelegate(ref CompressionInfo.Float compressionInfo, out float output);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ReadIntFromPacketDelegate(ref CompressionInfo.Integer compressionInfo, out int output);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ReadLongFromPacketDelegate(ref CompressionInfo.LongInteger compressionInfo, out long output);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int ReadStringFromPacketDelegate([MarshalAs(UnmanagedType.U1)] ref bool bufferReadValid);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ReadUintFromPacketDelegate(ref CompressionInfo.UnsignedInteger compressionInfo, out uint output);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ReadUlongFromPacketDelegate(ref CompressionInfo.UnsignedLongInteger compressionInfo, out ulong output);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveBotOnServerDelegate(int botPlayerIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResetDebugUploadsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResetDebugVariablesDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResetMissionDataDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ServerPingDelegate(byte[] serverAddress, int port);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetServerBandwidthLimitInMbpsDelegate(double value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetServerFrameRateDelegate(double limit);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetServerTickRateDelegate(double value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TerminateClientSideDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TerminateServerSideDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteByteArrayToPacketDelegate(ManagedArray value, int offset, int size);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteFloatToPacketDelegate(float value, ref CompressionInfo.Float compressionInfo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteIntToPacketDelegate(int value, ref CompressionInfo.Integer compressionInfo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteLongToPacketDelegate(long value, ref CompressionInfo.LongInteger compressionInfo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteStringToPacketDelegate(byte[] value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteUintToPacketDelegate(uint value, ref CompressionInfo.UnsignedInteger compressionInfo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteUlongToPacketDelegate(ulong value, ref CompressionInfo.UnsignedLongInteger compressionInfo);

	private static readonly Encoding _utf8;

	public static AddNewBotOnServerDelegate call_AddNewBotOnServerDelegate;

	public static AddNewPlayerOnServerDelegate call_AddNewPlayerOnServerDelegate;

	public static AddPeerToDisconnectDelegate call_AddPeerToDisconnectDelegate;

	public static BeginBroadcastModuleEventDelegate call_BeginBroadcastModuleEventDelegate;

	public static BeginModuleEventAsClientDelegate call_BeginModuleEventAsClientDelegate;

	public static CanAddNewPlayersOnServerDelegate call_CanAddNewPlayersOnServerDelegate;

	public static ClearReplicationTableStatisticsDelegate call_ClearReplicationTableStatisticsDelegate;

	public static ElapsedTimeSinceLastUdpPacketArrivedDelegate call_ElapsedTimeSinceLastUdpPacketArrivedDelegate;

	public static EndBroadcastModuleEventDelegate call_EndBroadcastModuleEventDelegate;

	public static EndModuleEventAsClientDelegate call_EndModuleEventAsClientDelegate;

	public static GetActiveUdpSessionsIpAddressDelegate call_GetActiveUdpSessionsIpAddressDelegate;

	public static GetAveragePacketLossRatioDelegate call_GetAveragePacketLossRatioDelegate;

	public static GetDebugUploadsInBitsDelegate call_GetDebugUploadsInBitsDelegate;

	public static GetMultiplayerDisabledDelegate call_GetMultiplayerDisabledDelegate;

	public static InitializeClientSideDelegate call_InitializeClientSideDelegate;

	public static InitializeServerSideDelegate call_InitializeServerSideDelegate;

	public static IsDedicatedServerDelegate call_IsDedicatedServerDelegate;

	public static PrepareNewUdpSessionDelegate call_PrepareNewUdpSessionDelegate;

	public static PrintDebugStatsDelegate call_PrintDebugStatsDelegate;

	public static PrintReplicationTableStatisticsDelegate call_PrintReplicationTableStatisticsDelegate;

	public static ReadByteArrayFromPacketDelegate call_ReadByteArrayFromPacketDelegate;

	public static ReadFloatFromPacketDelegate call_ReadFloatFromPacketDelegate;

	public static ReadIntFromPacketDelegate call_ReadIntFromPacketDelegate;

	public static ReadLongFromPacketDelegate call_ReadLongFromPacketDelegate;

	public static ReadStringFromPacketDelegate call_ReadStringFromPacketDelegate;

	public static ReadUintFromPacketDelegate call_ReadUintFromPacketDelegate;

	public static ReadUlongFromPacketDelegate call_ReadUlongFromPacketDelegate;

	public static RemoveBotOnServerDelegate call_RemoveBotOnServerDelegate;

	public static ResetDebugUploadsDelegate call_ResetDebugUploadsDelegate;

	public static ResetDebugVariablesDelegate call_ResetDebugVariablesDelegate;

	public static ResetMissionDataDelegate call_ResetMissionDataDelegate;

	public static ServerPingDelegate call_ServerPingDelegate;

	public static SetServerBandwidthLimitInMbpsDelegate call_SetServerBandwidthLimitInMbpsDelegate;

	public static SetServerFrameRateDelegate call_SetServerFrameRateDelegate;

	public static SetServerTickRateDelegate call_SetServerTickRateDelegate;

	public static TerminateClientSideDelegate call_TerminateClientSideDelegate;

	public static TerminateServerSideDelegate call_TerminateServerSideDelegate;

	public static WriteByteArrayToPacketDelegate call_WriteByteArrayToPacketDelegate;

	public static WriteFloatToPacketDelegate call_WriteFloatToPacketDelegate;

	public static WriteIntToPacketDelegate call_WriteIntToPacketDelegate;

	public static WriteLongToPacketDelegate call_WriteLongToPacketDelegate;

	public static WriteStringToPacketDelegate call_WriteStringToPacketDelegate;

	public static WriteUintToPacketDelegate call_WriteUintToPacketDelegate;

	public static WriteUlongToPacketDelegate call_WriteUlongToPacketDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddNewBotOnServer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddNewPlayerOnServer(bool serverPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPeerToDisconnect(int peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginBroadcastModuleEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginModuleEventAsClient(bool isReliable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanAddNewPlayersOnServer(int numPlayers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearReplicationTableStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public double ElapsedTimeSinceLastUdpPacketArrived()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndBroadcastModuleEvent(int broadcastFlags, int targetPlayer, bool isReliable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndModuleEventAsClient(bool isReliable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetActiveUdpSessionsIpAddress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAveragePacketLossRatio()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetDebugUploadsInBits(ref GameNetwork.DebugNetworkPacketStatisticsStruct networkStatisticsStruct, ref GameNetwork.DebugNetworkPositionCompressionStatisticsStruct posStatisticsStruct)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetMultiplayerDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeClientSide(string serverAddress, int port, int sessionKey, int playerIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeServerSide(int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDedicatedServer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrepareNewUdpSession(int player, int sessionKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrintDebugStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrintReplicationTableStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int ReadByteArrayFromPacket(byte[] buffer, int offset, int bufferCapacity, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadFloatFromPacket(ref CompressionInfo.Float compressionInfo, out float output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadIntFromPacket(ref CompressionInfo.Integer compressionInfo, out int output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadLongFromPacket(ref CompressionInfo.LongInteger compressionInfo, out long output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ReadStringFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadUintFromPacket(ref CompressionInfo.UnsignedInteger compressionInfo, out uint output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadUlongFromPacket(ref CompressionInfo.UnsignedLongInteger compressionInfo, out ulong output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveBotOnServer(int botPlayerIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetDebugUploads()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetDebugVariables()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetMissionData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ServerPing(string serverAddress, int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetServerBandwidthLimitInMbps(double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetServerFrameRate(double limit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetServerTickRate(double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TerminateClientSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TerminateServerSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteByteArrayToPacket(byte[] value, int offset, int size)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteFloatToPacket(float value, ref CompressionInfo.Float compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteIntToPacket(int value, ref CompressionInfo.Integer compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteLongToPacket(long value, ref CompressionInfo.LongInteger compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteStringToPacket(string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteUintToPacket(uint value, ref CompressionInfo.UnsignedInteger compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteUlongToPacket(ulong value, ref CompressionInfo.UnsignedLongInteger compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBNetwork()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBNetwork()
	{
		throw null;
	}
}
