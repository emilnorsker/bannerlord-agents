using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class BinaryReader : IReader
{
	private int _cursor;

	private byte[] _buffer;

	public byte[] Data
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

	public int UnreadByteCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BinaryReader(byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ISerializableObject ReadSerializableObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int Read3ByteInt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int ReadInt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public short ReadShort()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReadFloats(float[] output, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReadShorts(short[] output, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ReadString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color ReadColor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadBool()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float ReadFloat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint ReadUInt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong ReadULong()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public long ReadLong()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte ReadByte()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] ReadBytes(int length)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 ReadVec2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ReadVec3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3i ReadVec3Int()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte ReadSByte()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ushort ReadUShort()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public double ReadDouble()
	{
		throw null;
	}
}
