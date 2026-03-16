using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

[Serializable]
[DataContract]
[JsonConverter(typeof(LoginResultObjectJsonConverter))]
public abstract class LoginResultObject
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected LoginResultObject()
	{
		throw null;
	}
}
