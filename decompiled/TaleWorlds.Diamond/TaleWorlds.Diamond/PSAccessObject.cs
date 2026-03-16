using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

[Serializable]
public class PSAccessObject : AccessObject
{
	[JsonProperty]
	public int IssuerId
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
	public string AuthCode
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PSAccessObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PSAccessObject(int issuerId, string authCode)
	{
		throw null;
	}
}
