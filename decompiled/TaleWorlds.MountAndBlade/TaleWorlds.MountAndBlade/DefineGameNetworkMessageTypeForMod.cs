using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DefineGameNetworkMessageTypeForMod : Attribute
{
	public readonly GameNetworkMessageSendType SendType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefineGameNetworkMessageTypeForMod(GameNetworkMessageSendType sendType)
	{
		throw null;
	}
}
