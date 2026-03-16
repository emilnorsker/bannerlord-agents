using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

public class CheckClanTagValidResult : FunctionResult
{
	[JsonProperty]
	public bool TagExists
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
	public CheckClanTagValidResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheckClanTagValidResult(bool tagExists)
	{
		throw null;
	}
}
