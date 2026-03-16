using System;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public class MBMultiplayerData
{
	public delegate void GameServerInfoReceivedDelegate(CustomBattleId id, string gameServer, string gameModule, string gameType, string map, int currentPlayerCount, int maxPlayerCount, string address, int port);

	public static string ServerName;

	public static string GameModule;

	public static string GameType;

	public static string Map;

	public static int PlayerCountLimit;

	public static Guid ServerId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public static event GameServerInfoReceivedDelegate GameServerInfoReceived
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static string GetServerId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static string GetServerName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static string GetGameModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static string GetGameType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static string GetMap()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static int GetCurrentPlayerCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static int GetPlayerCountLimit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static void UpdateGameServerInfo(string id, string gameServer, string gameModule, string gameType, string map, int currentPlayerCount, int maxPlayerCount, string address, int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBMultiplayerData()
	{
		throw null;
	}
}
