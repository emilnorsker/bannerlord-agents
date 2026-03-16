using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

public class AccessObjectJsonConverter : JsonConverter
{
	public override bool CanWrite
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanConvert(Type objectType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AccessObjectJsonConverter()
	{
		throw null;
	}
}
