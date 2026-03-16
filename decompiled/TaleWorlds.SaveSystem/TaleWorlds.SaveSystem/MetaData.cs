using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.SaveSystem;

public class MetaData
{
	[JsonProperty("List")]
	private Dictionary<string, string> _list;

	[JsonIgnore]
	public int Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string this[string key]
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

	[JsonIgnore]
	public Dictionary<string, string>.KeyCollection Keys
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(string key, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetValue(string key, out string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Serialize(Stream stream)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MetaData Deserialize(Stream stream)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaData()
	{
		throw null;
	}
}
