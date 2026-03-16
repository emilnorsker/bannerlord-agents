using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Network;

public class JsonSocketMessage
{
	public MessageInfo MessageInfo
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

	[JsonProperty]
	public string SocketMessageTypeId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Obsolete]
	public JsonSocketMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTypeId(Type messageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dictionary<string, Type> GetMessageDictionary()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Dictionary<string, Type> RetrieveJSONSocketMessages(Assembly assembly)
	{
		throw null;
	}
}
