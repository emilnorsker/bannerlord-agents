using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromBattleServer.ToBattleServerManager;

[Serializable]
[MessageDescription("BattleServer", "BattleServerManager", true)]
public class BattleReadyMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleReadyMessage()
	{
		throw null;
	}
}
