using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.MountAndBlade.Multiplayer;

namespace TaleWorlds.MountAndBlade.DedicatedCustomServer.ClientHelper;

public class DedicatedCustomServerClientHelperSubModule : MBSubModuleBase
{
	private class LobbyStateListener : IGameStateListener
	{
		private LobbyState _lobbyState;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public LobbyStateListener(LobbyState lobbyState)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool ServerSupportsDownloadPanel(GameServerEntry serverEntry)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OpenDownloadPanelForServer(GameServerEntry serverEntry)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<CustomServerAction> ActionSupplier(GameServerEntry serverEntry)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void HandleFailedServerJoinAttempt(GameServerEntry serverEntry)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnActivate()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnDeactivate()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnInitialize()
		{
			throw null;
		}
	}

	private class StateManagerListener : IGameStateManagerListener
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnCreateState(GameState gameState)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnPopState(GameState gameState)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnPushState(GameState gameState, bool isTopGameState)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnCleanStates()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnSavedGameLoadFinished()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StateManagerListener()
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDownloadMapFromHost_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string hostAddress;

		public string mapName;

		public DedicatedCustomServerClientHelperSubModule _003C_003E4__this;

		public IProgress<ProgressUpdate> progress;

		public CancellationToken cancellationToken;

		public bool replaceExisting;

		private TaskAwaiter<string> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetMapListFromHost_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<MapListResponse> _003C_003Et__builder;

		public string hostAddress;

		private TaskAwaiter<string> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public const string ModuleName = "Multiplayer";

	public static readonly bool DebugMode;

	public static DedicatedCustomServerClientHelperSubModule Instance;

	private readonly HttpClient _httpClient;

	private const string CommandGroup = "dcshelper";

	private const string DownloadMapCommandName = "download_map";

	private const string GetMapListCommandName = "get_map_list";

	private const string OpenDownloadPanelCommandName = "open_download_panel";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DedicatedCustomServerClientHelperSubModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMultiplayerGameStart(Game game, object _)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CDownloadMapFromHost_003Ed__7))]
	public Task DownloadMapFromHost(string hostAddress, string mapName, bool replaceExisting = false, IProgress<ProgressUpdate> progress = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetMapListFromHost_003Ed__8))]
	public Task<MapListResponse> GetMapListFromHost(string hostAddress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("download_map", "dcshelper")]
	public static string DownloadMapCommand(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("get_map_list", "dcshelper")]
	public static string GetMapListCommand(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("open_download_panel", "dcshelper")]
	public static string OpenDownloadPanel(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DedicatedCustomServerClientHelperSubModule()
	{
		throw null;
	}
}
