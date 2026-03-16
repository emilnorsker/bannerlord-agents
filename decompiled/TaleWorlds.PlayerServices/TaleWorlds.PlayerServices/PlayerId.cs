using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Library;

namespace TaleWorlds.PlayerServices;

[Serializable]
[JsonConverter(typeof(PlayerIdJsonConverter))]
public struct PlayerId : IComparable<PlayerId>, IEquatable<PlayerId>
{
	private byte _providedType;

	private byte _reserved1;

	private byte _reserved2;

	private byte _reserved3;

	private byte _reserved4;

	private byte _reserved5;

	private byte _reserved6;

	private byte _reserved7;

	private ulong _reservedBig;

	private ulong _id1;

	private ulong _id2;

	public ulong Id1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong Id2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public PlayerIdProvidedTypes ProvidedType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong Part1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong Part2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong Part3
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong Part4
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static PlayerId Empty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerId(byte providedType, ulong id1, ulong id2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerId(byte providedType, ulong reservedBig, ulong id1, ulong id2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerId(byte providedType, string guid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerId(ulong part1, ulong part2, ulong part3, ulong part4)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerId(byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerId(Guid guid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] ToByteArray()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Serialize(IWriter writer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deserialize(IReader reader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(PlayerId a, PlayerId b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(PlayerId a, PlayerId b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PlayerId FromString(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CompareTo(PlayerId other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(PlayerId other)
	{
		throw null;
	}
}
