using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

[Serializable]
public class EpicAccessObject : AccessObject
{
	[JsonProperty]
	public string AccessToken;

	[JsonProperty]
	public string EpicId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EpicAccessObject()
	{
		throw null;
	}
}
