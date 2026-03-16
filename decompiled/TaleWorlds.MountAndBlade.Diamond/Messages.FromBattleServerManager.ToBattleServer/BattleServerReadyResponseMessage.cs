using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using TaleWorlds.Diamond;

namespace Messages.FromBattleServerManager.ToBattleServer;

[Serializable]
[MessageDescription("BattleServerManager", "BattleServer", true)]
[DataContract]
public class BattleServerReadyResponseMessage : LoginResultObject
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleServerReadyResponseMessage()
	{
		throw null;
	}
}
