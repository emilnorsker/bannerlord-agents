using System;
using System.Runtime.CompilerServices;
using System.Xml;
using Newtonsoft.Json;

namespace TaleWorlds.Core;

[Serializable]
[JsonConverter(typeof(BodyPropertiesJsonConverter))]
public struct BodyProperties
{
	private readonly DynamicBodyProperties _dynamicBodyProperties;

	private readonly StaticBodyProperties _staticBodyProperties;

	private const float DefaultAge = 30f;

	private const float DefaultWeight = 0.5f;

	private const float DefaultBuild = 0.5f;

	public StaticBodyProperties StaticProperties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public DynamicBodyProperties DynamicProperties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Age
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Weight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Build
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong KeyPart1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong KeyPart2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong KeyPart3
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong KeyPart4
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong KeyPart5
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong KeyPart6
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong KeyPart7
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong KeyPart8
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static BodyProperties Default
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BodyProperties(DynamicBodyProperties dynamicBodyProperties, StaticBodyProperties staticBodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool FromXmlNode(XmlNode node, out BodyProperties bodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool FromString(string keyValue, out BodyProperties bodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BodyProperties GetRandomBodyProperties(int race, bool isFemale, BodyProperties bodyPropertiesMin, BodyProperties bodyPropertiesMax, int hairCoverType, int seed, string hairTags, string beardTags, string tattooTags, float variationAmount = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(BodyProperties a, BodyProperties b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(BodyProperties a, BodyProperties b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BodyProperties ClampForMultiplayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private StaticBodyProperties ClampHeightMultiplierFaceKey(in StaticBodyProperties staticBodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ulong SetBits(in ulong ipart7, int startBit, int numBits, int inewValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetBitsValueFromKey(in ulong part, int startBit, int numBits)
	{
		throw null;
	}
}
