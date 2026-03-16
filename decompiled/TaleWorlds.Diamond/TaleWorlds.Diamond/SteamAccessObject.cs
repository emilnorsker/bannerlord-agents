using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Diamond;

[Serializable]
public class SteamAccessObject : AccessObject
{
	[JsonProperty]
	public string UserName
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
	public string ExternalAccessToken
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
	public int AppId
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
	public SteamAccessObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SteamAccessObject(string userName, string externalAccessToken, int appId)
	{
		throw null;
	}
}
