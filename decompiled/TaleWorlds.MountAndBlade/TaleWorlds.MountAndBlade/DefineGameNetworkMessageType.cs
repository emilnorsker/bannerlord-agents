using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class DefineGameNetworkMessageType : Attribute
{
	public readonly GameNetworkMessageSendType SendType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefineGameNetworkMessageType(GameNetworkMessageSendType sendType)
	{
		throw null;
	}
}
