using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace NetworkMessages.FromServer;

[DefineGameNetworkMessageType(GameNetworkMessageSendType.FromServer)]
public sealed class MultiplayerOptionsDefault : GameNetworkMessage
{
	private readonly List<MultiplayerOptions.OptionType> _optionList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerOptionsDefault()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnRead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnWrite()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override MultiplayerMessageFilter OnGetLogFilter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override string OnGetLogFormat()
	{
		throw null;
	}
}
