using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromBattleServer.ToBattleServerManager;

[Serializable]
[MessageDescription("BattleServer", "BattleServerManager", false)]
public class SendBattleResultToPlayerMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public SendBattleResultToPlayerMessage()
	{
		throw null;
	}
}
