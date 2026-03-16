using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Diamond;

namespace Messages.FromCustomBattleServerManager.ToCustomBattleServer;

[Serializable]
[MessageDescription("CustomBattleServerManager", "CustomBattleServer", true)]
public class TerminateOperationCustomMessage : Message
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public TerminateOperationCustomMessage()
	{
		throw null;
	}
}
