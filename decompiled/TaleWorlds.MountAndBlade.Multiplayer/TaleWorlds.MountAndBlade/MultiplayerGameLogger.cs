using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NetworkMessages.FromClient;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerGameLogger : GameHandler
{
	public const int PreInitialLogId = 0;

	private ChatBox _chatBox;

	private int _lastLogId;

	private List<GameLog> _gameLogs;

	public IReadOnlyList<GameLog> GameLogs
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerGameLogger()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Log(GameLog log)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnGameStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforeSave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterSave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnGameNetworkBegin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventPlayerMessageAll(NetworkCommunicator networkPeer, PlayerMessageAll message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventPlayerMessageTeam(NetworkCommunicator networkPeer, PlayerMessageTeam message)
	{
		throw null;
	}
}
