using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromBattleServerManager.ToBattleServer;

[Serializable]
[MessageDescription("BattleServerManager", "BattleServer", true)]
public class TerminateOperationMatchmakingMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public TerminateOperationMatchmakingMessage()
	{
		throw null;
	}
}
