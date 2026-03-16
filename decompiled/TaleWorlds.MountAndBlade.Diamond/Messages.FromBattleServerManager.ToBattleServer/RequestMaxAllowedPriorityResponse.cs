using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromBattleServerManager.ToBattleServer;

[Serializable]
[MessageDescription("BattleServerManager", "BattleServer", true)]
public class RequestMaxAllowedPriorityResponse : FunctionResult
{
	[JsonProperty]
	public sbyte Priority
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
	public RequestMaxAllowedPriorityResponse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RequestMaxAllowedPriorityResponse(sbyte priority)
	{
		throw null;
	}
}
