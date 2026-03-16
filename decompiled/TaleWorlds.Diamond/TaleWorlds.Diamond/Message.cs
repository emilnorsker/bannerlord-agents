using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

[Serializable]
[JsonConverter(typeof(MessageJsonConverter))]
public abstract class Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected Message()
	{
		throw null;
	}
}
