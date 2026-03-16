using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

public class LoginResultObjectJsonConverter : JsonConverter
{
	private static readonly Dictionary<string, Type> _knownTypes;

	public override bool CanWrite
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LoginResultObjectJsonConverter()
	{
		throw null;
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
	public LoginResultObjectJsonConverter()
	{
		throw null;
	}
}
