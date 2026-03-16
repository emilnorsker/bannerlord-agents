using System.Runtime.CompilerServices;
using System.Text;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.MountAndBlade.Network.Messages;

public abstract class GameNetworkMessage
{
	public delegate bool ClientMessageHandlerDelegate<T>(NetworkCommunicator peer, T message) where T : GameNetworkMessage;

	public delegate void ServerMessageHandlerDelegate<T>(T message) where T : GameNetworkMessage;

	private static readonly Encoding StringEncoding;

	private static CompressionInfo.Integer TestValueCompressionInfo;

	private const int ConstTestValue = 5;

	public int MessageId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public static bool IsClientMissionOver
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Write()
	{
		throw null;
	}

	protected abstract void OnWrite();

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool Read()
	{
		throw null;
	}

	protected abstract bool OnRead();

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MultiplayerMessageFilter GetLogFilter()
	{
		throw null;
	}

	protected abstract MultiplayerMessageFilter OnGetLogFilter();

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal string GetLogFormat()
	{
		throw null;
	}

	protected abstract string OnGetLogFormat();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ReadBoolFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteBoolToPacket(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ReadIntFromPacket(CompressionInfo.Integer compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteIntToPacket(int value, CompressionInfo.Integer compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint ReadUintFromPacket(CompressionInfo.UnsignedInteger compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteUintToPacket(uint value, CompressionInfo.UnsignedInteger compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static long ReadLongFromPacket(CompressionInfo.LongInteger compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLongToPacket(long value, CompressionInfo.LongInteger compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ulong ReadUlongFromPacket(CompressionInfo.UnsignedLongInteger compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteUlongToPacket(ulong value, CompressionInfo.UnsignedLongInteger compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ReadFloatFromPacket(CompressionInfo.Float compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteFloatToPacket(float value, CompressionInfo.Float compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ReadStringFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteStringToPacket(string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ReadByteArrayFromPacket(byte[] buffer, int offset, int bufferCapacity, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteBannerCodeToPacket(string bannerCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ReadBannerCodeFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteByteArrayToPacket(byte[] value, int offset, int size)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBActionSet ReadActionSetReferenceFromPacket(CompressionInfo.Integer compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteActionSetReferenceToPacket(MBActionSet actionSet, CompressionInfo.Integer compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ReadAgentIndexFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteAgentIndexToPacket(int agentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBObjectBase ReadObjectReferenceFromPacket(MBObjectManager objectManager, CompressionInfo.UnsignedInteger compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteObjectReferenceToPacket(MBObjectBase value, CompressionInfo.UnsignedInteger compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VirtualPlayer ReadVirtualPlayerReferenceToPacket(ref bool bufferReadValid, bool canReturnNull = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NetworkCommunicator ReadNetworkPeerReferenceFromPacket(ref bool bufferReadValid, bool canReturnNull = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteVirtualPlayerReferenceToPacket(VirtualPlayer virtualPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteNetworkPeerReferenceToPacket(NetworkCommunicator networkCommunicator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ReadTeamIndexFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteTeamIndexToPacket(int teamIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionObjectId ReadMissionObjectIdFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteMissionObjectIdToPacket(MissionObjectId value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 ReadVec3FromPacket(CompressionInfo.Float compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteVec3ToPacket(Vec3 value, CompressionInfo.Float compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 ReadVec2FromPacket(CompressionInfo.Float compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteVec2ToPacket(Vec2 value, CompressionInfo.Float compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mat3 ReadRotationMatrixFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteRotationMatrixToPacket(Mat3 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MatrixFrame ReadMatrixFrameFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteMatrixFrameToPacket(MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MatrixFrame ReadNonUniformTransformFromPacket(CompressionInfo.Float positionCompressionInfo, CompressionInfo.Float quaternionCompressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteNonUniformTransformToPacket(MatrixFrame frame, CompressionInfo.Float positionCompressionInfo, CompressionInfo.Float quaternionCompressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MatrixFrame ReadTransformFromPacket(CompressionInfo.Float positionCompressionInfo, CompressionInfo.Float quaternionCompressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteTransformToPacket(MatrixFrame frame, CompressionInfo.Float positionCompressionInfo, CompressionInfo.Float quaternionCompressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MatrixFrame ReadUnitTransformFromPacket(CompressionInfo.Float positionCompressionInfo, CompressionInfo.Float quaternionCompressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteUnitTransformToPacket(MatrixFrame frame, CompressionInfo.Float positionCompressionInfo, CompressionInfo.Float quaternionCompressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Quaternion ReadQuaternionFromPacket(CompressionInfo.Float compressionInfo, ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteQuaternionToPacket(Quaternion q, CompressionInfo.Float compressionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteBodyPropertiesToPacket(BodyProperties bodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BodyProperties ReadBodyPropertiesFromPacket(ref bool bufferReadValid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameNetworkMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GameNetworkMessage()
	{
		throw null;
	}
}
