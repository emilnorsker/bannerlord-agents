using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

[Serializable]
public class GDKAccessObject : AccessObject
{
	[JsonProperty]
	public string Id;

	[JsonProperty]
	public string Token;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GDKAccessObject()
	{
		throw null;
	}
}
