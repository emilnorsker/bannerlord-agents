using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class RegisterCustomGameResult : FunctionResult
{
	[JsonProperty]
	public bool Success
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
	public RegisterCustomGameResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RegisterCustomGameResult(bool success)
	{
		throw null;
	}
}
