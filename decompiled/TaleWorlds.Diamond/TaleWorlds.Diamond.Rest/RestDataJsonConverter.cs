using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TaleWorlds.Diamond.Rest;

public class RestDataJsonConverter : JsonConverter<RestData>
{
	public override bool CanWrite
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool CanRead
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private RestData Create(Type objectType, JObject jObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T ReadJson<T>(string json)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override RestData ReadJson(JsonReader reader, Type objectType, RestData existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void WriteJson(JsonWriter writer, RestData value, JsonSerializer serializer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RestDataJsonConverter()
	{
		throw null;
	}
}
