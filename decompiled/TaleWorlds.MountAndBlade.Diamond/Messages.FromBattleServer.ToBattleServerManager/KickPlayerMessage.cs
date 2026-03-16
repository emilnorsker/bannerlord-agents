using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromBattleServer.ToBattleServerManager;

[Serializable]
[MessageDescription("BattleServer", "BattleServerManager", false)]
public class KickPlayerMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public KickPlayerMessage()
	{
		throw null;
	}
}
