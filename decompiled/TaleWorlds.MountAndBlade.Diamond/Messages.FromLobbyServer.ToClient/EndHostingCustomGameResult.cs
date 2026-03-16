using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromLobbyServer.ToClient;

[Serializable]
public class EndHostingCustomGameResult : FunctionResult
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public EndHostingCustomGameResult()
	{
		throw null;
	}
}
