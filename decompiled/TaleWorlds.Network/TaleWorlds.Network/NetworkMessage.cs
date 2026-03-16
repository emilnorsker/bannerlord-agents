using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

public class NetworkMessage : INetworkMessageWriter, INetworkMessageReader
{
	private int _readCursor;

	private int _writeCursor;

	private bool _finalized;

	private byte[] Buffer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal MessageBuffer MessageBuffer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal int DataLength
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NetworkMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static NetworkMessage CreateForReading(MessageBuffer messageBuffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static NetworkMessage CreateForWriting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(string data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(int data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(short data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(bool data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(byte data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(float data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(long data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(ulong data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(Guid data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Write(MessageContract messageContract)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int ReadInt32()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public short ReadInt16()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadBoolean()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte ReadByte()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ReadString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float ReadFloat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public long ReadInt64()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong ReadUInt64()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Guid ReadGuid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] ReadByteArray()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ResetRead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BeginRead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BeginWrite()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void FinalizeWrite()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UpdateHeader()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal string GetDebugText()
	{
		throw null;
	}
}
