using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromBattleServer.ToBattleServerManager;

[Serializable]
[MessageDescription("BattleServer", "BattleServerManager", true)]
public class BattleEndingMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleEndingMessage()
	{
		throw null;
	}
}
